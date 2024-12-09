using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Java.Util;
using Android.Bluetooth;
using Protogen_Bluetooth_App.Services;
using Protogen_Bluetooth_App.Platforms.Android.Bluetooth;
using Android.OS;
using Java.Lang;

//[assembly: Dependency(typeof(BluetoothConnector))]
namespace Protogen_Bluetooth_App.Platforms.Android.Bluetooth
{
    public class BluetoothConnector : IBluetoothService
    {
        private bool connection_failed = false;
        private BluetoothAdapter _bluetoothAdapter;
        private BluetoothDevice _bluetoothDevice;
        private BluetoothSocket _bluetoothSocket;
        private List<BluetoothSocket> bluetoothSockets = new();

        public BluetoothConnector()
        {
            _bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
        }

        public List<RCBluetoothDevice> GetAvailableDevices()
        {
            List<RCBluetoothDevice> connectedDevices = new List<RCBluetoothDevice>();

            foreach (BluetoothDevice device in _bluetoothAdapter.BondedDevices)
            {
                connectedDevices.Add(new RCBluetoothDevice
                {
                    Name = device.Name,
                    Address = device.Address,
                    Status = "Connected",
                    Manufacturer = "Unknown"
                });
            }

            return connectedDevices;
        }

        public bool ConnectToDevice(RCBluetoothDevice device)
        {
            _bluetoothDevice = _bluetoothAdapter.GetRemoteDevice(device.Address);

            //var method = Device.GetType().GetMethod("createRfcommSocket");

            //BluetoothSocket _bluetoothSocket = _bluetoothDevice.CreateRfcommSocketToServiceRecord(UUID.FromString("00001101-0000-1000-8000-00805f9b34fb"));
            // Print UUIDs to debug
            _bluetoothSocket = _bluetoothDevice.CreateInsecureRfcommSocketToServiceRecord(UUID.FromString("00001101-0000-1000-8000-00805f9b34fb"));            //try
            //{
            //    _bluetoothSocket.Connect();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    return;
            //}

            try
            {
                _bluetoothSocket.Connect();
                bluetoothSockets.Add(_bluetoothSocket);
            }
            catch
            {
                return false;
            }

            return true;

        }

        public void DisconnectDevice(RCBluetoothDevice device)
        {
            BluetoothSocket _bluetoothSocket = bluetoothSockets.Find(socket => socket.RemoteDevice.Address == device.Address);
            _bluetoothSocket.Close();
            bluetoothSockets.Remove(_bluetoothSocket);
        }

        public bool isDeviceConnected(RCBluetoothDevice device)
        {
            // Check if device has an open socket
            return bluetoothSockets.Contains(bluetoothSockets.Find(socket => socket.RemoteDevice.Address == device.Address));
        }

        const byte SignatureByte = 0xAA;

        public bool SendData(ProtoData data)
        {
            // Convert to byte array. Structure: [Signature, Identifier, Data, Data2 (Direction for Motors)]
            byte[] dataBytes = new byte[6];
            byte IdentifierByte = (byte)data.Type;

            dataBytes[0] = SignatureByte;

            switch (data.Type)
            {
                case ProtoSentDataType.SetColor: 
                    dataBytes[1] = (byte)data.data1;
                    dataBytes[2] = (byte)data.data2;
                    dataBytes[3] = (byte)data.data3;
                    break;
                case ProtoSentDataType.ToggleGaymode:
                    dataBytes[1] = 0;
                    dataBytes[2] = 0;
                    dataBytes[3] = 0;
                    break;
                case ProtoSentDataType.OverrideMenu:
                    dataBytes[1] = (byte)data.data1;
                    dataBytes[2] = 0;
                    dataBytes[3] = 0;
                    break;
                default:
                    break;
            }

            

            dataBytes[4] = IdentifierByte;

            byte checksum = 0;

            //for (int i = 1; i < dataBytes.Length - 2; i++)
            //{
            //    Console.WriteLine("checksum: " + dataBytes.Length);
            //    checksum += dataBytes[i];
            //}

            dataBytes[5] = checksum;

            // Print to debug
            Console.WriteLine("Sending data: " + BitConverter.ToString(dataBytes));

            // Send data to all connected devices
            //foreach (BluetoothSocket socket in bluetoothSockets)
            //{
            //    socket.OutputStream.Write(dataBytes, 0, dataBytes.Length);
            //}

            try
            {
                if (_bluetoothSocket.IsConnected)
                {
                    // Send data to all connected devices
                    foreach (BluetoothSocket socket in bluetoothSockets)
                    {
                        socket.OutputStream.Write(dataBytes, 0, dataBytes.Length);
                    }
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
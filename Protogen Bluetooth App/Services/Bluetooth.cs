using Shiny;
using Shiny.BluetoothLE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protogen_Bluetooth_App.Services
{
    public struct RCBluetoothDevice
    {
        public string Name;
        public string Address;
        public string Status;
        public string Manufacturer;
    }

    public enum ProtoSentDataType
    {
        SetColor,
        ToggleGaymode,
        OverrideMenu,
        OverrideExpressions,
        Expression,
        SetFace
    }

    public struct ProtoData
    {
        public ProtoSentDataType Type;
        public int data1;
        public int data2;
        public int data3;
    }

    public interface IBluetoothService
    {
        List<RCBluetoothDevice> GetAvailableDevices();

        bool ConnectToDevice(RCBluetoothDevice device);
        void DisconnectDevice(RCBluetoothDevice device);

        bool isDeviceConnected(RCBluetoothDevice device);

        bool SendData(ProtoData data);
    }
}

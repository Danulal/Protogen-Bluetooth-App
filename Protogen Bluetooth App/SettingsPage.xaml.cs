namespace Protogen_Bluetooth_App;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    private void MenuButton_Pressed(object sender, EventArgs e)
    {
        Services.IBluetoothService bluetoothService = DependencyService.Get<Services.IBluetoothService>();
        if (bluetoothService.SendData(new Services.ProtoData { Type = Services.ProtoSentDataType.Setting, data1 = 0, data2 = 1, data3 = 0 }) == false)
        {
            //Toast.Make("Failed to send data.", ToastDuration.Short, 14);
        }
    }

    private void MenuButton_Released(object sender, EventArgs e)
    {
        Services.IBluetoothService bluetoothService = DependencyService.Get<Services.IBluetoothService>();
        if (bluetoothService.SendData(new Services.ProtoData { Type = Services.ProtoSentDataType.Setting, data1 = 0, data2 = 0, data3 = 0 }) == false)
        {
            //Toast.Make("Failed to send data.", ToastDuration.Short, 14);
        }
    }
}
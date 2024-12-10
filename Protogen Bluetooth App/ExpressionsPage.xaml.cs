namespace Protogen_Bluetooth_App;

public partial class ExpressionsPage : ContentPage
{
	public ExpressionsPage()
	{
		InitializeComponent();
	}

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        int enabled;
        if (e.Value)
        {
            enabled = 1;
        }
        else
        {
            enabled = 0;
        }

        Services.IBluetoothService bluetoothService = DependencyService.Get<Services.IBluetoothService>();
        if (bluetoothService.SendData(new Services.ProtoData { Type = Services.ProtoSentDataType.OverrideExpressions, data1 = enabled, data2 = 0, data3 = 0 }) == false)
        {
            //Toast.Make("Failed to send data.", ToastDuration.Short, 14);
        }
    }

    private void BtnDefault_Clicked(object sender, EventArgs e)
    {
        Services.IBluetoothService bluetoothService = DependencyService.Get<Services.IBluetoothService>();
        if (bluetoothService.SendData(new Services.ProtoData { Type = Services.ProtoSentDataType.Expression, data1 = 0, data2 = 0, data3 = 0 }) == false)
        {
            //Toast.Make("Failed to send data.", ToastDuration.Short, 14);
        }
    }

    private void BtnAngry_Clicked(object sender, EventArgs e)
    {
        Services.IBluetoothService bluetoothService = DependencyService.Get<Services.IBluetoothService>();
        if (bluetoothService.SendData(new Services.ProtoData { Type = Services.ProtoSentDataType.Expression, data1 = 1, data2 = 0, data3 = 0 }) == false)
        {
            //Toast.Make("Failed to send data.", ToastDuration.Short, 14);
        }
    }

    private void BtnDoubt_Clicked(object sender, EventArgs e)
    {
        Services.IBluetoothService bluetoothService = DependencyService.Get<Services.IBluetoothService>();
        if (bluetoothService.SendData(new Services.ProtoData { Type = Services.ProtoSentDataType.Expression, data1 = 2, data2 = 0, data3 = 0 }) == false)
        {
            //Toast.Make("Failed to send data.", ToastDuration.Short, 14);
        }
    }

    private void BtnFrown_Clicked(object sender, EventArgs e)
    {
        Services.IBluetoothService bluetoothService = DependencyService.Get<Services.IBluetoothService>();
        if (bluetoothService.SendData(new Services.ProtoData { Type = Services.ProtoSentDataType.Expression, data1 = 3, data2 = 0, data3 = 0 }) == false)
        {
            //Toast.Make("Failed to send data.", ToastDuration.Short, 14);
        }
    }

    private void BtnAudioReactive_Clicked(object sender, EventArgs e)
    {
        Services.IBluetoothService bluetoothService = DependencyService.Get<Services.IBluetoothService>();
        if (bluetoothService.SendData(new Services.ProtoData { Type = Services.ProtoSentDataType.Expression, data1 = 6, data2 = 0, data3 = 0 }) == false)
        {
            //Toast.Make("Failed to send data.", ToastDuration.Short, 14);
        }
    }

    private void BtnLookUp_Clicked(object sender, EventArgs e)
    {
        Services.IBluetoothService bluetoothService = DependencyService.Get<Services.IBluetoothService>();
        if (bluetoothService.SendData(new Services.ProtoData { Type = Services.ProtoSentDataType.Expression, data1 = 4, data2 = 0, data3 = 0 }) == false)
        {
            //Toast.Make("Failed to send data.", ToastDuration.Short, 14);
        }
    }

    private void BtnLookDown_Clicked(object sender, EventArgs e)
    {
        Services.IBluetoothService bluetoothService = DependencyService.Get<Services.IBluetoothService>();
        if (bluetoothService.SendData(new Services.ProtoData { Type = Services.ProtoSentDataType.Expression, data1 = 9, data2 = 0, data3 = 0 }) == false)
        {
            //Toast.Make("Failed to send data.", ToastDuration.Short, 14);
        }
    }

    private void BtnSurprised_Clicked(object sender, EventArgs e)
    {
        Services.IBluetoothService bluetoothService = DependencyService.Get<Services.IBluetoothService>();
        if (bluetoothService.SendData(new Services.ProtoData { Type = Services.ProtoSentDataType.Expression, data1 = 8, data2 = 0, data3 = 0 }) == false)
        {
            //Toast.Make("Failed to send data.", ToastDuration.Short, 14);
        }
    }

    private void BtnSad_Clicked(object sender, EventArgs e)
    {
        Services.IBluetoothService bluetoothService = DependencyService.Get<Services.IBluetoothService>();
        if (bluetoothService.SendData(new Services.ProtoData { Type = Services.ProtoSentDataType.Expression, data1 = 5, data2 = 0, data3 = 0 }) == false)
        {
            //Toast.Make("Failed to send data.", ToastDuration.Short, 14);
        }
    }

    private void BtnOscilloscope_Clicked(object sender, EventArgs e)
    {
        Services.IBluetoothService bluetoothService = DependencyService.Get<Services.IBluetoothService>();
        if (bluetoothService.SendData(new Services.ProtoData { Type = Services.ProtoSentDataType.Expression, data1 = 7, data2 = 0, data3 = 0 }) == false)
        {
            //Toast.Make("Failed to send data.", ToastDuration.Short, 14);
        }
    }

    private void BtnSpectrum_Clicked(object sender, EventArgs e)
    {
        Services.IBluetoothService bluetoothService = DependencyService.Get<Services.IBluetoothService>();
        if (bluetoothService.SendData(new Services.ProtoData { Type = Services.ProtoSentDataType.Expression, data1 = 10, data2 = 0, data3 = 0 }) == false)
        {
            //Toast.Make("Failed to send data.", ToastDuration.Short, 14);
        }
    }
}
using CommunityToolkit.Maui.Core;
using Shiny.Reflection;

namespace Protogen_Bluetooth_App;

public partial class ColorPage : ContentPage
{
	public ColorPage()
	{
		InitializeComponent();
	}

    private void BtnGayMode_Clicked(object sender, EventArgs e)
    {
        Services.IBluetoothService bluetoothService = DependencyService.Get<Services.IBluetoothService>();
        if (bluetoothService.SendData(new Services.ProtoData { Type = Services.ProtoSentDataType.ToggleGaymode, data1 = 0, data2 = 0, data3 = 0 }) == false)
        {
            //Toast.Make("Failed to send data.", ToastDuration.Short, 14);
        }
    }

    private void MenuOverride_Toggled(object sender, ToggledEventArgs e)
    {
        int enabled;
        if (e.Value)
        {
            enabled = 1;
        } else
        {
            enabled = 0;
        }

        Services.IBluetoothService bluetoothService = DependencyService.Get<Services.IBluetoothService>();
        if (bluetoothService.SendData(new Services.ProtoData { Type = Services.ProtoSentDataType.OverrideMenu, data1 = enabled, data2 = 0, data3 = 0 }) == false)
        {
            //Toast.Make("Failed to send data.", ToastDuration.Short, 14);
        }
    }

    private void BtnConfirmColor_Clicked(object sender, EventArgs e)
    {
        var color = ColorPicker.PickedColor;

        Services.IBluetoothService bluetoothService = DependencyService.Get<Services.IBluetoothService>();
        if (bluetoothService.SendData(new Services.ProtoData { Type = Services.ProtoSentDataType.SetColor, data1 = (int)(color.Red * 255), data2 = (int)(color.Green * 255), data3 = (int)(color.Blue * 255) }) == false)
        {
            //Toast.Make("Failed to send data.", ToastDuration.Short, 14);
        }
    }
    private void ColorPicker_PickedColorChanged(object sender, Maui.ColorPicker.PickedColorChangedEventArgs e)
    {
        var e3 = e.NewPickedColorValue;

        CurrentColorIndicator.Text = $"R: {e3.Red * 255:0}, G: {e3.Green * 255:0}, B: {e3.Blue * 255:0}";
        CurrentColorIndicator.BackgroundColor = new Color(e3.Red, e3.Green, e3.Blue);
    }

    private void BtnSetDefaultColorEEPROM_Clicked(object sender, EventArgs e)
    {
        Services.IBluetoothService bluetoothService = DependencyService.Get<Services.IBluetoothService>();
        if (bluetoothService.SendData(new Services.ProtoData { Type = Services.ProtoSentDataType.WriteDefaultColorEEPROM, data1 = 1, data2 = 0, data3 = 0 }) == false)
        {
            //Toast.Make("Failed to send data.", ToastDuration.Short, 14);
        }
    }
}
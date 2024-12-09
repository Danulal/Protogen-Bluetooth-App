using CommunityToolkit.Maui.Core;
using Shiny.Reflection;

namespace Protogen_Bluetooth_App;

public partial class ColorPage : ContentPage
{
	public ColorPage()
	{
		InitializeComponent();
	}

    private void ColorPicker_PickedColorChanged(object sender, Maui.ColorPicker.PickedColorChangedEventArgs e)
    {
		var e3 = e.NewPickedColorValue;

        Services.IBluetoothService bluetoothService = DependencyService.Get<Services.IBluetoothService>();
        if (bluetoothService.SendData(new Services.ProtoData { Type = Services.ProtoSentDataType.SetColor, data1 = (int)(e.NewPickedColorValue.Red * 255), data2 = (int)(e.NewPickedColorValue.Green * 255), data3 = (int)(e.NewPickedColorValue.Blue * 255) }) == false)
        {
            //Toast.Make("Failed to send data.", ToastDuration.Short, 14);
        }
    }
}
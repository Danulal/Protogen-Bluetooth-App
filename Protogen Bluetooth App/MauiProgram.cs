using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MauiIcons.SegoeFluent;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace Protogen_Bluetooth_App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("FluentSystemIcons-Regular.ttf", "FluentIcons");
                })
                .UseMauiCommunityToolkit();

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.UseSegoeFluentMauiIcons();

            DependencyService.Register<Services.IBluetoothService, Protogen_Bluetooth_App.Platforms.Android.Bluetooth.BluetoothConnector>();

            return builder.Build();
        }
    }
}

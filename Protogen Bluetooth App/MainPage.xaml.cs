namespace Protogen_Bluetooth_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void BTScanBtn_Clicked(object sender, EventArgs e)
        {
#if ANDROID
            var enable = new Android.Content.Intent(Android.Bluetooth.BluetoothAdapter.ActionRequestEnable);
            enable.SetFlags(Android.Content.ActivityFlags.NewTask);

            var bluetoothManager = (Android.Bluetooth.BluetoothManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.BluetoothService);
            var bluetoothAdapter = bluetoothManager.Adapter;

            if (bluetoothAdapter.IsEnabled == true)
            {
                // todo: scan for devices
            }
            else
            {
                // Enable the Bluetooth
                Android.App.Application.Context.StartActivity(enable);
            }
#endif
        }
    }

}

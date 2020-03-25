using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MobileHMI.Droid.BroadcastReceivers;
using Android.Bluetooth;
using Android.Content;

namespace MobileHMI.Droid
{
    [Activity(Label = "MobileHMI", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        BluetoothDeviceDetector bluetoothDeviceDetector;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        protected override void OnResume()
        {
            if (bluetoothDeviceDetector == null)
            {
                bluetoothDeviceDetector = new BluetoothDeviceDetector();
            }

            RegisterReceiver(bluetoothDeviceDetector, new IntentFilter(BluetoothDevice.ActionFound));

            base.OnResume();
        }
    }
}
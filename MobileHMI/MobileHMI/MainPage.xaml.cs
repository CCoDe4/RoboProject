using Android.Bluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileHMI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();            
        }

        public void StartScan()
        {
            BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;

            if (adapter.IsEnabled)
            {
                adapter.StartDiscovery();
            }
        }

        private void Connect(object sender, EventArgs e)
        {

        }

        private async void ScanForDevices(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;

                if (adapter.IsEnabled)
                {
                    adapter.StartDiscovery();
                }
            });
         
        }
    }
}

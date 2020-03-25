using Android.Bluetooth;
using Java.Util;
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

            MessagingCenter.Subscribe<BluetoothDevice>(this, "NXT_Robot", (sender) => 
            {
                ConnectToDevice(sender);
            });
        }

        public void StartScan()
        {
            BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;

            if (adapter.IsEnabled)
            {
                adapter.StartDiscovery();
            }
        }

        private void ConnectToDevice(BluetoothDevice device)
        {
            try
            {
                var _socket = device.CreateRfcommSocketToServiceRecord(UUID.FromString("00001101-0000-1000-8000-00805f9b34fb"));//Note that the UUID specified below is the standard UUID for SPP
                _socket.Connect();

                byte[] MessageLength = { 0x0C, 0x00 };
                //byte[] Command = { 0x6d, 0x6f, 0x74, 0x6f, 0x72, 0xC0, 0x80};
                byte[] Command = { 0x80, 0x04, 0xFF, 0x64, 0x07, 0x00, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00 }; //test

                MessageLength[0] = (byte)Command.Length; //set the LSB(least significant bit) to the length of the message 

                _socket.OutputStream.Write(MessageLength, 0, MessageLength.Length); //send the 2 bytes header 
                _socket.OutputStream.Write(Command, 0, Command.Length); // send the message itself      
            }
            catch (Exception ex)
            {

                throw;
            }
                  
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

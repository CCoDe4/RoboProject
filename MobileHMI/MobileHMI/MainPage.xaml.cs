using Android.Bluetooth;
using Java.Util;
using MobileHMI.Common;
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
        public MobileRoboManager RoboManager;
        public MainPage()
        {
            InitializeComponent();
            RoboManager = new MobileRoboManager();

            MessagingCenter.Subscribe<BluetoothDevice>(this, "NXT_Robot", (sender) =>
            {
                ConnectToDevice(sender);
            });
        }

        //public void StartScan()
        //{
        //    BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;

        //    if (adapter.IsEnabled)
        //    {
        //        adapter.StartDiscovery();
        //    }
        //}

        private void ConnectToDevice(BluetoothDevice device)
        {
            try
            {
                RoboManager.Connect(device);

                if (RoboManager.IsConnected)
                {
                    lblConnectionStatus.Text = "Connected";
                    lblConnectionStatus.TextColor = Color.Green;
                }
                else
                {
                    lblConnectionStatus.Text = "Disconnected";
                    lblConnectionStatus.TextColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        #region Events

        private void ScanForDevices_Clicked(object sender, EventArgs e)
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

        private void Beep_Clicked(object sender, EventArgs e)
        {
            if (!RoboManager.IsConnected) return;

            RoboManager.Beep();
        }

        private void Stop_Clicked(object sender, EventArgs e)
        {
            if (!RoboManager.IsConnected) return;

            RoboManager.StopMotors();
        }

        private void Up_Clicked(object sender, EventArgs e)
        {
            if (!RoboManager.IsConnected) return;

            RoboManager.MoveForwards();
        }

        private void Down_Clicked(object sender, EventArgs e)
        {
            if (!RoboManager.IsConnected) return;

            RoboManager.MoveBackwards();
        }

        private void Right_Clicked(object sender, EventArgs e)
        {
            if (!RoboManager.IsConnected) return;

            RoboManager.LeftMotor();
        }

        private void Left_Clicked(object sender, EventArgs e)
        {
            if (!RoboManager.IsConnected) return;

            RoboManager.RightMotor();
        }
        #endregion
    }
}

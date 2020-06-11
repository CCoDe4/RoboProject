using Android.Bluetooth;
using Java.Util;
using MobileHMI.Common;
using MobileHMI.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileHMI
{
    public partial class MainPage : ContentPage
    {
        public MobileRoboManager RoboManager;
        public Regulator Regulator;
        List<string> Metrics = new List<string>() { Constants.meter, Constants.centimeter };

        public MainPage()
        {
            InitializeComponent();
            RoboManager = new MobileRoboManager();
            Regulator = new Regulator(RoboManager);

            MessagingCenter.Subscribe<BluetoothDevice>(this, "NXT_Robot", (sender) =>
            {
                ConnectToDevice(sender);
            });

            DistancePicker.ItemsSource = Metrics;
            DistancePicker.SelectedItem = Metrics[0];
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

                    //Regulator.BluetoothConnection = RoboManager.BluetoothConnection;
                    //Regulator.IsConnected = RoboManager.IsConnected;
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
            lblConnectionStatus.Text = "Trying to connect";

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

        private void ModeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (ModeToggle.IsToggled)
            {
                RealTimeControlPanel.IsVisible = false;
                RegulatorControl.IsVisible = true;
            }
            else
            {
                RealTimeControlPanel.IsVisible = true;
                RegulatorControl.IsVisible = false;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                RoboManager.MoveForwards();

            });
        }


        private void PID_Clicked(object sender, EventArgs e)
        {
            if (!RoboManager.IsConnected) return;

            Task.Run(() =>
            {
                if (DistancePicker.SelectedItem.ToString() == Constants.meter) //work with cm
                    Regulator.TargetDistance = int.Parse(distanceBox.Text) * 100;
                else
                    Regulator.TargetDistance = int.Parse(distanceBox.Text);

                Regulator.RunPIDAsync();
            });
        }


        private void Relay_Clicked(object sender, EventArgs e)
        {

            if (!RoboManager.IsConnected) return;
            Task.Run(() =>
            {
                if (DistancePicker.SelectedItem.ToString() == Constants.meter) //work with cm
                    Regulator.TargetDistance = int.Parse(distanceBox.Text) * 100;
                else
                    Regulator.TargetDistance = int.Parse(distanceBox.Text);

                Regulator.RunRelay();
            });
        }

        private void StopControllers_Clicked(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Regulator.StopRegulators();
            });

        }
    }
}

using Android.Bluetooth;
using Java.Util;
using MobileHMI.Common;
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
        public MainPage()
        {
            InitializeComponent();
            RoboManager = new MobileRoboManager();
            Regulator = new Regulator();

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

                    Regulator.BluetoothConnection = RoboManager.BluetoothConnection;
                    Regulator.IsConnected = RoboManager.IsConnected;
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

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            //Test();

            string resp = Regulator.GetState();
            
            string[] words = resp.Split(' ');

            var num1 = int.Parse(words[21], System.Globalization.NumberStyles.HexNumber);   //215         
            var num2 = int.Parse(words[22], System.Globalization.NumberStyles.HexNumber);//14

            ;
        }

        private void Test()
        {
            while (true)
            {
                string resp = Regulator.GetState();

                string[] words = resp.Split(' ');

                var num1 = int.Parse(words[21], System.Globalization.NumberStyles.HexNumber);   //215         
                var num2 = int.Parse(words[22], System.Globalization.NumberStyles.HexNumber);//14
                var num3 = int.Parse(words[23], System.Globalization.NumberStyles.HexNumber);//14
                var num4 = int.Parse(words[24], System.Globalization.NumberStyles.HexNumber);//14

              
                Debug.WriteLine(num1.ToString() + " " + num2.ToString() + " " + num3.ToString() + " " + num4.ToString());

            }
        }
    }
}

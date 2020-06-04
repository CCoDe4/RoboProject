using Android.Bluetooth;
using MobileHMI.Helpers;
using MobileHMI.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MobileHMI.Common
{
    public class Regulator
    {
        private double currentDistance;
        private const double wheelCircumference = 17.59291886010284; //cm
        private IRoboManager _roboManager;

        public Regulator(IRoboManager roboManager)
        {
            _roboManager = roboManager;
        }

        public bool IsConnected { get; set; }

        public int TargetDistance { get; set; }

        public int Kp { get; set; } = 1;
        public int Ki { get; set; } = 0;
        public int Kd { get; set; } = 0;

        public Timer Timer { get; set; } //100ms

        public void Run()
        {
            _roboManager.MoveForwards();
            RunTimer();
        }

        private void RunTimer()
        {
            this.Timer = new Timer();
            Timer.Interval = 500; //ms
            this.Timer.Elapsed += OnTimedEvent;

            this.Timer.Start();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            this.Timer.Stop();

            //var thread =
            Task.Run(() =>
            {
                Stopwatch test = new Stopwatch();
                test.Start();

                var response = _roboManager.GetState();

                while (response == Constants.error)
                {
                    response = _roboManager.GetState();
                }

                var formatedResponse = response.Split(' ');

                byte[] responseBytes = new byte[4];

                //2 motors

                for (int i = 0; i < responseBytes.Length; i++)
                {
                    responseBytes[i] = byte.Parse(formatedResponse[21 + i].ToString(), System.Globalization.NumberStyles.HexNumber);
                }

                var encoderImpulses = BitConverter.ToInt32(responseBytes, 0);
                double numberOfRotations = encoderImpulses / 360.00;
                currentDistance = numberOfRotations * wheelCircumference;

                if (currentDistance >= this.TargetDistance)
                {
                    _roboManager.StopMotors();
                    var a = 1;
                }
                else
                {
                    this.Timer.Start();

                }

                test.Stop();
                ;
            });

        }

    }
}

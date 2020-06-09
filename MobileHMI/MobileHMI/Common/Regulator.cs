using Android.Bluetooth;
using MobileHMI.Helpers;
using MobileHMI.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace MobileHMI.Common
{
    public class Regulator
    {

        private const double WHEEL_CIRCUMFERENCE = 17.59291886010284; //cm
        private IRoboManager _roboManager;
        private bool runPID = true;

        public Regulator(IRoboManager roboManager)
        {
            _roboManager = roboManager;
            
        }

        public bool IsConnected { get; set; }

        public int TargetDistance { get; set; }

        public double Kp { get; set; } = 5;
        public double Ki { get; set; } = 0.1;
        public double Kd { get; set; } = 0.15;

        // public Timer Timer { get; set; } //100ms

        public async void RunPIDAsync()
        {
            await PID();
        }
    
        public void RunRelay()
        {
            this.runPID = false;
            StopAfterTargetDistance();
        }

        private void StopAfterTargetDistance()
        {
            bool shouldRun = true;
            double totalDistance = 0.00;
            double currentDistance = 0.00;

            _roboManager.MoveForwards();

            while (shouldRun)
            {
                currentDistance = GetDistance() - totalDistance;
                Debug.WriteLine("Current distance: " + currentDistance);

                totalDistance += currentDistance;
                Debug.WriteLine("totalDistance Distance: " + totalDistance);

                shouldRun = totalDistance >= this.TargetDistance ? false : true;
                Debug.WriteLine("Should run: " + shouldRun);
            }

            _roboManager.StopMotors();

            string firstMotor = _roboManager.ResetMotors(0);
            string secondMotor = _roboManager.ResetMotors(1);

            _roboManager.StopMotors();
        }

        private async Task PID()
        {
            double currentDistance = 0.00;
            double integrator = 0.00;
            int Ts = 100;
            double error = (TargetDistance - currentDistance);
            double voltageToMotors = 50;
            bool shouldRun = true;
            double totalDistance = 0.00;
            byte sendVoltage = 0;
            runPID = true;

            string firstMotor = _roboManager.ResetMotors(0);
            string secondMotor = _roboManager.ResetMotors(1);

            await Task.Run(() =>
            {
                while (runPID)
                {
                    sendVoltage = (byte)voltageToMotors; //cast при отрицателен знак
                    _roboManager.Move(sendVoltage);
                    currentDistance = GetDistance() - totalDistance;

                    totalDistance += currentDistance;
                    error = (TargetDistance - totalDistance);
                    voltageToMotors = Kp * error + Ki * integrator;


                    Debug.WriteLine("totalDistance Distance: " + totalDistance + "Voltage: " + sendVoltage);

                    if (voltageToMotors > 95)
                    {
                        voltageToMotors = 95;
                    }

                    if (voltageToMotors < -95)
                    {
                        voltageToMotors = -95;
                    }

                    integrator = integrator + error * 0.1;

                    Thread.Sleep(Ts);

                    shouldRun = totalDistance >= this.TargetDistance ? false : true;
                }

                _roboManager.StopMotors();
                firstMotor = _roboManager.ResetMotors(0);
                secondMotor = _roboManager.ResetMotors(1);
            });
        }

        private double GetDistance()
        {
            var leftEncoder = ProcessEncoderImpulses(0);
            var rightEncoder = ProcessEncoderImpulses(1);

            var encoderImpulses = (leftEncoder + rightEncoder) / 2;

            double numberOfRotations = encoderImpulses / 360.00;

            return numberOfRotations * WHEEL_CIRCUMFERENCE;
        }

        private double ProcessEncoderImpulses(int port)
        {
            var response = _roboManager.GetState(port);

            if (response == Constants.error)
                return 0;

            var formatedResponse = response.Split(' ');
            byte[] responseBytes = new byte[4];

            //2 motors
            for (int i = 0; i < responseBytes.Length; i++)
            {
                responseBytes[i] = byte.Parse(formatedResponse[21 + i].ToString(), System.Globalization.NumberStyles.HexNumber);
            }

            var encoderImpulses = BitConverter.ToInt32(responseBytes, 0);

            return encoderImpulses;
        }
    }
}

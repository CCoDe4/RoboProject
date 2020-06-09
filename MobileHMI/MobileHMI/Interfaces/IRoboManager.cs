using Android.Bluetooth;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHMI.Interfaces
{
    public interface IRoboManager
    {
        BluetoothSocket BluetoothConnection { get; set; } //note
        void MoveForwards();
        void MoveBackwards();
        void LeftMotor();
        void RightMotor();
        void Beep();
        void StopMotors();
        string ResetMotors(int port);
        string GetState(int port);

        void Move(byte test);
    }
}

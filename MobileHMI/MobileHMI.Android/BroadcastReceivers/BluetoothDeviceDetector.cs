﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MobileHMI.Droid.BroadcastReceivers
{
    [BroadcastReceiver]
    [IntentFilter(new[] { BluetoothDevice.ActionFound })]
    public class BluetoothDeviceDetector : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context, "Received intent!", ToastLength.Short).Show();
        }
    }
}
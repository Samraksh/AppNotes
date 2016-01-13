using System;
using System.Runtime.CompilerServices;
using Microsoft.SPOT.Hardware;

namespace Samraksh.SPOT.RealTime
{
    public class Timer : NativeEventDispatcher
    {
        public Timer(string strDrvName, ulong drvData, int callbackCount) 
            : base(strDrvName, drvData) 
        {

        }

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern static public void Dispose();

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern static public bool Change(uint dueTime, uint period);

        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern static public void GenerateInterrupt(); 
    }
}

using System;
using System.Text;
using System.Threading;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;
using Samraksh.eMote.Net.Mac;


namespace Samraksh.AppNote.SerialWirelessBridge {

    /// <summary>
    /// Demonstrates two-way serial to wireless bridge.
    /// Also demonstrates
    /// - Simple leader election to select a .NOW as the unit to initiate serial messages.
    /// - How to write a uniform protocol where each node runs the same program.
    /// 
    /// Uses 3 .NOWs running the same program. Initially, !Leader and fixed SelfTime and Counter = 0
    /// 
    /// Leader Election. Assumes 2 nodes, each connected to the other.
    ///     !Leader -> send SelfTime as Time via serial
    ///     Receive serial Time as NeighborTime -> Leader = (SelfTime > NeighborTime)
    /// 
    /// Bridge. Message types: T = ouTgoing; R = return; C = confirm; E = error
    ///     Ideal
    ///         Leader -> increment counter, enlist value and send via serial (S)
    ///         Receive serial (T) -> send via CSMA (T)
    ///         Receive CSMA (T) -> print on console, send via CSMA (R)
    ///         Receive CSMA (R) -> send via serial (R)
    ///         Receive serial (R) -> send via CSMA (C) and delist value
    ///     Fault detection
    ///         Exists expired list entries -> send via CSMA (E) and delist
    ///         !Leader and no recent serial or CSMA activity -> LeaderElected := false
    /// 
    /// Hard wire .NOWs as follows:
    ///     - #1 to #2 via cross-over serial (COM2). 
    ///         May be powered via USB but cannot be connected to MF-Deploy. 
    ///     - #3 to PC via USB-serial.
    ///
    /// Configure all .NOWs with antennas (if external)
    ///
    /// </summary>
    public static class Program {
        /// <summary>
        /// Serial Wireless bridge
        /// </summary>
        public static void Main() {
            Debug.Print("\nSerial Wireless Bridge");
            Debug.Print(VersionInfo.VersionBuild());
            Debug.Print("");

            // This serves as the node id. Improbable that both nodes would choose the same value
            Global.NodeIdLong = DateTime.Now.Ticks;
            Global.NodeIdBytes = Encoding.UTF8.GetBytes(Global.NodeIdLong.ToString("X" + Global.NodeIdBytesLength));

            // Set initial status value
            Global.LdrStatus = Global.LeaderStatus.Undecided;

            // Set up serial
            Global.SrlLink = new SerialLink();

            // Set up CSMA radio
            //  _csmaRadio = new SimpleCsmaRadio(RadioName.RF231RADIO,10,TxPowerValue.Power_Minus9dBm, RadioReceive );

            // Start election periodic action
            ProtocolActions.SndSerialElectionClass.SndSerialElectionTimer =
                new Timer(_ => ProtocolActions.SndSerialElectionClass.SndSerialElection(), null, 0, Global.TimedActionIntervalMicrosec); // Starts immediately
        }

        private static void RadioReceive(CSMA csma) {

        }
    }
}






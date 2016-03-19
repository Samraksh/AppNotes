using System;
using Microsoft.SPOT;

namespace Samraksh.eMote.Net
{

    /// <summary>
    /// Kinds of callbacks
    /// </summary>
    public enum CallbackTypes
    {
        /// <summary>Packet received</summary>
        Received,
        /// <summary>Neighborhood has changed</summary>
        NeighborChanged,
	}

    /// <summary>
    /// Callback class, should only be used internally by the mac and not by any user programs
    /// </summary>
    internal static class Callbacks
    {
        private static ReceiveCallBack _receiveCallBack = null;
        private static NeighborhoodChangeCallBack _neighborChangeCallBack = null;
		
        /// <summary>
        /// Set the receive callback to be called on arrival of a packet
        /// </summary>
        /// <param name="callback">Receivecallback function pointer</param>
        public static void SetReceiveCallback(ReceiveCallBack callback)
        {
            _receiveCallBack = callback;
        }

		/// <summary>
		/// Set the neighbor change callback to be called when there is a change in neighbor table
		/// </summary>
		/// <param name="callback">Neighborcallback function pointer</param>
		public static void SetNeighborChangeCallback(NeighborhoodChangeCallBack callback) {
			_neighborChangeCallBack = callback;
		}

		/// <summary>
        /// Returns the receive callback function
        /// </summary>
        /// <returns></returns>
        public static ReceiveCallBack GetReceiveCallback()
        {
            return _receiveCallBack;
        }

        /// <summary>
        /// Returns the neighbor change callback function registered
        /// </summary>
        /// <returns></returns>
        public static NeighborhoodChangeCallBack GetNeighborChangeCallback()
        {
            return _neighborChangeCallBack;
        }

		/// <summary>
        /// First level callback from native code
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <param name="time"></param>
        /// <exception caption="CallbackNotConfigured Exception" cref="CallbackNotConfiguredException"></exception>
        public static void ReceiveFunction(uint data1, uint data2, DateTime time)
        {
            if (_receiveCallBack == null)
                throw new CallbackNotConfiguredException();

            /*if (_neighborChangeCallBack == null)
                Debug.Print("The Neighbor Callback has not been configured \n");*/

            if ((data1 == (uint)CallbackTypes.Received) && (_receiveCallBack != null))
                _receiveCallBack((UInt16)data2);
            else if ((data1 == (uint)CallbackTypes.NeighborChanged) && (_neighborChangeCallBack != null))
                _neighborChangeCallBack((UInt16)data2);
        }
    }
}

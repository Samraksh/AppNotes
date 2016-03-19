using System;
using Microsoft.SPOT;
using System.Runtime.CompilerServices;
using Samraksh.eMote.Net.Mac;

namespace Samraksh.eMote.Net.Mac
{
    /// <summary>CSMA objects</summary>
    public class CSMA : MACBase
    {
        //private static CSMA CSMAInstance;
        //private static object syncObject = new Object();

        /// <summary>
        /// 
        /// </summary>
        public CSMA(MACConfiguration MacConfig)
            : base(MacConfig, MACType.CSMA)
        {
        }

        /*/// <summary>
        /// Returns the instance of the CSMA object
        /// </summary>
        /// <remarks>This is a singleton pattern. There can only be one CSMA Mac object.</remarks>
        /// /// <value>Instance of CSMA object</value>
        public static CSMA Instance
        {
            get
            {
                if (CSMAInstance == null)
                {
                    lock (syncObject)
                    {
                        if (CSMAInstance == null)
                            CSMAInstance = new CSMA();
                    }
                }

                return CSMAInstance;
            }
        }*/

    }
}

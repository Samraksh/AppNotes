using System;
using Microsoft.SPOT;
using System.Runtime.CompilerServices;
using Samraksh.eMote.Net.Mac;

namespace Samraksh.eMote.Net.Mac
{
    /// <summary>OMAC objects</summary>
    public class OMAC : MACBase
    {
        //private static OMAC OMACInstance;
        //private static object syncObject = new Object();

        /// <summary>
        /// 
        /// </summary>
        public OMAC(MACConfiguration MacConfig)
            :base(MacConfig, MACType.OMAC)
        {
        }

        /*/// <summary>
        /// Returns the instance of the OMAC object
        /// </summary>
        /// <remarks>This is a singleton pattern. There can only be one OMAC Mac object.</remarks>
        /// <value>Instance of OMAC object</value>
        public static OMAC Instance
        {
            get
            {
                if (OMACInstance == null)
                {
                    lock (syncObject)
                    {
                        if (OMACInstance == null)
                            OMACInstance = new OMAC();
                    }
                }

                return OMACInstance;
            }
        }*/
    }
}

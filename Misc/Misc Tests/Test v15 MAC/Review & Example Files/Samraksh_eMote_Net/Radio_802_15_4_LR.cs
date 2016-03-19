using System;
using Microsoft.SPOT;

namespace Samraksh.eMote.Net.Radio
{
    /// <summary>Long range radio</summary>
    public class Radio_802_15_4_LR : Radio_802_15_4_Base
    {
        private static Radio_802_15_4_LR LRRadioInstance;
        private static object syncObject = new Object();

        private Radio_802_15_4_LR()
        {
        }
        
        private Radio_802_15_4_LR(string drvName, ulong drvdata)
            : base(drvName, drvdata)
        {
        }

        /// <summary>Get RadioInstance</summary>
        /// <returns>Instance</returns>
        /// <exception caption="RadioNotConfigured Exception" cref="O:Samraksh.eMote.Net.RadioNotConfiguredException._ctor"></exception>
        /// <exception caption="System Exception" cref="System.SystemException"></exception>
        public static Radio_802_15_4_LR GetInstance()
        {
            if (LRRadioInstance == null)
            {
                lock (syncObject)
                {
                    if (LRRadioInstance == null)
                        LRRadioInstance = new Radio_802_15_4_LR();
                }
            }

            return LRRadioInstance;
        }



        /// <summary>Get radio instance</summary>
        /// <param name="user">Radio user</param>
        /// <exception caption="RadioNotConfigured Exception" cref="O:Samraksh.eMote.Net.RadioNotConfiguredException._ctor"></exception>
        /// <exception caption="System Exception" cref="System.SystemException"></exception>
        public static Radio_802_15_4_LR GetInstance(RadioUser user)
        {
            if (LRRadioInstance == null)
            {
                lock (syncObject)
                {
                    if (LRRadioInstance == null)
                    {
                        if (user == RadioUser.CSMAMAC)
                        {
                            Radio_802_15_4_Base.CurrUser = RadioUser.CSMAMAC;
                            LRRadioInstance = new Radio_802_15_4_LR("CSMACallback", 4321);
                        }
                        else if (user == RadioUser.OMAC)
                        {
                            Radio_802_15_4_Base.CurrUser = RadioUser.OMAC;
                            LRRadioInstance = new Radio_802_15_4_LR("OMACCallback", 4322);
                        }
                        else if (user == RadioUser.CSharp)
                        {
                            Radio_802_15_4_Base.CurrUser = RadioUser.CSharp;
                            LRRadioInstance = new Radio_802_15_4_LR();
                        }
                    }
                }
            }

            return LRRadioInstance;
        }
    }
}

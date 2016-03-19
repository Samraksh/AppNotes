using System;
using Microsoft.SPOT;

namespace Samraksh.eMote.Net.Radio
{
    /// <summary>Generic radio object</summary>
    public class Radio_802_15_4 : Radio_802_15_4_Base
    {
        private static Radio_802_15_4 GenericRadioInstance;
        private static object syncObject = new Object();

        private Radio_802_15_4()
        {
        }

        private Radio_802_15_4(string drvName, ulong drvdata)
            : base(drvName, drvdata)
        {
        }

        /// <summary>Get the radio instance</summary>
        /// <returns>Radio instance</returns>
        /// <exception caption="RadioNotConfigured Exception" cref="O:Samraksh.eMote.Net.RadioNotConfiguredException._ctor"></exception>
        /// <exception caption="System Exception" cref="System.SystemException"></exception>
        public static Radio_802_15_4 GetInstance()
        {
            if (GenericRadioInstance == null)
            {
                lock (syncObject)
                {
                    if (GenericRadioInstance == null)
                        GenericRadioInstance = new Radio_802_15_4();
                }
            }
            return GenericRadioInstance;
        }

        /// <summary>Get the radio instance</summary>
        /// <param name="user">Radio user</param>
        /// <exception caption="RadioNotConfigured Exception" cref="O:Samraksh.eMote.Net.RadioNotConfiguredException._ctor"></exception>
        /// <exception caption="System Exception" cref="System.SystemException"></exception>
        public static Radio_802_15_4 GetInstance(RadioUser user)
        {
            if (GenericRadioInstance == null)
            {
                lock (syncObject)
                {
                    if (GenericRadioInstance == null)
                    {
                        if (user == RadioUser.CSMAMAC)
                        {
                            Radio_802_15_4_Base.CurrUser = RadioUser.CSMAMAC;
                            GenericRadioInstance = new Radio_802_15_4("CSMACallback", 4321);
                        }
                        else if (user == RadioUser.OMAC)
                        {
                            Radio_802_15_4_Base.CurrUser = RadioUser.OMAC;
                            GenericRadioInstance = new Radio_802_15_4("OMACCallback", 4322);
                        }
                        else if (user == RadioUser.CSharp)
                        {
                            Radio_802_15_4_Base.CurrUser = RadioUser.CSharp;
                            GenericRadioInstance = new Radio_802_15_4();
                        }
                    }
                }
            }
            return GenericRadioInstance;
        }
    }
}

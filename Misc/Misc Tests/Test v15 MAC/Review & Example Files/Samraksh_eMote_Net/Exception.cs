using System;
using Microsoft.SPOT;

namespace Samraksh.eMote.Net
{
    /// <summary>
    /// Exception thrown when the radio is configured incorrectly
    /// </summary>
    public class RadioConfigurationMismatchException : System.Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public RadioConfigurationMismatchException() 
        {
            throw new RadioConfigurationMismatchException();
            //Debug.Print("Mismatch between initialized radio object and configuration passed\n"); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public RadioConfigurationMismatchException(string message)
            : base(message)
        {
            throw new RadioConfigurationMismatchException(message);
            //throw new RadioConfigurationMismatchException("Mismatch between initialized radio object and configuration passed");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class RadioNotConfiguredException : System.Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public RadioNotConfiguredException() 
        {
            throw new RadioNotConfiguredException();
            //Debug.Print("The radio has not been configured with a config object or a callback\n"); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public RadioNotConfiguredException(string message) 
            : base(message) 
        {
            throw new RadioNotConfiguredException(message);
            //throw new RadioNotConfiguredException("The radio has not been configured with a config object or a callback");
            //Debug.Print(message); 
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class RadioBusyException : System.Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public RadioBusyException() 
        {
            throw new RadioBusyException();
            //Debug.Print("The radio already has a user\n"); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public RadioBusyException(string message)
            : base(message)
        {
            throw new RadioBusyException(message);
            //throw new RadioBusyException("The radio already has a user");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MACNotConfiguredException : System.Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public MACNotConfiguredException() 
        {
            throw new MACNotConfiguredException();
            //Debug.Print("You are attempting to acquire an instance of the mac without configuring it\n"); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public MACNotConfiguredException(string message) 
            : base(message) 
        {
            throw new MACNotConfiguredException(message);
            //throw new MACNotConfiguredException("You are attempting to acquire an instance of the mac without configuring it");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public MACNotConfiguredException(string message, Exception innerException) 
            : base(message, innerException) 
        {
            throw new MACNotConfiguredException(message, new MACNotConfiguredException());
            //throw new MACNotConfiguredException("You are attempting to acquire an instance of the mac without configuring it", new MACNotConfiguredException());
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class MACTypeMismatchException : System.Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public MACTypeMismatchException()
        {
            throw new MACTypeMismatchException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public MACTypeMismatchException(string message)
            : base(message)
        {
            throw new MACTypeMismatchException(message);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CallbackNotConfiguredException : System.Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public CallbackNotConfiguredException() 
        {
            throw new CallbackNotConfiguredException();
            //Debug.Print("Receive callback has not been configured \n"); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public CallbackNotConfiguredException(string message)
            : base(message)
        {
            throw new CallbackNotConfiguredException(message);
            //throw new CallbackNotConfiguredException("Receive callback has not been configured");
        }
    }
}

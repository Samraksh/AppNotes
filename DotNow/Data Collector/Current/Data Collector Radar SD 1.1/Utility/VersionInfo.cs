/*=========================
 * Version Info Class
 *  Generate version number and build date/time
 * Versions
 *  1.0 Initial Version
 *  1.1 Added VersionDateTime property
 ========================*/

using System;
using System.Reflection;

namespace Samraksh.AppNote.Utility {
    /// <summary>
    /// Get version info
    /// </summary>
    /// <remarks>?
    /// See http://stackoverflow.com/a/1601079/468523
    /// </remarks>
    public static class VersionInfo {

        /// <summary>
        /// The version for which info is required
        /// </summary>
        private static Version _theVersion = Assembly.GetExecutingAssembly().GetName().Version;

        /// <summary>
        /// Initialize the version
        /// </summary>
        /// <remarks>Skip this if you want version info from the assembly in which this class resides</remarks>
        /// <param name="theAssembly"></param>
        public static void Init(Assembly theAssembly) {
            _theVersion = theAssembly.GetName().Version;
        }

        /// <summary>
        /// Current build Major.Minor version info
        /// </summary>
        public static string Version {
            get { return _theVersion.Major + "." + _theVersion.Minor; }
        }


        /// <summary>
        /// Current build DateTime
        /// </summary>
        public static DateTime BuildDateTime {
            get {
                return new DateTime(2000, 1, 1).Add(
                   new TimeSpan(TimeSpan.TicksPerDay * _theVersion.Build + // Days since 1 Jan 2000
                       TimeSpan.TicksPerSecond * 2 * _theVersion.Revision));    // Seconds since midnight
            }
        }
    }
}

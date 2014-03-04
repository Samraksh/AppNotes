/*=========================
 * Version Info Class
 *  Generate version number and build date/time
 * Versions
 *  1.0 Initial Version
 *  1.1 Added VersionDateTime property
 ========================*/

using System;
using System.Reflection;

namespace Samraksh {
    namespace AppNote {
        namespace Utility {
            /// <summary>
            /// Get version info
            /// </summary>
            /// <remarks>?
            /// See http://stackoverflow.com/a/1601079/468523
            /// </remarks>
            public static class VersionInfo {
                /// <summary>
                /// Current build Major.Minor version info
                /// </summary>
                /// <remarks>In AssemblyInfo.cs, must have versions in the form of "major.minor.*"</remarks>
                public static string Version {
                    get {
                        return RunningVersion.Major + "." + RunningVersion.Minor;
                    }
                }

                /// <summary>
                /// Current build DateTime
                /// </summary>
                public static DateTime BuildDateTime {
                    get {
                        return new DateTime(2000, 1, 1).Add(
                            new TimeSpan(TimeSpan.TicksPerDay * RunningVersion.Build + // Days since 1 Jan 2000
                                TimeSpan.TicksPerSecond * 2 * RunningVersion.Revision));    // Half seconds since midnight
                    }
                }

                /// <summary>
                /// Conveniently formatted string with version and date-time of build
                /// </summary>
                public static string VersionDateTime {
                    get { return Version + " (" + BuildDateTime + ")"; }
                }

                private static readonly Version RunningVersion = Assembly.GetExecutingAssembly().GetName().Version;
            }

        }
    }
}

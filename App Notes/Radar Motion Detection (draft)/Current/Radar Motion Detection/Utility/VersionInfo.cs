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
                public static string Version {
                    get { return RunningVersion.Major.ToString() + "." + RunningVersion.Minor.ToString(); }
                }
                /// <summary>
                /// Current build DateTime
                /// </summary>
                public static DateTime BuildDateTime {
                    get {
                        return new DateTime(2000, 1, 1).Add(
                           new TimeSpan(TimeSpan.TicksPerDay * RunningVersion.Build + // Days since 1 Jan 2000
                               TimeSpan.TicksPerSecond * 2 * RunningVersion.Revision));    // Seconds since midnight
                    }
                }
                private static readonly Version RunningVersion = Assembly.GetExecutingAssembly().GetName().Version;
            }

        }
    }
}

using System;
using Microsoft.SPOT;
using Samraksh.AppNote.Utility;

namespace TestEnhancedeMoteLCD
{
    public class Program
    {
        private const string OtherAssemblyName = "Samraksh.AppNote.Utility.EnhancedeMoteLcd";
		private static readonly EnhancedEmoteLCD Lcd = new EnhancedEmoteLCD();

        public static void Main()
        {
            var otherAssemblyFullName = GetOtherAssemblyFullName(OtherAssemblyName);
            Debug.Print("Test " + otherAssemblyFullName + "\n");


        }

        private static string GetOtherAssemblyFullName(string assemblyName)
        {
            var domainAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var theAssembly in domainAssemblies)
            {
                if (theAssembly.GetName().Name.ToUpper() == assemblyName.ToUpper())
                {
                    return theAssembly.FullName;
                }
            }
            return assemblyName + " -- not found --";
        }
    }
}

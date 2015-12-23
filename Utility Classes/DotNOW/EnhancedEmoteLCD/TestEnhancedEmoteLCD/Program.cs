using System;
using Microsoft.SPOT;

namespace TestEnhancedeMoteLCD
{
    public class Program
    {
        private const string OtherAssemblyName = "Samraksh.AppNote.Utility.EnhancedeMoteLcd";

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

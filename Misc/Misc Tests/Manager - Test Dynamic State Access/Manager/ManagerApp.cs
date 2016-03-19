using System;
using System.Collections;
using System.Reflection;
using System.Text;
using Microsoft.SPOT;

namespace ManagerApp
{
	internal class SharedVarInfo
	{
		public readonly bool IsScalar;
		public readonly string TypeName;
		public readonly FieldInfo FieldInfo;

		public SharedVarInfo(bool isScalar, string typeName, FieldInfo fieldInfo)
		{
			IsScalar = isScalar;
			TypeName = typeName;
			FieldInfo = fieldInfo;
		}
	}


	public static class ManagerApp
	{
		private static Hashtable _sharedVars = new Hashtable();


		public static void Main()
		{
			Debug.Print("Manager App");
			Debug.Print("\n------------------------\n");

			var domainAssemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (var theAssembly in domainAssemblies)
			{
				Debug.Print(theAssembly.FullName);
				var assemblyTypes = theAssembly.GetTypes();
				foreach (var theType in assemblyTypes)
				{
					Debug.Print("\t" + theType.FullName);
					if (theType.FullName == "UserApp.UserApp+SharedVars")
					{
						var theFields = theType.GetFields();
						foreach (var theField in theFields)
						{
							Debug.Print("\t\t" + theField.Name + ", " + theField.FieldType + ", " + theField.MemberType);
							if (theField.FieldType != typeof(Array))
							{
								_sharedVars[theField.Name] = new SharedVarInfo(true, theField.FieldType.ToString(), theField);
								var theFieldVal = theField.GetValue(null);
								Debug.Print("\t\t\t" + theFieldVal);
							}
							else
							{
								var theArray = (Array)theField.GetValue(null);
								var theArrayType = theArray.GetType();
								Debug.Print("\t\t\t * " + theArrayType);
								if (theArrayType == typeof(byte[]))
								{
									var x = theField.FieldType;
									var x2 = x.ToString();
									_sharedVars[theField.Name] = new SharedVarInfo(false, theArrayType.ToString(), theField);
									foreach (var theArrayVal in theArray)
									{
										Debug.Print("\t\t\t" + (byte)theArrayVal);
									}
								}
								else
								{
									throw new Exception("Unknown array type " + theArrayType);
								}
							}

						}
					}
				}
			}
			Debug.Print("\n------------------------\n");

			var varName = "Third";
			var theVar = (SharedVarInfo)_sharedVars[varName];
			if (theVar != null)
			{
				if (theVar.IsScalar)
				{
					var firstVal = theVar.FieldInfo.GetValue(null);
					Debug.Print(varName + ": " + firstVal);
				}
				else
				{
					var theArray = (Array)theVar.FieldInfo.GetValue(null);
					switch (theVar.TypeName)
					{
						case "System.Byte[]":
							{
								var byteArr = (byte[])theArray;
								Debug.Print("Value of " + varName + " is " + PrintArray(byteArr));
							}
							break;
						default:
							{
								Debug.Print("Unsupported type for shared variable " + varName + " is " + theArray.GetType());
								break;
							}
					}
				}
			}
			else
			{
				Debug.Print("Shared variable " + varName + " not found");
			}

			Debug.Print("\n=========================================================\n");
		}

		private static string PrintArray(Array theArray)
		{
			var strB = new StringBuilder("{");
			foreach (var theItem in theArray)
			{
				strB.Append(theItem);
				strB.Append(',');
			}
			strB.Append("}");
			return strB.ToString();
		}

	}
}

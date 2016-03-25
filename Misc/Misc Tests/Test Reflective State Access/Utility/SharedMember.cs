//#define DiagPrint

using System;
using System.Collections;
using System.Reflection;
using System.Text;

#if DiagPrint
using Microsoft.SPOT;
#endif

namespace Samraksh.AppNote.Utility
{

	/// <summary>
	/// Reflectively access shared members
	/// </summary>
	public class SharedMembers
	{
		private const string NullVal = "Null";

		private static readonly Hashtable SharedVars = new Hashtable();

		/// <summary>
		/// Get the shared members in a hash table indexed by member name with value of type Info
		/// </summary>
		/// <param name="theDomain"></param>
		/// <param name="sharedMemberName"></param>
		/// <returns></returns>
		public static Hashtable Get(AppDomain theDomain, string sharedMemberName)
		{
			var assemblies = theDomain.GetAssemblies();
			foreach (var theAssembly in assemblies)
			{
#if DiagPrint
				Debug.Print(theAssembly.FullName);
#endif
				var fullNameParts = theAssembly.FullName.Split(',');
				var nameParts = fullNameParts[0].Split('.');
				if (nameParts[0] == "mscorlib" || nameParts[0] == "Microsoft" || nameParts[0]=="System")
				{
#if DiagPrint
					Debug.Print("\tSkipping ...");
#endif
					continue;
				}
				var assemblyTypes = theAssembly.GetTypes();
				foreach (var theType in assemblyTypes)
				{
#if DiagPrint
					Debug.Print("\tType: " + theType.FullName + " " + theType.Name + " IsClass: " + theType.IsClass);
#endif
					if (theType.Name != sharedMemberName)
					{
						continue;
					}
					var fields = theType.GetFields();
					foreach (var theField in fields)
					{
						if (theField.MemberType != MemberTypes.Field)
						{
							continue;
						}
						SharedVars[theField.Name] = new Info(theField.FieldType != typeof(Array), theField);
					}
					return SharedVars;
				}
			}
			return SharedVars;
		}

		/// <summary>
		/// Information about a shared member; includes ToString method
		/// </summary>
		public class Info
		{
			private readonly StringBuilder _valSb = new StringBuilder();

			/// <summary>
			/// True iff the member is scalar (else Array)
			/// </summary>
			public readonly bool IsScalar;
			/// <summary>
			/// Information about the field
			/// </summary>
			public readonly FieldInfo FieldInfo;

			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="isScalar"></param>
			/// <param name="fieldInfo"></param>
			public Info(bool isScalar, FieldInfo fieldInfo)
			{
				IsScalar = isScalar;
				FieldInfo = fieldInfo;
			}

			/// <summary>
			/// Convert to string
			/// </summary>
			/// <remarks>
			/// Scalar conversion is via base type method
			/// Array conversion iterates thru the members to build a string
			/// </remarks>
			/// <returns></returns>
			public new string ToString()
			{
				if (IsScalar)
				{
					var val = FieldInfo.GetValue(null);
					return val != null ? val.ToString() : NullVal;
				}

				_valSb.Clear();
				_valSb.Append('[');
				var theArray = (Array)FieldInfo.GetValue(null);
				if (theArray == null)
				{
					return NullVal;
				}
				var i = 0;
				foreach (var theItem in theArray)
				{
					_valSb.Append('"');
					_valSb.Append(theItem ?? NullVal);
					_valSb.Append('"');
					if (++i != theArray.Length)
					{
						_valSb.Append(',');
					}
				}
				_valSb.Append(']');
				return _valSb.ToString();
			}
		}
	}

}

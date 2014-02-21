using System;
using Microsoft.SPOT;

using IndianaJones.NETMF.String;
using IndianaJones.NETMF.Time;
using IndianaJones.NETMF.Json;
using IndianaJones.NETMF.Integer;
using System.Collections;

namespace TestJson.NETMF
{
	public class Program
	{
		public static void Main()
		{
			TestJson test = new TestJson();

			test.Run();
		}

	}

	public class TestJson
	{
		public TestJson()
		{
		}

		public void Run()
		{
			ObjectWithIdAndHashTbl mnc = new ObjectWithIdAndHashTbl();
			mnc.ListOfClasses.Add("new class 1");
			mnc.ListOfClasses.Add("new class 2");
			mnc.TheGuid = Guid.NewGuid();
			mnc.CurrentTime = DateTime.Now.AddDays(30);

			ObjectWithDT dateTime1 = new ObjectWithDT();
			dateTime1.CurrentTime = DateTime.Now;

			ObjectWithDT dateTime2 = new ObjectWithDT();
			dateTime2.CurrentTime = DateTime.Now.AddDays(1);

			ArrayList array = new ArrayList();
			array.Add(dateTime1);
			array.Add(dateTime2);

			DictionaryEntry de = new DictionaryEntry("KeyName", "ValueName");

			Hashtable ht = new Hashtable();
			ht.Add("KeyName", "ValueName");

			ObjectWithEmbeddedObjects c = new ObjectWithEmbeddedObjects();
			c.StringPropertyOne = "hello";
			c.StringPropertyTwo = "goodbye";
			c.ObjectPropertyOne.StringValue = "stupid";
			c.ObjectPropertyOne.DoubleValue = -3300.003;
			c.ObjectPropertyOne.BoolValue = true;
			c.ObjectPropertyTwo.TheGuid = Guid.NewGuid();
			c.ObjectPropertyTwo.CurrentTime = DateTime.Now;
			c.ObjectPropertyTwo.Hash.Add("key 1", "value 1");
			c.ObjectPropertyTwo.Hash.Add("key 2", "value 2");
			c.ObjectPropertyTwo.ListOfClasses.Add(new DictionaryEntry("ArrayKey", array));
			c.ObjectPropertyTwo.ListOfClasses.Add("list of classes 2");
			c.ObjectPropertyOne.Dict = new DictionaryEntry("DictKey", 99);

			Serializer serializer = new Serializer();

			Guid g = Guid.NewGuid();
			string gc = serializer.Serialize(mnc);

			string rc = serializer.Serialize(c);

			Debug.Print(rc);

			// CurrentTime and Guids are not deserializing.  Hmmm...
			ObjectWithIdAndHashTbl obj1 = serializer.Deserialize(gc) as ObjectWithIdAndHashTbl;

			ObjectWithEmbeddedObjects obj2 = serializer.Deserialize(rc) as ObjectWithEmbeddedObjects;
		}
	}

	public class ObjectWithDT
	{
		public ObjectWithDT()
		{
		}

		public System.DateTime CurrentTime { get; set; }
	}

	/// <summary>
	/// This class contains a Guid, an array of objects, and a hash table
	/// </summary>
	public class ObjectWithIdAndHashTbl
	{
		public ObjectWithIdAndHashTbl()
		{
			ListOfClasses = new ArrayList();
			Hash = new Hashtable();
		}

		public Guid TheGuid { get; set; }

		public ArrayList ListOfClasses { get; set; }

		public Hashtable Hash { get; set; }

		public DateTime CurrentTime { get; set; }
	}

	/// <summary>
	/// This class contains a couple simple strings, plus a couple embedded class objects
	/// </summary>
	public class ObjectWithEmbeddedObjects
	{
		public ObjectWithEmbeddedObjects()
		{
			ObjectPropertyOne = new ObjectWithPrimitivesAndDictEntry();
			ObjectPropertyTwo = new ObjectWithIdAndHashTbl();
		}

		public string StringPropertyOne { get; set; }

		public string StringPropertyTwo { get; set; }

		public ObjectWithPrimitivesAndDictEntry ObjectPropertyOne { get; set; }

		public ObjectWithIdAndHashTbl ObjectPropertyTwo { get; set; }
	}

	/// <summary>
	/// This class contains some primitives, plus a string and a DictionaryEntry
	/// </summary>
	public class ObjectWithPrimitivesAndDictEntry
	{
		public ObjectWithPrimitivesAndDictEntry()
		{

		}

		public string StringValue { get; set; }

		public double DoubleValue { get; set; }

		public bool BoolValue { get; set; }

		public DictionaryEntry Dict { get; set; }
	}
}

    public class Serializer
    {
        private PropertyTable _propertyTable;
        private DateTimeFormat _dateFormat;

        public Serializer()
        {
            _dateFormat = DateTimeFormat.ISO8601;
            _propertyTable = new PropertyTable();
        }

        /// <summary>
        /// Gets/Sets the format that will be used to display
        /// and parse dates in the Json data.
        /// </summary>
        public DateTimeFormat DateFormat
        {
            get
            {
                return _dateFormat;
            }
            set
            {
                _dateFormat = value;
            }
        }

        /// <summary>
        /// Serializes an object into a Json string.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public string Serialize(object o)
        {
            return JsonPrimitives.Serialize(o);
        }

        /// <summary>
        /// Desrializes a Json string into an object.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public object Deserialize(string json)
        {
            Hashtable table = JsonParser.JsonDecode(json) as Hashtable;
            JsonPrimitives.DumpObjects(table, 0);

            return _propertyTable.FindObject(table);
        }

        /// <summary>
        /// Resets the contents of the Property Table with current classes and property definitions.
        /// This does NOT need to be called when values change, only when new classes are
        /// loaded dynamically at runtime.
        /// </summary>
        public void Snapshot()
        {
            _propertyTable.Snapshot();
        }
    }

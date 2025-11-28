namespace CStringLib
{
    public struct CString30
    {
        private const int pathSize = 10;
        public CString10 s0;
        public CString10 s1;
        public CString10 s2;

        public char this[int i]
        {
            get
            {
                var indexOfField = i / pathSize;
                var indexOfChar = i % pathSize;

                object instance = (object)this;
                var type = this.GetType();
                var cString10 = type.GetFields()
                    .OrderBy(f => f.Name)
                    .Select(f => f.GetValue(instance))
                    .OfType<CString10>()
                    .ElementAt(indexOfField);

                return cString10[indexOfChar];
            }
            set
            {
                var indexOfField = i / pathSize;
                var indexOfChar = i % pathSize;

                object instance = (object)this;
                var type = this.GetType();
                var fields = type.GetFields()
                    .OrderBy(f => f.Name)
                    .ToArray();

                var fValues = fields.Select(f => f.GetValue(instance))
                    .OfType<CString10>()
                    .ElementAt(indexOfField);

                fValues[indexOfChar] = value;

                fields[indexOfField].SetValue(instance, fValues);

                this = (CString30)instance;
            }
        }

        public string GetString()
        {
            object instance = (object)this;
            var type = this.GetType();
            var fields = type.GetFields()
                .OrderBy(f => f.Name)
                .Select(f => f.GetValue(instance))
                .OfType<CString10>()
                .Select(f => f.GetString());

            return string.Join("", fields);
        }

        public void SetString(string value)
        {
            object instance = (object)this;
            var type = this.GetType();
            var fields = type.GetFields()
                .OrderBy(f => f.Name).ToArray();

            var fValues = fields.Select(f => f.GetValue(instance))
                .OfType<CString10>()
                .ToArray();

            for (int i = 0; i <= (value.Length / pathSize); i++)
            {
                if (i >= fValues.Length) break;
                var parth = value.Skip(i * pathSize).Take(pathSize).ToArray();
                fValues[i].SetString(parth);
            }

            for (int i = 0; i < fValues.Length; i++)
            {
                fields[i].SetValue(instance, fValues[i]);
            }

            this = (CString30)instance;
        }

        public override string ToString()
        {
            return GetString();
        }
    }
}

    public struct CString10
    {
        public char c0;
        public char c1;
        public char c2;
        public char c3;
        public char c4;
        public char c5;
        public char c6;
        public char c7;
        public char c8;
        public char c9;

        public char this[int i]
        {
            get
            {
                object instance = (object)this;
                var type = this.GetType();
                var fields = type.GetFields()
                    .OrderBy(f => f.Name)
                    .ToArray();

                if (fields.Length < i) throw new IndexOutOfRangeException();

                var result = (char)fields[i].GetValue(instance);
                return result;

            }
            set
            {
                var type = this.GetType();
                var fields = type.GetFields()
                    .OrderBy(f => f.Name)
                    .ToArray();

                if (fields.Length < i) throw new IndexOutOfRangeException();

                object obj = (object)this;
                fields[i].SetValue(obj, value);
                this = (CString10)obj;
            }
        }

        public void SetString(string value)
        {
            object obj = (object)this;
            var type = this.GetType();
            var fields = type.GetFields()
                .OrderBy(f => f.Name)
                .ToArray();

            for (int i = 0; i < fields.Length; i++)
            {
                if (i < value.Length) fields[i].SetValue(obj, value[i]);
                else fields[i].SetValue(obj, new char());
            }

            this = (CString10)obj;
        }

        public string GetString()
        {
            object instance = (object)this;
            var type = this.GetType();
            var fields = type.GetFields()
                .OrderBy(f => f.Name)
                .Select(f => f.GetValue(instance));

            return string.Join("", fields);
        }

        public override string ToString()
        {
            return GetString();
        }
    }

using System;
using System.Collections.Generic;

namespace KeyValueStore
{
    class Program
    {
        static void Main(string[] args)
        {

            var d = new MyDictionary();
            try
            {
                Console.WriteLine(d["Cats"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            d["Cats"] = 42;
            d["Dogs"] = 17;
            Console.WriteLine($"{(int)d["Cats"]}, {(int)d["Dogs"]}");
        }
    }

    struct KeyValue  // cretaing a struct named 'KeyValue'
    {
        public readonly string key;  // string key 
        public readonly object value; // object value 

        public KeyValue(string key, object value) //this is the constructor for struct keyvalue
        {
            this.key = key; // just for identifying the particular key above 
            this.value = value;
        }
    }

    class MyDictionary
    {
        KeyValue[] arry = new KeyValue[15];
        int track = 0;

        public object this[string indexer]
        {
            get
            {
                foreach (var item in arry)
                {
                    if (item.key == indexer)
                    {
                        return item.value;
                    }
                }

                throw new KeyNotFoundException();
            }

            set
            {
                for (int i = 0; i < arry.Length; i++)
                {
                    if (arry[i].key == indexer)
                    {
                        arry[i] = new KeyValue(indexer, value);
                        return;
                    }
                }

                if (track < arry.Length)
                {
                    arry[track++] = new KeyValue(indexer, value);
                }
            }
        }
    }
}

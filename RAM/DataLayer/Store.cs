using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RAM
{
    public class Store<T>
    {
        private string DatabaseName;
        public List<T> Items = new List<T>();

        public Store(string storeName)
        {
            DatabaseName = storeName;
            readFromDisk();
        }

        public void SaveToDisk()
        {
            using (FileStream fs = new FileStream(DatabaseName, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, Items);
            }
        }
        
        public void readFromDisk()
        {
            try {
                using (FileStream fs = new FileStream(DatabaseName, FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Items = bf.Deserialize(fs) as List<T>;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

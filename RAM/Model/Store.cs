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
        private string _storeName;
        public List<T> Items = new List<T>();

        public Store(string storeName)
        {
            _storeName = storeName;
            ReadFromDisk();
        }

        public void Erase()
        {
            Items.Clear();
            if (File.Exists(_storeName))
            {
                File.Delete(_storeName);
            }
        }

        public void SaveToDisk()
        {
            using (FileStream fs = new FileStream(_storeName, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, Items);
            }
        }
        
        public void ReadFromDisk()
        {
            if (!File.Exists(_storeName))
            {
                return;
            }

            try {
                using (FileStream fs = new FileStream(_storeName, FileMode.OpenOrCreate))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Items = bf.Deserialize(fs) as List<T>;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RAM
{
    class Store
    {
        private string databaseName;
        private List<Carrier> carriers;

        public Store(string storeName)
        {
            databaseName = storeName;
        }

        public void saveToDisk()
        {
            using (FileStream fs = new FileStream(databaseName, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, carriers);
            }
        }

        public void readFromDisk()
        {
            using (FileStream fs = new FileStream(databaseName, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                carriers = bf.Deserialize(fs) as List<Carrier>;
            }
        }
    }
}

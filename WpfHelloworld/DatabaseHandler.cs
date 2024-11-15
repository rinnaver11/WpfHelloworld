using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;


namespace WpfHelloworld
{
    public class DatabaseHandler
    {
        private string _filePath;

        public DatabaseHandler(string filePath)
        {
            _filePath = filePath;
        }

        public void SaveDictionary(Dictionary<string, string> dictionary)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(item[]));
            using (FileStream fs = new FileStream(_filePath, FileMode.Create))
            {
                serializer.Serialize(fs, dictionary.Select(kv => new item() { id = kv.Key, value = kv.Value }).ToArray());
            }
        }

        public Dictionary<string, string> LoadDictionary()
        {
            if (!File.Exists(_filePath))
                return new Dictionary<string, string>();

            XmlSerializer serializer = new XmlSerializer(typeof(item[]));
            using (FileStream fs = new FileStream(_filePath, FileMode.Open))
            {
                return ((item[])serializer.Deserialize(fs))
               .ToDictionary(i => i.id, i => i.value);
            }
        }

        public bool ContainsItem(string login, string passwd)
        {
            var dictionary = LoadDictionary();
            return dictionary.TryGetValue(login, out passwd);
        }

        public class item
        {
            [XmlAttribute]
            public string id;
            [XmlAttribute]
            public string value;
        }

    }
}

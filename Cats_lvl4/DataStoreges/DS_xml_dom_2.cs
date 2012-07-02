using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Cats_lvl4.DataStoreges
{
    public class DS_xml_dom_2 : IDs
    {
        string path_to_file;
        private string p;

        public override bool Equals(object obj)
        {
            DS_xml_dom_2 ds = obj as DS_xml_dom_2;
            if (this.path_to_file == ds.path_to_file)
            { return true; }
            else
            { return false; }
        }

        public string getPath()
        {
            return this.path_to_file;
        }

        public DS_xml_dom_2(string p)
        {
            // TODO: Complete member initialization
            this.path_to_file = p;
        }

        public void Save(List<Cat> cats_list)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Cat>));
            FileStream fs = new FileStream(path_to_file, FileMode.OpenOrCreate);
            TextWriter textWriter = new StreamWriter(fs, Encoding.UTF8);
            serializer.Serialize(textWriter, cats_list);            
            textWriter.Close();
        }

        public List<Cat> Load()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Cat>));
            FileStream fs = new FileStream(path_to_file, FileMode.OpenOrCreate);
            TextReader textReader = new StreamReader(fs, Encoding.UTF8);
            List<Cat> cat_lst;
            cat_lst = (List<Cat>)deserializer.Deserialize(textReader);
            textReader.Close();
            return cat_lst;
        }
    }
}

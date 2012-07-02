using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Cats_lvl4.DataStoreges
{
    public class DS_xml_sax : IDs
    {
        string path_to_file;

        public override bool Equals(object obj)
        {
            DS_xml_sax ds = obj as DS_xml_sax;
            if (this.path_to_file == ds.path_to_file)
            { return true; }
            else
            { return false; }
        }

        public DS_xml_sax(string fName)
        {
            this.path_to_file = fName;
        }
        public string getPath()
        {
            return this.path_to_file;
        }

        public void Save(List<Cat> cats_list)
        {
            FileStream fs = new FileStream(path_to_file, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sw.WriteLine("<content>");
            foreach (Cat item in cats_list)
            {
                sw.WriteLine(ConverterFactory.getInstance("sxml", item).toStr(item));
            }
            sw.WriteLine("</content>");
            sw.Close();
            fs.Close();
        }

        public List<Cat> Load()
        {
            List<Cat> lst = new List<Cat>();
            FileStream fs = new FileStream(path_to_file, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            SAX_parser parser = new SAX_parser(sr);
            Cat obj = null;
            parser.StartTag += (tag_name) =>
            {
                if (tag_name == "bobcat") { obj = new Bobcat(); }
                if (tag_name == "tiger") { obj = new Tiger(); }
            };
            parser.Characters += (name,value) =>
            {
                switch (name)
                {
                    case "name": { obj.name = value; break; }
                    case "age": { obj.age = Convert.ToInt32(value);  break; }
                    case "weight": { obj.weight = Convert.ToSingle(value); break; }
                    case "hear_count": { ((Bobcat)(obj)).hear_count = Convert.ToInt64(value); break; }
                    case "cat_type": { ((Bobcat)(obj)).cat_type = value; break; }
                    case "location": { ((Tiger)(obj)).location = value; break; }
                    case "color": { ((Tiger)(obj)).color = value; break; }
                    case "height": { ((Tiger)(obj)).height = Convert.ToSingle(value); break; }
                    case "is_hungry": { ((Tiger)(obj)).is_hungry = Convert.ToBoolean(value); break; }
                }
            };
            parser.EndTag += (tag_name) =>
                {
                    if (tag_name == "bobcat" || tag_name == "tiger")
                    {
                        lst.Add(obj);
                    }
                };
            parser.start();
            sr.Close();
            fs.Close();
            return lst;
        }
    }
}

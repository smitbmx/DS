using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using Cats_lvl4.CatConverters;

namespace Cats_lvl4.DataStoreges
{
    public class DS_xml_dom : IDs
    {
        string path_to_file;

        public override bool Equals(object obj)
        {
            DS_xml_dom ds = obj as DS_xml_dom;
            if (this.path_to_file == ds.path_to_file)
            { return true; }
            else
            { return false; }
        }

        public string getPath()
        {
            return this.path_to_file;
        }
        
        public DS_xml_dom(string fName)
        {
            this.path_to_file = fName;
        }
        public void Save(List<Cat> cat_list)
        {
            Convert_cat_xml_dom conv = new Convert_cat_xml_dom();
            XmlDocument doc = conv.toXML(cat_list);
            XmlTextWriter xw = new XmlTextWriter(path_to_file, Encoding.UTF8);
            xw.Formatting = Formatting.Indented;
            doc.Save(xw);
            xw.Close();
        }
        public List<Cat> Load()
        {
            List<Cat> cat_list_out = new List<Cat>();
            FileStream fs = new FileStream(path_to_file, FileMode.OpenOrCreate);            
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            string buf;
            StringBuilder xml_string = new StringBuilder();
            while ((buf = sr.ReadLine()) != null)
            {
                xml_string.Append(buf);
            }            
            XmlDocument doc = new XmlDocument();             
            doc.LoadXml(xml_string.ToString());
            Convert_cat_xml_dom conv = new Convert_cat_xml_dom();
            foreach(XmlElement item in doc.DocumentElement.ChildNodes)
            {
                cat_list_out.Add(conv.fromNode(item));                
            }
            sr.Close();
            fs.Close();
            return cat_list_out;
        }
    }
}

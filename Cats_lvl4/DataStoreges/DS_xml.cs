using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;

namespace Cats_lvl4
{    
    public class DS_xml : IDs
    {
        string path_to_file;

        public override bool Equals(object obj)
        {
            DS_xml ds = obj as DS_xml;
            if (this.path_to_file == ds.path_to_file)
            { return true; }
            else
            { return false; }
        }

        public DS_xml(string fName)
        {
            this.path_to_file = fName;
        }
        public string getPath()
        {
            return this.path_to_file;
        }
        public void Save(List<Cat> cat_list)
        {
            FileStream fs = new FileStream(path_to_file, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sw.WriteLine("<content>");
            foreach (Cat item in cat_list)
            {
                sw.WriteLine(ConverterFactory.getInstance("xml", item).toStr(item));
            }
            sw.WriteLine("</content>");
            sw.Close();
            fs.Close();
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
            string trim_xml_string = xml_string.ToString().Trim().Replace("\t", "");
            Regex xmlHeader = new Regex("^<\\?xml version=\"1.0\" encoding=\"UTF-8\"\\?>");
            Regex xmlRootStart = new Regex("^<content>");
            Regex xmlRootEnd = new Regex("</content>$");
            if (xmlHeader.IsMatch(trim_xml_string)) { trim_xml_string = xmlHeader.Replace(trim_xml_string, String.Empty); }
            else { throw new FormatException("Неверный заголовок xml файла"); }
            if (xmlRootStart.IsMatch(trim_xml_string) && xmlRootEnd.IsMatch(trim_xml_string))
            {
                trim_xml_string = xmlRootStart.Replace(trim_xml_string, String.Empty);
                trim_xml_string = xmlRootEnd.Replace(trim_xml_string, String.Empty);
            }
            else { throw new FormatException("Неверный корень xml файла"); }
            Regex xmlCatObj = new Regex(@"<([a-zA-Z]+)>(.*?)</[a-zA-Z]+>"); 
            foreach (Match match in xmlCatObj.Matches(trim_xml_string))
            {   
                cat_list_out.Add(ConverterFactory.getInstance("xml", match.Value).fromStr(match.Value));                
            }
            sr.Close();
            fs.Close();
            return cat_list_out;
        }
    }
}

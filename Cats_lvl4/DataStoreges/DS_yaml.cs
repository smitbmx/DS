using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Cats_lvl4
{
    public class DS_yaml: IDs
    {
        string path_to_file;
        public override bool Equals(object obj)
        {
            DS_yaml ds = obj as DS_yaml;
            if (this.path_to_file == ds.path_to_file)
            { return true; }
            else
            { return false; }
        }
        public DS_yaml(string fName)
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
            foreach (Cat item in cat_list)
            {
                sw.WriteLine(ConverterFactory.getInstance("yaml", item).toStr(item));
            }
            sw.Close();
            fs.Close();
        }
        public List<Cat> Load()
        {
            List<Cat> cat_list_out = new List<Cat>();
            FileStream fs = new FileStream(path_to_file, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            string buf;
            StringBuilder yaml_string = new StringBuilder();
            while ((buf = sr.ReadLine()) != null)
            {
                yaml_string.Append(buf);
            }
            string trim_yaml_string = yaml_string.ToString().Trim().Replace("\t", String.Empty)
                                                                   .Replace(" ", String.Empty)
                                                                   .Replace("\"", String.Empty);
            Regex yamlCatObj = new Regex(@"-ClassObject_[a-zA-Z]+:(-.*?)---");
            foreach (Match match in yamlCatObj.Matches(trim_yaml_string))
            {
                cat_list_out.Add(ConverterFactory.getInstance("yaml", match.Value).fromStr(match.Value));
            }
            sr.Close();
            fs.Close();
            return cat_list_out;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Cats_lvl4
{
    public class DS_json: IDs
    {
        string path_to_file;
        public override bool Equals(object obj)
        {
            DS_json ds = obj as DS_json;
            if (this.path_to_file == ds.path_to_file)
            { return true; }
            else
            { return false; }
        }
        public DS_json(string fName)
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
            sw.WriteLine("[");
            for (int i = 0; i < cat_list.Count - 1; i++)
            {
                sw.WriteLine(ConverterFactory.getInstance("json", cat_list[i]).toStr(cat_list[i]) + ",");
            }
            if (cat_list.Count != 0)
            {
                sw.WriteLine(ConverterFactory.getInstance("json", cat_list[cat_list.Count - 1]).toStr(cat_list[cat_list.Count - 1]));
            }
            sw.WriteLine("]");
            sw.Close();
            fs.Close();
        }
        public List<Cat> Load()
        {
            List<Cat> cat_list_out = new List<Cat>();
            FileStream fs = new FileStream(path_to_file, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            string buf;
            StringBuilder json_string = new StringBuilder();
            while ((buf = sr.ReadLine()) != null)
            {
                json_string.Append(buf);
            }
            string trim_json_string = json_string.ToString().Trim().Replace("\t", String.Empty).Replace(" ", String.Empty);           
            Regex jsonRoot = new Regex(@"^(\[).*(\])");                        
            if (jsonRoot.IsMatch(trim_json_string))
            {
                trim_json_string = trim_json_string.TrimStart('[').TrimStart(']');                
            }
            else { throw new FormatException("Неверный  формат json файла"); }
            Regex jsonCatObj = new Regex(@"{(""[a-zA-Z]+""):\[(.*?)\]}");  
            foreach (Match match in jsonCatObj.Matches(trim_json_string))
            {
                cat_list_out.Add(ConverterFactory.getInstance("json", match.Value).fromStr(match.Value));
            }
            sr.Close();
            fs.Close();
            return cat_list_out;
        }
    }
}

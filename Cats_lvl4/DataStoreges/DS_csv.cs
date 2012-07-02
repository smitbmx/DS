using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Cats_lvl4
{
    public class DS_csv:IDs
    {
        string path_to_file;
        public override bool Equals(object obj)
        {
            DS_csv ds = obj as DS_csv;
            if (this.path_to_file == ds.path_to_file)
            { return true; }
            else
            { return false; }
        }
        public DS_csv(string fName)
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
                sw.WriteLine(ConverterFactory.getInstance("csv", item).toStr(item));
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
            while ((buf = sr.ReadLine()) != null)
            {
                cat_list_out.Add(ConverterFactory.getInstance("csv", buf).fromStr(buf));
            }
            sr.Close();
            fs.Close();
            return cat_list_out;
        }
    }
}

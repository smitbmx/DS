using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cats_lvl4
{
    class Convert_cat_xml:IConverter_custom
    {
        public Cat item=null;
        public Convert_cat_xml(Cat item)
        {
            this.item = item;
        }
        public Convert_cat_xml() { ;}
        public Cat fromStr(string str)
        {
            Regex fieldValue = new Regex("value=\"\\S+\"");
            var variables = fieldValue.Matches(str);
            item.name = variables[0].Value.Replace("value=", "").Replace("\"", "");
            item.age = Convert.ToInt32(variables[1].Value.Replace("value=", "").Replace("\"", ""));
            item.weight = Convert.ToSingle(variables[2].Value.Replace("value=", "").Replace("\"", ""));
            return item;
        }

        public string toStr(Cat item)
        {
            return String.Format("\t\t<name type=\"string\" value=\"{0}\" />\r\n\t\t" +
                                 "<age type=\"int\" value=\"{1}\" />\r\n\t\t" +
                                 "<weight type=\"float\" value=\"{2}\" />\r\n\t\t",
                                 item.name, item.age.ToString(), item.weight.ToString());
        }
    }
}

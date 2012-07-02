using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cats_lvl4.BobcatConverters
{
    class Convert_bobcat_xml:IConverter_custom
    {
        public Cat fromStr(string str)
        {
            Cat obj = null;
            Regex fieldValue = new Regex("value=\"\\S+\"");
            obj = (new Convert_cat_xml(new Bobcat())).fromStr(str);
            var variables = fieldValue.Matches(str);
            ((Bobcat)obj).hear_count = Convert.ToInt64(variables[3].Value.Replace("value=", "").Replace("\"", ""));
            ((Bobcat)obj).cat_type = variables[4].Value.Replace("value=", "").Replace("\"", "");
            return obj;
        }

        public string toStr(Cat item)
        {
            Bobcat obj = item as Bobcat;
            return String.Format("\t<bobcat>\r\n{0}<hear_count type=\"long\" value=\"{1}\" />\r\n\t\t<cat_type type=\"string\" value=\"{2}\" />\r\n\t</bobcat>",
                (new Convert_cat_xml()).toStr(item), obj.hear_count, obj.cat_type);
        }
    }
}

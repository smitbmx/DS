using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cats_lvl4.TigerConverters
{
    class Convert_tiger_xml:IConverter_custom
    {
        public Cat fromStr(string str)
        {
            Cat obj = null;
            obj = (new Convert_cat_xml(new Tiger())).fromStr(str);
            Regex fieldValue = new Regex("value=\"\\S+\"");
            var variables = fieldValue.Matches(str);
            ((Tiger)obj).location = variables[3].Value.Replace("value=", "").Replace("\"", "");
            ((Tiger)obj).color = variables[4].Value.Replace("value=", "").Replace("\"", "");
            ((Tiger)obj).height = Convert.ToSingle(variables[5].Value.Replace("value=", "").Replace("\"", ""));
            ((Tiger)obj).is_hungry = Convert.ToBoolean(variables[6].Value.Replace("value=", "").Replace("\"", ""));
            return obj;
        }

        public string toStr(Cat item)
        {
            Tiger obj = item as Tiger;
            return String.Format("\t<tiger>\r\n{0}" +
                                            "<location type=\"string\" value=\"{1}\" />\r\n\t\t" +
                                            "<color type=\"string\" value=\"{2}\" />\r\n\t\t" +
                                            "<height type=\"float\" value=\"{3}\" />\r\n\t\t" +
                                            "<is_hungry type=\"bool\" value=\"{4}\" />\r\n\t" +
                                          "</tiger>", (new Convert_cat_xml()).toStr(item), obj.location, obj.color, obj.height.ToString(), obj.is_hungry.ToString());
        }
    }
}

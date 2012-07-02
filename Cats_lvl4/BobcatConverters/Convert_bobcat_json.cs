using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cats_lvl4.BobcatConverters
{
    class Convert_bobcat_json:IConverter_custom
    {
        public Cat fromStr(string str)
        {
            Cat obj = null;
            Regex fieldValue = new Regex(@":""(\S+?)""}");
            obj = (new Convert_cat_json(new Bobcat())).fromStr(str);
            var variables = fieldValue.Matches(str);
            ((Bobcat)obj).hear_count = Convert.ToInt64(variables[3].Groups[1].Value);
            ((Bobcat)obj).cat_type = variables[4].Groups[1].Value;            
            return obj;
        }

        public string toStr(Cat item)
        {
            Bobcat obj = item as Bobcat;
            return String.Format("\t{{\"bobcat\": [\r\n{0}" +
                                    "\t\t{{\"hear_count\": \"{1}\"}},\r\n"+
                                    "\t\t{{\"cat_type\": \"{2}\"}}\r\n"+
                                 "\t]}}",
                (new Convert_cat_json()).toStr(item), obj.hear_count, obj.cat_type);
        }
    }
}

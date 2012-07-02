using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cats_lvl4.BobcatConverters
{
    class Convert_bobcat_yaml:IConverter_custom
    {
        public Cat fromStr(string str)
        {
            Cat obj = null;
            Regex fieldValue = new Regex(@"-[a-zA-Z_]+:([а-яА-Я]+|[0-9]+[.,]*[0-9]*|[A-Za-z]+)");
            obj = (new Convert_cat_yaml(new Bobcat())).fromStr(str);
            var variables = fieldValue.Matches(str);
            ((Bobcat)obj).hear_count = Convert.ToInt64(variables[3].Groups[1].Value);
            ((Bobcat)obj).cat_type = variables[4].Groups[1].Value;
            return obj;
        }

        public string toStr(Cat item)
        {
            Bobcat obj = item as Bobcat;
            return String.Format("- ClassObject_bobcat:\r\n{0}" +
                                    "  - hear_count: \"{1}\"\r\n" +
                                    "  - cat_type: {2}\r\n---",
                (new Convert_cat_yaml()).toStr(item), obj.hear_count, obj.cat_type);
        }
    }
}

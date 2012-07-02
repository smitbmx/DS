using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cats_lvl4.TigerConverters
{
    class Convert_tiger_yaml:IConverter_custom
    {
        public Cat fromStr(string str)
        {
            Cat obj = null;
            Regex fieldValue = new Regex(@"-[a-zA-Z_]+:([а-яА-Я]+|[0-9]+[.,]*[0-9]*|[A-Za-z]+)");
            obj = (new Convert_cat_yaml(new Tiger())).fromStr(str);
            var variables = fieldValue.Matches(str);
            ((Tiger)obj).location = variables[3].Groups[1].Value;
            ((Tiger)obj).color = variables[4].Groups[1].Value;
            ((Tiger)obj).height = Convert.ToSingle(variables[5].Groups[1].Value);
            ((Tiger)obj).is_hungry = Convert.ToBoolean(variables[6].Groups[1].Value);
            return obj;          
        }

        public string toStr(Cat item)
        {
            Tiger obj = item as Tiger;
            return String.Format("- ClassObject_tiger:\r\n{0}" +
                                    "  - location: {1}\r\n" +
                                    "  - color: {2}\r\n" +
                                    "  - height: \"{3}\"\r\n" +
                                    "  - is_hungry: \"{4}\"\r\n---", 
                                            (new Convert_cat_yaml()).toStr(item),
                                            obj.location, obj.color,
                                            obj.height.ToString(),
                                            obj.is_hungry.ToString());
        }
    }
}

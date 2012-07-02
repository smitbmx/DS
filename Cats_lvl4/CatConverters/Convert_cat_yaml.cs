using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cats_lvl4
{
    class Convert_cat_yaml:IConverter_custom
    {
        public Cat item = null;
        public Convert_cat_yaml(Cat item)
        {
            this.item = item;
        }
        public Convert_cat_yaml() { ;}
        public Cat fromStr(string str)
        {
            Regex fieldValue = new Regex(@"-[a-zA-Z_]+:([а-яА-Я]+|[0-9]+[.,]*[0-9]*|[A-Za-z]+)");
            var variables = fieldValue.Matches(str);
            item.name = variables[0].Groups[1].Value;
            item.age = Convert.ToInt32(variables[1].Groups[1].Value);
            item.weight = Convert.ToSingle(variables[2].Groups[1].Value);
            return item;
        }

        public string toStr(Cat item)
        {
            return String.Format("  - name: {0}\r\n" +
                                 "  - age: \"{1}\"\r\n" +
                                 "  - weight: \"{2}\"\r\n",
                                 item.name, item.age.ToString(), item.weight.ToString());
        }
    }
}

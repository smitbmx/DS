using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cats_lvl4.BobcatConverters
{
    class Convert_bobcat_csv:IConverter_custom
    {
        public Cat fromStr(string str)
        {
            Cat obj = null;
            Regex bobcatStringObj = new Regex("^bobcat; ([А-Яа-я]+); ([0-9]+); ([0-9][.,][0-9]+); ([0-9]+); ([А-Яа-я]+)$");
            if (!bobcatStringObj.IsMatch(str)) { throw new ArgumentException("Не правильный формат строки в CSV файле"); }
            string[] obj_fields = str.Split(';');
            obj = (new Convert_cat_csv(new Bobcat())).fromStr(str);
            if (bobcatStringObj.IsMatch(str))
            {
                ((Bobcat)obj).hear_count = Convert.ToInt64(obj_fields[4].Trim());
                ((Bobcat)obj).cat_type = obj_fields[5].Trim();
            }
            else
            {
                throw new ArgumentException("Не правильный формат строки в CSV файле");
            }
            return obj;
        }

        public string toStr(Cat item)
        {
            Bobcat obj = item as Bobcat;
            return String.Format("bobcat; {0} {1}; {2}", (new Convert_cat_csv()).toStr(item), obj.hear_count.ToString(), obj.cat_type);            
        }
    }
}

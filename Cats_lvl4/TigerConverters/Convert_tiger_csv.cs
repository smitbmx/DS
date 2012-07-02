using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cats_lvl4.TigerConverters
{
    class Convert_tiger_csv:IConverter_custom
    {
        public Cat fromStr(string str)
        {
            Cat obj = null;
            Regex tigerStringObj = new Regex("^tiger; ([А-Яа-я]+); ([0-9]+); ([0-9]+[,.][0-9]+); [А-Яа-я]+; [А-Яа-я]+; ([0-9]+[,.][0-9]+); (False|True);$");
            if (!tigerStringObj.IsMatch(str)) { throw new ArgumentException("Не правильный формат строки в CSV файле"); }
            string[] obj_fields = str.Split(';');
            obj = (new Convert_cat_csv(new Tiger())).fromStr(str);
            ((Tiger)obj).location = obj_fields[4].Trim();
            ((Tiger)obj).color = obj_fields[5].Trim();
            ((Tiger)obj).height = Convert.ToSingle(obj_fields[6].Trim());
            ((Tiger)obj).is_hungry = Convert.ToBoolean(obj_fields[7].Trim());
            return obj;
        }

        public string toStr(Cat item)
        {
            Tiger obj = item as Tiger;
            return String.Format("tiger; {0} {1}; {2}; {3}; {4};", (new Convert_cat_csv()).toStr(item), obj.location, obj.color, obj.height.ToString(), obj.is_hungry.ToString());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cats_lvl4
{
    class Convert_cat_csv: IConverter_custom
    {
        public Cat item=null;
        public Convert_cat_csv(Cat item)
        {
            this.item = item;
        }
        public Convert_cat_csv() { ;}
        public Cat fromStr(string str)
        {                
            string[] obj_fields = str.Split(';');
            item.name = obj_fields[1].Trim();
            item.age = Convert.ToInt32(obj_fields[2].Trim());
            item.weight = Convert.ToSingle(obj_fields[3].Trim());
            return item;
        }

        public string toStr(Cat item)
        {
            return String.Format("{0}; {1}; {2};", item.name, item.age.ToString(), item.weight.ToString());
        }
    }
}

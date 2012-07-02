using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Cats_lvl4
{
    public class CatCollection
    {
        public List<Cat> cat_list = new List<Cat>();
                
        public void Serialize(string path_to_file)
        {
            DsFactory.getInstance(path_to_file).Save(cat_list);
        }

        public void DeSerialize(string path_to_file)
        {
            cat_list = DsFactory.getInstance(path_to_file).Load();            
        }

        public List<Cat> SortCatList()
        {
            this.cat_list.Sort(delegate(Cat n1, Cat n2) { return n1.getWeight().CompareTo(n2.getWeight()); });
            return cat_list;
        }
    }
}

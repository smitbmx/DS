using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cats_lvl4.DataStoreges
{
    public class DS_Mock : IDs
    {
        List<Cat> cat_list = new List<Cat>();
        string path_to_file;
        public DS_Mock(string fName)
        {
            this.path_to_file = fName;
        }

        public string getPath()
        {
            return this.path_to_file;
        }

        public void Save(List<Cat> cat_list)
        {            
            this.cat_list = cat_list;            
        }
        public List<Cat> Load()
        {
            return this.cat_list;
        }
    }
}

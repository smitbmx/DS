using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cats_lvl4
{
    public interface IDs
    {
        void Save(List<Cat> cats_list);
        List<Cat> Load();
        string getPath();
    }
}

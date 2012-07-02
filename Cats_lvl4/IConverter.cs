using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cats_lvl4
{
    interface IConverter_custom
    {
        Cat fromStr(string str);
        string toStr(Cat obj);
    }
}

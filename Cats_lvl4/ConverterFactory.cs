using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cats_lvl4.BobcatConverters;
using Cats_lvl4.TigerConverters;

namespace Cats_lvl4
{
    class ConverterFactory
    {
        static IConverter_custom[,] converter_collection = new IConverter_custom[,]{{new Convert_bobcat_csv(), new Convert_tiger_csv()},
                                                                                    {new Convert_bobcat_xml(), new Convert_tiger_xml()},
                                                                                    {new Convert_bobcat_json(), new Convert_tiger_json()},
                                                                                    {new Convert_bobcat_yaml(), new Convert_tiger_yaml()}};

        public static IConverter_custom getInstance(string format, object item)
        {            
            int j = -1;
            if (item is Bobcat) { j = 0; }
            else if (item is Tiger) { j = 1; }
            else if ((item is string) && (((string)(item)).Contains("bobcat"))) { j = 0; }
            else if ((item is string) && (((string)(item)).Contains("tiger"))) { j = 1; }
            int i = -1;
            switch (format)
            {
                case "csv": { i = 0; break; }
                case "xml": { i = 1; break; }
                case "json": { i = 2; break; }
                case "yaml": { i = 3; break; }
            }
            return converter_collection[i, j];
        }
    }
}

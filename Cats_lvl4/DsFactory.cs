using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cats_lvl4.DataStoreges;

namespace Cats_lvl4
{
    public class DsFactory
    {
        static IDs[] storage_collection = new IDs[7];

        public static IDs getInstance(string fName)
        {
            IDs obj = null;            
            switch (fName.Split('.')[1])
            {
                case "csv":
                    {
                        if (storage_collection[0] == null) { storage_collection[0] = new DS_csv(fName); }
                        obj = storage_collection[0];
                        break;
                    }
                case "xml":
                    {
                        if (storage_collection[1] == null) { storage_collection[1] = new DS_xml(fName); }
                        obj = storage_collection[1];
                        break;
                    }
                case "dxml":
                    {
                        if (storage_collection[2] == null) { storage_collection[2] = new DS_xml_dom(fName); }
                        obj = storage_collection[2];
                        break;
                    }               
                case "json":
                    {
                        if (storage_collection[3] == null) { storage_collection[3] = new DS_json(fName); }
                        obj = storage_collection[3];
                        break;
                    }
                case "yaml":
                    {
                        if (storage_collection[4] == null) { storage_collection[4] = new DS_yaml(fName); }
                        obj = storage_collection[4];
                        break;
                    }
                case "ddxml":
                    {
                        if (storage_collection[5] == null) { storage_collection[5] = new DS_xml_dom_2(fName); }
                        obj = storage_collection[5];
                        break;
                    }
                case "sxml":
                    {
                        if (storage_collection[6] == null) { storage_collection[6] = new DS_xml_sax(fName); }
                        obj = storage_collection[6];
                        break;
                    }
            }            
            return obj;
        }
    }
}

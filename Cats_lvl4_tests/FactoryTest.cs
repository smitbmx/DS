using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Cats_lvl4;
using System.IO;
using Cats_lvl4.DataStoreges;

namespace Cats_lvl4_tests
{
    [TestFixture]
    public class FactoryTest
    {
        static string file_path = Settings.TestFilePath;
        static public object[] ds_factory = { new object[] {file_path+ "cats.csv", new DS_csv(file_path+"cats.csv") },
                                           new object[] {file_path+ "cats.xml", new DS_xml(file_path+"cats.xml")},
                                           new object[] { file_path+"cats.sxml", new DS_xml_sax(file_path+"cats.sxml")},
                                           new object[] { file_path+"cats.dxml", new DS_xml_dom(file_path+"cats.dxml")},
                                           new object[] { file_path+"cats.ddxml", new DS_xml_dom_2(file_path+"cats.ddxml")},
                                           new object[] { file_path+"cats.json", new DS_json(file_path+"cats.json")},
                                           new object[] { file_path+"cats.yaml", new DS_yaml(file_path+"cats.yaml")}};

        [Test, TestCaseSource("ds_factory")]
        public void TestFactory(string fname, IDs ds)
        {
            Assert.AreEqual(DsFactory.getInstance(fname), ds);
        }

        [TestFixtureTearDown]
        public void CleanFiles()
        {
            File.Delete(file_path + "cats.csv");
            File.Delete(file_path + "cats.xml");
            File.Delete(file_path + "cats.json");
            File.Delete(file_path + "cats.yaml");
        }
    }
}

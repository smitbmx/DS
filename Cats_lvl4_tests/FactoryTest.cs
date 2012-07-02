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
        static public object[] ds_factory = { new object[] { "cats.csv", new DS_csv("cats.csv") },
                                           new object[] { "cats.xml", new DS_xml("cats.xml")},
                                           new object[] { "cats.sxml", new DS_xml_sax("cats.sxml")},
                                           new object[] { "cats.dxml", new DS_xml_dom("cats.dxml")},
                                           new object[] { "cats.ddxml", new DS_xml_dom_2("cats.ddxml")},
                                           new object[] { "cats.json", new DS_json("cats.json")},
                                           new object[] { "cats.yaml", new DS_yaml("cats.yaml")}};

        [Test, TestCaseSource("ds_factory")]
        public void TestFactory(string fname, IDs ds)
        {
            Assert.AreEqual(DsFactory.getInstance(fname), ds);
        }        
    }
}

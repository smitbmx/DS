using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Cats_lvl4;
using Cats_lvl4.DataStoreges;
using System.IO; 

namespace Cats_lvl4_tests
{   
    [TestFixture]
    public class DS_Storage_test
    {
        static string file_path = @"C:/BuildAgent/work/9839fd882d9d77f0/Cats_lvl4/bin/Debug/";     
        static List<Cat> result4 = new List<Cat>(){ new Bobcat(12345, "большой","том", 5, 4.5f), 
                new Bobcat(54321, "маленький","джой",6,3.2f), 
                new Tiger("Канада", "Серый", 2.2f, true,"рой",8,80.5f), 
                new Tiger("Африка", "Оранжевый", 2.2f, true, "мак", 10, 105.1f) };
        static List<Cat> result1 = new List<Cat>() { new Bobcat(12345, "большой", "том", 5, 4.5f) };
        static List<Cat> result0 = new List<Cat>();
        static public IDs[] ds = { new DS_csv(file_path + "ds_cats.csv"),
                                     new DS_xml(file_path + "ds_cats.xml"),
                                     new DS_xml_sax(file_path + "ds_cats.sxml"),
                                     new DS_xml_dom(file_path + "ds_cats.dxml"),
                                     new DS_xml_dom_2(file_path + "ds_cats.ddxml"),
                                     new DS_json(file_path + "ds_cats.json"),
                                     new DS_yaml(file_path + "ds_cats.yaml"),
                                     new DS_Mock(@"cats.txt")};

        static public object[] ds_load = { new object[] { file_path + "cats_0_ideal.", result0 },
                                               new object[]{ file_path + "cats_1_ideal.", result1 },
                                               new object[] { file_path + "cats_4_ideal.", result4 }};

        static public object[] ds_save = { new object[] { file_path + "cats_0.", file_path + "cats_0_ideal.", result0 },
                                               new object[]{ file_path + "cats_1.", file_path + "cats_1_ideal.", result1 },
                                               new object[] { file_path + "cats_4.", file_path + "cats_4_ideal.", result4 }};

                            
        [Test, TestCaseSource("ds")]
        public void ALL_storages_test(IDs ds)
        {            
            ds.Save(result0);
            Assert.AreEqual(ds.Load(),result0);
            ds.Save(result1);
            Assert.AreEqual(ds.Load(), result1);
            ds.Save(result4);            
        }

        [Test, TestCaseSource("ds_load")]
        public void DS_csv_load_test(string path, List<Cat> result)

        {
            Assert.AreEqual((new DS_csv(path + "csv")).Load(), result);           
        }

        [Test, TestCaseSource("ds_load")]
        public void DS_xml_load_test(string path, List<Cat> result)
        {
            Assert.AreEqual((new DS_xml(path + "xml")).Load(), result);
        }

        [Test, TestCaseSource("ds_load")]
        public void DS_xml_sax_load_test(string path, List<Cat> result)
        {
            Assert.AreEqual((new DS_xml_sax(path + "sxml")).Load(), result);
        }

        [Test, TestCaseSource("ds_load")]
        public void DS_xml_dom_load_test(string path, List<Cat> result)
        {
            Assert.AreEqual((new DS_xml_dom(path + "dxml")).Load(), result);
        }

        [Test, TestCaseSource("ds_load")]
        public void DS_xml_dom_2_load_test(string path, List<Cat> result)
        {
            Assert.AreEqual((new DS_xml_dom_2(path + "ddxml")).Load(), result);
        }

        [Test, TestCaseSource("ds_load")]
        public void DS_json_load_test(string path, List<Cat> result)
        {
            Assert.AreEqual((new DS_json(path + "json")).Load(), result);
        }

        [Test, TestCaseSource("ds_load")]
        public void DS_yaml_load_test(string path, List<Cat> result)
        {
            Assert.AreEqual((new DS_yaml(path + "yaml")).Load(), result);
        }

        [Test, TestCaseSource("ds_save")]
        public void DS_csv_save_test(string fsave, string fideal, List<Cat> result)
        {
            IDs ds = new DS_csv(fsave + "csv");
            ds.Save(result);
            Stream expectedStream = File.OpenRead(fsave + "csv");
            Stream actualStream = File.OpenRead(fideal + "csv");
            Assert.That(actualStream, Is.EqualTo(expectedStream));            
            expectedStream.Close();
            actualStream.Close();
        }

        [Test, TestCaseSource("ds_save")]
        public void DS_xml_save_test(string fsave, string fideal, List<Cat> result)
        {
            IDs ds = new DS_xml(fsave + "xml");
            ds.Save(result);
            Stream expectedStream = File.OpenRead(fsave + "xml");
            Stream actualStream = File.OpenRead(fideal + "xml");
            Assert.That(actualStream, Is.EqualTo(expectedStream));
            expectedStream.Close();
            actualStream.Close();
        }

        [Test, TestCaseSource("ds_save")]
        public void DS_xml_sax_save_test(string fsave, string fideal, List<Cat> result)
        {
            IDs ds = new DS_xml_sax(fsave + "sxml");
            ds.Save(result);
            Stream expectedStream = File.OpenRead(fsave + "sxml");
            Stream actualStream = File.OpenRead(fideal + "sxml");
            Assert.That(actualStream, Is.EqualTo(expectedStream));
            expectedStream.Close();
            actualStream.Close();
        }

        [Test, TestCaseSource("ds_save")]
        public void DS_xml_dom_save_test(string fsave, string fideal, List<Cat> result)
        {
            IDs ds = new DS_xml_dom(fsave + "dxml");
            ds.Save(result);
            Stream expectedStream = File.OpenRead(fsave + "dxml");
            Stream actualStream = File.OpenRead(fideal + "dxml");
            Assert.That(actualStream, Is.EqualTo(expectedStream));
            expectedStream.Close();
            actualStream.Close();
        }

        [Test, TestCaseSource("ds_save")]
        public void DS_xml_dom_2_save_test(string fsave, string fideal, List<Cat> result)
        {
            IDs ds = new DS_xml_dom_2(fsave + "ddxml");
            ds.Save(result);
            Stream expectedStream = File.OpenRead(fsave + "ddxml");
            Stream actualStream = File.OpenRead(fideal + "ddxml");
            Assert.That(actualStream, Is.EqualTo(expectedStream));
            expectedStream.Close();
            actualStream.Close();
        }

        [Test, TestCaseSource("ds_save")]
        public void DS_json_save_test(string fsave, string fideal, List<Cat> result)
        {
            IDs ds = new DS_json(fsave + "json");
            ds.Save(result);
            Stream expectedStream = File.OpenRead(fsave + "json");
            Stream actualStream = File.OpenRead(fideal + "json");
            Assert.That(actualStream, Is.EqualTo(expectedStream));
            expectedStream.Close();
            actualStream.Close();
        }

        [Test, TestCaseSource("ds_save")]
        public void DS_yaml_save_test(string fsave, string fideal, List<Cat> result)
        {
            IDs ds = new DS_yaml(fsave + "yaml");
            ds.Save(result);
            Stream expectedStream = File.OpenRead(fsave + "yaml");
            Stream actualStream = File.OpenRead(fideal + "yaml");
            Assert.That(actualStream, Is.EqualTo(expectedStream));
            expectedStream.Close();
            actualStream.Close();
        }

        [TestFixtureTearDown]
        public void CleanFiles()
        {
            File.Delete(file_path + "ds_cats.csv");
            File.Delete(file_path + "ds_cats.xml");
            File.Delete(file_path + "ds_cats.json");
            File.Delete(file_path + "ds_cats.yaml");
            File.Delete(file_path + "cats_0.csv");
            File.Delete(file_path + "cats_0.xml");
            File.Delete(file_path + "cats_0.dxml");
            File.Delete(file_path + "cats_0.ddxml");
            File.Delete(file_path + "cats_0.json");
            File.Delete(file_path + "cats_0.yaml");
            File.Delete(file_path + "cats_1.csv");
            File.Delete(file_path + "cats_1.xml");
            File.Delete(file_path + "cats_1.dxml");
            File.Delete(file_path + "cats_1.ddxml");
            File.Delete(file_path + "cats_1.json");
            File.Delete(file_path + "cats_1.yaml");
            File.Delete(file_path + "cats_4.csv");
            File.Delete(file_path + "cats_4.xml");
            File.Delete(file_path + "cats_4.dxml");
            File.Delete(file_path + "cats_4.ddxml");
            File.Delete(file_path + "cats_4.json");
            File.Delete(file_path + "cats_4.yaml");
        }
    }
}

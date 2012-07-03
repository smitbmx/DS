using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Cats_lvl4;
using Cats_lvl4.DataStoreges;
using System.IO;
using System.Reflection;

namespace Cats_lvl4_tests
{
    [TestFixture]
    class ParamTest
    {
        List<Cat> result4;
        List<Cat> result1;
        List<Cat> result0;
        static string file_path = Settings.TestFilePath;
        string path;
        static public IDs[] ds0 = { new DS_csv(file_path + "cats_0_ideal.csv"),
                                     new DS_xml(file_path + "cats_0_ideal.xml"),
                                     new DS_xml_sax(file_path + "cats_0_ideal.sxml"),
                                     new DS_xml_dom(file_path + "cats_0_ideal.dxml"),
                                     new DS_xml_dom_2(file_path + "cats_0_ideal.ddxml"),
                                     new DS_json(file_path + "cats_0_ideal.json"),
                                     new DS_yaml(file_path + "cats_0_ideal.yaml")};
        static public IDs[] ds1 = { new DS_csv(file_path + "cats_1_ideal.csv"),
                                     new DS_xml(file_path + "cats_1_ideal.xml"),
                                     new DS_xml_sax(file_path + "cats_1_ideal.sxml"),
                                     new DS_xml_dom(file_path + "cats_1_ideal.dxml"),
                                     new DS_xml_dom_2(file_path + "cats_1_ideal.ddxml"),
                                     new DS_json(file_path + "cats_1_ideal.json"),
                                     new DS_yaml(file_path + "cats_1_ideal.yaml")};
        static public IDs[] ds4 = { new DS_csv(file_path + "cats_4_ideal.csv"),
                                     new DS_xml(file_path + "cats_4_ideal.xml"),
                                     new DS_xml_sax(file_path + "cats_4_ideal.sxml"),
                                     new DS_xml_dom(file_path + "cats_4_ideal.dxml"),
                                     new DS_xml_dom_2(file_path + "cats_4_ideal.ddxml"),
                                     new DS_json(file_path + "cats_4_ideal.json"),
                                     new DS_yaml(file_path + "cats_4_ideal.yaml")};

        static public IDs[] ds0_save = { new DS_csv(file_path + "cats_0.csv"),
                                     new DS_xml(file_path + "cats_0.xml"),
                                     new DS_xml_sax(file_path + "cats_0.sxml"),
                                     new DS_xml_dom(file_path + "cats_0.dxml"),
                                     new DS_xml_dom_2(file_path + "cats_0.ddxml"),
                                     new DS_json(file_path + "cats_0.json"),
                                     new DS_yaml(file_path + "cats_0.yaml")};
        static public IDs[] ds1_save = { new DS_csv(file_path + "cats_1.csv"),
                                     new DS_xml(file_path + "cats_1.xml"),
                                     //new DS_xml_sax(file_path + "cats_1.sxml"),
                                     new DS_xml_dom(file_path + "cats_1.dxml"),
                                     new DS_xml_dom_2(file_path + "cats_1.ddxml"),
                                     new DS_json(file_path + "cats_1.json"),
                                     new DS_yaml(file_path + "cats_1.yaml")};
        static public IDs[] ds4_save = { new DS_csv(file_path + "cats_4.csv"),
                                     new DS_xml(file_path + "cats_4.xml"),
                                     //new DS_xml_sax(file_path + "cats_4.sxml"),
                                     new DS_xml_dom(file_path + "cats_4.dxml"),
                                     new DS_xml_dom_2(file_path + "cats_4.ddxml"),
                                     new DS_json(file_path + "cats_4.json"),
                                     new DS_yaml(file_path + "cats_4.yaml")};

        [SetUp]
        public void SetUp()
        {
            //this.path = @"C:/BuildAgent/work/9839fd882d9d77f0/Cats_lvl4/bin/Debug/";
            this.path = Settings.TestFilePath;
            result4 = new List<Cat>(){ new Bobcat(12345, "большой","том", 5, 4.5f), 
                new Bobcat(54321, "маленький","джой",6,3.2f), 
                new Tiger("Канада", "Серый", 2.2f, true,"рой",8,80.5f), 
                new Tiger("Африка", "Оранжевый", 2.2f, true, "мак", 10, 105.1f) };
            result1 = new List<Cat>() { new Bobcat(12345, "большой", "том", 5, 4.5f) };
            result0 = new List<Cat>();
        }

        [Test, TestCaseSource("ds0")]
        public void NullItemTestLoad(IDs ds)
        {
            Assert.AreEqual(ds.Load(), result0);
        }

        [Test, TestCaseSource("ds1")]
        public void OneItemTestLoad(IDs ds)
        {
            Assert.AreEqual(ds.Load(), result1);
        }

        [Test, TestCaseSource("ds4")]
        public void ManyItemTestLoad(IDs ds)
        {
            Assert.AreEqual(ds.Load(), result4);
        }

        [Test, TestCaseSource("ds0_save")]
        public void NullItemTestSave(IDs ds)
        {
            ds.Save(result0);
            Stream expectedStream = File.OpenRead(ds.getPath());
            string ext = ds.getPath().Split('.')[1];
            Stream actualStream = File.OpenRead(this.path + "cats_0_ideal." + ext);
            Assert.That(actualStream, Is.EqualTo(expectedStream));
        }

        [Test, TestCaseSource("ds1_save")]
        public void OneItemTestSave(IDs ds)
        {
            ds.Save(result1);
            Stream expectedStream = File.OpenRead(ds.getPath());
            string ext = ds.getPath().Split('.')[1];
            Stream actualStream = File.OpenRead(this.path + "cats_1_ideal." + ext);
            Assert.That(actualStream, Is.EqualTo(expectedStream));
        }

        [Test, TestCaseSource("ds4_save")]
        public void ManyItemTestSave(IDs ds)
        {
            ds.Save(result4);
            Stream expectedStream = File.OpenRead(ds.getPath());
            string ext = ds.getPath().Split('.')[1];
            Stream actualStream = File.OpenRead(this.path + "cats_4_ideal." + ext);
            Assert.That(actualStream, Is.EqualTo(expectedStream));
        }

        [TestFixtureTearDown]
        public void CleanFiles()
        {
            File.Delete(file_path + "cats_0.csv");
            File.Delete(file_path + "cats_0.xml");
            File.Delete(file_path + "cats_0.sxml");
            File.Delete(file_path + "cats_0.dxml");
            File.Delete(file_path + "cats_0.ddxml");
            File.Delete(file_path + "cats_0.json");
            File.Delete(file_path + "cats_0.yaml");
            File.Delete(file_path + "cats_1.csv");
            File.Delete(file_path + "cats_1.xml");
            File.Delete(file_path + "cats_1.sxml");
            File.Delete(file_path + "cats_1.dxml");
            File.Delete(file_path + "cats_1.ddxml");
            File.Delete(file_path + "cats_1.json");
            File.Delete(file_path + "cats_1.yaml");
            File.Delete(file_path + "cats_4.csv");
            File.Delete(file_path + "cats_4.xml");
            File.Delete(file_path + "cats_4.sxml");
            File.Delete(file_path + "cats_4.dxml");
            File.Delete(file_path + "cats_4.ddxml");
            File.Delete(file_path + "cats_4.json");
            File.Delete(file_path + "cats_4.yaml");
        }
    }
}

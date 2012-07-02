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
    public class MainTest
    {
        string path;
        Cat[] cat_list;
        List<Cat> result;
        [TestFixtureSetUp]
        public void SetCollection()
        {
            this.path = @"C:/BuildAgent/work/9839fd882d9d77f0/Cats_lvl4/bin/Debug/"; 
            cat_list = new Cat[] { new Bobcat(12345, "большой","том", 5, 4.5f), 
                new Bobcat(54321, "маленький","джой",6,3.2f), 
                new Tiger("Канада", "Серый", 2.2f, true,"рой",8,80.5f), 
                new Tiger("Африка", "Оранжевый", 2.2f, true, "мак", 10, 105.1f) };
            result = new List<Cat>();
            result.AddRange(cat_list);
        }

        [Test]
        public void TestMOCK()
        {
            DS_Mock ds_MOCK = new DS_Mock(this.path + "cats.txt");
            ds_MOCK.Save(result);
            List<Cat> load_lst = ds_MOCK.Load();
            Assert.AreEqual(load_lst, result);
        }

        [Test]
        public void TestYAML()
        {
            CatCollection cl = new CatCollection();
            cl.cat_list.AddRange(cat_list);
            cl.Serialize(this.path + "cats.yaml");
            cl.DeSerialize(this.path + "cats.yaml");
            Assert.AreEqual(cl.cat_list, result);
        }

        [Test]
        public void TestJSON()
        {
            CatCollection cl = new CatCollection();
            cl.cat_list.AddRange(cat_list);
            cl.Serialize(this.path + "cats.json");
            cl.DeSerialize(this.path + "cats.json");
            Assert.AreEqual(cl.cat_list, result);
        }

        [Test]
        public void TestXML()
        {
            CatCollection cl = new CatCollection();
            cl.cat_list.AddRange(cat_list);
            cl.Serialize(this.path + "cats.xml");
            cl.DeSerialize(this.path + "cats.xml");
            Assert.AreEqual(cl.cat_list, result);
        }

        [Test]
        public void TestCSV()
        {
            CatCollection cl = new CatCollection();
            cl.cat_list.AddRange(cat_list);
            cl.Serialize(this.path + "cats.csv");
            cl.DeSerialize(this.path + "cats.csv");
            Assert.AreEqual(cl.cat_list, result);
        }

        [TestFixtureTearDown]
        public void CleanFiles()
        {
            File.Delete(this.path + "cats.csv");
            File.Delete(this.path + "cats.xml");
            File.Delete(this.path + "cats.json");
            File.Delete(this.path + "cats.yaml");            
        }
    }
}

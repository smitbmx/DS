using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cats_lvl4
{
    [System.Xml.Serialization.XmlInclude(typeof(Bobcat))]
    [System.Xml.Serialization.XmlInclude(typeof(Tiger))]
    abstract public class Cat
    {
        public string name;
        public int age;
        public float weight;
        public Cat() { ;}
        public Cat(string name, int age, float weight)
        {
            this.age = age;
            this.name = name;
            this.weight = weight;
        }
        abstract public float getWeight();        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Cats_lvl4.CatConverters
{
    class Convert_cat_xml_dom
    {                
        public Convert_cat_xml_dom() { ;}
        public Cat fromNode(XmlNode node)
        {
            Cat obj = null;
            if (node.Name == "bobcat")
            {
                obj = new Bobcat();
                ((Bobcat)obj).hear_count = Convert.ToInt64(node.Attributes[0].Value);
                ((Bobcat)obj).cat_type = node.Attributes[1].Value;
                obj.age = Convert.ToInt32(node.Attributes[3].Value);
                obj.name = node.Attributes[2].Value;
                obj.weight = Convert.ToSingle(node.Attributes[4].Value);
            }
            if (node.Name == "tiger")
            {
                obj = new Tiger();
                ((Tiger)obj).location = node.Attributes[0].Value;
                ((Tiger)obj).color = node.Attributes[1].Value;
                ((Tiger)obj).height = Convert.ToSingle(node.Attributes[2].Value);
                ((Tiger)obj).is_hungry = Convert.ToBoolean(node.Attributes[3].Value);
                obj.age = Convert.ToInt32(node.Attributes[5].Value);
                obj.name = node.Attributes[4].Value;
                obj.weight = Convert.ToSingle(node.Attributes[6].Value);
            }           
            return obj;
        }

        public XmlDocument toXML(List<Cat> cat_list)
        {            
            XmlDocument doc = new XmlDocument();
            XmlElement root = doc.CreateElement("content");
            foreach(Cat item in cat_list)
            {
                XmlElement element = doc.CreateElement("cat");
                if (item is Bobcat)
                {
                    element = doc.CreateElement("bobcat");
                    Bobcat obj = item as Bobcat;
                    element.SetAttribute("hear_count",obj.hear_count.ToString());
                    element.SetAttribute("cat_type",obj.cat_type);
                }
                if (item is Tiger)
                {
                    element = doc.CreateElement("tiger");
                    Tiger obj = item as Tiger;
                    element.SetAttribute("location",obj.location);
                    element.SetAttribute("color",obj.color);
                    element.SetAttribute("height",obj.height.ToString());
                    element.SetAttribute("is_hungry",obj.is_hungry.ToString());
                }
                element.SetAttribute("name",item.name);
                element.SetAttribute("age",item.age.ToString());
                element.SetAttribute("weight",item.weight.ToString());
                root.AppendChild(element);
            }
            doc.AppendChild(root);
            return doc;            
        }
    }
}

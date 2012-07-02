using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cats_lvl4
{
    public class Tiger: Cat
    {
        public string location;
        public bool is_hungry;
        public string color;
        public float height;
        public Tiger(string loc, string color, float h, bool hungry, string name, int age, float weight)
            : base(name, age, weight)
        {
            location = loc;
            is_hungry = hungry;
            this.color = color;
            height = h;
        }

        public Tiger() : base() { ;}

        public override float getWeight()
        {
            return base.weight;
        }

        public override bool Equals(object obj)
        {
            Tiger tg = obj as Tiger;
            if ((tg.age == base.age) && (tg.name == base.name) && (tg.weight == base.weight) &&
                (tg.location == this.location) && (tg.color == this.color) && (tg.height == this.height) && (tg.is_hungry == this.is_hungry))
            { return true; }
            else 
            { return false; }
        }
    }
}

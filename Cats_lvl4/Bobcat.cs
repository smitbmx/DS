using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Cats_lvl4
{
    public class Bobcat:Cat
    {
        public long hear_count;
        public string cat_type;
        public Bobcat(long hear_count, string cat_type, string name, int age, float weight)
            : base(name, age, weight)
        {
            this.cat_type = cat_type;
            this.hear_count = hear_count;
        }

        public Bobcat() : base() { ;}

        public override float getWeight()
        {
            return base.weight;
        }

        public override bool Equals(object obj)
        {
            Bobcat bc = obj as Bobcat;
            if ((bc.age == base.age) && (bc.name == base.name) && (bc.weight == base.weight) &&
                (bc.cat_type == this.cat_type) && (bc.hear_count == this.hear_count))
            { return true; }
            else
            { return false; }
        }
    }
}

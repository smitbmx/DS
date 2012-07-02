using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Cats_lvl4
{
    public delegate void saxTagEventHandler(string str);
    public delegate void saxAtributeEventHandler(string name, string value);
    public class SAX_parser
    {
        StreamReader sr;
        public SAX_parser(StreamReader sr)
        {
            this.sr = sr;
        }
        public void start()
        {
            string buf = "";
            Regex xmlHeader = new Regex("^<\\?xml version=\"1.0\" encoding=\"UTF-8\"\\?>");
            Regex xmlCatObjStart = new Regex(@"<([a-zA-Z]+)>");
            Regex xmlCatObjEnd = new Regex(@"</([a-zA-Z]+)>");
            Regex fieldValue = new Regex(@"<([a-z_]+) type=""([a-z]+)"" value=""(\S+)""");
            while ((buf = sr.ReadLine()) != null)
            {
                //if (xmlHeader.IsMatch(buf)) { StartDocument(""); }
                MatchCollection mc = xmlCatObjStart.Matches(buf);
                if (mc.Count > 0) { StartTag(mc[0].Groups[1].Value); }
                mc = fieldValue.Matches(buf);
                if (mc.Count > 0) { Characters(mc[0].Groups[1].Value, mc[0].Groups[3].Value); }
                mc = xmlCatObjEnd.Matches(buf);
                if (mc.Count > 0) { EndTag(mc[0].Groups[1].Value); }
            }
            //EndDocument("");
        }
        public event saxTagEventHandler StartDocument;
        public event saxTagEventHandler StartTag;
        public event saxTagEventHandler EndTag;
        public event saxAtributeEventHandler Characters;
        public event saxTagEventHandler EndDocument;
    }
}

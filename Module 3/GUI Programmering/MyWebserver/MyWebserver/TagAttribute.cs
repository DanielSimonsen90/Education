using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebserver
{
    public class TagAttribute
    {
        public TagAttribute(string attribute, string value)
        {
            Attribute = attribute;
            Value = value;
        }

        public string Attribute { get; }
        public string Value { get; }
        public override string ToString() => $"{Attribute}={Value}";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    [AttributeUsage(AttributeTargets.Class)]
    public class StateAttribute : Attribute
    {
        private bool _label;

        public StateAttribute(bool label)
        {
            Label = label;
        }

        public bool Label
        {
            get { return _label; }
            set { _label = value; }
        }
    }
}

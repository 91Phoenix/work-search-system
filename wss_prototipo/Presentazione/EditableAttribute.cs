using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Presentazione
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EditableAttribute : Attribute
    {
        private string _label;
        private int _width = 100;

        public EditableAttribute(string label)
        {
            Label = label;
        }

        public string Label
        {
            get { return _label; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("String.IsNullOrEmpty(value)");
                _label = value;
            }
        }

        public int Width
        {
            get { return _width; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("value <= 0");
                _width = value;
            }
        }
    }
}

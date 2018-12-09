using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace WSS_Prototipo.Model
{ 
    static class CalcoloRequisitiFactory
    {
        private static readonly Dictionary<string, ICalcoloRequisiti> _dictionary = new Dictionary<string, ICalcoloRequisiti>();

        static CalcoloRequisitiFactory()
        {
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.GetInterface(typeof(ICalcoloRequisiti).Name) != null && !type.IsAbstract)
                {
                    Add((ICalcoloRequisiti)Activator.CreateInstance(type));
                }
            }
        }

        public static ICalcoloRequisiti GetCalcolo(string name)
        {
            if (!_dictionary.ContainsKey(name))
                throw new ArgumentException("!_dictionary.ContainsKey(nome)");
            return _dictionary[name];
        }
        public static IEnumerable<string> GetKeys()
        {
            return _dictionary.Keys;
        }
        public static IEnumerable<ICalcoloRequisiti> GetCalcoli()
        {
            return _dictionary.Values;
        }
        private static void Add(ICalcoloRequisiti calcolo)
        {
            if (calcolo == null)
                throw new ArgumentNullException("calcolo");
            if (_dictionary.ContainsKey(calcolo.GetType().Name))
                throw new ArgumentException("calcolo already exist");
            _dictionary.Add(calcolo.GetType().Name, calcolo);
        }
    }
    
}

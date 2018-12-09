using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace WSS_Prototipo.Model
{
    public static class TipologiaFactory
    {
        private static readonly Dictionary<string, ITipologia> _tipologie = new Dictionary<string, ITipologia>();
        private static readonly List<string> _nomeTipologie = new List<string>();

        static TipologiaFactory()
        {
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.GetInterface(typeof(ITipologia).Name) != null)
                {
                    _nomeTipologie.Add(type.Name);
                }
            }
            foreach (ModalitàDiConoscenza m in Enum.GetValues(typeof(ModalitàDiConoscenza)))
            {
                CreateModalitàDiConoscenzaAdapter(m);
            }

        }
        public static ITipologia GetTipologia(string name)
        {
            if(!_tipologie.ContainsKey(name))
            {
                throw new ArgumentException("tipologia inesistente");
            }
            return _tipologie[name];
        }
        public static IEnumerable<ITipologia> GetTipologie()
        {
            return _tipologie.Values;
        }
        public static IEnumerable<string> GetKeys()
        {
            return _tipologie.Keys;
        }

        public static IEnumerable<string> GetNomeTipologie()
        {
            return _nomeTipologie;
        }

        private static ITipologia CheckTipologia(string name)
        {
            List<ITipologia> tipologie = (from k in _tipologie select k.Value).Where(n => n.Name.ToLower().Equals(name.ToLower())).ToList();
            if (tipologie.Count == 0) return null;
            else return tipologie[0];
        }
        public static ITipologia CreateCategoria(string name)
        {
            ITipologia tipologia = CheckTipologia(name);
            if (tipologia == null)
            {
                tipologia = new Categoria(name);
                _tipologie.Add(name, tipologia);
                return tipologia;
            }
            else
                return tipologia;
        }
        public static ITipologia CreateLivelloDiIstruzione(string name)
        {
            ITipologia tipologia = CheckTipologia(name);
            if (tipologia == null)
            {
                tipologia = new LivelloDiIstruzione(name);
                _tipologie.Add(name, tipologia);
                return tipologia;
            }
            else
                return tipologia;
        }
        public static ITipologia CreateModalitàDiConoscenzaAdapter(ModalitàDiConoscenza modalitàDiConoscenza)
        {
            ITipologia tipologia = CheckTipologia(Enum.GetName(typeof(ModalitàDiConoscenza), modalitàDiConoscenza));
            if (tipologia == null)
            {
                tipologia = new ModalitàDiConoscenzaAdapter(modalitàDiConoscenza);
                _tipologie.Add(tipologia.Name, tipologia);
                return tipologia;
            }
            else
                return tipologia;
        }

        public class Categoria : ITipologia
        {
            private string _name;

            public Categoria(string name)
            {
                if (name == String.Empty) throw new ArgumentException("name is empty");
                _name = name;
            }

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            public override string ToString()
            {
                return String.Format("{0}", Name);
            } 
        }
        public class LivelloDiIstruzione : ITipologia
        {
            private string _name;

            public LivelloDiIstruzione(string name)
            {
                if (name == String.Empty) throw new ArgumentException("name is empty");
                _name = name;
            }

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            public override string ToString()
            {
                return String.Format("{0}", Name);
            } 
        }
        public class ModalitàDiConoscenzaAdapter : ITipologia
        {
            private ModalitàDiConoscenza _modalitàDiConoscenza;

            public ModalitàDiConoscenzaAdapter(ModalitàDiConoscenza modalitàDiConoscenza)
            {
                if (!Enum.IsDefined(typeof(ModalitàDiConoscenza), modalitàDiConoscenza)) throw new ArgumentNullException("modalità di conoscenza is bad");
                _modalitàDiConoscenza = modalitàDiConoscenza;
            }

            public string Name
            {
                get { return Enum.GetName(typeof(ModalitàDiConoscenza), _modalitàDiConoscenza); }
                set { _modalitàDiConoscenza = (ModalitàDiConoscenza) Enum.Parse(typeof(ModalitàDiConoscenza), value, true); }
            }

            public override string ToString()
            {
                return String.Format("{0}", Name);
            } 
        }
    }
}

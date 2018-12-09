using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace WSS_Prototipo.Model
{
    public static class RequisitoFactory
    {
        private static readonly Dictionary<Guid, IRequisito> _requisiti = new Dictionary<System.Guid, IRequisito>();
        private static readonly List<string> _nomeClassi = new List<string>();

        static RequisitoFactory()
        {
            foreach (Type ty in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (ty.GetInterface(typeof(IRequisito).Name) != null)
                {
                    _nomeClassi.Add(ty.Name);
                }
            }
        }

        public static IRequisito GetRequisito(Guid id)
        {
            if (!_requisiti.ContainsKey(id))
            {
                throw new ArgumentException("requisito inesistente");
            }
            return _requisiti[id];
        }

        public static IEnumerable<IRequisito> GetRequisiti()
        {
            return _requisiti.Values;
        }
        public static IEnumerable<string> GetNomeClassi()
        {
            return _nomeClassi;
        }

        private static IRequisito CheckRequisito(string name, ITipologia tipologia, string classe)
        {
            List<IRequisito> requisiti = (from k in _requisiti select k.Value).Where(r => r.Name.ToLower().Equals(name.ToLower()) && r.Tipologia == tipologia && r.Classe.Equals(classe)).ToList();
            if (requisiti.Count == 0) return null;
            else return requisiti[0];
        }

        public static Guid CreateRequisitoDiLingua(string name, ITipologia modalitàDiConoscenza)
        {
            IRequisito requisito = CheckRequisito(name, modalitàDiConoscenza, "Lingua");
            if (requisito == null)
            {
                Guid id = Guid.NewGuid();
                _requisiti.Add(id, new Lingua(id, name, modalitàDiConoscenza));
                return id;
            }
            else
                return requisito.Guid;
        }
        public static Guid CreateRequisitoDiFormazione(string name, ITipologia livelloDiIstruzione)
        {
            IRequisito requisito = CheckRequisito(name, livelloDiIstruzione, "Formazione");
            if (requisito == null)
            {
                Guid id = Guid.NewGuid();
                _requisiti.Add(id, new Formazione(id, name, livelloDiIstruzione));
                return id;
            }
            else
                return requisito.Guid;
        }
        public static Guid CreateRequisitoDiCompetenza(string name, ITipologia tipologia)
        {
            IRequisito requisito = CheckRequisito(name, tipologia, "Competenza");
            if (requisito == null)
            {
                Guid id = Guid.NewGuid();
                _requisiti.Add(id, new Competenza(id, name, tipologia));
                return id;
            }
            else
                return requisito.Guid;   
        }
        public static Guid CreateRequisitoDiEsperienza(string name, ITipologia tipologia)
        {
            IRequisito requisito = CheckRequisito(name, tipologia, "Esperienza");
            if (requisito == null)
            {
                Guid id = Guid.NewGuid();
                _requisiti.Add(id, new Esperienza(id, name, tipologia));
                return id;
            }
            else
                return requisito.Guid;   
        }

        #region Definizione delle sotto classi di IRequisito

        public class Lingua : IRequisito
        {
            private readonly string _classe;
            private string _name;
            private ITipologia _tipologia;
            private Guid _guid;

            public Lingua(Guid guid, string name, ITipologia tipologia)
            {
                if (guid == Guid.Empty) throw new ArgumentNullException("guid is empty");
                if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("name is null");
                if (String.IsNullOrEmpty(tipologia.Name)) throw new ArgumentNullException("modalità di conoscenza is null");
                _name = name;
                _tipologia = tipologia;
                _guid = guid;
                _classe = "Lingua";
            }

            public string Classe
            {
                get { return _classe; }
            }

            public ITipologia Tipologia
            {
                get { return _tipologia; }
                set { _tipologia = value; }
            }

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            public Guid Guid
            {
                get { return _guid; }
            }
            public override string ToString()
            {
                return "Nome: " + _name + " Tipologia: " + _tipologia.Name;
            }
        }
        public class Competenza : IRequisito
        {
            private readonly string _classe;
            private string _name;
            private ITipologia _tipologia;
            private Guid _guid;

            public Competenza(Guid guid, string name, ITipologia tipologia)
            {
                if (guid == Guid.Empty) throw new ArgumentNullException("guid is empty");
                if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("name is null");
                if (tipologia == null) throw new ArgumentNullException("tipologia is null");
                _name = name;
                _tipologia = tipologia;
                _guid = guid;
                _classe = "Competenza";
            }

            public string Classe
            {
                get { return _classe; }
            }

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            
            public ITipologia Tipologia
            {
                get { return _tipologia; }
                set { _tipologia = value; }
            }
            public Guid Guid
            {
                get { return _guid; }
            }
            public override string ToString()
            {
                return "Nome: " + _name + " Tipologia: " + _tipologia.Name;
            }
        }
        public class Esperienza : IRequisito
        {
            private readonly string _classe;
            private string _name;
            private ITipologia _tipologia;
            private Guid _guid;

            public Esperienza(Guid guid, string name, ITipologia tipologia)
            {
                if (guid == Guid.Empty) throw new ArgumentNullException("guid is empty");
                if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("name is null");
                if (tipologia == null) throw new ArgumentNullException("tipologia is null");
                _name = name;
                _tipologia = tipologia;
                _guid = guid;
                _classe = "Esperienza";
            }

            public string Classe
            {
                get { return _classe; }
            }

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            public ITipologia Tipologia
            {
                get { return _tipologia; }
                set { _tipologia = value; }
            }
            public Guid Guid
            {
                get { return _guid; }
            }
            public override string ToString()
            {
                return "Nome: " + _name + " Tipologia: " + _tipologia.Name;
            }
        }
        public class Formazione : IRequisito
        {
            private readonly string _classe;
            private string _name;
            private ITipologia _tipologia;
            private Guid _guid;

            public Formazione(Guid guid, string name, ITipologia tipologia)
            {
                if (guid == Guid.Empty) throw new ArgumentNullException("guid is empty");
                if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("name is null");
                if (tipologia == null) throw new ArgumentNullException("livello di istruzione is null");
                _name = name;
                _tipologia = tipologia;
                _guid = guid;
                _classe = "Formazione";
            }

            public string Classe
            {
                get { return _classe; }
            }

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            public ITipologia Tipologia
            {
                get { return _tipologia; }
                set { _tipologia = value; }
            }
            public Guid Guid
            {
                get { return _guid; }
            }
            public override string ToString()
            {
                return "Nome: " + _name + " Tipologia: " + _tipologia.Name;
            }
        }
        
        #endregion
    }
}

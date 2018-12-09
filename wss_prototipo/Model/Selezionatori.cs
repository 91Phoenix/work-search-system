using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    abstract class SelezionatoreBase : ISelezionatore
    {
        private readonly ISelezionatore _selezionatore;

        public readonly static ISelezionatore SelezionatoreDiTutto = new _SelezionatoreDiTutto();
        public readonly static ISelezionatore SelezionatoreDiNiente = new _SelezionatoreDiNiente();
        public readonly static ISelezionatore SelezionatoreDiRequisitiPiùRichiesti = new _SelezionatoreDiRequisitiPiùRichiesti();

        public SelezionatoreBase(ISelezionatore selezionatore)
        {
            _selezionatore = selezionatore ?? SelezionatoreDiTutto;
        }

        public IEnumerable<IRequisito> GetRequisiti()
        {
            return _selezionatore.GetRequisiti().Where(Predicate);
        }

        public override string ToString()
        {
            if (_selezionatore is SelezionatoreBase)
                return Description + " + " + _selezionatore.ToString();
            else
                return Description;
        }

        public abstract string Description { get; }

        protected abstract Func<IRequisito, bool> Predicate { get; }

        private class _SelezionatoreDiTutto : ISelezionatore
        {
            public IEnumerable<IRequisito> GetRequisiti()
            {
                return RequisitoFactory.GetRequisiti();
            }

            public override string ToString()
            {
                return "Tutto";
            }
        }
        private class _SelezionatoreDiNiente : ISelezionatore
        {
            public IEnumerable<IRequisito> GetRequisiti()
            {
                return new IRequisito[0];
            }

            public override string ToString()
            {
                return "Niente";
            }
        }
        private class _SelezionatoreDiRequisitiPiùRichiesti : ISelezionatore
        {
            public IEnumerable<IRequisito> GetRequisiti()
            {
                return CalcoloRequisitiFactory.GetCalcolo("CalcoloRequisitiPiùRichiesti").Calcolo(Archivio.GetInstance().GetDocumenti());
            }

            public override string ToString()
            {
                return "Più Richiesti";
            }
        }
        public class SelezionatoreDaLista : ISelezionatore
        {
            private IEnumerable<IRequisito> _requisiti;

            public SelezionatoreDaLista(IEnumerable<IRequisito> requisitiDoc)
            {
                _requisiti = requisitiDoc;
            }

            public IEnumerable<IRequisito> GetRequisiti()
            {
                return _requisiti;
            }
        }
    }

    class SelezionatorePerTipologia : SelezionatoreBase
    {
        private readonly ITipologia _tipologia;

        public SelezionatorePerTipologia(ISelezionatore selezionatore, ITipologia tipologia)
            : base(selezionatore)
        {
            _tipologia = tipologia;
        }

        public override string Description
        {
            get { return "per tipologia " + _tipologia.Name; }
        }

        protected override Func<IRequisito, bool> Predicate
        {
            get { return requisito => _tipologia.Name == requisito.Tipologia.Name; }
        }
    }

    class SelezionatorePerClasse : SelezionatoreBase
    {
        private readonly string _classe;

        public SelezionatorePerClasse(ISelezionatore selezionatore, string classe)
            : base(selezionatore)
        {
            _classe = classe;
        }

        public override string Description
        {
            get { return "per classe " + _classe; }
        }

        protected override Func<IRequisito, bool> Predicate
        {
            get { return requisito => requisito.Classe == _classe; }
        }
    }
}

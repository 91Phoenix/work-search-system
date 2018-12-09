using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSS_Prototipo.Presentazione;

namespace WSS_Prototipo.Model
{
    public abstract class DocumentoGenerico : IDocumento
    {
        private List<RequisitoPersonale> _requisiti;
        private List<Associazione> _associazioni;
        private Stato _state;

        protected DocumentoGenerico()
        {
            _requisiti = new List<RequisitoPersonale>();
            _associazioni = new List<Associazione>();
            _state = Stato.InitState();
            _state.Associated += DocumentAssociated;
            _state.RequisitoAdded += AddRequisito;
            _state.RequisitoRemoved += RemoveRequisito;

        }
        public IEnumerable<RequisitoPersonale> GetRequisiti()
        {
            return _requisiti;
        }

        public IEnumerable<Associazione> GetAssociazioni()
        {
            return _associazioni;
        }
        public void AggiungiRequisito(RequisitoPersonale requisito)
        {
            _state.AggiungiRequisito(requisito);
        }

        public void RimuoviRequisito(RequisitoPersonale requisito)
        {
            _state.RimuoviRequisito(requisito);
        }
        public void AggiungiAssociazione(Associazione associazione)
        {
            if (isAssociabile(associazione))
                _state.AggiungiAssociazione(associazione);
        }
        protected void AddAssociazione(Associazione associazione)
        {
            _associazioni.Add(associazione);
        }
        protected void AddRequisito(object sender, RequisitoEventArgs e)
        {
            if (_requisiti.Where(r => r.Requisito == e.Requisito.Requisito).ToList().Count == 0)
                _requisiti.Add(e.Requisito);
            else
                throw new ArgumentException("requisito già presente nel documento");
        }
        protected void RemoveRequisito(object sender, RequisitoEventArgs e)
        {
            if (_requisiti.Where(r => r.Requisito == e.Requisito.Requisito).ToList().Count == 0)
                throw new ArgumentException("requisito non presente nel documento");
            else
                _requisiti.Remove(e.Requisito);
        }


        public void CambiaStato()
        {
            _state = _state.CambiaStato();
            _state.Associated += DocumentAssociated;
            _state.RequisitoAdded += AddRequisito;
            _state.RequisitoRemoved += RemoveRequisito;
        }

        private void DocumentAssociated(object sender, AssociatedEventArgs e)
        {
            ModificaDocumento(e);
        }
        [Editable("Stato", Width = 50)]
        public string State
        {
            get { return _state.Name; }
        }

        protected abstract bool isAssociabile(Associazione associazione);
        protected abstract void ModificaDocumento(AssociatedEventArgs e);
        

    }
}

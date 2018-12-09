using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSS_Prototipo.Presentazione;

namespace WSS_Prototipo.Model
{
    public class  OffertaDiLavoro : DocumentoGenerico
    {
        private string _nomeAzienda;
        private int _postiDisponibili;
        private string _descrizione;
        private string _tipoContratto;
        private string _email;

        public OffertaDiLavoro(string nomeAzienda, int postiDisponibili, string descrizione, string tipoContratto, string email)
            : base()
        {
            if (String.IsNullOrEmpty(nomeAzienda)) throw new ArgumentException("nome azienda is empty");
            if (String.IsNullOrEmpty(descrizione)) throw new ArgumentException("descrizione is empty");
            if (String.IsNullOrEmpty(tipoContratto)) throw new ArgumentException("tipoContratto is empty");
            if (String.IsNullOrEmpty(email)) throw new ArgumentException("email is empty");
            if (postiDisponibili <= 0) throw new ArgumentNullException("posti disponibili is negative");
            _nomeAzienda = nomeAzienda;
            _postiDisponibili = postiDisponibili;
            _descrizione = descrizione;
            _tipoContratto = tipoContratto;
            _email = email;
        }

        [Editable("Nome Azienda", Width = 160)]
        public string NomeAzienda
        {
            get { return _nomeAzienda; }
            set { _nomeAzienda = value; }
        }
        [Editable("Posti Disponibili", Width = 160)]
        public int PostiDisponibili
        {
            get { return _postiDisponibili; }
            set {
                if (value < 0) throw new ArgumentException("I posti disponibili devono essere maggiori di zero");
                if (_postiDisponibili != 0 && value == 0) CambiaStato();
                if (_postiDisponibili == 0 && value > 0) CambiaStato();
                _postiDisponibili = value; 
            }
        }
        [Editable("Descrizione", Width = 160)]
        public string Descrizione
        {
            get { return _descrizione; }
            set { _descrizione = value; }
        }
        [Editable("Tipo Contratto", Width = 160)]
        public string TipoContratto
        {
            get { return _tipoContratto; }
            set { _tipoContratto = value; }
        }
        [Editable("Email", Width = 160)]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        protected override bool isAssociabile(Associazione associazione)
        {
            if (associazione == null) throw new ArgumentNullException("associazione is null");
            return associazione.Documento is RichiestaDiLavoro;
        }

        protected override void ModificaDocumento(AssociatedEventArgs e)
        {
            PostiDisponibili -= 1;         
            AddAssociazione(e.Associazione);
        }

        public override string ToString()
        {
            return "Azienda: " + _nomeAzienda;
        }
    }
}

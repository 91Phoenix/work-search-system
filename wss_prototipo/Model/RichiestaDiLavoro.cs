using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSS_Prototipo.Presentazione;

namespace WSS_Prototipo.Model
{
    public class RichiestaDiLavoro : DocumentoGenerico
    {
        private string _nome;
        private string _cognome;
        private DateTime _dataDiNascita;
        private ulong _telefono;
        private string _email;
        private string _codiceFiscale;
        private string _indirizzo;

        public RichiestaDiLavoro(string nome, string cognome, DateTime dataDiNascita, ulong telefono, string email, string codiceFiscale, string indirizzo)
        {
            if (String.IsNullOrEmpty(nome)) throw new ArgumentException("nome is empty");
            if (String.IsNullOrEmpty(cognome)) throw new ArgumentException("cognome is empty");
            if (String.IsNullOrEmpty(email)) throw new ArgumentException("email is empty");
            if (String.IsNullOrEmpty(codiceFiscale)) throw new ArgumentException("codiceFiscale is empty");
            if (String.IsNullOrEmpty(indirizzo)) throw new ArgumentException("indirizzo is empty");
            _nome = nome;
            _cognome = cognome;
            _dataDiNascita = dataDiNascita;
            _telefono = telefono;
            _email = email;
            _codiceFiscale = codiceFiscale;
            _indirizzo = indirizzo;

        }
        [Editable("Nome",  Width = 160)]
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        [Editable("Cognome", Width = 160)]
        public string Cognome
        {
            get { return _cognome; }
            set { _cognome = value; }
        }
        [Editable("Data Di Nascita", Width = 160)]
        public DateTime DataDiNascita
        {
            get { return _dataDiNascita; }
            set { _dataDiNascita = value; }
        }
        [Editable("Codice Fiscale", Width = 160)]
        public string CodiceFiscale
        {
            get { return _codiceFiscale; }
            set { _codiceFiscale = value; }
        }
        [Editable("Indirizzo", Width = 160)]
        public string Indirizzo
        {
            get { return _indirizzo; }
            set { _indirizzo = value; }
        }
        [Editable("Email", Width = 160)]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        [Editable("Telefono", Width = 160)]
        public ulong Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        

        protected override bool isAssociabile(Associazione associazione)
        {
            if (associazione == null) throw new ArgumentNullException("associazione is null");
            return associazione.Documento is OffertaDiLavoro;
        }

        protected override void ModificaDocumento(AssociatedEventArgs e)
        {
            AddAssociazione(e.Associazione);
            CambiaStato(); 
        }
        public override string ToString()
        {
            return _nome + " " + _cognome;
        }
    }
}

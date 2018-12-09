using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    public static class DocumentoFactory
    {
        public static DocumentoGenerico CreateOffertaDiLavoro(string nomeAzienda, int postiDisponibili, string descrizione, string tipoContratto, string email)
        {
            return new OffertaDiLavoro(nomeAzienda, postiDisponibili, descrizione, tipoContratto, email);
        }
        public static DocumentoGenerico CreateRichiestaDiLavoro(string nome, string cognome, DateTime dataDiNascita, ulong telefono, string email, string codiceFiscale, string indirizzo)
        {
            return new RichiestaDiLavoro(nome,cognome, dataDiNascita, telefono, email, codiceFiscale, indirizzo);
        }
    }
}

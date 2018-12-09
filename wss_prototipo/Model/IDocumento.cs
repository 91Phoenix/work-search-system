using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    public interface IDocumento
    {
        IEnumerable<RequisitoPersonale> GetRequisiti();
        void AggiungiRequisito(RequisitoPersonale requisiti);
        void RimuoviRequisito(RequisitoPersonale requisiti);
    }
}

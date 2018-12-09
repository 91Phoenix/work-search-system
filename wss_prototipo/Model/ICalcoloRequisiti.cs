using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    interface ICalcoloRequisiti
    {
        IEnumerable<IRequisito> Calcolo(IEnumerable<DocumentoGenerico> documenti);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    interface ICalcoloGraduatoriaFittizia
    {
        Dictionary<DocumentoGenerico, int> GraduatoriaFittizia(DocumentoGenerico documento, IEnumerable<DocumentoGenerico> documenti, IEnumerable<RequisitoPersonale> requisiti);
    }
}

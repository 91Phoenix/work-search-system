using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    public interface ICalcoloGraduatoria
    {
        Dictionary<DocumentoGenerico, int> Graduatoria(DocumentoGenerico documento, IEnumerable<DocumentoGenerico> documenti);
    }
}

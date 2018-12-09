using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    public interface IRequisito
    {
        string Classe { get; }
        string Name { get; set; }
        ITipologia Tipologia { get; set; }
        Guid Guid { get; }
    }
}

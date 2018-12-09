using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    public interface ISelezione
    {
        ISelezionatore Selezionatore { get; set; }
        IEnumerable<IRequisito> GetRequisiti();
        event EventHandler Changed;
    }
}

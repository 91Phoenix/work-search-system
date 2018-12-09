using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    public interface ISelezionatore
    {
        IEnumerable<IRequisito> GetRequisiti();
    }
}

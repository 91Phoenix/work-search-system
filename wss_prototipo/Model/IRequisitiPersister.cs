using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    public interface IRequisitiPersister
    {
        IRequisitiLoader GetLoader();
    }

    public interface IRequisitiLoader
    {
        IEnumerable<IRequisito> LoadRequisiti();   
    }
}

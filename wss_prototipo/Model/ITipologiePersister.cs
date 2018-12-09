using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    public interface ITipologiePersister
    {
        ITipologieLoader GetLoader();
    }

    public interface ITipologieLoader
    {
        List<ITipologia> LoadTipologie();
    }
}

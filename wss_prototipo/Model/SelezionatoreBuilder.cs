using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    static class SelezionatoreBuilder
    {
        public static ISelezionatore Build(ISelezionatore selezionatore = null, ITipologia tipologia = null, string classe = null)
        {
            if (tipologia != null)
            {
                selezionatore = new SelezionatorePerTipologia(selezionatore, tipologia);
            }
            if (classe != null)
            {
                selezionatore = new SelezionatorePerClasse(selezionatore, classe);
            }
            return selezionatore;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    [Flags]
    public enum ModalitàDiConoscenza
    {
        Comprensione = 1,
        Parlato = 2,
        Scritto = 3
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    public class AssociatedEventArgs : EventArgs
    {
        private readonly Associazione _associazione;

        public AssociatedEventArgs(Associazione associazione)
        {
            _associazione = associazione;
        }

        public Associazione Associazione
        {
            get { return _associazione; }
        } 
    }
}

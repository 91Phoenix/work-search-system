using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    public class Selezione : ISelezione
    {
        private ISelezionatore _selezionatore;
        //  Cache
        private IEnumerable<IRequisito> _requisiti;

        public event EventHandler Changed;

        public ISelezionatore Selezionatore
        {
            get { return _selezionatore ?? SelezionatoreBase.SelezionatoreDiTutto; }
            set
            {
                if (value != _selezionatore)
                {
                    _selezionatore = value;
                    Invalidate();
                }
            }
        }

        public IEnumerable<IRequisito> GetRequisiti()
        {
            if (_requisiti == null)
            {
                _requisiti = Selezionatore.GetRequisiti();
            }
            return _requisiti;
        }

        public override string ToString()
        {
            return Selezionatore.ToString();
        }

        public void Invalidate()
        {
            _requisiti = null;
            OnChanged();
        }

        private void OnChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }
    }
}

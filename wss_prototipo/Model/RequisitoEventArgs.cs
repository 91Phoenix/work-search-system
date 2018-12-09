using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    public class RequisitoEventArgs : EventArgs
    {
        private readonly RequisitoPersonale _requisito;

        public RequisitoEventArgs(RequisitoPersonale requisito)
        {

            _requisito = requisito;
        }

        public RequisitoPersonale Requisito
        {
            get { return _requisito; }
        }
    }
}

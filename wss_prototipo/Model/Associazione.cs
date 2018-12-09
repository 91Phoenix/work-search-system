using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    public class Associazione
    {
        private readonly IDocumento _documento;
        private readonly DateTime _data;
        private readonly Guid _id;

        public Associazione(IDocumento documento, DateTime data, Guid id)
        {
            _documento = documento;
            _data = data;
            _id = id;
        }

        public Guid Id
        {
            get { return _id; }
        } 

        public DateTime Data
        {
            get { return _data; }
        } 

        public IDocumento Documento
        {
            get { return _documento; }
        } 

        
        
    }
}

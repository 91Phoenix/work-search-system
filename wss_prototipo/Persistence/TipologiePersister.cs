using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using WSS_Prototipo.Model;

namespace WSS_Prototipo.Persistence
{
    class TipologiePersister : ITipologiePersister
    {
        private readonly string _fileName;

        public TipologiePersister(string fileName)
        {
            _fileName = fileName;
        }

        public ITipologieLoader GetLoader()
        {
            return new TipologieLoader(_fileName);
        }

        private class TipologieLoader : ITipologieLoader
        { 
            private readonly XmlDocument _xmlDocument;

            public TipologieLoader(string fileName)
            {
                _xmlDocument = new XmlDocument();
                _xmlDocument.Load(fileName);
            }

            public List<ITipologia> LoadTipologie()
            {
                List<ITipologia> tipologie = new List<ITipologia>();
                XmlElement categoriaElement = (XmlElement)_xmlDocument.SelectSingleNode("Tipologie/Categoria");
                XmlElement istruzioneElement = (XmlElement)_xmlDocument.SelectSingleNode("Tipologie/LivelloDiIstruzione");
                
                foreach(XmlElement node in categoriaElement.ChildNodes)
                {
                    TipologiaFactory.CreateCategoria(node.GetAttribute("nome"));
                }

                foreach (XmlElement node in istruzioneElement.ChildNodes)
                {
                    TipologiaFactory.CreateLivelloDiIstruzione(node.GetAttribute("nome"));
                }

                return tipologie;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using WSS_Prototipo.Model;

namespace WSS_Prototipo.Persistence
{
    class RequisitiPersister : IRequisitiPersister
    {
        private readonly string _fileName;

        public RequisitiPersister(string fileName)
        {
            _fileName = fileName;
        }

        public IRequisitiLoader GetLoader()
        {
            return new RequisitiLoader(_fileName);
        }

        private class RequisitiLoader : IRequisitiLoader
        {
            private readonly XmlDocument _xmlDocument;
            private readonly Random _random = new Random();

            public RequisitiLoader(string fileName)
            {
                _xmlDocument = new XmlDocument();
                _xmlDocument.Load(fileName);
            }

            public IEnumerable<IRequisito> LoadRequisiti()
            {
                List<IRequisito> requisiti = new List<IRequisito>();
                XmlElement esperienzaElement = (XmlElement)_xmlDocument.SelectSingleNode("Requisiti/Esperienza");
                XmlElement competenzaElement = (XmlElement)_xmlDocument.SelectSingleNode("Requisiti/Competenza");
                XmlElement formazioneElement = (XmlElement)_xmlDocument.SelectSingleNode("Requisiti/Formazione");
                XmlElement linguaElement = (XmlElement)_xmlDocument.SelectSingleNode("Requisiti/Lingua");
                
            
                foreach(XmlElement node in esperienzaElement.ChildNodes)
                {
                    ITipologia t = TipologiaFactory.GetTipologia(node.GetAttribute("tipologia"));
                    Guid id = RequisitoFactory.CreateRequisitoDiEsperienza(node.GetAttribute("nome"),t);
                    requisiti.Add(RequisitoFactory.GetRequisito(id));
                }

                foreach(XmlElement node in competenzaElement.ChildNodes)
                {
                    ITipologia t = TipologiaFactory.GetTipologia(node.GetAttribute("tipologia"));
                    Guid id = RequisitoFactory.CreateRequisitoDiCompetenza(node.GetAttribute("nome"), t);
                    requisiti.Add(RequisitoFactory.GetRequisito(id));
                }

                foreach(XmlElement node in formazioneElement.ChildNodes)
                {
                    ITipologia t = TipologiaFactory.GetTipologia(node.GetAttribute("tipologia"));
                    Guid id = RequisitoFactory.CreateRequisitoDiFormazione(node.GetAttribute("nome"), t);
                    requisiti.Add(RequisitoFactory.GetRequisito(id));
                }

                foreach(XmlElement node in linguaElement.ChildNodes)
                {
                    ITipologia t = TipologiaFactory.GetTipologia(node.GetAttribute("tipologia"));
                    Guid id = RequisitoFactory.CreateRequisitoDiLingua(node.GetAttribute("nome"), t);
                    requisiti.Add(RequisitoFactory.GetRequisito(id));
                }
                return requisiti;
            }
        }
    }
}

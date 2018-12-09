using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    public class Archivio
    {
        private static Archivio _instance;
        private List<DocumentoGenerico> _documenti;
        public event EventHandler Changed;

        private Archivio()
        {  
            Init();
            OnChanged();
        }
        private void Init()
        {
            _documenti = new List<DocumentoGenerico>();
        }

        public static Archivio GetInstance()
        {
            if (_instance == null)
                _instance = new Archivio();
            return _instance;
        }

        public IEnumerable<DocumentoGenerico> GetDocumenti()
        {
            return _documenti;
        }

        public IEnumerable<DocumentoGenerico> GetOfferteDiLavoro()
        {
            return _documenti.OfType<OffertaDiLavoro>().ToList();
        }
        public IEnumerable<DocumentoGenerico> GetRichiesteDiLavoro()
        {
            return _documenti.OfType<RichiestaDiLavoro>().ToList();
        }

        public void AggiungiDocumento(DocumentoGenerico doc)
        {
            #region check requisiti
            /* int countL = 0;
            int countF = 0;
            if (doc.GetRequisiti().ToList().Count >= 2)
            {
                foreach (RequisitoPersonale rp in doc.GetRequisiti())
                {
                    if (rp.GetType() == typeof(RequisitoPersonaleDiFormazione)) countF++;
                    if (rp.GetType() == typeof(RequisitoPersonaleDiLingua)) countL++;
                }
                if (countL >= 1 && countF >= 1)
                {
                    _documenti.Add(doc);
                }
                else
                {
                    throw new ArgumentException("Il documento deve contenere almeno un requisito di lingua e uno di formazione");
                }
            }
            else
            {
                throw new ArgumentException("Il documento deve contenere almeno un requisito di lingua e uno di formazione");
            }*/
            #endregion
            _documenti.Add(doc);
            OnChanged();
        }

        public void CreaAssociazione(DocumentoGenerico doc1, DocumentoGenerico doc2)
        {
            DateTime currentDate = DateTime.Today;
            Guid id = Guid.NewGuid();
            if (doc1.State.Equals("Disattivo") || doc2.State.Equals("Disattivo"))
            {
                throw new ArgumentException("Documento Disattivo");
            }
            doc2.AggiungiAssociazione(new Associazione(doc1, currentDate, id));
            doc1.AggiungiAssociazione(new Associazione(doc2, currentDate, id));
            OnChanged();
            
        }
        protected virtual void OnChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }

        private readonly Random _random = new Random();

        public IEnumerable<DocumentoGenerico> CreaDocumentiRandom(int count)
        {
            List<DocumentoGenerico> documenti = new List<DocumentoGenerico>();

            for (int k = 0; k <= count; k++)
            {
                DocumentoGenerico off =
                     DocumentoFactory.CreateOffertaDiLavoro("nomeAzienda" + k, _random.Next(1, 5), " ",
                                                                "tipoContratto" + k, "email" + k);
                DocumentoGenerico rich =
                DocumentoFactory.CreateRichiestaDiLavoro("nome" + k, "cognome" + k, new DateTime(), (ulong)_random.Next(1000, 2000),
                                                                "email" + k, "codiceFiscale" + k, "indirizzo" + k);
                this.AggiungiDocumento(rich);
                this.AggiungiDocumento(off);
            }
            return documenti;
        }

        public void Load(ITipologiePersister tipologiePersister, IRequisitiPersister requisitiPersister)
        {
            if (tipologiePersister == null)
                throw new ArgumentNullException("tipologia persister");
            if (requisitiPersister == null)
                throw new ArgumentNullException("requisiti persister");
            List<IRequisito> requisiti = new List<IRequisito>();

            CreaDocumentiRandom(20).ToList();

            ITipologieLoader tipologieLoader = tipologiePersister.GetLoader();
            tipologieLoader.LoadTipologie();
            IRequisitiLoader requisitiLoader = requisitiPersister.GetLoader();
            requisiti = requisitiLoader.LoadRequisiti().ToList();
            List<RequisitoFactory.Lingua> requisitiLingua = requisiti.OfType<RequisitoFactory.Lingua>().ToList();
            List<RequisitoFactory.Formazione> requisitiFormazione = requisiti.OfType<RequisitoFactory.Formazione>().ToList();
            List<RequisitoFactory.Competenza> requisitiCompetenza = requisiti.OfType<RequisitoFactory.Competenza>().ToList();
            List<RequisitoFactory.Esperienza> requisitiEsperienza = requisiti.OfType<RequisitoFactory.Esperienza>().ToList();
            List<RequisitoPersonaleDiLingua> requisitiLinguaPersonale = new List<RequisitoPersonaleDiLingua>();
            List<RequisitoPersonaleDiFormazione> requisitiFormazionePersonale = new List<RequisitoPersonaleDiFormazione>();
            List<RequisitoPersonaleDiCompetenza> requisitiCompetenzaPersonale = new List<RequisitoPersonaleDiCompetenza>();
            List<RequisitoPersonaleDiEsperienza> requisitiEsperienzaPersonale = new List<RequisitoPersonaleDiEsperienza>();


            foreach (IRequisito r in requisitiLingua)
            {
                for (int k = 0; k < _random.Next(1, 3); k++)
                {
                    requisitiLinguaPersonale.Add((RequisitoPersonaleDiLingua)RequisitoPersonaleFactory.CreateRequisitoDiLingua(r.Guid, (GradoDiValutazione)_random.Next(1, 4)));
                }
            }

            foreach (IRequisito r in requisitiFormazione)
            {
                for (int k = 0; k < _random.Next(1, 3); k++)
                {
                    requisitiFormazionePersonale.Add((RequisitoPersonaleDiFormazione)
                        RequisitoPersonaleFactory.CreateRequisitoDiFormazione(r.Guid, (GradoDiValutazione)_random.Next(1, 4)));
                }
            }

            foreach (IRequisito r in requisitiCompetenza)
            {
                for (int k = 0; k < _random.Next(1, 3); k++)
                {
                    requisitiCompetenzaPersonale.Add((RequisitoPersonaleDiCompetenza)
                        RequisitoPersonaleFactory.CreateRequisitoDiCompetenza(r.Guid, (GradoDiValutazione)_random.Next(1, 4)));
                }
            }

            foreach (IRequisito r in requisitiEsperienza)
            {
                for (int k = 0; k < _random.Next(1, 3); k++)
                {
                    requisitiEsperienzaPersonale.Add((RequisitoPersonaleDiEsperienza)
                        RequisitoPersonaleFactory.CreateRequisitoDiEsperienza(r.Guid, (GradoDiValutazione)_random.Next(1, 4)));
                }
            }

            foreach (DocumentoGenerico d in GetDocumenti())
            {
                d.AggiungiRequisito(requisitiLinguaPersonale[_random.Next(1, requisitiLinguaPersonale.Count)]);
                d.AggiungiRequisito(requisitiFormazionePersonale[_random.Next(1, requisitiFormazionePersonale.Count)]);
                d.AggiungiRequisito(requisitiCompetenzaPersonale[_random.Next(1, requisitiCompetenzaPersonale.Count)]);
                d.AggiungiRequisito(requisitiEsperienzaPersonale[_random.Next(1, requisitiEsperienzaPersonale.Count)]);
            }
            OnChanged();
        }
    }
}

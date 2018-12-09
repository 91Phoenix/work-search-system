using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{

    public abstract class CalcoloBaseGraduatoria : ICalcoloGraduatoria, ICalcoloGraduatoriaFittizia
    {

        protected CalcoloBaseGraduatoria()
        {
        }

        

        protected Dictionary<DocumentoGenerico, int> GraduatoriaGenerale(DocumentoGenerico documento, IEnumerable<DocumentoGenerico> documenti)
        {
            Dictionary<DocumentoGenerico, int> graduatoria = new Dictionary<DocumentoGenerico, int>();
            IEnumerable<RequisitoPersonale> requisiti = documento.GetRequisiti();

            foreach (DocumentoGenerico doc in documenti)
            {
                if (doc.State.Equals("Attivo"))
                {
                    int punteggio = 0;
                    foreach (RequisitoPersonale requisitoA in requisiti)
                    {
                        foreach (RequisitoPersonale requisitoB in doc.GetRequisiti())
                        {
                            if (requisitoA.Requisito.Guid == requisitoB.Requisito.Guid)
                            {
                                int quota = (int)requisitoA.GradoDiValutazione - (int)requisitoB.GradoDiValutazione;
                                if (quota <= 0)
                                    punteggio += 3;
                                if (quota == 1)
                                    punteggio += 2;
                                else
                                    punteggio += 0;
                            }
                        }
                    }
                    graduatoria.Add(doc, punteggio);
                }
            }
            return graduatoria;
        }

        protected Dictionary<DocumentoGenerico, int> OrderGraduatoria(Dictionary<DocumentoGenerico, int> graduatoria, bool descending)
        {
            Dictionary<DocumentoGenerico, int> result = new Dictionary<DocumentoGenerico, int>();
            IEnumerable<KeyValuePair<DocumentoGenerico, int>> partialResult = null;
            if(descending)
                partialResult = (IEnumerable<KeyValuePair<DocumentoGenerico, int>>)
                    (from r in graduatoria select r).OrderByDescending(r => r.Value);
            else
                partialResult = (IEnumerable<KeyValuePair<DocumentoGenerico, int>>)
                    (from r in graduatoria select r).OrderBy(r => r.Value);

            foreach (KeyValuePair<DocumentoGenerico, int> pair in partialResult)
            {
                result.Add(pair.Key, pair.Value);
            }
            return result;
        }

        public abstract Dictionary<DocumentoGenerico, int> Graduatoria(DocumentoGenerico documento, IEnumerable<DocumentoGenerico> documenti);
        public abstract Dictionary<DocumentoGenerico, int> GraduatoriaFittizia(DocumentoGenerico documento, IEnumerable<DocumentoGenerico> documenti, IEnumerable<RequisitoPersonale> requisiti);
    }

    public class CalcoloSuRichiesta : CalcoloBaseGraduatoria
    {
        public CalcoloSuRichiesta()
            : base()
        {
        }

        public override Dictionary<DocumentoGenerico, int> Graduatoria(DocumentoGenerico documento, IEnumerable<DocumentoGenerico> documenti)
        {
            if (!(documento is RichiestaDiLavoro)) throw new ArgumentException("il documento non è una richiesta");
            if (documento == null) throw new ArgumentNullException("Non è stato inserito nessun documento");
            if (documenti == null) throw new ArgumentNullException("Non è stata inserita nessuna lista di documenti");
            if (documento.State.Equals("Disattivo")) throw new ArgumentException("Documento disattivo");

            List<OffertaDiLavoro> offerte = documenti.OfType<OffertaDiLavoro>().ToList();
            List<RichiestaDiLavoro> richieste = documenti.OfType<RichiestaDiLavoro>().ToList();
            Dictionary<DocumentoGenerico, int> graduatoriaRichiesta = new Dictionary<DocumentoGenerico, int>();

            foreach (OffertaDiLavoro off in offerte)
            {
                if(off.State.Equals("Attivo"))
                {
                    Dictionary<DocumentoGenerico, int> graduatoriaOffNesima = this.GraduatoriaGenerale(off, richieste);
                    //ottengo il mio punteggio
                    int mioPunteggio = graduatoriaOffNesima[documento];
                    //attraverso una query ottengo la mia posizione in graduatoria
                    int position = (int)(from g in graduatoriaOffNesima select g).LongCount(g => g.Value > mioPunteggio);
                    //formo la graduatoria da restituire 
                    graduatoriaRichiesta.Add(off, position + 1);
                }
            }
            //ordino la graduatoria da restituire
            return OrderGraduatoria(graduatoriaRichiesta, false);
        }

        public override Dictionary<DocumentoGenerico, int> GraduatoriaFittizia(DocumentoGenerico documento, IEnumerable<DocumentoGenerico> documenti, IEnumerable<RequisitoPersonale> requisiti)
        {
            if (!(documento is RichiestaDiLavoro)) throw new ArgumentException("il documento non è una richiesta");
            if (documento == null) throw new ArgumentNullException("Non è stato inserito nessun documento");
            if (documenti == null) throw new ArgumentNullException("Non è stata inserita nessuna lista di documenti");
            if (documento.State.Equals("Disattivo")) throw new ArgumentException("Documento disattivo");

            List<OffertaDiLavoro> offerte = documenti.OfType<OffertaDiLavoro>().ToList();
            List<RichiestaDiLavoro> richieste = documenti.OfType<RichiestaDiLavoro>().ToList();
            Dictionary<DocumentoGenerico, int> graduatoriaRichiesta = new Dictionary<DocumentoGenerico, int>();
            List<RequisitoPersonale> requisitiAggiunti = new List<RequisitoPersonale>();
            List<RequisitoPersonale> requisitiModificati = new List<RequisitoPersonale>();
            RichiestaDiLavoro richiestaDaElaborare = null;

            foreach (RichiestaDiLavoro rdl in richieste)
            {
                if (rdl.Equals(documento))
                {
                    richiestaDaElaborare = rdl;
                    foreach (RequisitoPersonale rp in requisiti)
                    {
                        IEnumerable<RequisitoPersonale> flag = rdl.GetRequisiti().Where(r => r.Requisito == rp.Requisito);
                        if (flag.Count() == 0)
                        {
                            rdl.AggiungiRequisito(rp);
                            requisitiAggiunti.Add(rp);
                        }
                        else
                        {
                            //Aggiungo un requisito fittizio solo se il suo grado di valutazione è maggiore di quello presente
                            if ((int)rp.GradoDiValutazione > (int)flag.ElementAt(0).GradoDiValutazione)
                            {
                                rdl.RimuoviRequisito(flag.ElementAt(0));
                                rdl.AggiungiRequisito(rp);
                                requisitiAggiunti.Add(rp);
                                requisitiModificati.Add(flag.ElementAt(0));
                            }
                        }
                    }
                    break;
                }
            }

            foreach (OffertaDiLavoro off in offerte)
            {
                Dictionary<DocumentoGenerico, int> graduatoriaOffNesima = this.GraduatoriaGenerale(off, richieste);
                //ottengo il mio punteggio
                int mioPunteggio = graduatoriaOffNesima[documento];
                //attraverso una query ottengo la mia posizione in graduatoria
                int position = (int)(from g in graduatoriaOffNesima select g).LongCount(g => g.Value > mioPunteggio);
                //formo la graduatoria da restituire 
                graduatoriaRichiesta.Add(off, position + 1);
            }

            // Elimino i requisiti fittizi aggiunti
            foreach (RequisitoPersonale ra in requisitiAggiunti)
            {
                richiestaDaElaborare.RimuoviRequisito(ra);
            }
            //Riaggiungo i vecchi requisiti che sono stati modificati
            foreach (RequisitoPersonale rm in requisitiModificati)
            {
                richiestaDaElaborare.AggiungiRequisito(rm);
            }

            //ordino la graduatoria da restituire
            return OrderGraduatoria(graduatoriaRichiesta, false);
        }
    }

    public class CalcoloSuOfferta : CalcoloBaseGraduatoria
    {
        public CalcoloSuOfferta()
            : base()
        {
        }

        public override Dictionary<DocumentoGenerico, int> Graduatoria(DocumentoGenerico documento, IEnumerable<DocumentoGenerico> documenti)
        {
            if (!(documento is OffertaDiLavoro)) throw new ArgumentException("il documento non è una offerta");
            if (documento == null) throw new ArgumentNullException("Non è stato inserito nessun documento");
            if (documenti == null) throw new ArgumentNullException("Non è stata inserita nessuna lista di documenti");
            if (documento.State.Equals("Disattivo")) throw new ArgumentException("Documento disattivo");

            List<RichiestaDiLavoro> richieste = documenti.OfType<RichiestaDiLavoro>().ToList();
            //ordino la graduatoria da restituire
            return OrderGraduatoria(this.GraduatoriaGenerale(documento, richieste), true);
        }

        public override Dictionary<DocumentoGenerico, int> GraduatoriaFittizia(DocumentoGenerico documento, IEnumerable<DocumentoGenerico> documenti, IEnumerable<RequisitoPersonale> requisiti)
        {
            if (!(documento is OffertaDiLavoro)) throw new ArgumentException("il documento non è una offerta");
            if (documento == null) throw new ArgumentNullException("Non è stato inserito nessun documento");
            if (documenti == null) throw new ArgumentNullException("Non è stata inserita nessuna lista di documenti");
            if (documento.State.Equals("Disattivo")) throw new ArgumentException("Documento disattivo");

            List<OffertaDiLavoro> offerte = documenti.OfType<OffertaDiLavoro>().ToList();
            List<RichiestaDiLavoro> richieste = documenti.OfType<RichiestaDiLavoro>().ToList();
            List<RequisitoPersonale> requisitiRimossi = new List<RequisitoPersonale>();
            List<RequisitoPersonale> requisitiAggiunti = new List<RequisitoPersonale>();
            OffertaDiLavoro offertaDaElaborare = null;

            foreach (OffertaDiLavoro odl in offerte)
            {
                if (odl.Equals(documento))
                {
                    offertaDaElaborare = odl;
                    foreach (RequisitoPersonale rp in requisiti)
                    {
                        List<RequisitoPersonale> flag = new List<RequisitoPersonale>();
                        flag = odl.GetRequisiti().Where(r => r.Requisito.Guid == rp.Requisito.Guid).ToList();

                        if (flag.Count() != 0)
                        {
                            // Se il requisito presente nell'offerta ha un grado di valutazione maggiore di quello specificato
                            // viene sostituito, altrimenti viene rimosso.
                            if ((int)rp.GradoDiValutazione < (int)flag.ElementAt(0).GradoDiValutazione)
                            {
                                odl.RimuoviRequisito(flag.ElementAt(0));
                                odl.AggiungiRequisito(rp);
                                requisitiRimossi.Add(flag.ElementAt(0));
                                requisitiAggiunti.Add(rp);
                            }
                        }
                    }
                    break;
                }
            }
            Dictionary<DocumentoGenerico, int> graduatoriaOff = this.GraduatoriaGenerale(documento, richieste);

            foreach (RequisitoPersonale rp in requisitiAggiunti)
            {
                offertaDaElaborare.RimuoviRequisito(rp);
            }
            foreach (RequisitoPersonale rp in requisitiRimossi)
            {
                offertaDaElaborare.AggiungiRequisito(rp);
            }


            //ordino la graduatoria da restituire
            return OrderGraduatoria(graduatoriaOff, true);
        }
    }
}

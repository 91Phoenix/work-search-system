using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    public abstract class CalcoloBaseRequisiti : ICalcoloRequisiti
    {

        protected CalcoloBaseRequisiti()
        {
        }

        public abstract IEnumerable<IRequisito> Calcolo(IEnumerable<DocumentoGenerico> documenti);

        protected List<IRequisito> OrderList(Dictionary<IRequisito, int> requisiti)
        {
            List<IRequisito> result = new List<IRequisito>();

            IEnumerable<KeyValuePair<IRequisito, int>> partialResult =
               // (IEnumerable<KeyValuePair<IRequisito, int>>)
                (from r in requisiti select r).OrderByDescending(r => r.Value);

            foreach (KeyValuePair<IRequisito, int> pair in partialResult)
            {
                result.Add(pair.Key);
            }
            return result;
        }
        
    }
    public class CalcoloRequisitiPiùRichiesti : CalcoloBaseRequisiti
    {
        public CalcoloRequisitiPiùRichiesti()
            : base()
        {
        }

        public override IEnumerable<IRequisito> Calcolo(IEnumerable<DocumentoGenerico> documenti)
        {
            List<OffertaDiLavoro> offerteDiLavoro = documenti.OfType<OffertaDiLavoro>().ToList();
            Dictionary<IRequisito, int> requisitiPiùRichiesti = new Dictionary<IRequisito, int>(); 
            foreach (OffertaDiLavoro off in offerteDiLavoro)
            {
                foreach (RequisitoPersonale r in off.GetRequisiti())
                {
                    if (requisitiPiùRichiesti.ContainsKey(r.Requisito))
                    {
                        requisitiPiùRichiesti[r.Requisito]++;
                    }
                    else
                    {
                        requisitiPiùRichiesti.Add(r.Requisito, 1);
                    }
                }
            }
            return OrderList(requisitiPiùRichiesti);
        }
    }
}

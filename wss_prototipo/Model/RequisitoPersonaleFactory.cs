using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSS_Prototipo.Model
{
    public class RequisitoPersonaleFactory
    {
        public static RequisitoPersonale CreateRequisitoDiLingua(Guid idRequisito, GradoDiValutazione gradoDiValutazione)
        {
            return new RequisitoPersonaleDiLingua(RequisitoFactory.GetRequisito(idRequisito), gradoDiValutazione);
        }
        public static RequisitoPersonale CreateRequisitoDiFormazione(Guid idRequisito, GradoDiValutazione gradoDiValutazione)
        {
            return new RequisitoPersonaleDiFormazione(RequisitoFactory.GetRequisito(idRequisito), gradoDiValutazione);
        }
        public static RequisitoPersonale CreateRequisitoDiCompetenza(Guid idRequisito, GradoDiValutazione gradoDiValutazione)
        {
            return new RequisitoPersonaleDiCompetenza(RequisitoFactory.GetRequisito(idRequisito), gradoDiValutazione);
        }
        public static RequisitoPersonale CreateRequisitoDiEsperienza(Guid idRequisito, GradoDiValutazione gradoDiValutazione)
        {
            return new RequisitoPersonaleDiEsperienza(RequisitoFactory.GetRequisito(idRequisito), gradoDiValutazione);
        }
    }
}

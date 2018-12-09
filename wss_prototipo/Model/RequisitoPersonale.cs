using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSS_Prototipo.Presentazione;

namespace WSS_Prototipo.Model
{
    public abstract class RequisitoPersonale
    {
        private readonly IRequisito _requisito;
        private readonly GradoDiValutazione _gradoDiValutazione;

        protected RequisitoPersonale(IRequisito requisito, GradoDiValutazione gradoDiValutazione)
        {
            if (requisito == null) throw new ArgumentNullException("requisito is null");
            if (!Enum.IsDefined(typeof(GradoDiValutazione), gradoDiValutazione)) throw new ArgumentException("grado di valutazione is not defined");
            _requisito = requisito;
            _gradoDiValutazione = gradoDiValutazione;
        }

        public IRequisito Requisito
        {
            get { return _requisito; }    
        }
        
        public GradoDiValutazione GradoDiValutazione
        {
            get { return _gradoDiValutazione; }
        }

        public string Name
        {
            get { return _requisito.Name; }
        }

        public ITipologia Tipologia
        {
            get { return _requisito.Tipologia; }
        }
        public override string ToString()
        {
            return Name + " " + Tipologia.Name + " " + GradoDiValutazione.ToString();
        }
    }

    public class RequisitoPersonaleDiCompetenza : RequisitoPersonale
    {
        public RequisitoPersonaleDiCompetenza(IRequisito requisito, GradoDiValutazione gradoDiValutazione)
            : base(requisito, gradoDiValutazione)
        {
            if (!(requisito is RequisitoFactory.Competenza)) throw new ArgumentException("requisito is not RequisitoFactory.Competenza");
        }  
    }
    public class RequisitoPersonaleDiEsperienza : RequisitoPersonale
    {

        public RequisitoPersonaleDiEsperienza(IRequisito requisito, GradoDiValutazione gradoDiValutazione)
            : base(requisito, gradoDiValutazione)
        {
            if (!(requisito is RequisitoFactory.Esperienza)) throw new ArgumentException("requisito is not RequisitoFactory.Esperienza");
        }
    }
    public class RequisitoPersonaleDiFormazione : RequisitoPersonale
    {

        public RequisitoPersonaleDiFormazione(IRequisito requisito, GradoDiValutazione gradoDiValutazione)
            : base(requisito, gradoDiValutazione)
        {
            if (!(requisito is RequisitoFactory.Formazione)) throw new ArgumentException("requisito is not RequisitoFactory.Formazione");
        }
        
        
    }
    public class RequisitoPersonaleDiLingua : RequisitoPersonale
    {
        public RequisitoPersonaleDiLingua(IRequisito requisito, GradoDiValutazione gradoDiValutazione)
            : base(requisito, gradoDiValutazione)
        {
            if (!(requisito is RequisitoFactory.Lingua)) throw new ArgumentException("requisito is not RequisitoFactory.Lingua");
        }
    }
}

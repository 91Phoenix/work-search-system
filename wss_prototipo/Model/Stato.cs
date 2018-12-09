using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace WSS_Prototipo.Model
{  
    public abstract class Stato
    {
        private readonly string _name;

        public event EventHandler<AssociatedEventArgs> Associated;
        public event EventHandler<RequisitoEventArgs> RequisitoAdded;
        public event EventHandler<RequisitoEventArgs> RequisitoRemoved;

        protected Stato(string name)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentException("name is empty");
            _name = name;
        }

        public static Stato InitState()
        {
            Console.WriteLine(typeof(EventHandler));
            Stato result = null;
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.BaseType == typeof(Stato)) 
                {
                    StateAttribute[] attributes = (StateAttribute[]) type.GetCustomAttributes(typeof(StateAttribute), true);
                    if (attributes.Length != 0 && attributes[0].Label)
                    {
                        result = (Stato)Activator.CreateInstance(type);
                        break;
                    }
                }
            }
            return result;
            //return new Attivo();
        }

        public string Name
        {
            get { return _name; }
        }

        protected virtual void OnAssociated(AssociatedEventArgs e)
        {
            if (Associated != null)
                Associated(this, e);
        }
        protected virtual void OnRequisitoAdded(RequisitoEventArgs e)
        {
            if (RequisitoAdded != null)
                RequisitoAdded(this, e);
        }
        protected virtual void OnRequisitoRemoved(RequisitoEventArgs e)
        {
            if (RequisitoRemoved != null)
                RequisitoRemoved(this, e);
        }

        public abstract Stato CambiaStato();
        public abstract void AggiungiRequisito(RequisitoPersonale requisito);
        public abstract void RimuoviRequisito(RequisitoPersonale requisito);
        public abstract void AggiungiAssociazione(Associazione associazione);

        [State(false)]
        private class Disattivo : Stato
        {
            public Disattivo() 
                : base("Disattivo")
            {
            }

            public override Stato CambiaStato()
            {
                return new Attivo();
            }

            public override void AggiungiRequisito(RequisitoPersonale requisito)
            {
                throw new ArgumentException("Documento Disattivo");
            }

            public override void RimuoviRequisito(RequisitoPersonale requisito)
            {
                throw new ArgumentException("Documento Disattivo");
            }

            public override void AggiungiAssociazione(Associazione associazione)
            {
                throw new ArgumentException("Documento Disattivo");
            }
        }
        [State(true)]
        private class Attivo : Stato
        {
            public Attivo()
                : base("Attivo")
            {
            }

            public override Stato CambiaStato()
            {
                return new Disattivo();
            }
            public override void AggiungiRequisito(RequisitoPersonale requisito)
            {
                OnRequisitoAdded(new RequisitoEventArgs(requisito));
                
            }

            public override void RimuoviRequisito(RequisitoPersonale requisito)
            {
                OnRequisitoRemoved(new RequisitoEventArgs(requisito));
                
            }
            public override void AggiungiAssociazione(Associazione associazione)
            {
                OnAssociated(new AssociatedEventArgs(associazione));     
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSS_Prototipo.Model;

namespace WSS_Prototipo.Presentazione
{
    public abstract class Presenter<TControl>
        where TControl : Control
    {
        private readonly TControl _control;
        private readonly Control _container;

        public Presenter(TControl control, Control container)
        {
            if (control == null)
                throw new ArgumentNullException("control");
            if (container == null)
                throw new ArgumentNullException("container");
            _control = control;
            _container = container;
            InitializeControl();
        }

        public TControl Control
        {
            get { return _control; }
        }
        public Control Container
        {
            get { return _container; }
        }
        

        protected virtual void Changed(object sender, EventArgs e)
        {
            RefreshControl();
        }

        protected abstract void InitializeControl();

        protected abstract void RefreshControl(); 
    }
}

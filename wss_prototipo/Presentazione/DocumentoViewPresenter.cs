using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSS_Prototipo.Model;

namespace WSS_Prototipo.Presentazione
{
    public class DocumentoViewPresenter : Presenter<DocumentControl>
    {
        private readonly ListBox _lista;
        public DocumentoViewPresenter(DocumentControl editingControl, Control container, ListBox lista)
            : base(editingControl, container)
        {
            if (lista == null) throw new ArgumentNullException("listBox is null");
            _lista = lista;
            _lista.Click += Changed;
            RefreshControl();
        }

        protected override void InitializeControl()
        {
            Control.Dock = DockStyle.Fill;
        }

        protected override void RefreshControl()
        {
            if (_lista.SelectedItem != null)
            {
                Container.Controls.Clear();
                Container.Controls.Add(Control);
                Control.SetEditableObject(_lista.SelectedItem, false);
                Control.LoadItemsRequisiti(((DocumentoGenerico)_lista.SelectedItem).GetRequisiti());
                Control.LoadItemsAssociazioni(((DocumentoGenerico)_lista.SelectedItem).GetAssociazioni());
            }    
        }
    }
}

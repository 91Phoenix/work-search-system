using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using WSS_Prototipo.Model;

namespace WSS_Prototipo.Presentazione
{
    public partial class DocumentDialog : Form
    {
        public DocumentDialog()
        {
            InitializeComponent();
            _documentControl.SetVisiblePanelBottom(true);
        }
        public IEnumerable<RequisitoPersonale> NewRequisiti()
        { 
            return _documentControl.NewRequisiti();       
        }
        public void LoadItemsRequisiti(IEnumerable items)
        {
            _documentControl.LoadItemsRequisiti(items);
        }
        public void SetListBoxNewRequisiti()
        {      
            _documentControl.SetListBoxNewRequisiti();
        }

        public void SetEditableObject(object documento, bool visible)
        {
            _documentControl.SetEditableObject(documento, visible);
        }
        public void ResetEditingObject()
        {
            try
            {
                _documentControl.ResetEditingObject();
            }
            catch (Exception ex)
            {
            }
        }

        private void _reset_Click(object sender, EventArgs e)
        {
            ResetEditingObject();
        }

        private void _documentControl_HasErrorChanged(object sender, EventArgs e)
        {
            _okButton.Enabled = !_documentControl.HasError;
        
        }
    }
}

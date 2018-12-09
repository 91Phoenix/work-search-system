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
    public partial class EditingRequisitiDialog : Form
    {
        public EditingRequisitiDialog()
        {
            InitializeComponent();
        }

        public EditingRequisitiControl Control
        {
            get { return _editingRequisitiControl; }
        }
        public void LoadItemsRequisiti(IEnumerable items)
        {
            _editingRequisitiControl.LoadItemsRequisiti(items);
        }
        public void LoadItemsTipologie(IEnumerable items)
        {
            _editingRequisitiControl.LoadItemsTipologie(items);
        }
        public void LoadItemsGradoDiValutazione(IEnumerable items)
        {
            _editingRequisitiControl.LoadItemsGradoDiValutazione(items);
        }
        public void SetEnable(bool enable)
        {
            _editingRequisitiControl.SetEnable(enable);
        }
    }
}

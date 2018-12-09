using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace WSS_Prototipo.Presentazione
{
    public partial class SelectDialog : Form
    {
        public SelectDialog()
        {
            InitializeComponent();
        }
        public object SelectedItem
        {
            get
            {
                return _documenti.SelectedItem;
            }
        }
        public void LoadItems(IEnumerable items)
        {
            _documenti.DataSource = items;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSS_Prototipo.Model;

namespace WSS_Prototipo.Presentazione
{
    public partial class RequisitiFittiziDialog : Form
    {
        public RequisitiFittiziDialog()
        {
            InitializeComponent();
        }

        public RequisitiFittiziControl Control
        {
            get 
            {
                return _requisitiFittiziControl;
            }
        }

    }
}

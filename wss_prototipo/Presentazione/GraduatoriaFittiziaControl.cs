using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WSS_Prototipo.Presentazione
{
    public partial class GraduatoriaFittiziaControl : UserControl
    {
        public GraduatoriaFittiziaControl()
        {
            InitializeComponent();
        }

        public DataGridView DataGridViewAttuale
        {
            get
            {
                return _dataGraduatoria;
            }
        }
        public DataGridView DataGridViewFittizia
        {
            get
            {
                return _dataGraduatoriaFittizia;
            }
        }
    }
}

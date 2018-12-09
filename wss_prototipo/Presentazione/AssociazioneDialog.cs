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
    public partial class AssociazioneDialog : Form
    {
        public AssociazioneDialog()
        {
            InitializeComponent();
        }

        public object Offerta
        {
            get
            {
                return _offerte.SelectedItem;
            }
        }
        public object Richiesta
        {
            get
            {
                return _richieste.SelectedItem;
            }
        }

        public void LoadItems(IEnumerable items)
        {
            _richieste.DataSource = items.OfType<RichiestaDiLavoro>().ToList();
            _offerte.DataSource = items.OfType<OffertaDiLavoro>().ToList();
            //_richieste.DataSource = items.OfType<RichiestaDiLavoro>().Where(r => r.State.Equals("Attivo")).ToList();
            //_offerte.DataSource = items.OfType<OffertaDiLavoro>().Where(r => r.State.Equals("Attivo")).ToList();
        }
    }
}

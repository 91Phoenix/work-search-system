using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WSS_Prototipo.Model;
namespace WSS_Prototipo.Presentazione
{
    public partial class RequisitiFittiziControl : UserControl
    {
        public RequisitiFittiziControl()
        {
            InitializeComponent();
            AddValutazioneToComboBox();
        }

        public RequisitiViewControl RequisitiViewControl
        {
            get
            {
                return _requisitiViewControl;
            }
        }

        public SplitterPanel Panel2
        {
            get
            {
                return _splitContainer.Panel2;
            }
        }

        public ListBox RequisitiSelezionati
        {
            get
            {
                return _requisitiSelezionati;
            }
        }

        private void AddValutazioneToComboBox()
        {
            _gradiValutazione.DataSource = Enum.GetValues(typeof(GradoDiValutazione));
        }

        private void _aggiungi_Click(object sender, EventArgs e)
        {
            GradoDiValutazione grado = (GradoDiValutazione)_gradiValutazione.SelectedItem;
            DataGridViewRow row = null;
            IRequisito req = null;
            RequisitoPersonale reqP = null;
            bool found = false;

            try
            {
                row = _requisitiViewControl.DataGridView.SelectedRows[0];
                req = row.DataBoundItem as IRequisito;
                if (req != null)
                {
                    foreach (RequisitoPersonale rp in _requisitiSelezionati.Items)
                    {
                        if (rp.Requisito.Guid == req.Guid)
                        {
                            MessageBox.Show("Requisito già inserito");
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        String type = _requisitiViewControl.DataGridView.SelectedCells[0].Value.ToString();
                        switch (type)
                        {
                            case "Lingua":
                                reqP = RequisitoPersonaleFactory.CreateRequisitoDiLingua(req.Guid, grado);
                                break;
                            case "Formazione":
                                reqP = RequisitoPersonaleFactory.CreateRequisitoDiFormazione(req.Guid, grado);
                                break;
                            case "Esperienza":
                                reqP = RequisitoPersonaleFactory.CreateRequisitoDiEsperienza(req.Guid, grado);
                                break;
                            case "Competenza":
                                reqP = RequisitoPersonaleFactory.CreateRequisitoDiCompetenza(req.Guid, grado);
                                break;
                        }
                        _requisitiSelezionati.Items.Add(reqP);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Seleziona una riga dei requisiti");
            }
        }

        private void _rimuovi_Click(object sender, EventArgs e)
        {
            if (_requisitiSelezionati.SelectedItem != null)
                _requisitiSelezionati.Items.Remove(_requisitiSelezionati.SelectedItem);
            else
                MessageBox.Show("Nessun requisito selezionato");
        }
    }
}

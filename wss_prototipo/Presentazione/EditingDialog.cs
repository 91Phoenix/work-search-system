using System;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using WSS_Prototipo.Model;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;

namespace WSS_Prototipo.Presentazione
{
    public partial class EditingDialog : Form
    {
        private readonly List<RequisitoPersonale> _requisiti = new List<RequisitoPersonale>();
        private bool _validDocument = false;

        public IEnumerable<RequisitoPersonale> Requisiti
        {
            get { return _requisiti; }
        }

        public EditingDialog()
        {
            InitializeComponent();
        }

        public EditingDocumentControl RequisitiControl
        {
            get { return _splitter; }
            set { _splitter = value; }
        }

        public void SetEditableType(Type editingType)
        {
            _splitter.SetEditableType(editingType);
        }

        private void _editingControl_HasErrorChanged(object sender, EventArgs e)
        {
            _okButton.Enabled = !_splitter.HasError && _validDocument;
        }

        private void _resetButton_Click(object sender, EventArgs e)
        {
            _splitter.ResetEditingType();
            _requisiti.Clear();
            _okButton.Enabled = false;
            RefreshListBox();
        }
        
        private void _addReqEsperienzaButton_Click(object sender, EventArgs e)
        {
            using (EditingRequisitiDialog editingRequisitiDialog = new EditingRequisitiDialog())
            {
                editingRequisitiDialog.Control.Selezionatore = new SelezionatorePerClasse(SelezionatoreBase.SelezionatoreDiTutto, "Esperienza");
                editingRequisitiDialog.LoadItemsTipologie(TipologiaFactory.GetTipologie().Where(t => t.GetType().Name == "Categoria").ToList());
                if (editingRequisitiDialog.ShowDialog() == DialogResult.OK)
                {
                    IRequisito r;
                    GradoDiValutazione g;
                    bool notGood = false;
                    AggiungiRequisito(editingRequisitiDialog, out r, out g, out notGood, "Esperienza");
                    if (!notGood)
                    {
                        RequisitoPersonale rp = RequisitoPersonaleFactory.CreateRequisitoDiEsperienza(r.Guid, g);
                        GiaInserito(rp);
                        RefreshListBox();
                    }
                }
            }
            
        }

        
        private void _addReqCompetenzaButton_Click(object sender, EventArgs e)
        {
            using (EditingRequisitiDialog editingRequisitiDialog = new EditingRequisitiDialog())
            {
                editingRequisitiDialog.Control.Selezionatore = new SelezionatorePerClasse(SelezionatoreBase.SelezionatoreDiTutto, "Competenza");
                editingRequisitiDialog.LoadItemsTipologie(TipologiaFactory.GetTipologie().Where(t => t.GetType().Name == "Categoria").ToList());
                if (editingRequisitiDialog.ShowDialog() == DialogResult.OK)
                {
                    IRequisito r;
                    GradoDiValutazione g;
                    bool notGood = false;
                    AggiungiRequisito(editingRequisitiDialog, out r, out g, out notGood, "Competenza");
                    if (!notGood)
                    {
                        RequisitoPersonale rp = RequisitoPersonaleFactory.CreateRequisitoDiCompetenza(r.Guid, g);
                        GiaInserito(rp);
                        RefreshListBox();
                    }
                }
            }
        }

        private void _addReqFormazioneButton_Click(object sender, EventArgs e)
        {
            using (EditingRequisitiDialog editingRequisitiDialog = new EditingRequisitiDialog())
            {
                editingRequisitiDialog.Control.Selezionatore = new SelezionatorePerClasse(SelezionatoreBase.SelezionatoreDiTutto, "Formazione");
                editingRequisitiDialog.LoadItemsTipologie(TipologiaFactory.GetTipologie().Where(t => t.GetType().Name == "LivelloDiIstruzione").ToList());
                if (editingRequisitiDialog.ShowDialog() == DialogResult.OK)
                {
                    IRequisito r;
                    GradoDiValutazione g;
                    bool notGood = false;
                    AggiungiRequisito(editingRequisitiDialog, out r, out g, out notGood, "Formazione");
                    if (!notGood)
                    {
                        RequisitoPersonale rp = RequisitoPersonaleFactory.CreateRequisitoDiFormazione(r.Guid, g);
                        GiaInserito(rp);
                        RefreshListBox();
                    }
                    DocumentoValido();
                }
            }
            
        }

       
        private void _addReqLinguaButton_Click(object sender, EventArgs e)
        {
            using (EditingRequisitiDialog editingRequisitiDialog = new EditingRequisitiDialog())
            {
                editingRequisitiDialog.Control.Selezionatore = new SelezionatorePerClasse(SelezionatoreBase.SelezionatoreDiTutto, "Lingua");
                editingRequisitiDialog.LoadItemsTipologie(TipologiaFactory.GetTipologie().Where(t => t.GetType().Name == "ModalitàDiConoscenzaAdapter").ToList());
                editingRequisitiDialog.SetEnable(false);
                if (editingRequisitiDialog.ShowDialog() == DialogResult.OK)
                {
                    IRequisito r;
                    GradoDiValutazione g;
                    bool notGood = false;
                    AggiungiRequisito(editingRequisitiDialog, out r, out g, out notGood, "Lingua");
                    if (!notGood)
                    {
                        RequisitoPersonale rp = RequisitoPersonaleFactory.CreateRequisitoDiLingua(r.Guid, g);
                        GiaInserito(rp);
                        RefreshListBox();
                    }
                    DocumentoValido();
                }
            }
           
        }

        private void AggiungiRequisito(EditingRequisitiDialog dialog, out IRequisito r, out GradoDiValutazione g, out bool notGood, string tipo)
        {
            string nomeRequisito = null;
            string nomeTipologia = null;
            bool tipotext = false;
            bool reqtext = false;
            notGood = false;
            bool requisitoSelezionato = ((CheckBox)dialog.Control.Panel2.Controls["_checkNew"]).Checked;
            bool tipologiaSelezionata = ((CheckBox)dialog.Control.Panel3.Controls["_checkNewTip"]).Checked;
            r = null;
            ITipologia t = TipologiaFactory.GetTipologia(((ComboBox)dialog.Control.Panel3.Controls["_tipologie"]).SelectedItem.ToString());
            g = (GradoDiValutazione)Enum.Parse(typeof(GradoDiValutazione), ((ComboBox)dialog.Control.Panel2.Controls["_gradoValutazione"]).SelectedItem.ToString(), true);
            try
            {
                if (requisitoSelezionato)
                {
                    nomeRequisito = ((TextBox)dialog.Control.Panel3.Controls["_nomeReq"]).Text;
                    if (nomeRequisito == string.Empty) reqtext = true;
                    nomeTipologia = ((TextBox)dialog.Control.Panel3.Controls["_nomeTip"]).Text;
                    if (nomeTipologia == string.Empty) tipotext = true;

                    if (tipologiaSelezionata)
                    {
                        switch (tipo)
                        {
                            case "Formazione":
                                t = TipologiaFactory.CreateLivelloDiIstruzione(nomeTipologia);
                                break;
                            default:
                                t = TipologiaFactory.CreateCategoria(nomeTipologia);
                                break;
                        }
                        
                    }

                    Guid id = new Guid();
                    switch (tipo)
                    {
                        case "Lingua":
                            id = RequisitoFactory.CreateRequisitoDiLingua(nomeRequisito, t);
                            break;
                        case "Formazione":
                            id = RequisitoFactory.CreateRequisitoDiFormazione(nomeRequisito, t);
                            break;
                        case "Esperienza":
                            id = RequisitoFactory.CreateRequisitoDiEsperienza(nomeRequisito, t);
                            break;
                        case "Competenza":
                            id = RequisitoFactory.CreateRequisitoDiCompetenza(nomeRequisito, t);
                            break;
                    }
                    r = RequisitoFactory.GetRequisito(id);
                }
                else
                {
                    r = (IRequisito)dialog.Control.ListBoxRequisiti.SelectedItem;
                }
            }
            catch (ArgumentException)
            {
                notGood = true;
                StringBuilder s = new StringBuilder();
                if (tipotext) s.Append("una nuova tipologia,");
                if (reqtext) s.Append("un nuovo requisito,");
                MessageBox.Show("Si è scelto di inserire " + s + " ma lasciato vuoto il relativo campo di testo");
            }
        }

        public void DocumentoValido()
        {
            int countL = 0;
            int countF = 0;
            if (Requisiti.ToList().Count >= 2)
            {
                foreach (RequisitoPersonale rp in Requisiti)
                {
                    if (rp.GetType() == typeof(RequisitoPersonaleDiFormazione)) countF++;
                    if (rp.GetType() == typeof(RequisitoPersonaleDiLingua)) countL++;
                }
                if (countL >= 1 && countF >= 1)
                {
                    _validDocument = true;
                }
                else
                {
                    _validDocument = false;
                }
                _okButton.Enabled = !_splitter.HasError && _validDocument;
            }
            else
            {
                _validDocument = false;
                _okButton.Enabled = _validDocument;
            }
        }

        private void GiaInserito(RequisitoPersonale rp)
        {
            bool found = false;
            foreach (RequisitoPersonale r in _requisiti)
            {
                if (r.Requisito == rp.Requisito)
                {
                    found = true;
                    MessageBox.Show("Requisito già inserito");
                    break;
                }
            }
            if (!found)
                _requisiti.Add(rp);

        }

        private void RefreshListBox()
        {
            _listBox.DataSource = _requisiti.ToList();
        }

        private void _rimuoviButton_Click(object sender, EventArgs e)
        {
            _requisiti.Remove((RequisitoPersonale) _listBox.SelectedItem);
            DocumentoValido();
            RefreshListBox();
        }

        
    }
}

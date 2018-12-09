using System;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
using WSS_Prototipo.Model;
using System.Text;

namespace WSS_Prototipo.Presentazione
{
    public partial class DocumentControl : UserControl
    {
        private bool _validDocument = true;
        private object _editingObject = null;
        private readonly Dictionary<PropertyInfo, object> _originalValues = new Dictionary<PropertyInfo, object>();
        private List<RequisitoPersonale> _newRequisiti = new List<RequisitoPersonale>();
        private IEnumerable<RequisitoPersonale> _originalRequisiti = null;
        private int _errorCounter = 0;

        public event EventHandler HasErrorChanged;

        public DocumentControl()
        {
            InitializeComponent();
        }

        public IEnumerable<RequisitoPersonale> NewRequisiti()
        {
            return _newRequisiti;
        }

        public bool HasError
        {
            get
            {
                return _errorCounter > 0 || !_validDocument;
            }
        }

        public void SetVisiblePanelBottom(bool visible)
        {
            _panelBottom.Visible = visible;
        }
        public void LoadItemsRequisiti(IEnumerable items)
        {
            _requsitiListBox.DataSource = items;
            _requsitiListBox.SelectedIndex = -1;
            _requsitiListBox.Invalidate();
        }

        public void SetListBoxNewRequisiti()
        {
            _groupBoxAssociazioni.Text = "Requisiti Aggiunti:";
            _associazioniDataGridView.Visible = false;
            _newRequisitiListBox.Visible = true;
        }

        public void LoadItemsAssociazioni(IEnumerable items)
        {
            _associazioniDataGridView.DataSource = items;
            _associazioniDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _associazioniDataGridView.Invalidate();
        }
       
        public void SetEditableObject(object editingObject, bool editable)
        {
            if(editingObject == null)
                throw new ArgumentNullException("");
            _editingObject = editingObject;
            if (_editingObject is DocumentoGenerico)
            {
                DocumentoGenerico doc = (DocumentoGenerico)_editingObject;
                _originalRequisiti = doc.GetRequisiti().ToList();
                if (doc.State.Equals("Disattivo"))
                    SetVisiblePanelBottom(false);
            }
            _originalValues.Clear();
            _errorCounter = 0;
            _tableLayoutPanel.Controls.Clear();



            foreach (PropertyInfo propertyInfo in _editingObject.GetType().GetProperties()) 
            {
                EditableAttribute[] attributes = (EditableAttribute[]) propertyInfo.GetCustomAttributes(typeof(EditableAttribute), false);
                if (attributes.Length == 0)
                    continue;
                if (!propertyInfo.CanRead)
                    throw new ApplicationException("!propertyInfo.CanRead");
                if (propertyInfo.CanWrite)
                    _originalValues.Add(propertyInfo,propertyInfo.GetValue(_editingObject,null));
                AddRow(attributes[0], propertyInfo, editable);     
            }
            RefreshTextBoxes(null);
        }
        public void ResetEditingObject()
        {
            foreach(KeyValuePair<PropertyInfo,object> entry in _originalValues)
            {
                PropertyInfo propertyInfo = entry.Key;
                object value = entry.Value;
                try
                {
                    propertyInfo.SetValue(_editingObject, value, null);
                }
                catch
                {
                }   
            }
            foreach (RequisitoPersonale req in ((DocumentoGenerico)_editingObject).GetRequisiti().ToList())
            {
                ((DocumentoGenerico)_editingObject).RimuoviRequisito(req);  
            }
            foreach (RequisitoPersonale req in _originalRequisiti)
            {
                ((DocumentoGenerico)_editingObject).AggiungiRequisito(req);
            }
            _newRequisiti.Clear();
            CheckRequisitiPanel();
            RefreshListBox();
            RefreshTextBoxes(null);
        }
        private void AddRow(EditableAttribute editableAttribute, PropertyInfo propertyInfo, bool editable)
        {
            //----------- Label ---------
            Label label = new Label();
            label.Text = editableAttribute.Label;
            label.AutoSize = true;
            _tableLayoutPanel.Controls.Add(label);
            //----------- TextBox ---------
            TextBox textBox = new TextBox();
            textBox.Width = editableAttribute.Width;
            textBox.Height = textBox.PreferredHeight;
            textBox.Enabled = propertyInfo.CanWrite && editable;
            textBox.Tag = propertyInfo;
            textBox.Validating += ValidatingHandler;
            _tableLayoutPanel.Controls.Add(textBox);
        }
        private void RefreshTextBoxes(TextBox excludedTextBox)
        {
            foreach (Control control in _tableLayoutPanel.Controls)
            {
                if (control is TextBox && control != excludedTextBox)
                {
                    TextBox current = (TextBox) control;
                    PropertyInfo propertyInfo = (PropertyInfo) current.Tag;
                    object value = propertyInfo.GetValue(_editingObject,null);
                    if (value != null && value is DateTime) current.Text = ((DateTime)value).ToShortDateString();
                    else current.Text = value != null ? value.ToString() : String.Empty;
                    if (propertyInfo.CanWrite)
                        Validate(current);
                }
            } 
        }

        private void ValidatingHandler(object sender, CancelEventArgs args)
        {
            Validate((TextBox) sender);
            if(!HasError)
                RefreshTextBoxes((TextBox) sender);

            CheckRequisitiPanel();
        }

        private void CheckRequisitiPanel()
        {
            if (_editingObject is DocumentoGenerico)
            {
                DocumentoGenerico doc = (DocumentoGenerico)_editingObject;
                if (doc.State.Equals("Disattivo"))
                    SetVisiblePanelBottom(false);
                else
                    SetVisiblePanelBottom(true);
            }
        }

        private void Validate(TextBox textBox)
        {
            try
            {
                PropertyInfo propertyInfo = (PropertyInfo)textBox.Tag;
                object newValue = Convert.ChangeType(textBox.Text,propertyInfo.PropertyType);             
                propertyInfo.SetValue(_editingObject, newValue, null);
                SetError(textBox, null);
            }
            catch (Exception exception)
            {
                SetError(textBox, exception.Message);
            }
        }
        private void SetError(TextBox textBox, string newMessage)
        {
            string oldError = _errorProvider.GetError(textBox);
            _errorProvider.SetError(textBox,newMessage);
            if (String.IsNullOrEmpty(oldError))
            {
                if (!(String.IsNullOrEmpty(newMessage)))
                {
                    _errorCounter++;
                    if (_errorCounter == 1)
                        OnHasErrorChanged();
                }
            }
            else if (String.IsNullOrEmpty(newMessage))
            {
                _errorCounter--;
                if (_errorCounter == 0)
                    OnHasErrorChanged();
            }
        }
        protected virtual void OnHasErrorChanged()
        {
            if (HasErrorChanged != null)
                HasErrorChanged(this, EventArgs.Empty);
        }

        private void _associazioniDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_associazioniDataGridView.Columns[e.ColumnIndex].Name.Equals("Documento"))
            {
                IDocumento documento = e.Value as IDocumento;
                if (documento != null)
                    e.Value = documento.ToString();
            }
        }

        private void _linguaButton_Click(object sender, EventArgs e)
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

        private void _competenzaButton_Click(object sender, EventArgs e)
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

        private void _esperienzaButton_Click(object sender, EventArgs e)
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
        private void _formazioneButton_Click(object sender, EventArgs e)
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
            DocumentoGenerico doc = (DocumentoGenerico)_editingObject;
             
            foreach (RequisitoPersonale rp in doc.GetRequisiti())
            {
                if (rp.GetType() == typeof(RequisitoPersonaleDiFormazione)) countF++;
                if (rp.GetType() == typeof(RequisitoPersonaleDiLingua)) countL++;
            }
            foreach (RequisitoPersonale rp in _newRequisiti)
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
            OnHasErrorChanged();
        }

        private void GiaInserito(RequisitoPersonale rp)
        {
            bool found = false;
            foreach (RequisitoPersonale r in _newRequisiti)
            {
                if (r.Requisito == rp.Requisito)
                {
                    found = true;
                    MessageBox.Show("Requisito già inserito");
                    break;
                }
            }
            if (!found)
            {
                ((DocumentoGenerico)_editingObject).AggiungiRequisito(rp);
                _newRequisiti.Add(rp);
            }
                

        }

        private void RefreshListBox()
        {
            _newRequisitiListBox.DataSource = _newRequisiti.ToList();
            _newRequisitiListBox.SelectedIndex = -1;
        }

        private void _rimuoviButton_Click(object sender, EventArgs e)
        {
            if (_requsitiListBox.SelectedItem != null)
            {
                ((DocumentoGenerico)_editingObject).RimuoviRequisito((RequisitoPersonale)_requsitiListBox.SelectedItem);
                LoadItemsRequisiti(((DocumentoGenerico)_editingObject).GetRequisiti().ToList());
                DocumentoValido();
                RefreshListBox();
            }
        }
    }
}

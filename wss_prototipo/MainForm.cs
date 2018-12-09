using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using WSS_Prototipo.Model;
using WSS_Prototipo.Presentazione;
using WSS_Prototipo.Persistence;


namespace WSS_Prototipo
{
    public partial class MainForm : Form
    {
        private readonly SelectDialog _selectDialog = new SelectDialog();
        
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Archivio.GetInstance().Changed += DocumentiChanged;
            Archivio.GetInstance().Load(new TipologiePersister("../../Tipologie.xml"), new RequisitiPersister("../../Requisiti.xml"));
            new RequisitiViewPresenter(new RequisitiViewControl(), _splitContainer.Panel2, _visualizzaRequisiti, new Selezione());
            DocumentControl _documentControl = new DocumentControl();
            new DocumentoViewPresenter(_documentControl, _splitContainer.Panel2, _listOfferte);
            new DocumentoViewPresenter(_documentControl, _splitContainer.Panel2, _listRichieste);
            new GraduatoriaViewPresenter(new DataGridView(), _splitContainer.Panel2, _graduatoria);
            new GraduatoriaFittiziaViewPresenter(new GraduatoriaFittiziaControl(), _splitContainer.Panel2, _graduatoriaFittizia);
        }

        private void DocumentiChanged(object sender, EventArgs e)
        {
            RefreshListBox();
        }

        private void _associazioneButton_Click(object sender, EventArgs e)
        {
            using (AssociazioneDialog associazioneDialog = new AssociazioneDialog())
            {
                associazioneDialog.LoadItems(Archivio.GetInstance().GetDocumenti());
                if (associazioneDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Archivio.GetInstance().CreaAssociazione((DocumentoGenerico)associazioneDialog.Richiesta, (DocumentoGenerico)associazioneDialog.Offerta);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }     
            }
        }

        

        private void InserisciOfferta_Click(object sender, EventArgs e)
        {
            using (EditingDialog editDialog = new EditingDialog())
            {
                editDialog.SetEditableType((typeof(OffertaDiLavoro)));
                if (editDialog.ShowDialog() == DialogResult.OK)
                {
                    String nomeAzienda = String.Empty, Descrizione = String.Empty, TipoContratto = String.Empty, Email = String.Empty;
                    int PostiDisponibili = 0;

                    foreach (KeyValuePair<PropertyInfo, object> tb in editDialog.RequisitiControl.Properties)
                    {
                        if (tb.Key.Name == ("NomeAzienda"))
                            nomeAzienda = (string) tb.Value;
                        if (tb.Key.Name == "PostiDisponibili")
                            PostiDisponibili = (int) tb.Value;
                        if (tb.Key.Name == "Descrizione")
                            Descrizione = (string)tb.Value;
                        if (tb.Key.Name == "TipoContratto")
                            TipoContratto = (string)tb.Value;
                        if (tb.Key.Name == "Email")
                            Email = (string)tb.Value;
                    }

                    DocumentoGenerico d = DocumentoFactory.CreateOffertaDiLavoro(
                        nomeAzienda, PostiDisponibili, Descrizione, TipoContratto, Email);
                    foreach (RequisitoPersonale rp in editDialog.Requisiti)
                    {
                        d.AggiungiRequisito(rp);
                    }
                    Archivio.GetInstance().AggiungiDocumento(d);
                }  
            }
        }

        private void InserisciRichiesta_Click(object sender, EventArgs e)
        {
            using (EditingDialog editDialog = new EditingDialog())
            {
                editDialog.SetEditableType((typeof(RichiestaDiLavoro)));
                if (editDialog.ShowDialog() == DialogResult.OK)
                {
                    String nome = String.Empty, cognome = String.Empty, codiceFiscale = String.Empty, Email = String.Empty, via = String.Empty;
                    ulong telefono = 0;
                    DateTime nascita = new DateTime();

                    foreach (KeyValuePair<PropertyInfo, object> tb in editDialog.RequisitiControl.Properties)
                    {
                        if (tb.Key.Name == ("Nome"))
                            nome = (string) tb.Value;
                        if (tb.Key.Name == "Cognome")
                            cognome = (string) tb.Value;
                        if (tb.Key.Name == "Email")
                            Email = (string) tb.Value;
                        if (tb.Key.Name == "Telefono")
                            telefono = (ulong) tb.Value;
                        if (tb.Key.Name == "CodiceFiscale")
                            codiceFiscale = (string) tb.Value;
                        if (tb.Key.Name == "Indirizzo")
                            via = (string) tb.Value;
                        if (tb.Key.Name == "DataDiNascita")
                            nascita = (DateTime) tb.Value;
                    }
                    DocumentoGenerico d = DocumentoFactory.CreateRichiestaDiLavoro(
                        nome, cognome, nascita, telefono, Email, codiceFiscale, via);
                    foreach (RequisitoPersonale rp in editDialog.Requisiti)
                    {
                        d.AggiungiRequisito(rp);
                    }
                    Archivio.GetInstance().AggiungiDocumento(d);
                }
            }

        }

        private void _cambiaStato_Click(object sender, EventArgs e)
        {
            DocumentoGenerico documento = SelezionaDa(Archivio.GetInstance().GetDocumenti());
            if (documento != null)
            {
                documento.CambiaStato();
            }
        }

        private void _modificaDocumento_Click(object sender, EventArgs e)
        {
            DocumentoGenerico documento = SelezionaDa(Archivio.GetInstance().GetDocumenti());
            if (documento != null)
            {
                using (DocumentDialog documentDialog = new DocumentDialog())
                {
                    documentDialog.LoadItemsRequisiti(documento.GetRequisiti());
                    documentDialog.SetEditableObject(documento, true);
                    documentDialog.SetListBoxNewRequisiti();
                    if (documentDialog.ShowDialog() != DialogResult.OK)
                        documentDialog.ResetEditingObject();             
                }
                RefreshListBox();
            }
        }

        private T SelezionaDa<T>(IEnumerable<T> items)
            where T : class
        {
            _selectDialog.LoadItems(items);
            if (_selectDialog.ShowDialog() == DialogResult.OK)
                return (T)_selectDialog.SelectedItem;
            return null;
        }

        public void RefreshListBox()
        {
            _listOfferte.DataSource = Archivio.GetInstance().GetOfferteDiLavoro();
            _listOfferte.SelectedIndex = -1;
            _listRichieste.DataSource = Archivio.GetInstance().GetRichiesteDiLavoro();
            _listRichieste.SelectedIndex = -1;
            _toolStripStatusLabel.Text = String.Format("Documenti: {0}", Archivio.GetInstance().GetDocumenti().ToList().Count);
        }


    }
}

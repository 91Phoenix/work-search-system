using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSS_Prototipo.Model;

namespace WSS_Prototipo.Presentazione
{
    

    public class GraduatoriaFittiziaViewPresenter : Presenter<GraduatoriaFittiziaControl>
    {
        public GraduatoriaFittiziaViewPresenter(GraduatoriaFittiziaControl control, Control container, ToolStripButton visualizza)
            : base(control, container)
        {
            if(visualizza != null)
                visualizza.Click += VisualizzaGraduatoriaFittizia;
            RefreshControl();
        }

        protected override void InitializeControl()
        {
            Control.Dock = DockStyle.Fill;
        }

        private void VisualizzaGraduatoriaFittizia(object sender, EventArgs e)
        {
            DocumentoGenerico documento = null;
            using (SelectDialog selectDialog = new SelectDialog())
            {
                selectDialog.LoadItems(Archivio.GetInstance().GetDocumenti());
                if (selectDialog.ShowDialog() == DialogResult.OK)
                {
                    documento = (DocumentoGenerico) selectDialog.SelectedItem;  
                }
            }
            if (documento != null)
            {
                if (documento.State.Equals("Attivo"))
                {
                    using (RequisitiFittiziDialog dialog = new RequisitiFittiziDialog())
                    {
                        ISelezione selezione = new Selezione();
                        if (documento is OffertaDiLavoro)
                        {
                            selezione.Selezionatore = new SelezionatoreBase.SelezionatoreDaLista(documento.GetRequisiti().Select(req => req.Requisito));
                            dialog.Control.RequisitiViewControl.SetVisiblePanel(false);
                        }
                        new RequisitiViewPresenter(dialog.Control.RequisitiViewControl, dialog.Control.Panel2, null, selezione);
                        dialog.Control.Panel2.Controls.Add(dialog.Control.RequisitiViewControl);
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            List<RequisitoPersonale> listaRequisiti = new List<RequisitoPersonale>();
                            foreach (RequisitoPersonale rp in dialog.Control.RequisitiSelezionati.Items)
                            {
                                listaRequisiti.Add(rp);
                            }

                            if (documento is RichiestaDiLavoro)
                            {
                                Control.DataGridViewAttuale.DataSource = CalcoloGraduatoriaFactory.GetCalcoloGraduatoria("CalcoloSuRichiesta").Graduatoria(documento, Archivio.GetInstance().GetDocumenti()).ToList();
                                Control.DataGridViewAttuale.Columns["Value"].HeaderText = "Posizione in graduatoria Attuale";
                                Control.DataGridViewAttuale.Columns["Key"].HeaderText = "Offerte di lavoro";
                                Control.DataGridViewFittizia.DataSource = CalcoloGraduatoriaFactory.GetCalcoloGraduatoriaFittizia("CalcoloSuRichiesta").GraduatoriaFittizia(documento, Archivio.GetInstance().GetDocumenti(), listaRequisiti).ToList();
                                Control.DataGridViewFittizia.Columns["Value"].HeaderText = "Posizione in graduatoria Fittizia";
                                Control.DataGridViewFittizia.Columns["Key"].HeaderText = "Offerte di lavoro";
                            }
                            else
                            {
                                Control.DataGridViewAttuale.DataSource = CalcoloGraduatoriaFactory.GetCalcoloGraduatoria("CalcoloSuOfferta").Graduatoria(documento, Archivio.GetInstance().GetDocumenti()).ToList();
                                Control.DataGridViewAttuale.Columns["Value"].HeaderText = "Punteggio Attuale";
                                Control.DataGridViewAttuale.Columns["Key"].HeaderText = "Richieste di lavoro";
                                Control.DataGridViewFittizia.DataSource = CalcoloGraduatoriaFactory.GetCalcoloGraduatoriaFittizia("CalcoloSuOfferta").GraduatoriaFittizia(documento, Archivio.GetInstance().GetDocumenti(), listaRequisiti).ToList();
                                Control.DataGridViewFittizia.Columns["Value"].HeaderText = "Punteggio Fittizio";
                                Control.DataGridViewFittizia.Columns["Key"].HeaderText = "Richieste di lavoro";
                            }
                            Container.Controls.Clear();
                            Container.Controls.Add(Control);
                            RefreshControl();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Documento disattivo");
                }
            }
        }
        protected override void RefreshControl()
        {
            Control.Invalidate();
        }
    }
    
}

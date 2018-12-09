using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSS_Prototipo.Model;

namespace WSS_Prototipo.Presentazione
{
    
    public class GraduatoriaViewPresenter : Presenter<DataGridView>
    {
        public GraduatoriaViewPresenter(DataGridView dataGridViewControl, Control container, ToolStripButton visualizza)
            : base(dataGridViewControl, container)
        {
            if (visualizza != null)
                visualizza.Click += VisualizzaGraduatoria;
            RefreshControl();
        }

        protected override void InitializeControl()
        {
            Control.Dock = DockStyle.Fill;
            Control.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void VisualizzaGraduatoria(object sender, EventArgs e)
        {
            using (SelectDialog selectDialog = new SelectDialog())
            {
                selectDialog.LoadItems(Archivio.GetInstance().GetDocumenti());
                if (selectDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        DocumentoGenerico documento = (DocumentoGenerico) selectDialog.SelectedItem;
                        if (documento != null)
                        {
                            Container.Controls.Clear();
                            Container.Controls.Add(Control);
                            
                            if (documento is RichiestaDiLavoro)
                            {
                                Control.DataSource = CalcoloGraduatoriaFactory.GetCalcoloGraduatoria("CalcoloSuRichiesta").Graduatoria(documento, Archivio.GetInstance().GetDocumenti()).ToList();
                                Control.Columns["Value"].HeaderText = "Posizione in graduatoria";
                                Control.Columns["Key"].HeaderText = "Offerte di lavoro";
                            }
                            else
                            {
                                Control.DataSource = CalcoloGraduatoriaFactory.GetCalcoloGraduatoria("CalcoloSuOfferta").Graduatoria(documento, Archivio.GetInstance().GetDocumenti()).ToList();
                                Control.Columns["Value"].HeaderText = "Punteggio";
                                Control.Columns["Key"].HeaderText = "Richieste di lavoro";
                            }
                            RefreshControl();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }    
                }
            }     
        }
       
        protected override void RefreshControl()
        {        
            Control.Invalidate();
        }
    }
}

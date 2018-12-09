using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSS_Prototipo.Model;
using System.Windows.Forms;

namespace WSS_Prototipo.Presentazione
{
    public class RequisitiViewPresenter : Presenter<RequisitiViewControl>
    {
        private readonly ISelezione _selezione = new Selezione();

        public RequisitiViewPresenter(RequisitiViewControl dataGridViewControl, Control container, ToolStripButton visualizza, ISelezione selezione)
            : base(dataGridViewControl, container)
        {
            if (selezione == null)
                throw new ArgumentNullException();
            _selezione = selezione;
            _selezione.Changed += Changed;
            if(visualizza != null)
                visualizza.Click += VisualizzaRequisiti;
            Control.TreeView.AfterSelect += SelezioneChanged;
            Control.ListBoxClassi.Click += SelezioneChanged;
            Control.PiùRichiestiCheckBox.CheckedChanged += SelezioneChanged;
            Control.Reset.Click += ResetClick;
            RefreshControl();
        }

        protected override void InitializeControl()
        {    
            Control.Dock = DockStyle.Fill;   
        }
        private void VisualizzaRequisiti(object sender, EventArgs e)
        {
            Container.Controls.Clear();
            Container.Controls.Add(Control);
            Control.RefreshControl();
            RefreshControl();
        }

        private void SelezioneChanged(object sender, EventArgs e)
        {
            if (Control.PiùRichiestiCheckBox.Checked)
            {
                _selezione.Selezionatore = (ISelezionatore)Control.PiùRichiestiCheckBox.Tag;
            }
            else
            {
                _selezione.Selezionatore = SelezionatoreBase.SelezionatoreDiTutto;
            }
            ModificaSelezionatore();
        }
        private void ModificaSelezionatore()
        {
            _selezione.Selezionatore = SelezionatoreBuilder.Build(_selezione.Selezionatore,
                Control.TreeView.SelectedNode != null && !(Control.TreeView.SelectedNode.Tag is string) ? (ITipologia)Control.TreeView.SelectedNode.Tag : null,
                Control.ListBoxClassi.SelectedItem != null ? (string)Control.ListBoxClassi.SelectedItem : null);
        }
        private void ResetClick(object sender, EventArgs e)
        {
            Control.TreeView.SelectedNode = null;
            Control.ListBoxClassi.SelectedIndex = -1;
            Control.PiùRichiestiCheckBox.Checked = false;
            _selezione.Selezionatore = SelezionatoreBase.SelezionatoreDiTutto;
        }

        protected override void RefreshControl()
        {
            Control.LoadItems(_selezione.GetRequisiti().ToList());
        }
    }
}

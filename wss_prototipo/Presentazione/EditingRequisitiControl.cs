using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using WSS_Prototipo.Model;
using System.Collections;

namespace WSS_Prototipo.Presentazione
{
    public partial class EditingRequisitiControl : UserControl
    {
        
        private readonly Dictionary<PropertyInfo, object> _originalValues = new Dictionary<PropertyInfo, object>();
        private ISelezionatore _selezionatore = null;
        private ISelezione _selezione = new Selezione();


        public EditingRequisitiControl()
        {
            InitializeComponent();
            _selezione.Changed += Changed;
            LoadItemsGradoDiValutazione(Enum.GetNames(typeof(GradoDiValutazione)));
        }

        protected void Changed(object sender, EventArgs e)
        {
            LoadItemsRequisiti(_selezione.GetRequisiti().ToList());
        }
        public ISelezionatore Selezionatore
        {
            set 
            {
                _selezionatore = value;
                _selezione.Selezionatore = _selezionatore;
            }
        }

        public ListBox ListBoxRequisiti
        {
            get { return _requisitiList; }
        }
        
        public Panel Panel3
        {
            get { return panel3; }
        }

        public Panel Panel2
        {
            get { return panel2; }
        }

        public void LoadItemsRequisiti(IEnumerable items)
        {
            _requisitiList.DataSource = items;
            _requisitiList.Invalidate();
        }

        public void LoadItemsTipologie(IEnumerable items)
        {
            _tipologie.DataSource = items;
            AddTreeNodesTipologie(_treeView.Nodes, items);
        }

        public void LoadItemsGradoDiValutazione(IEnumerable items)
        {
            _gradoValutazione.DataSource = items;
        }

        public void SetEnable(bool enable)
        {
            _checkNewTip.Enabled = enable;
            _nomeTip.Enabled = enable;
        }

        private void AddTreeNodesTipologie(TreeNodeCollection treeNodes,IEnumerable items)
        {
            foreach (object tipologia in items)
            {
                TreeNode treeNode = new TreeNode(tipologia.ToString());
                treeNode.Tag = tipologia;
                treeNodes.Add(treeNode);
            }
        }

        private void _checkNew_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Visible = _checkNew.Checked;
        }

        private void _checkNewTip_CheckedChanged(object sender, EventArgs e)
        {
            _nomeTip.Enabled = _checkNewTip.Checked;
        }

        private void _treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _selezione.Selezionatore = SelezionatoreBuilder.Build(_selezionatore, (ITipologia)e.Node.Tag, null);
        }
        
    }
}

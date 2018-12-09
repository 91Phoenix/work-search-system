using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using WSS_Prototipo.Model;

namespace WSS_Prototipo.Presentazione
{
    public partial class RequisitiViewControl : UserControl
    {

        public RequisitiViewControl()
        {
            InitializeComponent();
            RefreshControl();
            _piùRichiestiCheckBox.Tag = SelezionatoreBase.SelezionatoreDiRequisitiPiùRichiesti;
        }

        public void LoadItems(IEnumerable items)
        {
            _dataGridView.DataSource = items;
            _dataGridView.Columns["Guid"].Visible = false;
            _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dataGridView.Invalidate();
        }
        public Button Reset
        {
            get
            {
                return _reset;
            }
        }
        public TreeView TreeView
        {
            get
            {
                return _treeView;
            }
        }
        public ListBox ListBoxClassi
        {
            get
            {
                return _listBoxClassi;
            }
        }
        public CheckBox PiùRichiestiCheckBox
        {
            get
            {
                return _piùRichiestiCheckBox;
            }
        }
        public DataGridView DataGridView
        {
            get
            {
                return _dataGridView;
            }
        }

        private void AddClassiToList(ListBox listBox)
        {
            listBox.DataSource = RequisitoFactory.GetNomeClassi();
            listBox.SelectedIndex = -1;
        }

        private void AddTreeNodesTipologie(TreeNodeCollection treeNodes)
        {
            treeNodes.Clear();
            foreach (string name in TipologiaFactory.GetNomeTipologie())
            {
                TreeNode treeNode = new TreeNode(name);
                treeNode.Tag = name;
                treeNodes.Add(treeNode);
                AddChilds(name, treeNode.Nodes);
            }
        }

        private void AddChilds(string typeName, TreeNodeCollection root)
        {
            foreach (ITipologia tipologia in TipologiaFactory.GetTipologie())
            {
                if (tipologia.GetType().Name == typeName)
                {
                    TreeNode treeNode = new TreeNode(tipologia.Name);
                    treeNode.Tag = tipologia;
                    root.Add(treeNode);
                }
            }
        }
        public void RefreshControl()
        {    
            AddTreeNodesTipologie(_treeView.Nodes);
            _treeView.ExpandAll();
            AddClassiToList(_listBoxClassi);
        }

        private void _dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_dataGridView.Columns[e.ColumnIndex].Name.Equals("Tipologia"))
            {
                ITipologia tipologia = e.Value as ITipologia;
                if (tipologia != null)
                    e.Value = tipologia.Name;
            }
        }

        public void SetVisiblePanel(bool visible)
        {
            _selezionePanel.Visible = visible;
        }
    }
}

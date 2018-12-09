namespace WSS_Prototipo.Presentazione
{
    partial class RequisitiViewControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._selezionePanel = new System.Windows.Forms.Panel();
            this._reset = new System.Windows.Forms.Button();
            this._piùRichiestiCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._treeView = new System.Windows.Forms.TreeView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._listBoxClassi = new System.Windows.Forms.ListBox();
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._selezionePanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _selezionePanel
            // 
            this._selezionePanel.AutoScroll = true;
            this._selezionePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._selezionePanel.Controls.Add(this._reset);
            this._selezionePanel.Controls.Add(this._piùRichiestiCheckBox);
            this._selezionePanel.Controls.Add(this.groupBox2);
            this._selezionePanel.Controls.Add(this.groupBox3);
            this._selezionePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this._selezionePanel.Location = new System.Drawing.Point(506, 0);
            this._selezionePanel.Name = "_selezionePanel";
            this._selezionePanel.Padding = new System.Windows.Forms.Padding(5);
            this._selezionePanel.Size = new System.Drawing.Size(174, 410);
            this._selezionePanel.TabIndex = 0;
            // 
            // _reset
            // 
            this._reset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._reset.Location = new System.Drawing.Point(34, 365);
            this._reset.Name = "_reset";
            this._reset.Size = new System.Drawing.Size(103, 23);
            this._reset.TabIndex = 7;
            this._reset.Text = "Reset Selezioni";
            this._reset.UseVisualStyleBackColor = true;
            // 
            // _piùRichiestiCheckBox
            // 
            this._piùRichiestiCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._piùRichiestiCheckBox.AutoSize = true;
            this._piùRichiestiCheckBox.Location = new System.Drawing.Point(9, 333);
            this._piùRichiestiCheckBox.Name = "_piùRichiestiCheckBox";
            this._piùRichiestiCheckBox.Size = new System.Drawing.Size(84, 17);
            this._piùRichiestiCheckBox.TabIndex = 6;
            this._piùRichiestiCheckBox.Text = "Più Richiesti";
            this._piùRichiestiCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._treeView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(5, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(162, 224);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipologie";
            // 
            // _treeView
            // 
            this._treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeView.Location = new System.Drawing.Point(3, 16);
            this._treeView.Name = "_treeView";
            this._treeView.Size = new System.Drawing.Size(156, 205);
            this._treeView.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._listBoxClassi);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(5, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(162, 97);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Classi";
            // 
            // _listBoxClassi
            // 
            this._listBoxClassi.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listBoxClassi.FormattingEnabled = true;
            this._listBoxClassi.Location = new System.Drawing.Point(3, 16);
            this._listBoxClassi.Name = "_listBoxClassi";
            this._listBoxClassi.Size = new System.Drawing.Size(156, 78);
            this._listBoxClassi.TabIndex = 0;
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AllowUserToDeleteRows = false;
            this._dataGridView.AllowUserToOrderColumns = true;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridView.Location = new System.Drawing.Point(0, 0);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.ReadOnly = true;
            this._dataGridView.Size = new System.Drawing.Size(506, 410);
            this._dataGridView.TabIndex = 1;
            this._dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this._dataGridView_CellFormatting);
            // 
            // RequisitiViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._dataGridView);
            this.Controls.Add(this._selezionePanel);
            this.Name = "RequisitiViewControl";
            this.Size = new System.Drawing.Size(680, 410);
            this._selezionePanel.ResumeLayout(false);
            this._selezionePanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _selezionePanel;
        private System.Windows.Forms.DataGridView _dataGridView;
        private System.Windows.Forms.TreeView _treeView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox _listBoxClassi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox _piùRichiestiCheckBox;
        private System.Windows.Forms.Button _reset;

    }
}

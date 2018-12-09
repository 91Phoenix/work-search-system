namespace WSS_Prototipo.Presentazione
{
    partial class EditingRequisitiControl
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
            this._requisitiList = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._treeView = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this._nomeReq = new System.Windows.Forms.TextBox();
            this._checkNewTip = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this._nomeTip = new System.Windows.Forms.TextBox();
            this._tipologie = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._checkNew = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this._gradoValutazione = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // _requisitiList
            // 
            this._requisitiList.Dock = System.Windows.Forms.DockStyle.Left;
            this._requisitiList.FormattingEnabled = true;
            this._requisitiList.HorizontalScrollbar = true;
            this._requisitiList.Location = new System.Drawing.Point(0, 0);
            this._requisitiList.Name = "_requisitiList";
            this._requisitiList.Size = new System.Drawing.Size(406, 194);
            this._requisitiList.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 365);
            this.panel1.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this._requisitiList);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(732, 194);
            this.panel4.TabIndex = 21;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this._treeView);
            this.groupBox2.Location = new System.Drawing.Point(410, 1);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 194);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleziona per Tipologia";
            // 
            // _treeView
            // 
            this._treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeView.Location = new System.Drawing.Point(3, 16);
            this._treeView.Name = "_treeView";
            this._treeView.Size = new System.Drawing.Size(316, 175);
            this._treeView.TabIndex = 2;
            this._treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._treeView_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this._checkNew);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this._gradoValutazione);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 194);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(732, 171);
            this.panel2.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._nomeReq);
            this.panel3.Controls.Add(this._checkNewTip);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this._nomeTip);
            this.panel3.Controls.Add(this._tipologie);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 85);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(732, 86);
            this.panel3.TabIndex = 3;
            this.panel3.Visible = false;
            // 
            // _nomeReq
            // 
            this._nomeReq.Location = new System.Drawing.Point(117, 20);
            this._nomeReq.Multiline = true;
            this._nomeReq.Name = "_nomeReq";
            this._nomeReq.Size = new System.Drawing.Size(121, 17);
            this._nomeReq.TabIndex = 3;
            // 
            // _checkNewTip
            // 
            this._checkNewTip.AutoSize = true;
            this._checkNewTip.Location = new System.Drawing.Point(299, 51);
            this._checkNewTip.Name = "_checkNewTip";
            this._checkNewTip.Size = new System.Drawing.Size(208, 17);
            this._checkNewTip.TabIndex = 7;
            this._checkNewTip.Text = "inserisci un nuova tipologia nel sistema";
            this._checkNewTip.UseVisualStyleBackColor = true;
            this._checkNewTip.CheckedChanged += new System.EventHandler(this._checkNewTip_CheckedChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(521, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nome della tipologia";
            // 
            // _nomeTip
            // 
            this._nomeTip.Enabled = false;
            this._nomeTip.Location = new System.Drawing.Point(523, 47);
            this._nomeTip.Name = "_nomeTip";
            this._nomeTip.Size = new System.Drawing.Size(100, 20);
            this._nomeTip.TabIndex = 10;
            // 
            // _tipologie
            // 
            this._tipologie.FormattingEnabled = true;
            this._tipologie.Location = new System.Drawing.Point(117, 47);
            this._tipologie.Name = "_tipologie";
            this._tipologie.Size = new System.Drawing.Size(121, 21);
            this._tipologie.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "oppure";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "seleziona tipologia";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nome del requisito";
            // 
            // _checkNew
            // 
            this._checkNew.AutoSize = true;
            this._checkNew.Location = new System.Drawing.Point(17, 62);
            this._checkNew.Name = "_checkNew";
            this._checkNew.Size = new System.Drawing.Size(208, 17);
            this._checkNew.TabIndex = 2;
            this._checkNew.Text = "inserisci un nuovo requisito nel sistema";
            this._checkNew.UseVisualStyleBackColor = true;
            this._checkNew.CheckedChanged += new System.EventHandler(this._checkNew_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Campo obligatorio :";
            // 
            // _gradoValutazione
            // 
            this._gradoValutazione.FormattingEnabled = true;
            this._gradoValutazione.Location = new System.Drawing.Point(196, 23);
            this._gradoValutazione.Name = "_gradoValutazione";
            this._gradoValutazione.Size = new System.Drawing.Size(121, 21);
            this._gradoValutazione.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "grado di valutazione del requisito ";
            // 
            // EditingRequisitiControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "EditingRequisitiControl";
            this.Size = new System.Drawing.Size(732, 365);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox _requisitiList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox _checkNew;
        private System.Windows.Forms.ComboBox _gradoValutazione;
        private System.Windows.Forms.ComboBox _tipologie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _nomeTip;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _nomeReq;
        private System.Windows.Forms.CheckBox _checkNewTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView _treeView;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;

    }
}

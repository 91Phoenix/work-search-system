namespace WSS_Prototipo.Presentazione
{
    partial class EditingDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this._resetButton = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._annullaButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this._addEsperienzaButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._listBox = new System.Windows.Forms.ListBox();
            this._rimuoviButton = new System.Windows.Forms.Button();
            this._splitter = new WSS_Prototipo.Presentazione.EditingDocumentControl();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this._resetButton);
            this.panel2.Controls.Add(this._okButton);
            this.panel2.Controls.Add(this._annullaButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 351);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(657, 75);
            this.panel2.TabIndex = 1;
            // 
            // _resetButton
            // 
            this._resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this._resetButton.Location = new System.Drawing.Point(11, 25);
            this._resetButton.Name = "_resetButton";
            this._resetButton.Size = new System.Drawing.Size(75, 23);
            this._resetButton.TabIndex = 2;
            this._resetButton.Text = "Reset";
            this._resetButton.UseVisualStyleBackColor = true;
            this._resetButton.Click += new System.EventHandler(this._resetButton_Click);
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Enabled = false;
            this._okButton.Location = new System.Drawing.Point(488, 25);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 1;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _annullaButton
            // 
            this._annullaButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._annullaButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._annullaButton.Location = new System.Drawing.Point(569, 25);
            this._annullaButton.Name = "_annullaButton";
            this._annullaButton.Size = new System.Drawing.Size(75, 23);
            this._annullaButton.TabIndex = 0;
            this._annullaButton.Text = "Annulla";
            this._annullaButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._rimuoviButton);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(128, 213);
            this.panel1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this._addEsperienzaButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 140);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Aggiungi requisito di:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(22, 106);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Lingua";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this._addReqLinguaButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Formazione";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this._addReqFormazioneButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Competenza";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this._addReqCompetenzaButton_Click);
            // 
            // _addEsperienzaButton
            // 
            this._addEsperienzaButton.Location = new System.Drawing.Point(22, 19);
            this._addEsperienzaButton.Name = "_addEsperienzaButton";
            this._addEsperienzaButton.Size = new System.Drawing.Size(75, 23);
            this._addEsperienzaButton.TabIndex = 0;
            this._addEsperienzaButton.Text = "Esperienza";
            this._addEsperienzaButton.UseVisualStyleBackColor = true;
            this._addEsperienzaButton.Click += new System.EventHandler(this._addReqEsperienzaButton_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.splitContainer1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(657, 351);
            this.panel4.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._splitter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._listBox);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(657, 351);
            this.splitContainer1.SplitterDistance = 134;
            this.splitContainer1.TabIndex = 1;
            // 
            // _listBox
            // 
            this._listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listBox.FormattingEnabled = true;
            this._listBox.Location = new System.Drawing.Point(128, 0);
            this._listBox.Name = "_listBox";
            this._listBox.Size = new System.Drawing.Size(529, 213);
            this._listBox.TabIndex = 0;
            // 
            // _rimuoviButton
            // 
            this._rimuoviButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._rimuoviButton.Location = new System.Drawing.Point(27, 182);
            this._rimuoviButton.Name = "_rimuoviButton";
            this._rimuoviButton.Size = new System.Drawing.Size(75, 23);
            this._rimuoviButton.TabIndex = 5;
            this._rimuoviButton.Text = "Rimuovi";
            this._rimuoviButton.UseVisualStyleBackColor = true;
            this._rimuoviButton.Click += new System.EventHandler(this._rimuoviButton_Click);
            // 
            // _splitter
            // 
            this._splitter.AutoScroll = true;
            this._splitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitter.Location = new System.Drawing.Point(0, 0);
            this._splitter.Name = "_splitter";
            this._splitter.Padding = new System.Windows.Forms.Padding(10);
            this._splitter.Size = new System.Drawing.Size(657, 134);
            this._splitter.TabIndex = 0;
            this._splitter.HasErrorChanged += new System.EventHandler(this._editingControl_HasErrorChanged);
            // 
            // EditingDialog
            // 
            this.AcceptButton = this._okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._annullaButton;
            this.ClientSize = new System.Drawing.Size(657, 426);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Name = "EditingDialog";
            this.Text = "EditingDialog";
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button _resetButton;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _annullaButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button _addEsperienzaButton;
        private System.Windows.Forms.Panel panel4;
        private EditingDocumentControl _splitter;
        private System.Windows.Forms.ListBox _listBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button _rimuoviButton;

    }
}
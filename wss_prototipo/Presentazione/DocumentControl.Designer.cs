namespace WSS_Prototipo.Presentazione
{
    partial class DocumentControl
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
            this.components = new System.ComponentModel.Container();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this._panelBottom = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._linguaButton = new System.Windows.Forms.Button();
            this._formazioneButton = new System.Windows.Forms.Button();
            this._competenzaButton = new System.Windows.Forms.Button();
            this._esperienzaButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._groupBoxAssociazioni = new System.Windows.Forms.GroupBox();
            this._newRequisitiListBox = new System.Windows.Forms.ListBox();
            this._associazioniDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._requsitiListBox = new System.Windows.Forms.ListBox();
            this._splitContainer = new System.Windows.Forms.SplitContainer();
            this._rimuoviButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this._panelBottom.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this._groupBoxAssociazioni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._associazioniDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).BeginInit();
            this._splitContainer.Panel1.SuspendLayout();
            this._splitContainer.Panel2.SuspendLayout();
            this._splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // _errorProvider
            // 
            this._errorProvider.ContainerControl = this;
            // 
            // _panelBottom
            // 
            this._panelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._panelBottom.Controls.Add(this._rimuoviButton);
            this._panelBottom.Controls.Add(this.groupBox1);
            this._panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._panelBottom.Location = new System.Drawing.Point(10, 332);
            this._panelBottom.Name = "_panelBottom";
            this._panelBottom.Padding = new System.Windows.Forms.Padding(4);
            this._panelBottom.Size = new System.Drawing.Size(534, 62);
            this._panelBottom.TabIndex = 1;
            this._panelBottom.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._linguaButton);
            this.groupBox1.Controls.Add(this._formazioneButton);
            this.groupBox1.Controls.Add(this._competenzaButton);
            this.groupBox1.Controls.Add(this._esperienzaButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 52);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Aggiungi requisito di:";
            // 
            // _linguaButton
            // 
            this._linguaButton.Location = new System.Drawing.Point(6, 19);
            this._linguaButton.Name = "_linguaButton";
            this._linguaButton.Size = new System.Drawing.Size(75, 23);
            this._linguaButton.TabIndex = 4;
            this._linguaButton.Text = "Lingua";
            this._linguaButton.UseVisualStyleBackColor = true;
            this._linguaButton.Click += new System.EventHandler(this._linguaButton_Click);
            // 
            // _formazioneButton
            // 
            this._formazioneButton.Location = new System.Drawing.Point(249, 19);
            this._formazioneButton.Name = "_formazioneButton";
            this._formazioneButton.Size = new System.Drawing.Size(75, 23);
            this._formazioneButton.TabIndex = 5;
            this._formazioneButton.Text = "Formazione";
            this._formazioneButton.UseVisualStyleBackColor = true;
            this._formazioneButton.Click += new System.EventHandler(this._formazioneButton_Click);
            // 
            // _competenzaButton
            // 
            this._competenzaButton.Location = new System.Drawing.Point(87, 19);
            this._competenzaButton.Name = "_competenzaButton";
            this._competenzaButton.Size = new System.Drawing.Size(75, 23);
            this._competenzaButton.TabIndex = 3;
            this._competenzaButton.Text = "Competenza";
            this._competenzaButton.UseVisualStyleBackColor = true;
            this._competenzaButton.Click += new System.EventHandler(this._competenzaButton_Click);
            // 
            // _esperienzaButton
            // 
            this._esperienzaButton.Location = new System.Drawing.Point(168, 19);
            this._esperienzaButton.Name = "_esperienzaButton";
            this._esperienzaButton.Size = new System.Drawing.Size(75, 23);
            this._esperienzaButton.TabIndex = 2;
            this._esperienzaButton.Text = "Esperienza";
            this._esperienzaButton.UseVisualStyleBackColor = true;
            this._esperienzaButton.Click += new System.EventHandler(this._esperienzaButton_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this._tableLayoutPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(534, 161);
            this.panel2.TabIndex = 2;
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.AutoScroll = true;
            this._tableLayoutPanel.ColumnCount = 2;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel.Location = new System.Drawing.Point(10, 10);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 2;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.Size = new System.Drawing.Size(512, 139);
            this._tableLayoutPanel.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(534, 157);
            this.panel3.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this._groupBoxAssociazioni, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(522, 145);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // _groupBoxAssociazioni
            // 
            this._groupBoxAssociazioni.Controls.Add(this._newRequisitiListBox);
            this._groupBoxAssociazioni.Controls.Add(this._associazioniDataGridView);
            this._groupBoxAssociazioni.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBoxAssociazioni.Location = new System.Drawing.Point(264, 3);
            this._groupBoxAssociazioni.Name = "_groupBoxAssociazioni";
            this._groupBoxAssociazioni.Size = new System.Drawing.Size(255, 139);
            this._groupBoxAssociazioni.TabIndex = 1;
            this._groupBoxAssociazioni.TabStop = false;
            this._groupBoxAssociazioni.Text = "Associazioni:";
            // 
            // _newRequisitiListBox
            // 
            this._newRequisitiListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._newRequisitiListBox.FormattingEnabled = true;
            this._newRequisitiListBox.Location = new System.Drawing.Point(3, 16);
            this._newRequisitiListBox.Name = "_newRequisitiListBox";
            this._newRequisitiListBox.Size = new System.Drawing.Size(249, 120);
            this._newRequisitiListBox.TabIndex = 1;
            this._newRequisitiListBox.Visible = false;
            // 
            // _associazioniDataGridView
            // 
            this._associazioniDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._associazioniDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._associazioniDataGridView.Location = new System.Drawing.Point(3, 16);
            this._associazioniDataGridView.Name = "_associazioniDataGridView";
            this._associazioniDataGridView.Size = new System.Drawing.Size(249, 120);
            this._associazioniDataGridView.TabIndex = 0;
            this._associazioniDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this._associazioniDataGridView_CellFormatting);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._requsitiListBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(255, 139);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Requisiti Personali:";
            // 
            // _requsitiListBox
            // 
            this._requsitiListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._requsitiListBox.FormattingEnabled = true;
            this._requsitiListBox.Location = new System.Drawing.Point(3, 16);
            this._requsitiListBox.Name = "_requsitiListBox";
            this._requsitiListBox.Size = new System.Drawing.Size(249, 120);
            this._requsitiListBox.TabIndex = 0;
            // 
            // _splitContainer
            // 
            this._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer.Location = new System.Drawing.Point(10, 10);
            this._splitContainer.Name = "_splitContainer";
            this._splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _splitContainer.Panel1
            // 
            this._splitContainer.Panel1.Controls.Add(this.panel2);
            // 
            // _splitContainer.Panel2
            // 
            this._splitContainer.Panel2.Controls.Add(this.panel3);
            this._splitContainer.Size = new System.Drawing.Size(534, 322);
            this._splitContainer.SplitterDistance = 161;
            this._splitContainer.TabIndex = 4;
            // 
            // _rimuoviButton
            // 
            this._rimuoviButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._rimuoviButton.Location = new System.Drawing.Point(446, 23);
            this._rimuoviButton.Name = "_rimuoviButton";
            this._rimuoviButton.Size = new System.Drawing.Size(75, 23);
            this._rimuoviButton.TabIndex = 7;
            this._rimuoviButton.Text = "Rimuovi";
            this._rimuoviButton.UseVisualStyleBackColor = true;
            this._rimuoviButton.Click += new System.EventHandler(this._rimuoviButton_Click);
            // 
            // DocumentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._splitContainer);
            this.Controls.Add(this._panelBottom);
            this.Name = "DocumentControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(554, 404);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this._panelBottom.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this._groupBoxAssociazioni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._associazioniDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this._splitContainer.Panel1.ResumeLayout(false);
            this._splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).EndInit();
            this._splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider _errorProvider;
        private System.Windows.Forms.Panel _panelBottom;
        private System.Windows.Forms.Button _formazioneButton;
        private System.Windows.Forms.Button _linguaButton;
        private System.Windows.Forms.Button _competenzaButton;
        private System.Windows.Forms.Button _esperienzaButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox _groupBoxAssociazioni;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView _associazioniDataGridView;
        private System.Windows.Forms.ListBox _requsitiListBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer _splitContainer;
        private System.Windows.Forms.ListBox _newRequisitiListBox;
        private System.Windows.Forms.Button _rimuoviButton;

    }
}

namespace WSS_Prototipo.Presentazione
{
    partial class RequisitiFittiziControl
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
            this._rimuovi = new System.Windows.Forms.Button();
            this._aggiungi = new System.Windows.Forms.Button();
            this._gradiValutazione = new System.Windows.Forms.ComboBox();
            this._requisitiSelezionati = new System.Windows.Forms.ListBox();
            this._splitContainer = new System.Windows.Forms.SplitContainer();
            this._requisitiViewControl = new WSS_Prototipo.Presentazione.RequisitiViewControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).BeginInit();
            this._splitContainer.Panel1.SuspendLayout();
            this._splitContainer.Panel2.SuspendLayout();
            this._splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _rimuovi
            // 
            this._rimuovi.Location = new System.Drawing.Point(106, 12);
            this._rimuovi.Name = "_rimuovi";
            this._rimuovi.Size = new System.Drawing.Size(75, 23);
            this._rimuovi.TabIndex = 5;
            this._rimuovi.Text = "Rimuovi";
            this._rimuovi.UseVisualStyleBackColor = true;
            this._rimuovi.Click += new System.EventHandler(this._rimuovi_Click);
            // 
            // _aggiungi
            // 
            this._aggiungi.Location = new System.Drawing.Point(25, 12);
            this._aggiungi.Name = "_aggiungi";
            this._aggiungi.Size = new System.Drawing.Size(75, 23);
            this._aggiungi.TabIndex = 4;
            this._aggiungi.Text = "Aggiungi";
            this._aggiungi.UseVisualStyleBackColor = true;
            this._aggiungi.Click += new System.EventHandler(this._aggiungi_Click);
            // 
            // _gradiValutazione
            // 
            this._gradiValutazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._gradiValutazione.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._gradiValutazione.DropDownWidth = 341;
            this._gradiValutazione.FormattingEnabled = true;
            this._gradiValutazione.Location = new System.Drawing.Point(605, 14);
            this._gradiValutazione.Name = "_gradiValutazione";
            this._gradiValutazione.Size = new System.Drawing.Size(135, 21);
            this._gradiValutazione.TabIndex = 3;
            // 
            // _requisitiSelezionati
            // 
            this._requisitiSelezionati.Dock = System.Windows.Forms.DockStyle.Fill;
            this._requisitiSelezionati.FormattingEnabled = true;
            this._requisitiSelezionati.Location = new System.Drawing.Point(0, 0);
            this._requisitiSelezionati.Name = "_requisitiSelezionati";
            this._requisitiSelezionati.Size = new System.Drawing.Size(360, 419);
            this._requisitiSelezionati.TabIndex = 0;
            // 
            // _splitContainer
            // 
            this._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer.Location = new System.Drawing.Point(0, 0);
            this._splitContainer.Name = "_splitContainer";
            // 
            // _splitContainer.Panel1
            // 
            this._splitContainer.Panel1.Controls.Add(this._requisitiSelezionati);
            // 
            // _splitContainer.Panel2
            // 
            this._splitContainer.Panel2.Controls.Add(this._requisitiViewControl);
            this._splitContainer.Size = new System.Drawing.Size(775, 419);
            this._splitContainer.SplitterDistance = 360;
            this._splitContainer.TabIndex = 6;
            // 
            // _requisitiViewControl
            // 
            this._requisitiViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._requisitiViewControl.Location = new System.Drawing.Point(0, 0);
            this._requisitiViewControl.Name = "_requisitiViewControl";
            this._requisitiViewControl.Size = new System.Drawing.Size(411, 419);
            this._requisitiViewControl.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._aggiungi);
            this.panel1.Controls.Add(this._rimuovi);
            this.panel1.Controls.Add(this._gradiValutazione);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(10, 429);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 48);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(492, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Grado di valutazione:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._splitContainer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(775, 419);
            this.panel2.TabIndex = 8;
            // 
            // RequisitiFittiziControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "RequisitiFittiziControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(795, 487);
            this._splitContainer.Panel1.ResumeLayout(false);
            this._splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).EndInit();
            this._splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _rimuovi;
        private System.Windows.Forms.Button _aggiungi;
        private System.Windows.Forms.ComboBox _gradiValutazione;
        private System.Windows.Forms.ListBox _requisitiSelezionati;
        private System.Windows.Forms.SplitContainer _splitContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private RequisitiViewControl _requisitiViewControl;

    }
}

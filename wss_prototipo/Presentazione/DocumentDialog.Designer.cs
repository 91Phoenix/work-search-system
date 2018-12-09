namespace WSS_Prototipo.Presentazione
{
    partial class DocumentDialog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this._reset = new System.Windows.Forms.Button();
            this._okButton = new System.Windows.Forms.Button();
            this._cancel = new System.Windows.Forms.Button();
            this._documentControl = new WSS_Prototipo.Presentazione.DocumentControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this._reset);
            this.panel1.Controls.Add(this._okButton);
            this.panel1.Controls.Add(this._cancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 399);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 55);
            this.panel1.TabIndex = 0;
            // 
            // _reset
            // 
            this._reset.Location = new System.Drawing.Point(12, 16);
            this._reset.Name = "_reset";
            this._reset.Size = new System.Drawing.Size(75, 23);
            this._reset.TabIndex = 2;
            this._reset.Text = "Reset";
            this._reset.UseVisualStyleBackColor = true;
            this._reset.Click += new System.EventHandler(this._reset_Click);
            // 
            // _okButton
            // 
            this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._okButton.Location = new System.Drawing.Point(545, 16);
            this._okButton.Name = "_okButton";
            this._okButton.Size = new System.Drawing.Size(75, 23);
            this._okButton.TabIndex = 1;
            this._okButton.Text = "OK";
            this._okButton.UseVisualStyleBackColor = true;
            // 
            // _cancel
            // 
            this._cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancel.Location = new System.Drawing.Point(626, 16);
            this._cancel.Name = "_cancel";
            this._cancel.Size = new System.Drawing.Size(75, 23);
            this._cancel.TabIndex = 0;
            this._cancel.Text = "Annulla";
            this._cancel.UseVisualStyleBackColor = true;
            // 
            // _documentControl
            // 
            this._documentControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._documentControl.Location = new System.Drawing.Point(0, 0);
            this._documentControl.Name = "_documentControl";
            this._documentControl.Padding = new System.Windows.Forms.Padding(10);
            this._documentControl.Size = new System.Drawing.Size(715, 399);
            this._documentControl.TabIndex = 1;
            this._documentControl.HasErrorChanged += new System.EventHandler(this._documentControl_HasErrorChanged);
            // 
            // DocumentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 454);
            this.Controls.Add(this._documentControl);
            this.Controls.Add(this.panel1);
            this.Name = "DocumentDialog";
            this.Text = "DocumentDialog";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _reset;
        private System.Windows.Forms.Button _okButton;
        private System.Windows.Forms.Button _cancel;
        private DocumentControl _documentControl;
    }
}
namespace WSS_Prototipo.Presentazione
{
    partial class EditingRequisitiDialog
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
            this._add = new System.Windows.Forms.Button();
            this._annulla = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._editingRequisitiControl = new WSS_Prototipo.Presentazione.EditingRequisitiControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _add
            // 
            this._add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._add.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._add.Location = new System.Drawing.Point(566, 16);
            this._add.Name = "_add";
            this._add.Padding = new System.Windows.Forms.Padding(3);
            this._add.Size = new System.Drawing.Size(110, 29);
            this._add.TabIndex = 1;
            this._add.Text = "Aggiungi Requisito ";
            this._add.UseVisualStyleBackColor = true;
            // 
            // _annulla
            // 
            this._annulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._annulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._annulla.Location = new System.Drawing.Point(452, 16);
            this._annulla.Name = "_annulla";
            this._annulla.Size = new System.Drawing.Size(108, 28);
            this._annulla.TabIndex = 2;
            this._annulla.Text = "Annulla";
            this._annulla.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this._annulla);
            this.panel1.Controls.Add(this._add);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 283);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(689, 58);
            this.panel1.TabIndex = 3;
            // 
            // _editingRequisitiControl
            // 
            this._editingRequisitiControl.AutoScroll = true;
            this._editingRequisitiControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._editingRequisitiControl.Location = new System.Drawing.Point(0, 0);
            this._editingRequisitiControl.Name = "_editingRequisitiControl";
            this._editingRequisitiControl.Size = new System.Drawing.Size(689, 283);
            this._editingRequisitiControl.TabIndex = 4;
            // 
            // RequisitiDialog
            // 
            this.AcceptButton = this._add;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.CancelButton = this._annulla;
            this.ClientSize = new System.Drawing.Size(689, 341);
            this.Controls.Add(this._editingRequisitiControl);
            this.Controls.Add(this.panel1);
            this.Name = "RequisitiDialog";
            this.Text = "RequisitiDialog";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _add;
        private System.Windows.Forms.Button _annulla;
        private System.Windows.Forms.Panel panel1;
        private EditingRequisitiControl _editingRequisitiControl;
    }
}
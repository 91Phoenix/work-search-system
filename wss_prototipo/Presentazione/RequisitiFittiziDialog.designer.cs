namespace WSS_Prototipo.Presentazione
{
    partial class RequisitiFittiziDialog
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
            this._annulla = new System.Windows.Forms.Button();
            this._ok = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this._requisitiFittiziControl = new WSS_Prototipo.Presentazione.RequisitiFittiziControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this._annulla);
            this.panel1.Controls.Add(this._ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 470);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 58);
            this.panel1.TabIndex = 0;
            // 
            // _annulla
            // 
            this._annulla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._annulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._annulla.Location = new System.Drawing.Point(776, 22);
            this._annulla.Name = "_annulla";
            this._annulla.Size = new System.Drawing.Size(75, 23);
            this._annulla.TabIndex = 1;
            this._annulla.Text = "Annulla";
            this._annulla.UseVisualStyleBackColor = true;
            // 
            // _ok
            // 
            this._ok.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._ok.Location = new System.Drawing.Point(695, 22);
            this._ok.Name = "_ok";
            this._ok.Size = new System.Drawing.Size(75, 23);
            this._ok.TabIndex = 0;
            this._ok.Text = "Ok";
            this._ok.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._requisitiFittiziControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(864, 470);
            this.panel2.TabIndex = 1;
            // 
            // _requisitiFittiziControl
            // 
            this._requisitiFittiziControl.AutoScroll = true;
            this._requisitiFittiziControl.AutoSize = true;
            this._requisitiFittiziControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._requisitiFittiziControl.Location = new System.Drawing.Point(0, 0);
            this._requisitiFittiziControl.Name = "_requisitiFittiziControl";
            this._requisitiFittiziControl.Padding = new System.Windows.Forms.Padding(10);
            this._requisitiFittiziControl.Size = new System.Drawing.Size(864, 470);
            this._requisitiFittiziControl.TabIndex = 0;
            // 
            // RequisitiFittiziDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 528);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "RequisitiFittiziDialog";
            this.Text = "AddRequisitiFittiziDialog";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button _annulla;
        private System.Windows.Forms.Button _ok;
        private RequisitiFittiziControl _requisitiFittiziControl;
    }
}
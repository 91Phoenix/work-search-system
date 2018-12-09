namespace WSS_Prototipo.Presentazione
{
    partial class GraduatoriaFittiziaControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._dataGraduatoria = new System.Windows.Forms.DataGridView();
            this._dataGraduatoriaFittizia = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGraduatoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGraduatoriaFittizia)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._dataGraduatoria);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._dataGraduatoriaFittizia);
            this.splitContainer1.Size = new System.Drawing.Size(624, 390);
            this.splitContainer1.SplitterDistance = 320;
            this.splitContainer1.TabIndex = 0;
            // 
            // _dataGraduatoria
            // 
            this._dataGraduatoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGraduatoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGraduatoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGraduatoria.Location = new System.Drawing.Point(0, 0);
            this._dataGraduatoria.Name = "_dataGraduatoria";
            this._dataGraduatoria.ReadOnly = true;
            this._dataGraduatoria.Size = new System.Drawing.Size(320, 390);
            this._dataGraduatoria.TabIndex = 0;
            // 
            // _dataGraduatoriaFittizia
            // 
            this._dataGraduatoriaFittizia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGraduatoriaFittizia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGraduatoriaFittizia.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGraduatoriaFittizia.Location = new System.Drawing.Point(0, 0);
            this._dataGraduatoriaFittizia.Name = "_dataGraduatoriaFittizia";
            this._dataGraduatoriaFittizia.ReadOnly = true;
            this._dataGraduatoriaFittizia.Size = new System.Drawing.Size(300, 390);
            this._dataGraduatoriaFittizia.TabIndex = 0;
            // 
            // GraduatoriaFittiziaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "GraduatoriaFittiziaControl";
            this.Size = new System.Drawing.Size(624, 390);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGraduatoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGraduatoriaFittizia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView _dataGraduatoria;
        private System.Windows.Forms.DataGridView _dataGraduatoriaFittizia;
    }
}

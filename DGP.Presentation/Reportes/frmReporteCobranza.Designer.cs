namespace DGP.Presentation.Reportes
{
    partial class frmReporteCobranza
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.crvCobranza = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvCobranza
            // 
            this.crvCobranza.ActiveViewIndex = -1;
            this.crvCobranza.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.crvCobranza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvCobranza.Location = new System.Drawing.Point(12, 12);
            this.crvCobranza.Name = "crvCobranza";
            this.crvCobranza.Size = new System.Drawing.Size(778, 446);
            this.crvCobranza.TabIndex = 0;
            // 
            // frmReporteCobranza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 470);
            this.Controls.Add(this.crvCobranza);
            this.Name = "frmReporteCobranza";
            this.Text = "frmReporteCobranza";
            this.Load += new System.EventHandler(this.frmReporteCobranza_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvCobranza;


    }
}
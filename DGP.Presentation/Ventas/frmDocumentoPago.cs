using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DGP.Presentation.Ventas
{
    public partial class frmDocumentoPago : Form
    {
        public frmDocumentoPago(BindingSource bs)
        {
            InitializeComponent();

            this.bindingSource1.DataSource = bs.DataSource;
        }

        private void frmDocumentoPago_Load(object sender, EventArgs e)
        {
            txtIdDocumento.DataBindings.Add("Text", bindingSource1, "IdDocumento");
            txtTipoDoc.DataBindings.Add("Text", bindingSource1, "IdTipoDocumento");
            dtFecha.DataBindings.Add("Text", bindingSource1, "Fecha");
            txtEstado.DataBindings.Add("Text", bindingSource1, "estado");
            numericUpDown1.DataBindings.Add("Text", bindingSource1, "Monto");
        }

        private void btnMostrarDetalle_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }


    }
}

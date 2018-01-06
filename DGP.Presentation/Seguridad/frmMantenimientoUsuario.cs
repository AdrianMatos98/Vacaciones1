using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DGP.BusinessLogic.Seguridad;
using DGP.Entities.Seguridad;



namespace DGP.Presentation.Seguridad
{
    public partial class frmMantenimientoUsuario : Form
    {
        public frmMantenimientoUsuario()
        {
            InitializeComponent();
        }

        private void frmMantenimientoUsuario_Load(object sender, EventArgs e)
        {
            cargarPersonal();
            this.bdsPerfil.DataSource = (new BLPerfil()).ListarPerfil(new BEPerfil());

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dgvUsuarios.Columns[e.ColumnIndex].Name == "claveDataGridViewTextBoxColumn" && e.Value != null && dgvUsuarios.Columns[e.ColumnIndex].DataPropertyName == "Clave")
                {
                    dgvUsuarios.Rows[e.RowIndex].Tag = e.Value;
                    e.Value = new String('\u2022', e.Value.ToString().Length);
                }

            }  
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvUsuarios.CurrentRow.Tag != null && dgvUsuarios.Columns[dgvUsuarios.CurrentCell.ColumnIndex].HeaderText == "Clave") e.Control.Text = dgvUsuarios.CurrentRow.Tag.ToString();

            
            
        }

        private void btnAgregarPersonal_Click(object sender, EventArgs e)
        {
            try
            {
                string pmensaje= string.Empty;
                if (!validar( ref pmensaje))
                {
                    MessageBox.Show(this, pmensaje, "Error", MessageBoxButtons.OK);
                    return;
                
                }
                
                BEPersonal oBEPersonal = new BEPersonal();
                oBEPersonal.Login = this.txtLogin.Text;
                oBEPersonal.Clave = this.txtPassword.Text;
                oBEPersonal.correo = this.txtCorreo.Text;
                oBEPersonal.Direccion = this.txtDireccion.Text;
                oBEPersonal.DNI = this.txtDNI.Text;
                oBEPersonal.Estado = 1;
                oBEPersonal.idPerfil = (int)this.cmbPerfil.SelectedValue;
                oBEPersonal.Nombre = txtNombre.Text;
                oBEPersonal.Auditoria = VariablesSession.BEUsuarioSession;
                BLPersonal oBLPersonal = new BLPersonal();
                bool bOk = oBLPersonal.InsertarPersonal(ref pmensaje, oBEPersonal);

                if (!bOk)
                {
                    MessageBox.Show(this, pmensaje, "Error", MessageBoxButtons.OK);
                    return;
                }
                this.cargarPersonal();


            }
            catch (Exception ex)
            {

                MessageBox.Show("Ha ocurrido un Error, Cierre la ventada, el detalle del error: "+ ex.Message+ " \n Trace : "+ ex.StackTrace);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private bool validar(ref string pmensaje)
        {
            //bool bOK = true;
            pmensaje = string.Empty;
            pmensaje += string.IsNullOrEmpty(this.txtNombre.Text.Trim()) ? "Ingrese el Nombre.\n" : string.Empty;
            pmensaje += string.IsNullOrEmpty(this.txtDNI.Text.Trim()) ? "Ingrese el DNI.\n" : string.Empty;
            pmensaje += string.IsNullOrEmpty(this.txtLogin.Text.Trim()) ? "Ingrese un login.\n" : string.Empty;
            pmensaje += string.IsNullOrEmpty(this.txtPassword.Text.Trim()) ? "Debe Ingresar Clave o Password.\n" : string.Empty;
            pmensaje += string.IsNullOrEmpty(this.txtConfirmPassword.Text.Trim()) ? "Debe Confirmar Clave o Password.\n" : string.Empty;
            pmensaje += (this.txtPassword.Text.Trim() != this.txtConfirmPassword.Text.Trim()) ? "Debe Confirmar el password" : "";
            
            return (string.IsNullOrEmpty(pmensaje));
        
        }
        private void  cargarPersonal()
        {
            DGP.BusinessLogic.Seguridad.BLPersonal oBLPersonal = new BLPersonal();
            this.bdsPersonal.DataSource = oBLPersonal.ListarPersonal(new DGP.Entities.Seguridad.BEPersonal());
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here

                string pmensaje = string.Empty;


                DialogResult dialogResult = MessageBox.Show(this, "Desea Actualizar?", "DGP", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    BEPersonal oBEPersonal = new BEPersonal();
                    oBEPersonal.IdPersonal = int.Parse(senderGrid["idPersonalDataGridViewTextBoxColumn", e.RowIndex].Value.ToString());
                    
                    oBEPersonal.Clave = senderGrid["claveDataGridViewTextBoxColumn", e.RowIndex].Value.ToString();
                    oBEPersonal.correo = senderGrid["correoDataGridViewTextBoxColumn", e.RowIndex].Value.ToString();
                    oBEPersonal.Direccion = senderGrid["direccionDataGridViewTextBoxColumn", e.RowIndex].Value.ToString();
                    oBEPersonal.DNI = senderGrid["dNIDataGridViewTextBoxColumn", e.RowIndex].Value.ToString();
                    oBEPersonal.Estado = int.Parse(senderGrid["Estado", e.RowIndex].Value.ToString()) ;
                    oBEPersonal.idPerfil = int.Parse(senderGrid["idPerfilDataGridViewTextBoxColumn", e.RowIndex].Value.ToString()) ;
                    oBEPersonal.Login = senderGrid["loginDataGridViewTextBoxColumn", e.RowIndex].Value.ToString();
                    oBEPersonal.Nombre = senderGrid["nombreDataGridViewTextBoxColumn", e.RowIndex].Value.ToString();
                    oBEPersonal.Auditoria = VariablesSession.BEUsuarioSession;
                    BLPersonal oBLPersonal = new BLPersonal();
                    bool bOk = oBLPersonal.ActualizarPersonal(ref pmensaje, oBEPersonal);
                    
                    if (!bOk)
                    {
                        MessageBox.Show(this, pmensaje, "Error", MessageBoxButtons.OK);
                        return;
                    }
                    this.cargarPersonal();

                }

            }
        }

    }
}

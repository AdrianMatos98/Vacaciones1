using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

using DGP.Entities.Seguridad;
using DGP.Entities;
using DGP.BusinessLogic.Seguridad;
using DGP.BusinessLogic;
using System.Threading;
using System.Collections.Generic;

namespace DGP.Presentation {

    public partial class frmLogin : Form {

        public frmLogin() {
            InitializeComponent();
        }

        #region "Eventos de frmLogin"

            private void frmLogin_Load(object sender, EventArgs e) {
                try {
                } catch (Exception ex) {
                    throw ex;
                }
            }

            private void frmLogin_FormClosing(object sender, FormClosingEventArgs e) {
                this.Dispose();
                Application.Exit();
                Application.ExitThread();
            }

            private void btnAceptar_Click(object sender, EventArgs e) {
                try {
                    // Definir la Cultura
                    Thread.CurrentThread.CurrentCulture = VariablesSession.ISOCulture;
                    Thread.CurrentThread.CurrentUICulture = VariablesSession.ISOCulture;
                    Application.CurrentCulture = VariablesSession.ISOCulture;
                    Application.CurrentInputLanguage = InputLanguage.FromCulture(VariablesSession.ISOCulture);
                    // Establecer el usuario
                    BEPersonal oBEPersonal = null;
                    BLCaja obLCaja = new BLCaja();
                    oBEPersonal = new BLPersonal().ObtenerPersonal(txtLogin.Text, txtClave.Text);
                    if (oBEPersonal == null) {
                        MessageBox.Show("No existe el Usuario", "DGP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    } else {
                        //
                        VariablesSession.BEUsuarioSession = oBEPersonal;
                        // Verificar la caja
                        BECaja oBECaja = new BECaja();
                        oBECaja.IdPersonal = oBEPersonal.IdPersonal;
                        oBECaja.Fecha = this.dtFechaCaja.Value.Date;

                        List<BECaja> vListaCaja = obLCaja.Listar(oBECaja);
                        
                        if (vListaCaja.Count > 1) throw new Exception("Existe mas de una caja  para la misma fecha comunicarse con el administrador");
                        BECaja oCajaCreada= new BECaja();
                        BECaja oCajaAbierta = obLCaja.ObtenerCajaAbierta(oBECaja);
                        if (vListaCaja.Count == 0)
                        {
                            if (oCajaAbierta == null){

                                oCajaCreada = obLCaja.CrearCaja(oBECaja);
                            }
                            else if (this.dtFechaCaja.Value.Date < oCajaAbierta.Fecha.Date )
                            {
                                //la fecha no 
                                if (MessageBox.Show(this, "La Fecha seleccionada es menor a la ultima caja abierta, se Creara una caja cerrada.¿Desea continuar?",
                                                        "Creación de Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {

                                    oCajaCreada = obLCaja.CrearCaja( oBECaja );
                                }
                                else return;
                            
                                                           
                            }
                            else if (this.dtFechaCaja.Value.Date > oCajaAbierta.Fecha.Date)
                            {
                                if (MessageBox.Show(this, "Se cerrara La caja del dia " + oCajaAbierta.Fecha.Date.ToString() + ".¿Desea continuar?",
                                                        "Creación de Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {

                                    oCajaCreada = obLCaja.CrearCaja(oBECaja);
                                }
                                else return;
                            }
                            else
                            {
                                oCajaCreada = oCajaAbierta;
                            }
                           
                        }
                        else
                        { // e
                            //if (this.dtFechaCaja.Value.Date < oCajaAbierta.Fecha.Date)
                            //oCajaCreada = oCajaAbierta;
                            oCajaCreada = vListaCaja[0];
                        }

                        //Agregar privilegios

                        VariablesSession.Privilegios = (new BLPrivilegio()).ObtenerPrivilegios(txtLogin.Text);
                        AplicarPrivilegios();

                        //
                        VariablesSession.BECaja = oCajaCreada;
                        oBEPersonal.IdCaja = oCajaCreada.IdCaja;
                        frmMDIPrincipal oFrmMDIPrincipal = new frmMDIPrincipal();
                        this.Visible = false;
                        oFrmMDIPrincipal.ShowDialog();
                        this.Close();
                        
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, "DGP",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void AplicarPrivilegios()
            {

                if (this.dtFechaCaja.Value.Date != DateTime.Now.Date && !VariablesSession.Privilegios.Exists(t=> t.IdPrivilegio == DGP.Entities.Seguridad.BEPrivilegio.Ventas_Iniciar_sesion_fuera_fecha))
                {
                    throw new Exception("Ud no tiene privilegios para cambiar la fecha de la caja");
                
                }
            
            
            }
        #endregion
 
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DGP.BusinessLogic.Ventas;
using DGP.BusinessLogic;
using DGP.BusinessLogic.Seguridad;
using DGP.Entities.Ventas;
using DGP.Entities.Seguridad;
using DGP.Entities;
using System.Threading;
using DGP.Entities.DataSet;
using DGP.Entities.DataSet.DSEntitiesTableroTableAdapters;
namespace DGP.Presentation.Ventas
{
    partial class frmTableroElectronico
    {
        private DSEntitiesTablero.tb_gastoDataTable dtGastos;
        private int filaAgregada = -1;
        //private DSEntitiesCliente.Tb_Cliente_ProveedorRow rowClienteProveedor;
        private int filaGastoAgregada = -1;

        private void loadTipoGasto()
        {
            Tb_Tipo_GastoTableAdapter tb_Tipo_GastoTableAdapter = new Tb_Tipo_GastoTableAdapter();
            
            this.bdsTipoGasto.DataSource = tb_Tipo_GastoTableAdapter.GetData();
            

        }
        private void loadGastos()
        {
            tb_gastoTableAdapter gastoTableAdapter = new tb_gastoTableAdapter();
            dtGastos = gastoTableAdapter.GetData(VariablesSession.BECaja.IdCaja);

            this.bdsGasto.DataSource = dtGastos;
            
         

        }
        private void cmbTipoGasto_Enter(object sender, EventArgs e)
        {
            Tb_Tipo_GastoTableAdapter tb_Tipo_GastoTableAdapter = new Tb_Tipo_GastoTableAdapter();

            this.bdsTipoGasto.DataSource = tb_Tipo_GastoTableAdapter.GetData();
            

        }
        private void CargarUsuarios()
        {
            List<BEPersonal> vLista = new BLPersonal().ListarPersonal(new BEPersonal());
            cmbPersonal.DataSource = vLista;
            cmbPersonal.DisplayMember = "Login";
            cmbPersonal.ValueMember = "IdPersonal";
            cmbPersonal.SelectedValue = VariablesSession.BECaja.IdPersonal;
        }


    }
}

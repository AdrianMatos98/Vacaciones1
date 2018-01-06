namespace DGP.Entities.DSRptClientesTableAdapters
{


    
}

namespace DGP.Entities.DataSet {
    
    
    public partial class DSRptClientes {
        partial class DGP_Rpt_Estado_CuentaClienteDataTable
        {
            public void GenerarAcumulado()
            {

                for (int i = 0; i < this.Rows.Count; i++)
                {
                    decimal montoVenta = this[i].IsMONTO_VENTANull() ? 0 : this[i].MONTO_VENTA;
                    decimal montoAmortizacion = this[i].IsAMORTIZACIONNull() ? 0 : this[i].AMORTIZACION;

                    if (i == 0) this[i].ACUMULADO = montoVenta + montoAmortizacion;
                    else {
                        this[i].ACUMULADO = this[i - 1].ACUMULADO + montoVenta + montoAmortizacion;    
                    }
                    
                }
            
            }
        }
    }
}

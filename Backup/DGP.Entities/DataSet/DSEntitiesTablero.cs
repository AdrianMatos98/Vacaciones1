using System.Data;
using System;

namespace DGP.Entities.DataSet {


    partial class DSEntitiesTablero
    {
        partial class tb_gastoDataTable
        {
            public int maxIdGasto()
            {
                try
                {
                    DSEntitiesCliente.Tb_Cliente_ProveedorRow[] arreglo = (DSEntitiesCliente.Tb_Cliente_ProveedorRow[])this.Select("", "Id_Gasto");
                    return (arreglo.Length == 0) ? 0 : arreglo[arreglo.Length - 1].Id_Cliente;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            public bool existeFilaAgregada(int filaAgregada)
            {
                DSEntitiesTablero.tb_gastoRow[] arreglo = (DSEntitiesTablero.tb_gastoRow[])this.Select("FilaAgregada = " + filaAgregada.ToString(), "");
                if (arreglo.Length > 1) throw new Exception("Error en el DataSet Clientes se agrego mas de una fila");
                return (arreglo.Length == 1);

            }
            public void limpiarError()
            {
                DSEntitiesTablero.tb_gastoRow[] arreglo = (DSEntitiesTablero.tb_gastoRow[])this.Select("id_caja is null or id_personal is null " , "");

                foreach (DSEntitiesTablero.tb_gastoRow item in arreglo)
                {
                    item.Delete();
                    //item.AcceptChanges();
                    
                }
            
            
            }
            
        }
    }
}

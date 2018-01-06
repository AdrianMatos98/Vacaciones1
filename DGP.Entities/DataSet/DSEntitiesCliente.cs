using System.Data;
using System;
namespace DGP.Entities.DataSet {


    partial class DSEntitiesCliente
    {
        partial class Tb_Prod_x_ClienteDataTable
        {
            public int maxId()
            {
                try
                {
                    DSEntitiesCliente.Tb_Prod_x_ClienteRow[] arreglo = (DSEntitiesCliente.Tb_Prod_x_ClienteRow[])this.Select("", "Id_ProductoCliente");
                    return (arreglo.Length == 0) ? 0 : arreglo[arreglo.Length - 1].Id_Cliente;
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            public bool existeFilaAgregada(int filaAgregada)
            {
                DSEntitiesCliente.Tb_Prod_x_ClienteRow[] arreglo = (DSEntitiesCliente.Tb_Prod_x_ClienteRow[])this.Select("FilaAgregada = " + filaAgregada.ToString(), "");
                if (arreglo.Length > 1) throw new Exception("Error en el DataSet Clientes se agrego mas de una fila");


                return (arreglo.Length == 1);

            }


        }
    
        partial class Tb_Cliente_ProveedorDataTable
        {
            public int maxIdCliente()
            {
                try
                {
                    DSEntitiesCliente.Tb_Cliente_ProveedorRow[] arreglo = (DSEntitiesCliente.Tb_Cliente_ProveedorRow[])this.Select("", "Id_Cliente");
                    return (arreglo.Length == 0) ? 0 : arreglo[arreglo.Length - 1].Id_Cliente;
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
            
            }
            public bool existeFilaAgregada(int filaAgregada)
            {
                DSEntitiesCliente.Tb_Cliente_ProveedorRow[] arreglo = (DSEntitiesCliente.Tb_Cliente_ProveedorRow[])this.Select("FilaAgregada = " + filaAgregada.ToString(), "");
                if (arreglo.Length > 1) throw new Exception("Error en el DataSet Clientes se agrego mas de una fila");

                return (arreglo.Length == 1);            
            
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DGP.Entities.Seguridad
{
    public class BEPrivilegio
    {
            public const int Ventas = 1 ;
            public const int Reportes = 2 ;
            public const int Compras = 3 ;
            public const int Mantenimiento_de_Compras = 4 ;
            public const int Tablero_Electronico = 5 ;
            public const int Mantenimiento_de_Venta = 6 ;
            public const int Amortización = 7 ;
            public const int Modificar_Precios_Masivos = 8 ;
            public const int Mantenimiento_de_Clientes = 9 ;
            public const int Mantenimiento_de_Usuarios = 10 ;
            public const int Hoja_de_Cobranza = 11 ;
            public const int Tablero_de_Ventas = 12 ;
            public const int Cuadre_de_Caja = 13 ;
            public const int Estado_de_Cuenta_Cliente = 14 ;
            public const int Herramientas_de_reportes = 15 ;
            //public const int Mantenimiento_de_Compras = 16 ;
            public const int Tablero_Registrar_Venta = 17 ;
            public const int Tablero_Lista_de_ventas = 18 ;
            public const int Tablero_Registrar_Gastos = 19 ;
            public const int Modificar_Detalle_de_venta = 20 ;
            public const int Cambio_Estado_Venta = 21 ;
            public const int Detalle_de_Venta_Lineas_de_Venta = 22 ;
            public const int Detalle_de_Venta_Amortizaciones = 23 ;
            public const int Detalle_de_Venta_Devoluciones = 24 ;
            public const int Amortizacion_Cambio_Cobrador = 25 ;
            public const int Amortizacion_Cambio_Fecha_de_Pago = 26 ;
            public const int Act_Precio_Venta_Masivo = 27 ;
            public const int Herramientas = 28 ;
            public const int Hoja_de_Tablero = 29 ;
            public const int Lista_de_Precios = 30 ;
            public const int Salir = 31 ;
            public const int Salir_del_Sistema = 32 ;
            public const int Aplicar_Vueltos = 33 ;
            public const int Ventas_Iniciar_sesion_fuera_fecha = 34;
            public const int Ventas_Documentos_Pago = 35;
            public const int Compras_Documentos_Pago = 36 ;

        public int IdPrivilegio { get; set; }
        public string Descripcion { get; set; }
        public BEPrivilegio Padre { get; set; }
        public BEPrivilegio()
        { 
        
        }
        public BEPrivilegio(int  IdPrivilegio, string descripcion)
        {
            this.IdPrivilegio = IdPrivilegio;
            this.Descripcion = descripcion;
        
        
        }
    }
}

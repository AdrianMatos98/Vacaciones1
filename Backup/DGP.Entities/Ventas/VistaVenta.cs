using System;
using System.Collections.Generic;
using System.Text;

namespace DGP.Entities.Ventas {

    public class VistaVenta {

        private int mIdVenta;
        private decimal mTotalPesoBruto;
        private decimal mTotalPesoTara;
        private decimal mTotalPesoNeto;
        private decimal mPrecio;
        private decimal mMontoSubTotal;
        private decimal mMontoIGV;
        private decimal mMontoTotal;
        private int mCantidadJavas;
        private decimal mTotalDevolucion;
        private decimal mTotalAmortizacion;
        private decimal mTotalSaldo;
        private int mIdProducto;
        private string mProducto;
        private int mIdCliente;
        private string mCliente;
        private string mIdTipoDocumento;
        private string mTipoDocumento;
        private string mNroDocumento;
        private DateTime mFechaInicio;
        private DateTime mFechaFin;
        private DateTime mFecha;

        private int mIdZona;
        private string mZona;

        public VistaVenta() { 
            mIdVenta = 0;
            mTotalPesoBruto = 0;
            mTotalPesoTara = 0;
            mTotalPesoNeto = 0;
            mPrecio = 0;
            mMontoSubTotal = 0;
            mMontoIGV = 0;
            mMontoTotal = 0;
            mCantidadJavas = 0;
            mTotalDevolucion = 0;
            mTotalAmortizacion = 0;
            mTotalSaldo = 0;
            mIdProducto = 0;
            mProducto = string.Empty;
            mIdCliente = 0;
            mCliente = string.Empty;
            mIdTipoDocumento = string.Empty;
            mTipoDocumento = string.Empty;
            mNroDocumento = string.Empty;
            mFechaInicio = DateTime.Now;
            mFechaFin = DateTime.Now;
            mFecha = DateTime.Now;

            mIdZona = 0;
            mZona = string.Empty;
        }

        public int IdVenta {
            get { return mIdVenta; }
            set { mIdVenta = value; }
        }

        public decimal Precio {
            get { return mPrecio; }
            set { mPrecio = value; }
        }

        public decimal MontoSubTotal {
            get { return mMontoSubTotal; }
            set { mMontoSubTotal = value; }
        }

        public decimal MontoIGV {
            get { return mMontoIGV; }
            set { mMontoIGV = value; }
        }

        public decimal MontoTotal {
            get { return mMontoTotal; }
            set { mMontoTotal = value; }
        }

        public int CantidadJavas {
            get { return mCantidadJavas; }
            set { mCantidadJavas = value; }
        }

        public decimal TotalPesoBruto {
            get { return mTotalPesoBruto; }
            set { mTotalPesoBruto = value; }
        }

        public decimal TotalPesoTara {
            get { return mTotalPesoTara; }
            set { mTotalPesoTara = value; }
        }

        public decimal TotalPesoNeto {
            get { return mTotalPesoNeto; }
            set { mTotalPesoNeto = value; }
        }

        public decimal TotalDevolucion {
            get { return mTotalDevolucion; }
            set { mTotalDevolucion = value; }
        }

        public decimal TotalAmortizacion {
            get { return mTotalAmortizacion; }
            set { mTotalAmortizacion = value; }
        }

        public decimal TotalSaldo {
            get { return mTotalSaldo; }
            set { mTotalSaldo = value; }
        }

        public int IdProducto {
            get { return mIdProducto; }
            set { mIdProducto = value; }
        }

        public string Producto {
            get { return mProducto; }
            set { mProducto = value; }
        }

        public int IdCliente {
            get { return mIdCliente; }
            set { mIdCliente = value; }
        }

        public string Cliente {
            get { return mCliente; }
            set { mCliente = value; }
        }

        public string IdTipoDocumento {
            get { return mIdTipoDocumento; }
            set { mIdTipoDocumento = value; }
        }

        public string TipoDocumento {
            get { return mTipoDocumento; }
            set { mTipoDocumento = value; }
        }

        public string NroDocumento {
            get { return mNroDocumento; }
            set { mNroDocumento = value; }
        }

        public DateTime FechaInicio {
            get { return mFechaInicio; }
            set { mFechaInicio = value; }
        }

        public DateTime FechaFin {
            get { return mFechaFin; }
            set { mFechaFin = value; }
        }

        public DateTime Fecha {
            get { return mFecha; }
            set { mFecha = value; }
        }


        public int IdZona {
            get { return mIdZona; }
            set { mIdZona = value; }
        }

        public string Zona {
            get { return mZona; }
            set { mZona = value; }
        }
        private string _estado;

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private int mTotalUnidades;

        public int TotalUnidades
        {
            get { return mTotalUnidades; }
            set { mTotalUnidades = value; }
        }
	

    }
}
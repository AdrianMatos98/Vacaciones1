using System;
using System.Text;

namespace DGP.Entities.Ventas {

    public class VistaAmortizacion {
        private int mIntIdAmortizacion = 0;
        private int mIdVenta = 0;
        private int mIdProducto = 0;
        private string mTipoDocumento = string.Empty;
        private string mProducto = string.Empty;
        private string mFecha = string.Empty;
        private int mCantidadJavas = 0;
        private decimal mPesoNeto = 0;
        private decimal mImporte = 0;
        private decimal mSaldo = 0;
        private int mIndicador = 0;
        private int mIdCliente = 0;

        public int IdAmortizacion
        {
            get { return mIntIdAmortizacion; }
            set { mIntIdAmortizacion = value; }
        }
        public int IdVenta {
            get { return mIdVenta; }
            set { mIdVenta = value; }
        }

        public int IdProducto {
            get { return mIdProducto; }
            set { mIdProducto = value; }
        }

        public int IdCliente {
            get { return mIdCliente; }
            set { mIdCliente = value; }
        }

        public string TipoDocumento {
            get { return mTipoDocumento; }
            set { mTipoDocumento = value; }
        }

        public string Producto {
            get { return mProducto; }
            set { mProducto = value; }
        }

        public string Fecha {
            get { return mFecha; }
            set { mFecha = value; }
        }

        public int CantidadJavas {
            get { return mCantidadJavas; }
            set { mCantidadJavas = value; }
        }

        public decimal PesoNeto {
            get { return mPesoNeto; }
            set { mPesoNeto = value; }
        }

        public decimal Importe {
            get { return mImporte; }
            set { mImporte = value; }
        }

        public decimal Saldo {
            get { return mSaldo; }
            set { mSaldo = value; }
        }

        public int Indicador {
            get { return mIndicador; }
            set { mIndicador = value; }
        }
	
        public string strCantidadJavas{
            get { return (mCantidadJavas == 0) ? string.Empty : mCantidadJavas.ToString(); }
        }

        public string strPesoNeto {
            get { return (mPesoNeto == decimal.Zero) ? string.Empty : mPesoNeto.ToString(); }
        }

        public string strSaldo {
            get { return (mSaldo == decimal.Zero) ? string.Empty : mSaldo.ToString(); }
        }

        private int _idPersonal;

        public int IdPersonal
        {
            get { return _idPersonal; }
            set { _idPersonal = value; }
        }
        private string _personal;

        public string Personal
        {
            get { return _personal; }
            set { _personal = value; }
        }

        private bool _IncluyeCancelados = false;

        public bool IncluyeCancelados
        {

            get { return _IncluyeCancelados; }
            set { _IncluyeCancelados = value; }
        }

        private string _idEstado;

        public string IdEstado
        {
            get { return _idEstado; }
            set { _idEstado = value; }
        }

	
	
	
	

    }
}
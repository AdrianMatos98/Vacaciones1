using System;
using System.Text;

using DGP.Entities.Seguridad; 

namespace DGP.Entities.Ventas {

    public class BEAmortizacionVenta {

        public const string ESTADO_REGISTRADO = "REG";
        public const string ESTADO_ELIMINADO = "ELM";

        public const string FORMAPAGO_EFECTIVO = "EFE";

        public const string TIPOAMORTIZACION_AMORTIZACION = "AMR";
        public const string TIPOAMORTIZACION_ADELANTO = "ADL";

        private int mIdAmortizacionVenta;
        private decimal mMonto;
        private string mNroDocumento;
        private string mIdFormaPago;
        private DateTime mFechaPago;
        private string mIdTipoAmortizacion;
        private string mObservacion;
        private string mIdEstado;
        private int mIdVenta;
        private int mIdCliente;
        private int mIdPersonal;
        private BEPersonal mBEUsuarioLogin;

        public BEAmortizacionVenta() {
            mIdAmortizacionVenta = 0;
            mMonto = 0;
            mNroDocumento = string.Empty;
            mIdFormaPago = string.Empty;
            mFechaPago = DateTime.MinValue.Date;
            mIdTipoAmortizacion = string.Empty;
            mObservacion = string.Empty;
            mIdEstado = string.Empty;
            mIdVenta = 0;
            mIdCliente = 0;
            mIdPersonal = 0;
            mBEUsuarioLogin = new BEPersonal();
        }

        public int IdAmortizacionVenta {
            get { return mIdAmortizacionVenta; }
            set { mIdAmortizacionVenta = value; }
        }

        public decimal Monto {
            get { return mMonto; }
            set { mMonto = value; }
        }

        public string NroDocumento {
            get { return mNroDocumento; }
            set { mNroDocumento = value; }
        }

        public string IdFormaPago {
            get { return mIdFormaPago; }
            set { mIdFormaPago = value; }
        }

        public DateTime FechaPago {
            get { return mFechaPago; }
            set { mFechaPago = value; }
        }

        public string IdTipoAmortizacion {
            get { return mIdTipoAmortizacion; }
            set { mIdTipoAmortizacion = value; }
        }

        public string Observacion {
            get { return mObservacion; }
            set { mObservacion = value; }
        }

        public string IdEstado {
            get { return mIdEstado; }
            set { mIdEstado = value; }
        }

        public int IdVenta {
            get { return mIdVenta; }
            set { mIdVenta = value; }
        }

        public int IdCliente {
            get { return mIdCliente; }
            set { mIdCliente = value; }
        }

        public int IdPersonal {
            get { return mIdPersonal; }
            set { mIdPersonal = value; }
        }
	
        public BEPersonal BEUsuarioLogin {
            get { return mBEUsuarioLogin; }
            set { mBEUsuarioLogin = value; }
        }
        private BECaja mCaja;

        public BECaja Caja
        {
            get { return mCaja; }
            set { mCaja = value; }
        }

        private bool _CancelarVenta =false;

        public bool CancelarVenta
        {
            get { return _CancelarVenta; }
            set { _CancelarVenta = value; }
        }

	
	

    }
}
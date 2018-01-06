using System;
using System.Text;

using DGP.Entities.Seguridad;

namespace DGP.Entities {

    public class BEClienteProveedor {

        private int mIdCliente;
        private string mNombre;
        private string mTipoCliente;
        private string mRazonSocial;
        private string mTipoDocumento;
        private string mNumDocumento;
        private int mEstado;
        private int mIdZona;
        private string mDescripcionZona;
        private BEPersonal mBEUsuarioLogin;

        public BEClienteProveedor() {
            mIdCliente = 0;
            mNombre = string.Empty;
            mTipoCliente = string.Empty;
            mRazonSocial = string.Empty;
            mTipoDocumento = string.Empty;
            mNumDocumento = string.Empty;
            mEstado = 0;
            mIdZona = 0;
            mDescripcionZona = string.Empty;
            mBEUsuarioLogin = new BEPersonal();
        }

        public BEClienteProveedor(int pIdCliente, string pNombre) {
            mIdCliente = pIdCliente;
            mNombre = pNombre;        
        }

        public int IdCliente {
            get { return mIdCliente; }
            set { mIdCliente = value; }
        }

        public string Nombre {
            get { return mNombre; }
            set { mNombre = value; }
        }

        public string TipoCliente {
            get { return mTipoCliente; }
            set { mTipoCliente = value; }
        }

        public string RazonSocial {
            get { return mRazonSocial; }
            set { mRazonSocial = value; }
        }

        public string TipoDocumento {
            get { return mTipoDocumento; }
            set { mTipoDocumento = value; }
        }

        public string NumDocumento  {
            get { return mNumDocumento; }
            set { mNumDocumento = value; }
        }

        public int Estado {
            get { return mEstado; }
            set { mEstado = value; }
        }

        public int IdZona {
            get { return mIdZona; }
            set { mIdZona = value; }
        }

        public string DescripcionZona {
            get { return mDescripcionZona; }
            set { mDescripcionZona = value; }
        }

        public BEPersonal BEUsuarioLogin {
            get { return mBEUsuarioLogin; }
            set { mBEUsuarioLogin = value; }
        }
	
    }
}
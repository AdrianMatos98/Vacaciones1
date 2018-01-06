using System;
using System.Text;

namespace DGP.Entities.Seguridad {

    public class BEPersonal {

        private int mIdPersonal;
        private string mNombre;
        private string mDireccion;
        private string mDNI;
        private string mLogin;
        private string mClave;
        private int mEstado;
        private int mIdCaja;

        public BEPersonal() {
            mIdPersonal = 0;
            mNombre = string.Empty;
            mDireccion = string.Empty;
            mDNI = string.Empty;
            mLogin = string.Empty;
            mClave = string.Empty;
            mEstado = 0;
            mIdCaja = 0;
        }

        public BEPersonal(int pIdPersonal, string pNombre, string pLogin) {
            mIdPersonal = pIdPersonal;
            mNombre = pNombre;
            mDireccion = string.Empty;
            mDNI = string.Empty;
            mLogin = pLogin;
            mClave = string.Empty;
            mEstado = 0;
            mIdCaja = 0;        
        }

        public int IdPersonal {
            get { return mIdPersonal; }
            set { mIdPersonal = value; }
        }

        public string Nombre {
            get { return mNombre; }
            set { mNombre = value; }
        }

        public string Direccion {
            get { return mDireccion; }
            set { mDireccion = value; }
        }

        public string DNI {
            get { return mDNI; }
            set { mDNI = value; }
        }

        public string Login {
            get { return mLogin; }
            set { mLogin = value; }
        }

        public string Clave {
            get { return mClave; }
            set { mClave = value; }
        }

        public int Estado {
            get { return mEstado; }
            set { mEstado = value; }
        }

        public int IdCaja {
            get { return mIdCaja; }
            set { mIdCaja = value; }
        }

    }
}
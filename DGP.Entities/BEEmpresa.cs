using System;
using System.Text;

using DGP.Entities.Seguridad;

namespace DGP.Entities {

    public class BEEmpresa {

        private int mIdEmpresa;
        private string mRazonSocial;
        private string mRUC;
        private string mDireccionFiscal;
        private int mPrioridad;
        private BEPersonal mBEUsuarioLogin;

        public BEEmpresa() {
            mIdEmpresa = 0;
            mRazonSocial = string.Empty;
            mRUC = string.Empty;
            mDireccionFiscal = string.Empty;
            mPrioridad = 0;
            mBEUsuarioLogin = new BEPersonal();
        }

        public BEEmpresa(int pIdEmpresa, string pRazonSocial) {
            mIdEmpresa = pIdEmpresa;
            mRazonSocial = pRazonSocial;
        }

        public int IdEmpresa {
            get { return mIdEmpresa; }
            set { mIdEmpresa = value; }
        }

        public string RazonSocial {
            get { return mRazonSocial; }
            set { mRazonSocial = value; }
        }

        public string RUC {
            get { return mRUC; }
            set { mRUC = value; }
        }

        public string DireccionFiscal {
            get { return mDireccionFiscal; }
            set { mDireccionFiscal = value; }
        }

        public int Prioridad {
            get { return mPrioridad; }
            set { mPrioridad = value; }
        }

        public BEPersonal BEUsuarioLogin {
            get { return mBEUsuarioLogin; }
            set { mBEUsuarioLogin = value; }
        }

    }
}
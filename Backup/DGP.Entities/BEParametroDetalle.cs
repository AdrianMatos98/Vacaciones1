using System;
using System.Text;

using DGP.Entities.Seguridad;

namespace DGP.Entities {

    public class BEParametroDetalle {

        private int mIdItem;
        private int mIdParametro;
        private string mValor;
        private string mTexto;
        private int mOrden;
        BEPersonal mBEUsuarioLogin;

        public BEParametroDetalle() { 
            mIdItem = 0;
            mIdParametro = 0;
            mValor = string.Empty;
            mTexto = string.Empty;
            mOrden = 0;
            mBEUsuarioLogin = new BEPersonal();
        }

        public BEParametroDetalle(string pValor, string pTexto) {
            mValor = pValor;
            mTexto = pTexto;
        }

        public int IdItem {
            get { return mIdItem; }
            set { mIdItem = value; }
        }

        public int IdParametro {
            get { return mIdParametro; }
            set { mIdParametro = value; }
        }

        public string Valor {
            get { return mValor; }
            set { mValor = value; }
        }

        public string Texto {
            get { return mTexto; }
            set { mTexto = value; }
        }

        public int Orden {
            get { return mOrden; }
            set { mOrden = value; }
        }

        public BEPersonal BEUsuarioLogin {
            get { return mBEUsuarioLogin; }
            set { mBEUsuarioLogin = value; }
        }

    }
}
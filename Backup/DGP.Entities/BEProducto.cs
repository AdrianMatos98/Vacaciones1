using System;
using System.Text;

using DGP.Entities.Seguridad;

namespace DGP.Entities {

    public class BEProducto {

        private int mIdProducto;
        private string mNombre;
        private decimal mTara;
        private decimal mPrecioVenta;
        private decimal mPrecioCompra;
        private BEPersonal mBEUsuarioLogin;

        public BEProducto() {
            mIdProducto = 0;
            mNombre = string.Empty;
            mTara = 0;
            mPrecioVenta = 0;
            mPrecioCompra = 0;
            mBEUsuarioLogin = new BEPersonal();
        }

        public BEProducto(int pIdProducto, string pNombre) {
            mIdProducto = pIdProducto;
            mNombre = pNombre;
        }

        public int IdProducto {
            get { return mIdProducto; }
            set { mIdProducto = value; }
        }

        public string Nombre {
            get { return mNombre; }
            set { mNombre = value; }
        }

        public decimal Tara {
            get { return mTara; }
            set { mTara = value; }
        }

        public decimal PrecioVenta {
            get { return mPrecioVenta; }
            set { mPrecioVenta = value; }
        }

        public decimal PrecioCompra {
            get { return mPrecioCompra; }
            set { mPrecioCompra = value; }
        }

        public BEPersonal BEUsuarioLogin {
            get { return mBEUsuarioLogin; }
            set { mBEUsuarioLogin = value; }
        }

        public override string ToString()
        {
            return IdProducto.ToString();
        }

        private decimal mMargen;

        public decimal Margen
        {
            get { return mMargen; }
            set { mMargen = value; }
        }
	

    }
}
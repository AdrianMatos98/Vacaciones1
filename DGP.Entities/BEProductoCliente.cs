using System;
using System.Text;

using DGP.Entities.Seguridad;

namespace DGP.Entities {

    public class BEProductoCliente {

        private int mIdProductoCliente;
        private decimal mTara;
        private decimal mMargen;
        private decimal mPrecioVenta;
        private decimal mPrecioCompra;
        private int mIdProducto;
        private int mIdCliente;
        private string mProducto;
        private BEPersonal mBEUsuarioLogin;

        public BEProductoCliente() { 
            mIdProductoCliente = 0;
            mTara = 0;
            mMargen = 0;
            mPrecioVenta = 0;
            mPrecioCompra = 0;
            mIdProducto = 0;
            mIdCliente = 0;
            mProducto = string.Empty;
            mBEUsuarioLogin = new BEPersonal();
        }

        public BEProductoCliente(int pIdProducto, string pProducto) {
            mIdProducto = pIdProducto;
            mProducto = pProducto;
        }

        public BEProductoCliente(int pIdProducto, int pIdCliente) {
            mIdProductoCliente = 0;
            mIdProducto = pIdProducto;
            mIdCliente = pIdCliente;
            mBEUsuarioLogin = new BEPersonal();
        }

        public int IdProductoCliente {
            get { return mIdProductoCliente; }
            set { mIdProductoCliente = value; }
        }
	
        public int IdProducto {
            get { return mIdProducto; }
            set { mIdProducto = value; }
        }

        public int IdCliente {
            get { return mIdCliente; }
            set { mIdCliente = value; }
        }

        public decimal Tara {
            get { return mTara; }
            set { mTara = value; }
        }

        public decimal Margen {
            get { return mMargen; }
            set { mMargen = value; }
        }

        public decimal PrecioVenta {
            get { return mPrecioVenta; }
            set { mPrecioVenta = value; }
        }

        public decimal PrecioCompra {
            get { return mPrecioCompra; }
            set { mPrecioCompra = value; }
        }

        public string Producto {
            get { return mProducto; }
            set { mProducto = value; }
        }
	
        public BEPersonal BEUsuarioLogin {
            get { return mBEUsuarioLogin; }
            set { mBEUsuarioLogin = value; }
        }
	
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace DGP.Entities {

    public class BEZona {

        private int mIdZona;
        private string mDescripcion;

        public BEZona() {
            mIdZona = 0;
            mDescripcion = string.Empty;
        }

        public BEZona(int pIdZona, string pZona) {
            mIdZona = pIdZona;
            mDescripcion = pZona;
        }

        public int IdZona {
            get { return mIdZona; }
            set { mIdZona = value; }
        }

        public string Descripcion {
            get { return mDescripcion; }
            set { mDescripcion = value; }
        }
        public override string ToString()
        {
            return IdZona.ToString();
        }
	
    }
}
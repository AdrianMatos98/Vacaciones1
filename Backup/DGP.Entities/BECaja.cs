using System;
using System.Text;

using DGP.Entities.Seguridad;

namespace DGP.Entities {

    public class BECaja {

        private int mIdCaja;
        private DateTime mFechaInicio;
        private DateTime? mFechaFin = null;
        private DateTime mFecha;
        private int mIdPersonal;
        private BEPersonal mBEUsuarioLogin;

        public BECaja() {
            mIdCaja = 0;
            mFechaInicio = DateTime.MinValue;
            mFechaFin = DateTime.MinValue;
            mFecha = DateTime.MinValue;
            mIdPersonal = 0;
            mBEUsuarioLogin = new BEPersonal();
        }

        public int IdCaja {
            get { return mIdCaja; }
            set { mIdCaja = value; }
        }

        public DateTime FechaInicio {
            get { return mFechaInicio; }
            set { mFechaInicio = value; }
        }

        public DateTime? FechaFin {
            get { return mFechaFin; }
            set { mFechaFin = value; }
        }

        public DateTime Fecha {
            get { return mFecha; }
            set { mFecha = value; }
        }

        public int IdPersonal {
            get { return mIdPersonal; }
            set { mIdPersonal = value; }
        }

        public BEPersonal BEUsuarioLogin {
            get { return mBEUsuarioLogin; }
            set { mBEUsuarioLogin = value; }
        }
        public bool cajaCerrada()
        {
            return (mFechaFin != null);
        }

    }
}
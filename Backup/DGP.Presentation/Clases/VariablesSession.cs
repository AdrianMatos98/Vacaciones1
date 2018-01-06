using System;
using System.Text;

using DGP.Entities.Seguridad;
using System.Configuration;
using System.Globalization;
using DGP.Entities;
namespace DGP.Presentation {

    public class VariablesSession {

        private static BEPersonal mBEPersonal = new BEPersonal();
        private static CultureInfo mCulture = new CultureInfo(ConfigurationSettings.AppSettings["asCultura"]);
        private static BECaja mBECaja = new BECaja();
        public static BEPersonal BEUsuarioSession {
            get { return mBEPersonal; }
            set { mBEPersonal = value; }
        }
        public static BECaja BECaja
        {
            get { return mBECaja; }
            set { mBECaja = value; }
        }

        public static CultureInfo ISOCulture {
            get { return mCulture; }
        }
    }
}
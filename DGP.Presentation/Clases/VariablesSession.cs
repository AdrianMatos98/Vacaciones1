using System;
using System.Text;

using DGP.Entities.Seguridad;
using System.Configuration;
using System.Globalization;
using System.Collections.Generic;
using DGP.Entities;
namespace DGP.Presentation {

    public class VariablesSession {

        private static BEPersonal mBEPersonal = new BEPersonal();
        private static CultureInfo mCulture = new CultureInfo(ConfigurationSettings.AppSettings["asCultura"]);
        private static BECaja mBECaja = new BECaja();
       // private static List<BEPrivilegio> privilegio = new List<BEPrivilegio>();
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
        public static  List<BEPrivilegio> Privilegios { get; set; }

    }
}
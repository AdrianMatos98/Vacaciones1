using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace DGP.Util
{
    public class Cadenas
    {
        public const string SEPARADOR = "|";
        
        public static string ListToString(ICollection enumerator, string Propiedad)
        {

            string cadena = "";

            
            foreach (object item in enumerator)
            {
                cadena = cadena + SEPARADOR + item.ToString();
            
                
            }

            return cadena;
        
        }

    }
}

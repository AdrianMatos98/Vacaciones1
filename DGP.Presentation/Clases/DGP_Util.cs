using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

namespace DGP.Presentation {
    
    public class DGP_Util {

        public static void LiberarComboBox(ComboBox pComboBox) {
            pComboBox.DataSource = null;
            pComboBox.Items.Clear();
        }

        public static void EnabledComboBox(ComboBox pComboBox, bool pValor) {
            pComboBox.Enabled = pValor;
        }

        public static void EnableControl(Control pControl, bool pValor) {
            pControl.Enabled = pValor;
        }

        public static void LiberarGridView(DataGridView pDataGridView) {
            pDataGridView.DataSource = null;
            pDataGridView.Rows.Clear();
        }

        public static bool ValidarDigitosDecimales(string pCadena) {
            // Validar Decimales
            bool boTemp = false;
            string vTemp = pCadena.ToString();
            int posPunto = vTemp.LastIndexOf(".");
            if (posPunto == -1) {
                boTemp = false;
            } else {
                posPunto++;
                int cantDecimal = vTemp.Substring(posPunto, (vTemp.Length - posPunto)).Length;
                if (cantDecimal == VariablesSession.ISOCulture.NumberFormat.NumberDecimalDigits) {
                    boTemp = true;
                }
            }
            return boTemp;
        }

        public static void SetDateTimeNow(DateTimePicker pDateTimePicker) {
            pDateTimePicker.Value = DateTime.Now;
        }

    }
}
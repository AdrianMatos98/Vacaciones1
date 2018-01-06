namespace DGP.Entities.Ventas {

    using DGP.Entities.Ventas;

    partial class dsLineaVenta {

        partial class DTLineaVentaDataTable { }

        partial class DTLineaVentaRow {

            public bool EsLineaVentaBD() {
                bool boResultado = false;
                if (this.IdAccion == eAccion.BaseDatos.GetHashCode() || this.IdAccion == eAccion.Modificar.GetHashCode()) {
                    boResultado = true;
                }
                return boResultado;
            }

            public bool ValidarCantidadJavas(ref string pMensaje, string pCantidadDefault) {
                bool boIndicadorCJ = true;
                // Validar si ingresa algun valor
                if (this.IsCantidadJavasNull() || string.IsNullOrEmpty(this.CantidadJavas.Trim())) {
                    if (!string.IsNullOrEmpty(pCantidadDefault)) {
                        this.CantidadJavas = pCantidadDefault;
                    } else {
                        boIndicadorCJ = false;
                        pMensaje = "Ingresar cantidad javas";
                    }
                } else { 
                    // Validar que sea tipo INT
                    int intCantidadJavas = 0;
                    int.TryParse(this.CantidadJavas, out intCantidadJavas);
                    // Validar Accion para modificar
                    if (this.IdAccion == eAccion.BaseDatos.GetHashCode()) {
                        if (intCantidadJavas > 0 && !this.CantidadJavas.Equals(pCantidadDefault)) {
                            this.IdAccion = eAccion.Modificar.GetHashCode();
                        }
                    }
                    // Validar si es cero o negativo
                    if (intCantidadJavas <= 0) {
                        boIndicadorCJ = false;
                        pMensaje = "Ingresar cantidad javas válida";
                        this.CantidadJavas = pCantidadDefault;
                    }
                }
                return boIndicadorCJ;
            }

            public void CalcularCantidadJavas() {
                int intCantidad = int.Parse(this.CantidadJavas);
                decimal decPesoJava = decimal.Parse(this.PesoJava);
                // Calcular Peso Tara
                decimal decPesoTara = (intCantidad * decPesoJava);
                this.PesoTara = decPesoTara.ToString();
                // Recalcular Peso Neto
                if (!this.IsPesoBrutoNull() && !string.IsNullOrEmpty(this.PesoBruto.Trim())) {
                    decimal decPesoBruto = decimal.Parse(this.PesoBruto);
                    decimal decPesoNeto = (decPesoBruto - decPesoTara);
                    this.PesoNeto = decPesoNeto.ToString();
                }
            }
            public void CalcularCantidadUnidades()
            {
                int intCantidadJavas = 0;
                int.TryParse(this.CantidadJavas, out intCantidadJavas);

                this.Unidades = intCantidadJavas * BEVenta.UNIDAD_JAVA;

                if (this.IdAccion == eAccion.BaseDatos.GetHashCode())     
                    this.IdAccion = eAccion.Modificar.GetHashCode();
            
            
            }
            public bool ValidarPesoJava(ref string pMensaje, string pPesoJavaDefault) {
                bool boIndicadorPJ = true;
                // Validar si ingresa algun valor
                if (this.IsPesoJavaNull() || string.IsNullOrEmpty(this.PesoJava.Trim())) {
                    this.PesoJava = pPesoJavaDefault;
                } else {
                    // Validar que sea de tipo decimal
                    decimal decPesoJava = decimal.Zero;
                    decimal.TryParse(this.PesoJava, out decPesoJava);
                    // Validar Accion para modificar
                    if (this.IdAccion == eAccion.BaseDatos.GetHashCode()) {
                        if (decPesoJava > decimal.Zero && !decPesoJava.ToString().Equals(pPesoJavaDefault)) {
                            this.IdAccion = eAccion.Modificar.GetHashCode();
                        }
                    }
                    // Validar si es cero o negativo
                    if (decPesoJava <= decimal.Zero) {
                        boIndicadorPJ = false;
                        pMensaje = "Ingresar peso javas válido";
                        this.PesoJava = pPesoJavaDefault;
                    }
                }
                return boIndicadorPJ;
            }

            public void RecalcularPesoJava() {
                // Recalcular Peso Tara
                if (!string.IsNullOrEmpty(this.CantidadJavas)) {
                    int intCantidad = int.Parse(this.CantidadJavas);
                    decimal decPesoJava = decimal.Parse(this.PesoJava);
                    decimal decPesoTara = (intCantidad * decPesoJava);
                    this.PesoTara = decPesoTara.ToString();
                    // Recalcular Peso Neto
                    if (!string.IsNullOrEmpty(this.PesoBruto)) {
                        decimal decPesoBruto = decimal.Parse(this.PesoBruto);
                        decimal decPesoNeto = (decPesoBruto - decPesoTara);
                        this.PesoNeto = decPesoNeto.ToString();
                    }
                }
            }

            public bool ValidarPesoBruto(ref string pMensaje, string pPesoBrutoDefault) {
                bool boIndicadorPB = true;
                // Validar si ingresa algun valor
                if (this.IsPesoBrutoNull() || string.IsNullOrEmpty(this.PesoBruto)) {
                    if (!string.IsNullOrEmpty(pPesoBrutoDefault)) {
                        this.PesoBruto = pPesoBrutoDefault;
                    } else {
                        boIndicadorPB = false;
                        pMensaje = "Ingresar peso bruto";
                    }
                } else {
                    // Validar que sea de tipo decimal
                    decimal decPesoBruto = decimal.Zero;
                    decimal.TryParse(this.PesoBruto, out decPesoBruto);
                    // Validar Accion para modificar
                    if (this.IdAccion == eAccion.BaseDatos.GetHashCode()) {
                        if (decPesoBruto > decimal.Zero && !decPesoBruto.ToString().Equals(pPesoBrutoDefault)) {
                            this.IdAccion = eAccion.Modificar.GetHashCode();
                        }
                    }
                    // Validar si es cero o negativo
                    if (decPesoBruto <= decimal.Zero) {
                        boIndicadorPB = false;
                        pMensaje = "Ingresar peso bruto válido";
                        this.PesoBruto = pPesoBrutoDefault;
                    }
                }
                return boIndicadorPB;
            }

            public void CalcularPesoBruto() {
                // Recalcular Peso Neto
                if (!string.IsNullOrEmpty(this.PesoTara)) {
                    decimal decPesoTara = decimal.Parse(this.PesoTara);
                    decimal decPesoBruto = decimal.Parse(this.PesoBruto);
                    decimal decPesoNeto = (decPesoBruto - decPesoTara);
                    this.PesoNeto = decPesoNeto.ToString();
                }
            }

            public bool ValidarPesoTara(ref string pMensaje, string pPesoTaraDefault) {
                bool boIndicadorPT = true;
                // Validar si ingresa algun valor
                if (this.IsPesoTaraNull() || string.IsNullOrEmpty(this.PesoTara)) {
                    if (!string.IsNullOrEmpty(pPesoTaraDefault)) {
                        this.PesoTara = pPesoTaraDefault;
                        RecalcularPesoTara();
                    } else {
                        boIndicadorPT = false;
                        pMensaje = "Ingresar peso tara";
                    }
                } else {
                    // Validar que sea de tipo decimal
                    decimal decPesoTara = decimal.Zero;
                    decimal.TryParse(this.PesoTara, out decPesoTara);
                    // Validar Accion para modificar
                    if (this.IdAccion == eAccion.BaseDatos.GetHashCode()) {
                        if (decPesoTara > decimal.Zero && !decPesoTara.ToString().Equals(pPesoTaraDefault)) {
                            this.IdAccion = eAccion.Modificar.GetHashCode();
                        }
                    }
                    if (decPesoTara <= decimal.Zero) {
                        boIndicadorPT = false;
                        pMensaje = "Ingresar peso tara válido";
                        this.PesoTara = pPesoTaraDefault;
                    }
                }
                return boIndicadorPT;
            }

            public void RecalcularPesoTara() {
                // Recalcular Peso Neto
                if (!string.IsNullOrEmpty(this.PesoBruto)) {
                    decimal decPesoBruto = decimal.Parse(this.PesoBruto);
                    decimal decPesoTara = decimal.Parse(this.PesoTara);
                    decimal decPesoNeto = (decPesoBruto - decPesoTara);
                    this.PesoNeto = decPesoNeto.ToString();
                }
            }

        }

    }
}
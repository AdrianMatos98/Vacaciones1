using System;
using System.Collections.Generic;
using System.Text;

namespace DGP.Entities.Reportes
{
    public class BEFiltroTablero
    {
        private int _idCaja;

        public int IdCaja
        {
            get { return _idCaja; }
            set { _idCaja = value; }

        }
	
        private string _personal= null;

        public string strListPersonal
        {
            get { return _personal; }
            set { _personal = value; }
        }
	
        private string _zonas = null;

        public string  strListZonas
        {
            get { return _zonas; }
            set { _zonas = value; }
        }
        private string _productos = null;

        public string strListProductos
        {
            get { return _productos; }
            set { _productos = value; }
        }

        private DateTime? _dtFechaInicio = null;

        public DateTime? dtFechaInicio
        {
            get { return _dtFechaInicio; }
            set { _dtFechaInicio = value; }
        }
        private DateTime? _dtFechaFinal =null;

        public DateTime? dtFechaFinal
        {
            get { return _dtFechaFinal; }
            set { _dtFechaFinal = value; }
        }
        private int _idModoReporte = 0;

        public int IdModoReporte
        {
            get { return _idModoReporte; }
            set { _idModoReporte = value; }
        }
	


	
	
	
    }
}

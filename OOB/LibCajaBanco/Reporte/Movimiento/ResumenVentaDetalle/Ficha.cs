using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDetalle
{
    
    public class Ficha
    {

        public string auto { get; set; }
        public string documento { get; set; }
        public DateTime fecha { get; set; }
        public string hora { get; set; }
        public string usuarioNombre { get; set; }
        public string usuarioCodigo { get; set; }
        public decimal total { get; set; }
        public int renglones { get; set; }
        public string nombreProducto { get; set; }
        public decimal cantidadUnd { get; set; }
        public decimal precioUnd { get; set; }
        public decimal totalRenglon { get; set; }
        public int signo { get; set; }
        public string documentoNombre { get; set; }
        public string decimales { get; set; }

        public string CajaEstacion
        {
            get 
            {
                var rt = "";
                rt = auto.Substring(2, 2);
                return rt;
            }
        }

    }

}
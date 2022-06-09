using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorProducto
{
    
    public class Ficha
    {

        public string codigoPrd { get; set; }
        public string nombrePrd { get; set; }
        public decimal cantidad { get; set; }
        public decimal totalMonto { get; set; }
        public decimal totalMontoDivisa { get; set; }
        public string nombreDocumento { get; set; }
        public int signo { get; set; }

    }

}
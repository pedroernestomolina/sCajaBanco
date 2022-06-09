using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCajaBanco.Reporte.Movimiento.ResumenInventario
{
    
    public class Ficha
    {

        public string codigoPrd { get; set; }
        public string nombrePrd { get; set; }
        public decimal tEntradas { get; set; }
        public decimal entradas { get; set; }
        public decimal entradasOt { get; set; }
        public decimal tSalidas { get; set; }
        public decimal salidas { get; set; }
        public string decimales { get; set; }


        public Ficha()
        {
            codigoPrd = "";
            nombrePrd = "";
            tEntradas = 0.0m;
            entradas = 0.0m;
            entradasOt = 0.0m;
            tSalidas = 0.0m;
            salidas = 0.0m;
            decimales = "";
        }

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibCajaBanco.Reporte.Analisis.VentasAnuladas
{
    public class Detalle
    {
        public string autoPrd { get; set; }
        public string prdDesc { get; set; }
        public decimal cntEmp { get; set; }
        public int contEmp { get; set; }
        public decimal cntUnd { get; set; }
        public int cntDocInvol { get; set; }
    }
}
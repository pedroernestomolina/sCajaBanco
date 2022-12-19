using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibCajaBanco.Reporte.Analisis.VentaPorTasa
{
    
    public class Ficha
    {
        public decimal monto { get; set; }
        public decimal factor { get; set; }
        public int cnt { get; set; }
        public string codSuc { get; set; }
        public string descSuc { get; set; }
        public DateTime fecha { get; set; }
    }

}
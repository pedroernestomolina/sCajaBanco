using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCajaBanco.Reporte.Analisis.VentasAnuladas
{
    public class Documento
    {
        public string docNumero { get; set; }
        public DateTime docFecha { get; set; }
        public string docEntidad { get; set; }
        public decimal docMontoDivisa{ get; set; }
        public string docTipo { get; set; }
        public string docNombre { get; set; }
        public int docRenglones { get; set; }
        public string docHora { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal
{
    public class DocDetalle
    {
        public string idDocVta { get; set; }
        public string entidad { get; set; }
        public DateTime fecha { get; set; }
        public decimal importeDoc { get; set; }
        public decimal importeDocDivisa { get; set; }
        public decimal factorCambio { get; set; }
        public string nombrePrd { get; set; }
        public decimal cant { get; set; }
        public string empq { get; set; }
        public int contEmp { get; set; }
        public bool isProductoDivisa { get; set; }
        public decimal importeItem { get; set; }
        public decimal importeItemDivisa { get; set; }
    }
}
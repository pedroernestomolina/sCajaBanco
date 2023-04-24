using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.src.Analisis.PorMetPago
{
    public class dataTot
    {
        public string descripcion { get; set; }
        public decimal Efectivo { get; set; }
        public decimal Divisa { get; set; }
        public decimal Tarjeta { get; set; }
        public decimal CntDivisa { get; set; }
        public decimal SumaBs { get; set; }
        public decimal TotEnBs { get; set; }
        public decimal TotEnDiv { get; set; }
    }
}
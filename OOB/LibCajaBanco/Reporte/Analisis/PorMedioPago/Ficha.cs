using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCajaBanco.Reporte.Analisis.PorMedioPago
{
    public class Ficha
    {
        public string autoSuc { get; set; }
        public string codigoSuc { get; set; }
        public string descSuc { get; set; }
        public decimal efectivo { get; set; }
        public decimal divisa { get; set; }
        public decimal debito { get; set; }
        public decimal otros { get; set; }
        public decimal cntDivisa { get; set; }
        public decimal efectivoUsu { get; set; }
        public decimal divisaUsu { get; set; }
        public decimal debitoUsu { get; set; }
        public decimal otrosUsu { get; set; }
        public decimal cntDivisaUsu { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.src.Consulta.VentaProductoDivisaPagoEnMonLocal.Domain.Models
{
    public class Data
    {
        public string idDoc { get; set; }
        public string docNumero { get; set; }
        public DateTime fechaEmision { get; set; }
        public string entidadNombre { get; set; }
        public string entidadCiRif { get; set; }
        public decimal montoDivisa { get; set; }
        public string idRecibo { get; set; }
        public string nombrePrd { get; set; }
        public decimal cantidad { get; set; }
        public string empqNombre { get; set; }
        public decimal empqCont { get; set; }
        public bool isPrdDivisa { get; set; }
        public string codigoMp { get; set; }
        public string nombreMp { get; set; }
        public string codigoMonRecibe { get; set; }
        public decimal montoMonRecibe { get; set; }
        public decimal montoMonRecibeMonRef { get; set; }
    }
}
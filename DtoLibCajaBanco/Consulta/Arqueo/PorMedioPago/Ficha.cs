using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibCajaBanco.Consulta.Arqueo.PorMedioPago
{
    public class Ficha
    {
        public DateTime fecha { get; set; }
        public int cierreNro { get; set; }
        public string codigoMP { get; set; }
        public string descMP { get; set; }
        public string codigoMon { get; set; }
        public string descMon { get; set; }
        public string simboloMon { get; set; }
        public decimal montoSS { get; set; }
        public decimal montoSU{ get; set; }
        public decimal importeSegunSistema { get; set; }
        public decimal importeSegunUsuario { get; set; }
        public string codigoSuc { get; set; }
        public string nombreSuc { get; set; }
    }
}
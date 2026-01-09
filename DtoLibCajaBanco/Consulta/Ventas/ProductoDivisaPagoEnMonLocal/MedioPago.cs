using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal
{
    public class MedioPago
    {
        public string idDocVta { get; set; }
        public string idRecibo{ get; set; }
        public string idMedioPago { get; set; }
        public string nombreMedioPago { get; set; }
        public string codigoMonedaRecibe { get; set; }
        public string simboloMonedaRecibe { get; set; }
        public decimal montoMonedaRecibe { get; set; }
        public decimal montoMonedaReferencia { get; set; }
    }
}
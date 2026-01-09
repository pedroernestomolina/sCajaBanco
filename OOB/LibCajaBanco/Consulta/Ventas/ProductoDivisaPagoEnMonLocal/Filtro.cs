using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal
{
    public class Filtro: baseFiltro
    {
        public string codigoSuc { get; set; }
        public string codigoMon { get; set; }
        public Filtro()
            :base()
        {
            codigoSuc = "";
            codigoMon = "";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal
{
    public class Ficha
    {
        public List<DocDetalle> docDetalle { get; set; }
        public List<MedioPago> mediosPago { get; set; }
    }
}
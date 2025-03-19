using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibCajaBanco.Reporte.Analisis.VentasAnuladas
{
    public class Ficha
    {
        public List<Documento> Documentos { get; set; }
        public List<Detalle> Detalles { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCajaBanco.Reporte.Analisis.VentaPromedio
{
    
    public class Ficha
    {

        public int cntMov { get; set; }
        public decimal venta { get; set; }
        public decimal ventaDivisa { get; set; }
        public string codSucursal { get; set; }
        public string sucursal { get; set; }
        public string mes { get; set; }
        public string ano { get; set; }
        public DateTime fecha { get { return new DateTime(int.Parse(ano), int.Parse(mes), 1); } }
        public int dias { get; set; }
        public decimal cntItemStock { get; set; }
        public decimal costoStock { get; set; }
        public decimal ventaPromedio { get { return ventaDivisa / dias; } }
        public decimal cntMovPromedio { get { return cntMov / dias; } }

    }

}
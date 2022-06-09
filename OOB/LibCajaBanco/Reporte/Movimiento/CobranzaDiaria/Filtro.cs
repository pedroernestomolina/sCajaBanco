using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCajaBanco.Reporte.Movimiento.CobranzaDiaria
{
    
    public class Filtro
    {

        public string codSucursal { get; set; }
        public DateTime desdeFecha { get; set; }
        public DateTime hastaFecha { get; set; }
        public bool esPorFecha { get; set; }
        public int desdeCierre { get; set; }
        public int hastaCierre { get; set; }
        public bool esPorCierre { get; set; }


        public Filtro()
        {
            codSucursal = "";
            esPorFecha = false;
            desdeFecha = DateTime.Now.Date;
            hastaFecha = DateTime.Now.Date;
            esPorCierre = false;
            desdeCierre = 0;
            hastaCierre = 0;
        }

    }

}
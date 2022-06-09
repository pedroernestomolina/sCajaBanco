using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCajaBanco.Reporte.Analisis.VentaDiaria
{
    
    public class Ficha
    {

        public string auto { get; set; }
        public DateTime fecha { get; set; }
        public string codSucursal { get; set; }
        public string nomSucursal { get; set; }
        public int estacion { get { return int.Parse(auto.Substring(2, 2)); } }
        public int dia { get { return  fecha.Day; } }
        public int mes { get { return fecha.Month; } }
        public int ano { get { return fecha.Year; } }


        public Ficha()
        {
            auto = "";
            fecha = DateTime.Now.Date;
            codSucursal = "";
            nomSucursal = "";
        }

    }

}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCajaBanco.Reporte.Analisis.VentaDiaria
{
    
    public class Filtro
    {

        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }


        public Filtro()
        {
            desde = DateTime.Now.Date;
            hasta = DateTime.Now.Date;
        }

    }

}
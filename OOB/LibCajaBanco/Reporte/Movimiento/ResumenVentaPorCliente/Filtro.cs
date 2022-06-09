﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorCliente
{
    
    public class Filtro
    {

        public string codigoSucursal { get; set; }
        public DateTime desdeFecha { get; set; }
        public DateTime hastaFecha { get; set; }


        public Filtro()
        {
            codigoSucursal = "";
            desdeFecha = DateTime.Now.Date;
            hastaFecha = DateTime.Now.Date;
        }

    }

}
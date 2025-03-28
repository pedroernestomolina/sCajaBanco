﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCajaBanco.Sucursal
{
    public class Ficha
    {
        public string auto { get; set; }
        public string autoGrupoEmpresa { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string nombreGrupoEmpresa { get; set; }
        public string estatusActivo { get; set; }
        public bool IsActivo { get { return estatusActivo.Trim().ToUpper() == "1"; } }
    }
}
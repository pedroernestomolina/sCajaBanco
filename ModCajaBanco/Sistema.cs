using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco
{
    
    public class Sistema
    {

        static public DataProvCajaBanco.Infra.IData MyData;
        static public OOB.LibCajaBanco.Usuario.Ficha UsuarioP;
        static public string _Instancia { get; set; }
        static public string _BaseDatos { get; set; }
        public static bool _ActivarComoSucursal { get; set; }

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCajaBanco.Infra
{
    
    public interface IUsuario
    {

        OOB.ResultadoEntidad<OOB.LibCajaBanco.Usuario.Ficha> Usuario_Principal();

    }

}
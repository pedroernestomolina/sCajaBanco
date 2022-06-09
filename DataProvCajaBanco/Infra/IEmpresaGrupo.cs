using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCajaBanco.Infra
{
    
    public interface IEmpresaGrupo
    {

        OOB.ResultadoEntidad<OOB.LibCajaBanco.EmpresaGrupo.Ficha > EmpresaGrupo_GetFicha(string autoGrupo);

    }

}
using ServiceCajaBanco.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCajaBanco.MyService
{
    
    public partial class Service : IService
    {

        public DtoLib.ResultadoEntidad<DtoLibCajaBanco.EmpresaGrupo.Ficha> EmpresaGrupo_GetFicha(string autoGrupo)
        {
            return ServiceProv.EmpresaGrupo_GetFicha(autoGrupo);
        }

    }

}
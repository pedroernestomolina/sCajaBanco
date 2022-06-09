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

        public DtoLib.ResultadoLista<DtoLibCajaBanco.Sucursal.Resumen> Sucursal_GetLista()
        {
            return ServiceProv.Sucursal_GetLista();
        }

        public DtoLib.ResultadoEntidad<DtoLibCajaBanco.Sucursal.Ficha> Sucursal_GetPrincipal()
        {
            return ServiceProv.Sucursal_GetPrincipal();
        }

        public DtoLib.ResultadoEntidad<DtoLibCajaBanco.Sucursal.Ficha> Sucursal_GetFicha(string auto)
        {
            return ServiceProv.Sucursal_GetFicha(auto);
        }

    }

}
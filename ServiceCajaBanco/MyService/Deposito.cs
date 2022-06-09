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

        public DtoLib.ResultadoLista<DtoLibCajaBanco.Deposito.Resumen> Deposito_GetLista()
        {
            return ServiceProv.Deposito_GetLista();
        }

        public DtoLib.ResultadoEntidad<DtoLibCajaBanco.Deposito.Ficha> Deposito_GetPrincipal()
        {
            return ServiceProv.Deposito_GetPrincipal();
        }

        public DtoLib.ResultadoEntidad<DtoLibCajaBanco.Deposito.Ficha> Deposito_GetFicha(string auto)
        {
            return ServiceProv.Deposito_GetFicha(auto);
        }

    }

}
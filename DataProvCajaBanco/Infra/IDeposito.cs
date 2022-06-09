using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCajaBanco.Infra
{
    
    public interface IDeposito
    {

        OOB.ResultadoLista<OOB.LibCajaBanco.Deposito.Ficha> Deposito_GetLista();
        OOB.ResultadoEntidad<OOB.LibCajaBanco.Deposito.Ficha> Deposito_GetPrincipal();
        OOB.ResultadoEntidad<OOB.LibCajaBanco.Deposito.Ficha> Deposito_GetFicha(string auto);

    }

}
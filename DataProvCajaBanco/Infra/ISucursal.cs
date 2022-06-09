using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCajaBanco.Infra
{
    
    public interface ISucursal
    {

        OOB.ResultadoLista<OOB.LibCajaBanco.Sucursal.Ficha> Sucursal_GetLista();
        OOB.ResultadoEntidad<OOB.LibCajaBanco.Sucursal.Ficha> Sucursal_GetPrincipal();
        OOB.ResultadoEntidad<OOB.LibCajaBanco.Sucursal.Ficha> Sucursal_GetFicha(string auto);

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibCajaBanco
{
    public interface IProvider: ISucursal, IUsuario, IReporteMovimiento, IDeposito, IEmpresaGrupo
    {
        DtoLib.ResultadoEntidad<DateTime> 
            FechaServidor();
        DtoLib.ResultadoEntidad<DtoLibCajaBanco.Empresa.Entidad.Ficha>
            Sistema_Empresa_GetFicha();
    }
}
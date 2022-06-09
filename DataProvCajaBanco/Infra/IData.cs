using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCajaBanco.Infra
{

    public interface IData: ISucursal, IUsuario, IReporteMovimiento, IDeposito, IEmpresaGrupo
    {

        OOB.ResultadoEntidad<DateTime> FechaServidor();

    }

}
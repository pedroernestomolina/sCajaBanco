using DataProvCajaBanco.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCajaBanco.Data
{
 
    public partial class DataProv: IData
    {

        public OOB.ResultadoEntidad<OOB.LibCajaBanco.EmpresaGrupo.Ficha> EmpresaGrupo_GetFicha(string autoGrupo)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCajaBanco.EmpresaGrupo.Ficha>();

            var r01 = MyData.EmpresaGrupo_GetFicha(autoGrupo);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var r = new OOB.LibCajaBanco.EmpresaGrupo.Ficha()
            {
                auto = s.auto,
                nombre = s.nombre,
                 idPrecio=s.idPrecio,
            };
            rt.Entidad = r;

            return rt;
        }

    }

}
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

        public OOB.ResultadoLista<OOB.LibCajaBanco.Sucursal.Ficha> Sucursal_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibCajaBanco.Sucursal.Ficha>();

            var r01 = MyData.Sucursal_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var list = new List<OOB.LibCajaBanco.Sucursal.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    list = r01.Lista.Select(s =>
                    {
                        return new OOB.LibCajaBanco.Sucursal.Ficha()
                        {
                            auto = s.auto,
                            codigo = s.codigo,
                            nombre = s.nombre,
                        };
                    }).ToList();
                }
            }
            rt.Lista = list;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCajaBanco.Sucursal.Ficha> Sucursal_GetPrincipal()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCajaBanco.Sucursal.Ficha>();

            var r01 = MyData.Sucursal_GetPrincipal();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var r = new OOB.LibCajaBanco.Sucursal.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
                autoGrupoEmpresa=s.autoEmpresaGrupo,
                nombreGrupoEmpresa= s.nombreEmpresaGrupo,
            };
            rt.Entidad = r;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCajaBanco.Sucursal.Ficha> Sucursal_GetFicha(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCajaBanco.Sucursal.Ficha>();

            var r01 = MyData.Sucursal_GetFicha(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var r = new OOB.LibCajaBanco.Sucursal.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
                autoGrupoEmpresa = s.autoEmpresaGrupo,
                nombreGrupoEmpresa = s.nombreEmpresaGrupo,
            };
            rt.Entidad = r;

            return rt;
        }

    }

}
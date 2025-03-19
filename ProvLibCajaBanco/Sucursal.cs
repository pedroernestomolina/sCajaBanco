using LibEntityCajaBanco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProvLibCajaBanco
{
    public partial class Provider : ILibCajaBanco.IProvider 
    {
        public DtoLib.ResultadoLista<DtoLibCajaBanco.Sucursal.Resumen> 
            Sucursal_GetLista()
        {
            var result = new DtoLib.ResultadoLista<DtoLibCajaBanco.Sucursal.Resumen>();
            //
            try
            {
                var lst = new List<DtoLibCajaBanco.Sucursal.Resumen>();
                using (var cnn = new cajaBancoEntities(_cnCajBanco.ConnectionString))
                {
                    var _sql = @"select 
                                    suc.auto as auto,
                                    suc.codigo as codigo,
                                    suc.nombre as nombre,
                                    sucExt.es_activo as estatusActivo
                                from empresa_sucursal as suc
                                join empresa_sucursal_ext as sucExt on sucExt.auto_sucursal=suc.auto";
                    lst = cnn.Database.SqlQuery<DtoLibCajaBanco.Sucursal.Resumen>(_sql).ToList();
                    result.Lista = lst;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
        public DtoLib.ResultadoEntidad<DtoLibCajaBanco.Sucursal.Ficha> 
            Sucursal_GetPrincipal()
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibCajaBanco.Sucursal.Ficha>();

            try
            {
                using (var cnn = new cajaBancoEntities(_cnCajBanco.ConnectionString))
                {
                    var codigo= "";

                    var entSistema = cnn.sistema.FirstOrDefault();
                    if (entSistema == null)
                    {
                        result.Mensaje = "REGISTRO PRINCIPAL [ SISTEMA ] NO DEFINIDO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                    }
                    codigo= entSistema.codigo_empresa;

                    var ent = cnn.empresa_sucursal.FirstOrDefault(f=>f.codigo==codigo);
                    if (ent == null)
                    {
                        result.Mensaje = "SUCURSAL NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                    }

                    var autoEmpresaGrupo = "";
                    var nombreEmpresaGrupo = "";
                    var entEmpresaGrupo = cnn.empresa_grupo.Find(ent.autoEmpresaGrupo);
                    if (entEmpresaGrupo != null) 
                    {
                        autoEmpresaGrupo = entEmpresaGrupo.auto;
                        nombreEmpresaGrupo = entEmpresaGrupo.nombre;
                    }

                    var r = new DtoLibCajaBanco.Sucursal.Ficha()
                    {
                        auto = ent.auto,
                        autoEmpresaGrupo=ent.autoEmpresaGrupo,
                        codigo = ent.codigo,
                        nombre = ent.nombre,
                        nombreEmpresaGrupo= nombreEmpresaGrupo,
                    };

                    result.Entidad = r;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
        public DtoLib.ResultadoEntidad<DtoLibCajaBanco.Sucursal.Ficha> 
            Sucursal_GetFicha(string auto)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibCajaBanco.Sucursal.Ficha>();

            try
            {
                using (var cnn = new cajaBancoEntities(_cnCajBanco.ConnectionString))
                {
                    var ent = cnn.empresa_sucursal.Find(auto);
                    if (ent == null)
                    {
                        result.Mensaje = "SUCURSAL NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }

                    var autoEmpresaGrupo = "";
                    var nombreEmpresaGrupo = "";
                    var entEmpresaGrupo = cnn.empresa_grupo.Find(ent.autoEmpresaGrupo);
                    if (entEmpresaGrupo != null)
                    {
                        autoEmpresaGrupo = entEmpresaGrupo.auto;
                        nombreEmpresaGrupo = entEmpresaGrupo.nombre;
                    }

                    var r = new DtoLibCajaBanco.Sucursal.Ficha()
                    {
                        auto = ent.auto,
                        autoEmpresaGrupo = ent.autoEmpresaGrupo,
                        codigo = ent.codigo,
                        nombre = ent.nombre,
                        nombreEmpresaGrupo = nombreEmpresaGrupo,
                    };

                    result.Entidad = r;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }
    }
}
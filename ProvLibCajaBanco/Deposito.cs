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

        public DtoLib.ResultadoLista<DtoLibCajaBanco.Deposito.Resumen> Deposito_GetLista()
        {
            var result = new DtoLib.ResultadoLista<DtoLibCajaBanco.Deposito.Resumen>();
            //
            try
            {
                var lst = new List<DtoLibCajaBanco.Deposito.Resumen>();
                using (var cnn = new cajaBancoEntities(_cnCajBanco.ConnectionString))
                {
                    var _sql = @"select 
                                    dep.auto as auto, 
                                    dep.codigo as codigo, 
                                    dep.nombre as nombre, 
                                    depExt.es_activo as estatusActivo 
                                from empresa_depositos as dep
                                join empresa_depositos_ext as depExt on depExt.auto_deposito=dep.auto";
                    lst = cnn.Database.SqlQuery<DtoLibCajaBanco.Deposito.Resumen>(_sql).ToList();
                }
                result.Lista = lst;
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }

        public DtoLib.ResultadoEntidad<DtoLibCajaBanco.Deposito.Ficha> Deposito_GetPrincipal()
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibCajaBanco.Deposito.Ficha>();

            try
            {
                using (var cnn = new cajaBancoEntities(_cnCajBanco.ConnectionString))
                {
                    var auto="";

                    var entSistema = cnn.sistema.FirstOrDefault();
                    if (entSistema == null) 
                    {
                        result.Mensaje = "REGISTRO PRINCIPAL [ SISTEMA ] NO DEFINIDO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                    }
                    auto = entSistema.deposito_principal;

                    var ent = cnn.empresa_depositos.Find(auto);
                    if (ent == null)
                    {
                        result.Mensaje = "[ AUTO ] DEPOSITO PRINCIPAL NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                    }

                    var r = new DtoLibCajaBanco.Deposito.Ficha()
                    {
                        auto = ent.auto,
                        codigo = ent.codigo,
                        nombre = ent.nombre,
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

        public DtoLib.ResultadoEntidad<DtoLibCajaBanco.Deposito.Ficha> Deposito_GetFicha(string auto)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibCajaBanco.Deposito.Ficha>();

            try
            {
                using (var cnn = new cajaBancoEntities(_cnCajBanco.ConnectionString))
                {
                    var ent = cnn.empresa_depositos.Find(auto);
                    if (ent == null)
                    {
                        result.Mensaje = "[ AUTO ] DEPOSITO NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }

                    var r = new DtoLibCajaBanco.Deposito.Ficha()
                    {
                        auto = ent.auto,
                        codigo = ent.codigo,
                        nombre = ent.nombre,
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
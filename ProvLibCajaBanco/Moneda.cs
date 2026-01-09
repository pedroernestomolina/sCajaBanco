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
        public DtoLib.ResultadoEntidad<DtoLibCajaBanco.Moneda.Entidad.Ficha> 
            Moneda_GetFichaById(int id)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibCajaBanco.Moneda.Entidad.Ficha>();
            //
            try
            {
                using (var cnn = new cajaBancoEntities(_cnCajBanco.ConnectionString))
                {
                    var _sql = @"select 
                                    id,
                                    codigo,
                                    nombre,
                                    simbolo,
                                    tasa_respecto_mon_referencia as tasaRespectoMonReferencia
                            from vl_currencies where id=@id";
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@id", id);
                    var ent = cnn.Database.SqlQuery<DtoLibCajaBanco.Moneda.Entidad.Ficha>(_sql, p1).FirstOrDefault();
                    if (ent == null)
                    {
                        throw new Exception("[ ID MONEDA ] NO ENCONTRADO");
                    }
                    result.Entidad = ent;
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
    }
}
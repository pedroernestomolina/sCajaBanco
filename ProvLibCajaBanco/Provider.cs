﻿using LibEntityCajaBanco;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProvLibCajaBanco
{
    public partial class Provider : ILibCajaBanco.IProvider 
    {
        static EntityConnectionStringBuilder _cnCajBanco;
        private string _Instancia;
        private string _BaseDatos;
        private string _Usuario;
        private string _Password;


        public Provider(string instancia, string bd)
        {
            _Usuario = "root";
            _Password = "123";
            _Instancia = instancia;
            _BaseDatos = bd ;
            setConexion();
        }


        private void setConexion()
        {
            _cnCajBanco = new EntityConnectionStringBuilder();
            _cnCajBanco.Metadata = "res://*/ModelLibCajaBanco.csdl|res://*/ModelLibCajaBanco.ssdl|res://*/ModelLibCajaBanco.msl";
            _cnCajBanco.Provider = "MySql.Data.MySqlClient";
            _cnCajBanco.ProviderConnectionString = "data source=" + _Instancia + ";initial catalog=" + _BaseDatos + ";user id=" + _Usuario + ";Password=" + _Password + ";Convert Zero Datetime=True;";
        }


        public DtoLib.ResultadoEntidad<DateTime> 
            FechaServidor()
        {
            var result = new DtoLib.ResultadoEntidad<DateTime>();
            try
            {
                using (var ctx = new cajaBancoEntities(_cnCajBanco.ConnectionString))
                {
                    var fechaSistema = ctx.Database.SqlQuery<DateTime>("select now()").FirstOrDefault();
                    result.Entidad = fechaSistema.Date;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            return result;
        }
        public DtoLib.ResultadoEntidad<DtoLibCajaBanco.Empresa.Entidad.Ficha> 
            Sistema_Empresa_GetFicha()
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibCajaBanco.Empresa.Entidad.Ficha>();
            try
            {
                using (var cnn = new cajaBancoEntities(_cnCajBanco.ConnectionString))
                {
                    var sql = @"SELECT nombre, direccion, rif as cirif, telefono 
                                FROM empresa
                                WHERE auto='0000000001'";
                    var ent = cnn.Database.SqlQuery<DtoLibCajaBanco.Empresa.Entidad.Ficha>(sql).FirstOrDefault();

                    sql = @"select logo from empresa_extra";
                    var _logo = cnn.Database.SqlQuery<byte[]>(sql).FirstOrDefault();
                    ent.logo = _logo;
                    result.Entidad = ent;
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
﻿using DataProvCajaBanco.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCajaBanco.Data
{
    
    public partial class DataProv: IData
    {

        public OOB.ResultadoLista<OOB.LibCajaBanco.Deposito.Ficha> Deposito_GetLista()
        {
            var rt = new OOB.ResultadoLista<OOB.LibCajaBanco.Deposito.Ficha>();
            //
            try
            {
                var r01 = MyData.Deposito_GetLista();
                if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                var list = new List<OOB.LibCajaBanco.Deposito.Ficha>();
                if (r01.Lista != null)
                {
                    if (r01.Lista.Count > 0)
                    {
                        list = r01.Lista.Select(s =>
                        {
                            return new OOB.LibCajaBanco.Deposito.Ficha()
                            {
                                auto = s.auto,
                                codigo = s.codigo,
                                nombre = s.nombre,
                                estatusActivo = s.estatusActivo,
                            };
                        }).ToList();
                    }
                }
                rt.Lista = list;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCajaBanco.Deposito.Ficha> Deposito_GetPrincipal()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCajaBanco.Deposito.Ficha>();

            var r01 = MyData.Deposito_GetPrincipal();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var r = new OOB.LibCajaBanco.Deposito.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
            };
            rt.Entidad = r;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCajaBanco.Deposito.Ficha> Deposito_GetFicha(string auto)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCajaBanco.Deposito.Ficha>();

            var r01 = MyData.Deposito_GetFicha(auto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var r = new OOB.LibCajaBanco.Deposito.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
            };
            rt.Entidad = r;

            return rt;
        }

    }

}
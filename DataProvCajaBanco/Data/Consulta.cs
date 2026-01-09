using DataProvCajaBanco.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCajaBanco.Data
{
    public partial class DataProv : IData
    {
        public OOB.ResultadoLista<OOB.LibCajaBanco.Consulta.Arqueo.PorMedioPago.Ficha>
            Consulta_Arqueo_PorMedioPago(OOB.LibCajaBanco.Consulta.Arqueo.PorMedioPago.Filtro filtro)
        {
            var rt = new OOB.ResultadoLista<OOB.LibCajaBanco.Consulta.Arqueo.PorMedioPago.Ficha>();
            //
            try
            {
                var filtroDTO = new DtoLibCajaBanco.Consulta.Arqueo.PorMedioPago.Filtro()
                {
                    desde = filtro.desde,
                    hasta = filtro.hasta,
                };
                var rst = MyData.Consulta_Arqueo_PorMedioPago(filtroDTO);
                if (rst.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst.Mensaje);
                }
                if (rst.Lista == null) 
                {
                    throw new Exception("DATA NO CARGADA");
                }
                var _lst = new List<OOB.LibCajaBanco.Consulta.Arqueo.PorMedioPago.Ficha>();
                if (rst.Lista.Count > 0)
                {
                    _lst = rst.Lista.Select (s =>
                    {
                        return new OOB.LibCajaBanco.Consulta.Arqueo.PorMedioPago.Ficha()
                        {
                            fecha=s.fecha,
                            cierreNro= s.cierreNro,
                            codigoMon = s.codigoMon,
                            codigoMP = s.codigoMP,
                            codigoSuc = s.codigoSuc,
                            descMon = s.descMon,
                            descMP = s.descMP,
                            montoSS = s.montoSS,
                            montoSU = s.montoSU,
                            importeSegunSistema= s.importeSegunSistema,
                            importeSegunUsuario= s.importeSegunUsuario,
                            nombreSuc = s.nombreSuc,
                            simboloMon = s.simboloMon,
                        };
                    }).ToList();
                }
                rt.Lista = _lst;
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Ficha> 
            Consulta_Ventas_ProductoDivisaPagoEnMonLocal(OOB.LibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Filtro filtro)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Ficha>();
            //
            try
            {
                var filtroDTO = new DtoLibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Filtro()
                {
                    desde = filtro.desde,
                    hasta = filtro.hasta,
                    codigoMon = filtro.codigoMon,
                    codigoSuc = filtro.codigoSuc,
                };
                var rst = MyData.Consulta_Ventas_ProductoDivisaPagoEnMonLocal(filtroDTO);
                if (rst.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst.Mensaje);
                }
                if (rst.Entidad == null)
                {
                    throw new Exception("DATA NO CARGADA");
                }
                if (rst.Entidad.docDetalle == null)
                {
                    throw new Exception("DATA NO CARGADA");
                }
                if (rst.Entidad.mediosPago == null)
                {
                    throw new Exception("DATA NO CARGADA");
                }
                var _lstDocDet = new List<OOB.LibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.DocDetalle>();
                if (rst.Entidad.docDetalle.Count > 0)
                {
                    _lstDocDet = rst.Entidad.docDetalle.Select(s =>
                    {
                        return new OOB.LibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.DocDetalle()
                        {
                            cant = s.cant,
                            contEmp = s.contEmp,
                            empq = s.empq,
                            entidad = s.entidad,
                            isProductoDivisa = s.estatusDivisaProducto.Trim().ToUpper() == "1",
                            factorCambio = s.factorCambio,
                            fecha = s.fecha,
                            idDocVta = s.idDocVta,
                            importeDoc = s.importeDoc,
                            importeDocDivisa = s.importeDocDivisa,
                            importeItem = s.importeItem,
                            importeItemDivisa = s.importeItemDivisa,
                            nombrePrd = s.nombrePrd,
                        };
                    }).ToList();
                }
                var _lstMedPago = new List<OOB.LibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.MedioPago>();
                if (rst.Entidad.mediosPago.Count > 0)
                {
                    _lstMedPago = rst.Entidad.mediosPago.Select(s =>
                    {
                        return new OOB.LibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.MedioPago()
                        {
                            codigoMonedaRecibe = s.codigoMonedaRecibe,
                            idDocVta = s.idDocVta,
                            idMedioPago = s.idMedioPago,
                            idRecibo = s.idRecibo,
                            montoMonedaRecibe = s.montoMonedaRecibe,
                            montoMonedaReferencia = s.montoMonedaReferencia,
                            nombreMedioPago = s.nombreMedioPago,
                            simboloMonedaRecibe = s.simboloMonedaRecibe,
                        };
                    }).ToList();
                }
                rt.Entidad = new OOB.LibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Ficha()
                {
                    docDetalle = _lstDocDet,
                    mediosPago = _lstMedPago,
                };
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = OOB.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
    }
}
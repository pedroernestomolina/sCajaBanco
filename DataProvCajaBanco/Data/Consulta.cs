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
                var _lstDocDet = new List<OOB.LibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.DocDetalle>();
                if (rst.Entidad.docDetalle.Count > 0)
                {
                    _lstDocDet = rst.Entidad.docDetalle.Select(s =>
                    {
                        return new OOB.LibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.DocDetalle()
                        {
                            cantidad = s.cantidad,
                            codigoMonRecibe = s.codigoMonRecibe,
                            codigoMp = s.codigoMp,
                            docNumero = s.docNumero,
                            empqCont = s.empqCont,
                            empqNombre = s.empqNombre,
                            entidadCiRif = s.entidadCiRif,
                            entidadNombre = s.entidadNombre,
                            fechaEmision = s.fechaEmision,
                            idDoc = s.idDoc,
                            idRecibo = s.idRecibo,
                            isPrdDivisa = s.estatusPrdDivisa.Trim().ToUpper() == "1",
                            montoDivisa = s.montoDivisa,
                            montoMonRecibe = s.montoMonRecibe,
                            montoMonRecibeMonRef = s.montoMonRecibeMonRef,
                            nombreMp = s.nombreMp,
                            nombrePrd = s.nombrePrd,
                        };
                    }).ToList();
                }
                rt.Entidad = new OOB.LibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Ficha()
                {
                    docDetalle = _lstDocDet,
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
        public OOB.ResultadoEntidad<OOB.LibCajaBanco.Moneda.Entidad.Ficha> 
            Consulta_GetMonedaLocal()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCajaBanco.Moneda.Entidad.Ficha>();
            //
            try
            {
                var rst = MyData.Configuracion_MonedaLocal();
                if (rst.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst.Mensaje);
                }
                if (rst.Entidad == null)
                {
                    throw new Exception("DATA NO CARGADA");
                }
                var id = 0;
                if (!int.TryParse(rst.Entidad, out id))
                {
                    throw new Exception("PROBLEMA AL CONVERTIR ID DE MONEDA LOCAL");
                }
                var rst2 = MyData.Moneda_GetFichaById(id);
                if (rst2.Result == DtoLib.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst2.Mensaje);
                }
                if (rst2.Entidad == null)
                {
                    throw new Exception("DATA NO CARGADA");
                }
                var s = rst2.Entidad;
                rt.Entidad = new OOB.LibCajaBanco.Moneda.Entidad.Ficha()
                {
                    codigo = s.codigo,
                    id = s.id,
                    nombre = s.nombre,
                    simbolo = s.simbolo,
                    tasaRespectoMonReferencia = s.tasaRespectoMonReferencia,
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
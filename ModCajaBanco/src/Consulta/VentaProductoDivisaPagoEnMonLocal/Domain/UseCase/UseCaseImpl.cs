using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.src.Consulta.VentaProductoDivisaPagoEnMonLocal.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public List<Models.Data>
            ConsultarVentasProductoDivisaConPagoEnMonLocal(DateTime pDesde, DateTime pHasta, string pCodigoSuc, string pCodigoMon)
        {
            try
            {
                var filtroOOB = new OOB.LibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Filtro()
                {
                    codigoMon = pCodigoMon,
                    codigoSuc = pCodigoSuc,
                    desde = pDesde,
                    hasta = pHasta,
                };
                var rst = Sistema.MyData.Consulta_Ventas_ProductoDivisaPagoEnMonLocal(filtroOOB);
                if (rst.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(rst.Mensaje);
                }
                //
                var _lst = new List<Models.Data>();
                if (rst.Entidad.docDetalle.Count > 0) 
                {
                    _lst = rst.Entidad.docDetalle.Select(s =>
                    {
                        return new Models.Data()
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
                            isPrdDivisa = s.isPrdDivisa,
                            montoDivisa = s.montoDivisa,
                            montoMonRecibe = s.montoMonRecibe,
                            montoMonRecibeMonRef = s.montoMonRecibeMonRef,
                            nombreMp = s.nombreMp,
                            nombrePrd = s.nombrePrd,
                        };
                    }).ToList();
                }
                return _lst;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Models.Moneda 
            ObtenerMonedaLocal()
        {
            try
            {
                var rst = Sistema.MyData.Consulta_GetMonedaLocal();
                if (rst.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst.Mensaje);
                }
                //
                var s= rst.Entidad;
                var rt = new Models.Moneda()
                {
                    codigo = s.codigo,
                    id = s.id,
                    nombre = s.nombre,
                    simbolo = s.simbolo,
                    tasaRespectoMonReferencia = s.tasaRespectoMonReferencia,
                };
                return rt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public Models.Sucursal 
            ObtenerSucursal(string id)
        {
            try
            {
                var rst = Sistema.MyData.Sucursal_GetFicha(id);
                if (rst.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst.Mensaje);
                }
                //
                var s = rst.Entidad;
                var rt = new Models.Sucursal()
                {
                    auto = s.auto,
                    codigo = s.codigo,
                    nombre = s.nombre,
                };
                return rt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.src.Consulta.VentaProductoDivisaPagoEnMonLocal.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public Models.Data 
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
                var rt = new Models.Data();
                return rt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void 
            ObtenerMonedaLocal()
        {
        }
    }
}
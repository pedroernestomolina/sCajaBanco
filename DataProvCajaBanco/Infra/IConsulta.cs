using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCajaBanco.Infra
{
    public interface IConsulta
    {
        OOB.ResultadoEntidad<OOB.LibCajaBanco.Moneda.Entidad.Ficha>
            Consulta_GetMonedaLocal();
        OOB.ResultadoLista<OOB.LibCajaBanco.Consulta.Arqueo.PorMedioPago.Ficha>
            Consulta_Arqueo_PorMedioPago(OOB.LibCajaBanco.Consulta.Arqueo.PorMedioPago.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Ficha>
            Consulta_Ventas_ProductoDivisaPagoEnMonLocal(OOB.LibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Filtro filtro);
    }
}
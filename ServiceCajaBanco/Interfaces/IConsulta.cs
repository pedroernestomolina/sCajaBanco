using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCajaBanco.Interfaces
{
    public interface IConsulta
    {
        DtoLib.ResultadoLista<DtoLibCajaBanco.Consulta.Arqueo.PorMedioPago.Ficha>
            Consulta_Arqueo_PorMedioPago(DtoLibCajaBanco.Consulta.Arqueo.PorMedioPago.Filtro filtro);
        DtoLib.ResultadoEntidad<DtoLibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Ficha>
            Consulta_Ventas_ProductoDivisaPagoEnMonLocal(DtoLibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Filtro filtro);
        DtoLib.ResultadoEntidad<string>
            Configuracion_MonedaLocal();
    }
}
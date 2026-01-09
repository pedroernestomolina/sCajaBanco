using ServiceCajaBanco.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCajaBanco.MyService
{
    public partial class Service : IService
    {
        public DtoLib.ResultadoLista<DtoLibCajaBanco.Consulta.Arqueo.PorMedioPago.Ficha> 
            Consulta_Arqueo_PorMedioPago(DtoLibCajaBanco.Consulta.Arqueo.PorMedioPago.Filtro filtro)
        {
            return ServiceProv.Consulta_Arqueo_PorMedioPago(filtro);
        }
        public DtoLib.ResultadoEntidad<DtoLibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Ficha> 
            Consulta_Ventas_ProductoDivisaPagoEnMonLocal(DtoLibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Filtro filtro)
        {
            return ServiceProv.Consulta_Ventas_ProductoDivisaPagoEnMonLocal(filtro);
        }
        public DtoLib.ResultadoEntidad<string> 
            Configuracion_MonedaLocal()
        {
            return ServiceProv.Configuracion_MonedaLocal();
        }
        public DtoLib.ResultadoEntidad<DtoLibCajaBanco.Moneda.Entidad.Ficha> 
            Moneda_GetFichaById(int id)
        {
            return ServiceProv.Moneda_GetFichaById(id);
        }
    }
}
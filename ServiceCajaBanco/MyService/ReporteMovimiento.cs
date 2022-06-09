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

        public DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Movimiento.ArqueoCajaPos.Ficha> CajaBanco_ArqueoCajaPos(DtoLibCajaBanco.Reporte.Movimiento.Filtro filtro)
        {
            return ServiceProv.CajaBanco_ArqueoCajaPos(filtro);
        }

        public DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Movimiento.Inventario.Ficha> Reporte_InventarioResumen(DtoLibCajaBanco.Reporte.Movimiento.Inventario.Filtro filtro)
        {
            return ServiceProv.Reporte_InventarioResumen(filtro);
        }

        public DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Movimiento.ResumenVenta.Ficha> Reporte_VentaResumen(DtoLibCajaBanco.Reporte.Movimiento.ResumenVenta.Filtro filtro)
        {
            return ServiceProv.Reporte_VentaResumen(filtro);
        }

        public DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Habladores.Ficha> Reporte_Habladores(DtoLibCajaBanco.Reporte.Habladores.Filtro filtro)
        {
            return ServiceProv.Reporte_Habladores(filtro);
        }

        public DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Movimiento.FacturaDetalle.Ficha> Reporte_VentaDetalle(DtoLibCajaBanco.Reporte.Movimiento.FacturaDetalle.Filtro filtro)
        {
            return ServiceProv.Reporte_VentaDetalle (filtro);
        }

        public DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Movimiento.VentasPorProducto.Ficha> Reporte_VentaPorProducto(DtoLibCajaBanco.Reporte.Movimiento.VentasPorProducto.Filtro filtro)
        {
            return ServiceProv.Reporte_VentaPorProducto(filtro);
        }

        public DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Movimiento.ResumenVentaSucursal.Ficha> Reporte_ResumenVentaSucursal(DtoLibCajaBanco.Reporte.Movimiento.ResumenVentaSucursal.Filtro filtro)
        {
            return ServiceProv.Reporte_ResumenVentaSucursal(filtro);
        }

        public DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Movimiento.VentasPorProductoSucursal.Ficha> Reporte_VentaPorProductoSucursal(DtoLibCajaBanco.Reporte.Movimiento.VentasPorProductoSucursal.Filtro filtro)
        {
            return ServiceProv.Reporte_VentaPorProductoSucursal(filtro);
        }

        public DtoLib.ResultadoEntidad<DtoLibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Ficha> Reporte_CobranzaDiara(DtoLibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Filtro filtro)
        {
            return ServiceProv.Reporte_CobranzaDiara(filtro);
        }

        public DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Movimiento.ResumenDiarioVentaSucursal.Ficha> Reporte_ResumenDiarioVentaSucursal(DtoLibCajaBanco.Reporte.Movimiento.ResumenDiarioVentaSucursal.Filtro filtro)
        {
            return ServiceProv.Reporte_ResumenDiarioVentaSucursal(filtro);
        }

        public DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Movimiento.VentaPorCliente.Ficha> Reporte_VentaPorCliente(DtoLibCajaBanco.Reporte.Movimiento.VentaPorCliente.Filtro filtro)
        {
            return ServiceProv.Reporte_VentaPorCliente(filtro);
        }


        //ANALISIS

        public DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Analisis.VentaPromedio.Ficha> Reporte_Analisis_VentaPromedio(DtoLibCajaBanco.Reporte.Analisis.VentaPromedio.Filtro filtro)
        {
            return ServiceProv.Reporte_Analisis_VentaPromedio(filtro);
        }

        public DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Analisis.VentaProducto.Ficha> Reporte_Analisis_VentaProducto(DtoLibCajaBanco.Reporte.Analisis.VentaProducto.Filtro filtro)
        {
            return ServiceProv.Reporte_Analisis_VentaProducto(filtro);
        }
        
        public DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Analisis.VentaDiaria.Ficha> Reporte_Analisis_VentaDiaria(DtoLibCajaBanco.Reporte.Analisis.VentaDiaria.Filtro filtro)
        {
            return ServiceProv.Reporte_Analisis_VentaDiaria(filtro);
        }

        public DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Analisis.VentaPorCierre.Ficha> Reporte_Analisis_VentaPorCierre(DtoLibCajaBanco.Reporte.Analisis.VentaPorCierre.Filtro filtro)
        {
            return ServiceProv.Reporte_Analisis_VentaPorCierre(filtro);
        }

    }

}
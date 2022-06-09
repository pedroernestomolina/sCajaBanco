using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCajaBanco.Infra
{
    
    public interface IReporteMovimiento
    {

        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ArqueoCajaPos.Ficha > CajaBanco_ArqueoCajaPos(OOB.LibCajaBanco.Reporte.Movimiento.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenInventario.Ficha> Reporte_ResumenInventario(OOB.LibCajaBanco.Reporte.Movimiento.ResumenInventario.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVenta.Ficha> Reporte_ResumenVenta(OOB.LibCajaBanco.Reporte.Movimiento.ResumenVenta.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Habladores.Ficha> Reporte_Habladores(OOB.LibCajaBanco.Reporte.Habladores.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDetalle.Ficha> Reporte_ResumenVentaDetalle(OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDetalle.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorProducto.Ficha> Reporte_ResumenVentaPorProducto(OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorProducto.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaSucursal.Ficha> Reporte_ResumenVentaSucursal(OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaSucursal.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaProductoSucursal.Ficha> Reporte_ResumenVentaProductoSucursal(OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaProductoSucursal.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Ficha> Reporte_CobranzaDiaria(OOB.LibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDiarioSucursal.Ficha> Reporte_ResumenVentaDiarioSucursal(OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDiarioSucursal.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorCliente.Ficha> Reporte_ResumenVentaPorClient(OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorCliente.Filtro filtro);


        //ANALISIS

        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Analisis.VentaPromedio.Ficha> Reporte_Analisis_VentaPromedio(OOB.LibCajaBanco.Reporte.Analisis.VentaPromedio.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Analisis.VentaProducto.Ficha> Reporte_Analisis_VentaProducto(OOB.LibCajaBanco.Reporte.Analisis.VentaProducto.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Analisis.VentaDiaria.Ficha> Reporte_Analisis_VentaDiaria(OOB.LibCajaBanco.Reporte.Analisis.VentaDiaria.Filtro filtro);
        OOB.ResultadoLista<OOB.LibCajaBanco.Reporte.Analisis.VentaPorCierre.Ficha> Reporte_Analisis_VentaPorCierre(OOB.LibCajaBanco.Reporte.Analisis.VentaPorCierre.Filtro filtro);

    }

}
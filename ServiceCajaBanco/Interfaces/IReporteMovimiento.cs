﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCajaBanco.Interfaces
{
    public interface IReporteMovimiento
    {
        DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Movimiento.ArqueoCajaPos.Ficha> 
            CajaBanco_ArqueoCajaPos(DtoLibCajaBanco.Reporte.Movimiento.Filtro filtro);
        DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Movimiento.Inventario.Ficha> 
            Reporte_InventarioResumen(DtoLibCajaBanco.Reporte.Movimiento.Inventario.Filtro filtro);
        DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Movimiento.ResumenVenta.Ficha> 
            Reporte_VentaResumen(DtoLibCajaBanco.Reporte.Movimiento.ResumenVenta.Filtro filtro);
        DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Habladores.Ficha> 
            Reporte_Habladores(DtoLibCajaBanco.Reporte.Habladores.Filtro filtro);
        DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Movimiento.VentasPorProducto.Ficha> 
            Reporte_VentaPorProducto(DtoLibCajaBanco.Reporte.Movimiento.VentasPorProducto.Filtro filtro);
        DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Movimiento.FacturaDetalle.Ficha>
            Reporte_VentaDetalle(DtoLibCajaBanco.Reporte.Movimiento.FacturaDetalle.Filtro filtro);
        DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Movimiento.ResumenVentaSucursal.Ficha> 
            Reporte_ResumenVentaSucursal(DtoLibCajaBanco.Reporte.Movimiento.ResumenVentaSucursal.Filtro filtro);
        DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Movimiento.VentasPorProductoSucursal.Ficha> 
            Reporte_VentaPorProductoSucursal(DtoLibCajaBanco.Reporte.Movimiento.VentasPorProductoSucursal.Filtro filtro);
        DtoLib.ResultadoEntidad<DtoLibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Ficha> 
            Reporte_CobranzaDiara(DtoLibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Filtro filtro);
        DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Movimiento.ResumenDiarioVentaSucursal.Ficha> 
            Reporte_ResumenDiarioVentaSucursal(DtoLibCajaBanco.Reporte.Movimiento.ResumenDiarioVentaSucursal.Filtro filtro);
        DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Movimiento.VentaPorCliente.Ficha> 
            Reporte_VentaPorCliente(DtoLibCajaBanco.Reporte.Movimiento.VentaPorCliente.Filtro filtro);
        //ANALISIS
        DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Analisis.VentaPromedio.Ficha> 
            Reporte_Analisis_VentaPromedio(DtoLibCajaBanco.Reporte.Analisis.VentaPromedio.Filtro filtro);
        DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Analisis.VentaProducto.Ficha> 
            Reporte_Analisis_VentaProducto(DtoLibCajaBanco.Reporte.Analisis.VentaProducto.Filtro filtro);
        DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Analisis.VentaDiaria.Ficha> 
            Reporte_Analisis_VentaDiaria(DtoLibCajaBanco.Reporte.Analisis.VentaDiaria.Filtro filtro);
        DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Analisis.VentaPorCierre.Ficha> 
            Reporte_Analisis_VentaPorCierre(DtoLibCajaBanco.Reporte.Analisis.VentaPorCierre.Filtro filtro);
        //UTILIDAD
        DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Utilidad.General.Ficha>
            Reporte_Utilidad_General(DtoLibCajaBanco.Reporte.Utilidad.General.Filtro filtro);
        DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Analisis.VentaPorTasa.Ficha>
            Reporte_Aalisis_VentasPorTasa(DtoLibCajaBanco.Reporte.Analisis.VentaPorTasa.Filtro filtro);
        // ANALISIS POR MEDIO DE PAGO 
        DtoLib.ResultadoLista<DtoLibCajaBanco.Reporte.Analisis.PorMedioPago.Ficha>
            Reporte_Analisis_PorMediosPago(DtoLibCajaBanco.Reporte.Analisis.PorMedioPago.Filtro filtro);
        //
        // ANALISIS VENTAS NAULADAS
        DtoLib.ResultadoEntidad<DtoLibCajaBanco.Reporte.Analisis.VentasAnuladas.Ficha>
            Reporte_Analisis_VentasAnuladas(DtoLibCajaBanco.Reporte.Analisis.VentasAnuladas.Filtro filtro);
    }
}
﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCajaBanco
{
    public class Gestion
    {
        private Reportes.Movimientos.Gestion _filtroGestion;
        private Reportes.Analisis.Gestion _analisisGestion;
        private Habladores.Gestion _gestionHab;


        public string Version { get { return "Ver. " + Application.ProductVersion; } }
        public string Host { get { return "Base Dato: " + Sistema._Instancia + "/" + Sistema._BaseDatos; } }
        public System.Drawing.Image EmpresaLogo { get { return logo(); } }


        public Gestion()
        {
            _filtroGestion = new Reportes.Movimientos.Gestion();
            _analisisGestion = new Reportes.Analisis.Gestion();
            _gestionHab = new Habladores.Gestion();
        }


        Form1 frm ;
        public void Inicia() 
        {
            if (cargarData())
            {
                if (frm == null) 
                {
                    frm = new Form1();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public void ArqueoCajaPos()
        {
            _filtroGestion.Inicializa();
            if (Sistema._ActivarComoSucursal)
            {
                _filtroGestion.setHabilitarSucursal(false);
                _filtroGestion.setHabilitarDeposito(false);
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(true);
                _filtroGestion.setHabilitarDeposito(false);
                _filtroGestion.setValidarPorSucursal(true);
            }
            _filtroGestion.setHabilitarPorFecha(true);
            _filtroGestion.setHabilitarPorNumeroCierre(false);

            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk) 
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var sucursalNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                    var r00 = Sistema.MyData.Sucursal_GetPrincipal();
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    sucursalNombre = r00.Entidad.nombre;
                    filtro.autoSucursal = r00.Entidad.codigo;
                }
                else
                {
                    var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    filtro.autoSucursal = r00.Entidad.codigo;
                    sucursalNombre = r00.Entidad.nombre;
                }

                var r01 = Sistema.MyData.CajaBanco_ArqueoCajaPos(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() +
                    Environment.NewLine + sucursalNombre;
                var rp1 = new Reportes.Movimientos.ArqueoCajaPos (r01.Lista, filtros);
                rp1.Generar();
            }
        }

        public void ReporteResumenInventario()
        {
            _filtroGestion.Inicializa();
            if (Sistema._ActivarComoSucursal)
            {
                _filtroGestion.setHabilitarSucursal(false);
                _filtroGestion.setHabilitarDeposito(false);
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(false);
                _filtroGestion.setHabilitarDeposito(true);
                _filtroGestion.setValidarDeposito(true);
            }

            _filtroGestion.setHabilitarPorFecha(true);
            _filtroGestion.setHabilitarPorNumeroCierre(false);
            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.ResumenInventario.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var depositoNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                    var r00 = Sistema.MyData.Deposito_GetPrincipal();
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    filtro.autoDeposito = r00.Entidad.auto;
                    depositoNombre = r00.Entidad.nombre;
                }
                else 
                {
                    filtro.autoDeposito = _filtroGestion.autoDeposito;
                    var r00 = Sistema.MyData.Deposito_GetFicha(filtro.autoDeposito);
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    depositoNombre = r00.Entidad.nombre;
                }

                var r01 = Sistema.MyData.Reporte_ResumenInventario(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() + 
                    Environment.NewLine+ depositoNombre;
                var rp1 = new Reportes.Movimientos.ResumenInventario.GestionRep(r01.Lista, filtros);
                rp1.Generar();
            }
        }

        public void ReporteResumenVenta()
        {
            _filtroGestion.Inicializa();
            if (Sistema._ActivarComoSucursal)
            {
                _filtroGestion.setHabilitarSucursal(false);
                _filtroGestion.setHabilitarDeposito(false);
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(true);
                _filtroGestion.setHabilitarDeposito(false);
                _filtroGestion.setValidarPorSucursal(true);
            }

            _filtroGestion.setHabilitarPorFecha(true);
            _filtroGestion.setHabilitarPorNumeroCierre(false);
            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVenta.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };
                
                var sucursalNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                    var r00 = Sistema.MyData.Sucursal_GetPrincipal();
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    sucursalNombre = r00.Entidad.nombre;
                    filtro.codigoSucursal = r00.Entidad.codigo;
                }
                else 
                {
                    var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    filtro.codigoSucursal = r00.Entidad.codigo;
                    sucursalNombre= r00.Entidad.nombre;
                }

                var r01 = Sistema.MyData.Reporte_ResumenVenta(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() +
                    Environment.NewLine + "Sucursal: "+ sucursalNombre ;
                var rp1 = new Reportes.Movimientos.ResumenVenta.GestionRep(r01.Lista, filtros);
                rp1.Generar();
            }
        }

        public void ReporteHabladores()
        {
            _gestionHab.Inicia();
        }

        public void ReporteResumenVentaDetalle()
        {
            _filtroGestion.Inicializa();
            if (Sistema._ActivarComoSucursal)
            {
                _filtroGestion.setHabilitarSucursal(false);
                _filtroGestion.setHabilitarDeposito(false);
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(true);
                _filtroGestion.setHabilitarDeposito(false);
                _filtroGestion.setValidarPorSucursal(true);
            }

            _filtroGestion.setHabilitarPorFecha(true);
            _filtroGestion.setHabilitarPorNumeroCierre(false);
            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDetalle.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var sucursalNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                    var r00 = Sistema.MyData.Sucursal_GetPrincipal();
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    sucursalNombre = r00.Entidad.nombre;
                    filtro.codigoSucursal = r00.Entidad.codigo;
                }
                else
                {
                    if (_filtroGestion.autoSucursal == "")
                    {
                        Helpers.Msg.Error("DEBES SELECCIONAR UNA SUCURSAL POR FAVOR...");
                        return;
                    }

                    var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    filtro.codigoSucursal = r00.Entidad.codigo;
                    sucursalNombre = r00.Entidad.nombre;
                }

                var r01 = Sistema.MyData.Reporte_ResumenVentaDetalle(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() +
                    Environment.NewLine + "Sucursal: " + sucursalNombre;
                var rp1 = new Reportes.Movimientos.VentaDetalle.GestionRep(r01.Lista, filtros);
                rp1.Generar();
            }
        }

        public void ReporteResumenVentaporProducto()
        {
            _filtroGestion.Inicializa();
            if (Sistema._ActivarComoSucursal)
            {
                _filtroGestion.setHabilitarSucursal(false);
                _filtroGestion.setHabilitarDeposito(false);
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(true);
                _filtroGestion.setHabilitarDeposito(false);
            }

            _filtroGestion.setHabilitarPorFecha(true);
            _filtroGestion.setHabilitarPorNumeroCierre(false);
            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorProducto.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var sucursalNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                    var r00 = Sistema.MyData.Sucursal_GetPrincipal();
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    sucursalNombre = r00.Entidad.nombre;
                    filtro.codigoSucursal = r00.Entidad.codigo;
                }
                else
                {
                    sucursalNombre = "GENERAL";
                    if (_filtroGestion.autoSucursal != "") 
                    {
                        var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                        if (r00.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r00.Mensaje);
                            return;
                        }
                        filtro.codigoSucursal = r00.Entidad.codigo;
                        sucursalNombre = r00.Entidad.nombre;
                    }
                }

                var r01 = Sistema.MyData.Reporte_ResumenVentaPorProducto(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() +
                    Environment.NewLine + "Sucursal: " + sucursalNombre;
                var rp1 = new Reportes.Movimientos.VentaPorProducto.GestionRep(r01.Lista, filtros);
                rp1.Generar();
            }
        }

        public void ReporteResumenVentaSucursal()
        {
            if (Sistema._ActivarComoSucursal)
            {
                return;
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(true);
                _filtroGestion.setHabilitarDeposito(false);
            }

            _filtroGestion.setHabilitarPorFecha(true);
            _filtroGestion.setHabilitarPorNumeroCierre(false);
            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaSucursal.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var sucursalNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                }
                else
                {
                    sucursalNombre = "GENERAL";
                    if (_filtroGestion.autoSucursal != "")
                    {
                        var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                        if (r00.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r00.Mensaje);
                            return;
                        }
                        filtro.codigoSucursal = r00.Entidad.codigo;
                        sucursalNombre = r00.Entidad.nombre;
                    }
                }

                var r01 = Sistema.MyData.Reporte_ResumenVentaSucursal(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() +
                    Environment.NewLine + "Sucursal: " + sucursalNombre;
                var rp1 = new Reportes.Movimientos.ResumenVentaSucursal.GestionRep(r01.Lista, filtros);
                rp1.Generar();
            }
        }

        public void ReporteResumenVentaProductoSucursal()
        {
            if (Sistema._ActivarComoSucursal)
            {
                return;
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(true);
                _filtroGestion.setHabilitarDeposito(false);
            }

            _filtroGestion.setHabilitarPorFecha(true);
            _filtroGestion.setHabilitarPorNumeroCierre(false);
            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaProductoSucursal.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var sucursalNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                }
                else
                {
                    sucursalNombre = "GENERAL";
                    if (_filtroGestion.autoSucursal != "")
                    {
                        var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                        if (r00.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r00.Mensaje);
                            return;
                        }
                        filtro.codigoSucursal = r00.Entidad.codigo;
                        sucursalNombre = r00.Entidad.nombre;
                    }
                }

                var r01 = Sistema.MyData.Reporte_ResumenVentaProductoSucursal(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() +
                    Environment.NewLine + "Sucursal: " + sucursalNombre;
                var rp1 = new Reportes.Movimientos.VentaProductoSucursal.GestionRep(r01.Lista, filtros);
                rp1.Generar();
            }
        }

        public void CobranzaDiaria()
        {
            _filtroGestion.Inicializa();
            if (Sistema._ActivarComoSucursal)
            {
                _filtroGestion.setHabilitarSucursal(false);
                _filtroGestion.setHabilitarDeposito(false);
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(true);
                _filtroGestion.setHabilitarDeposito(false);
                _filtroGestion.setValidarPorSucursal(true);
            }
            _filtroGestion.setHabilitarPorNumeroCierre(false);
            _filtroGestion.setHabilitarPorFecha(true);

            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Filtro()
                {
                    esPorFecha=true,
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var sucursalNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                    var r00 = Sistema.MyData.Sucursal_GetPrincipal();
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    sucursalNombre = r00.Entidad.nombre;
                    filtro.codSucursal = r00.Entidad.codigo;
                }
                else
                {
                    sucursalNombre = "GENERAL";
                    if (_filtroGestion.autoSucursal != "")
                    {
                        var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                        if (r00.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r00.Mensaje);
                            return;
                        }
                        filtro.codSucursal= r00.Entidad.codigo;
                        sucursalNombre = r00.Entidad.nombre;
                    }
                }

                var r01 = Sistema.MyData.Reporte_CobranzaDiaria(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() +
                    Environment.NewLine + "Sucursal: " + sucursalNombre;
                var rp1 = new Reportes.Movimientos.CobranzaDiaria.GestionRep(r01.Entidad, filtros);
                rp1.Generar();
            }
        }

        public void ReporteResumenVentaDiarioSucursal()
        {
            if (Sistema._ActivarComoSucursal)
            {
                return;
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(true);
                _filtroGestion.setHabilitarDeposito(false);
            }

            _filtroGestion.setHabilitarPorFecha(true);
            _filtroGestion.setHabilitarPorNumeroCierre(false);
            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDiarioSucursal.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var sucursalNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                }
                else
                {
                    sucursalNombre = "GENERAL";
                    if (_filtroGestion.autoSucursal != "")
                    {
                        var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                        if (r00.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r00.Mensaje);
                            return;
                        }
                        filtro.codigoSucursal = r00.Entidad.codigo;
                        sucursalNombre = r00.Entidad.nombre;
                    }
                }

                var r01 = Sistema.MyData.Reporte_ResumenVentaDiarioSucursal(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() +
                    Environment.NewLine + "Sucursal: " + sucursalNombre;
                var rp1 = new Reportes.Movimientos.ResumenVentaDiarioSucursal.GestionRep(r01.Lista, filtros);
                rp1.Generar();
            }
        }

        public void CobranzaDiariaPorCierre()
        {
            _filtroGestion.Inicializa();
            if (Sistema._ActivarComoSucursal)
            {
                _filtroGestion.setHabilitarSucursal(false);
                _filtroGestion.setHabilitarDeposito(false);
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(true);
                _filtroGestion.setHabilitarDeposito(false);
                _filtroGestion.setValidarPorSucursal(true);
            }
            _filtroGestion.setHabilitarPorFecha(false);
            _filtroGestion.setHabilitarPorNumeroCierre(true);

            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                if (_filtroGestion.autoSucursal == "") 
                {
                    Helpers.Msg.Error("Debes Indicar Una Sucursal");
                    return;
                }

                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Filtro()
                {
                    esPorCierre  = true,
                    desdeCierre= _filtroGestion.desdeNumero,
                    hastaCierre=_filtroGestion.hastaNumero,
                };

                var sucursalNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                    var r00 = Sistema.MyData.Sucursal_GetPrincipal();
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    sucursalNombre = r00.Entidad.nombre;
                    filtro.codSucursal = r00.Entidad.codigo;
                }
                else
                {
                    sucursalNombre = "GENERAL";
                    if (_filtroGestion.autoSucursal != "")
                    {
                        var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                        if (r00.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r00.Mensaje);
                            return;
                        }
                        filtro.codSucursal = r00.Entidad.codigo;
                        sucursalNombre = r00.Entidad.nombre;
                    }
                }

                var r01 = Sistema.MyData.Reporte_CobranzaDiaria(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde Cierre: " + _filtroGestion.desdeNumero.ToString().PadLeft(6,'0') + ", Hasta Cierre: " + _filtroGestion.hastaNumero.ToString().PadLeft(6,'0') +
                    Environment.NewLine + "Sucursal: " + sucursalNombre;
                var rp1 = new Reportes.Movimientos.CobranzaDiaria.GestionRep(r01.Entidad, filtros);
                rp1.Generar();
            }
        }

        public void AnalisisVentasPromedio()
        {
            if (!Sistema._ActivarComoSucursal) 
            {
                _analisisGestion.setGestion(new Reportes.Analisis.VentaPromedio.Gestion());
                _analisisGestion.Inicializar();
                _analisisGestion.Inicia();
            }
        }

        public void AnalisisVentasProducto()
        {
            if (!Sistema._ActivarComoSucursal)
            {
                _analisisGestion.setGestion(new Reportes.Analisis.VentaProducto.Gestion());
                _analisisGestion.Inicializar();
                _analisisGestion.Inicia();
            }
        }

        public void ReporteResumenVentaSaltoFactura()
        {
            _filtroGestion.Inicializa();

            if (Sistema._ActivarComoSucursal)
            {
                _filtroGestion.setHabilitarSucursal(false);
                _filtroGestion.setHabilitarDeposito(false);
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(true);
                _filtroGestion.setHabilitarDeposito(false);
                _filtroGestion.setValidarPorSucursal(true);
            }

            _filtroGestion.setHabilitarPorFecha(true);
            _filtroGestion.setHabilitarPorNumeroCierre(false);
            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVenta.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var sucursalNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                    var r00 = Sistema.MyData.Sucursal_GetPrincipal();
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    sucursalNombre = r00.Entidad.nombre;
                    filtro.codigoSucursal = r00.Entidad.codigo;
                }
                else
                {
                    var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    filtro.codigoSucursal = r00.Entidad.codigo;
                    sucursalNombre = r00.Entidad.nombre;
                }
                var r01 = Sistema.MyData.Reporte_ResumenVenta(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                if (r01.Lista != null)
                {
                    if (r01.Lista.Count > 0)
                    {
                        //// TODO : INDICAR LISTA DE SUCURSAL CON VENTAS AL MAYOR PARA CUANDO SE CHEQEUE LA ENUMERACION PARA SALTO DE FACTURA NO HAYA NINGUN PROBLEMA
                        //if ((new[] { "03","12","14","15", "16", "17", "0B" }.Contains(filtro.codigoSucursal))) // todos los documentos una misma estacion, es para verificar salto de numero documento 
                        //{
                        //    foreach (var rg in r01.Lista)
                        //    {
                        //        rg.estacion = "";
                        //    }
                        //}
                        foreach (var rg in r01.Lista)
                        {
                            rg.estacion = "";
                        }
                        var xl = r01.Lista.GroupBy(g => new { g.estacion, g.tipo }).Select(t => t).ToList();
                        foreach (var t in xl)
                        {
                            var d = r01.Lista.OrderBy(o=>o.documento).First(w=>w.estacion==t.Key.estacion.ToString() && w.tipo==t.Key.tipo.ToString());
                            if (d != null) 
                            {
                                var x = int.Parse(d.documento);
                                foreach (var r in r01.Lista.Where(w=>w.estacion==t.Key.estacion.ToString() && w.tipo==t.Key.tipo.ToString()).OrderBy(o=>o.documento).ToList())
                                {
                                    if (int.Parse(r.documento) != x)
                                    {
                                        var st = r.documento + " de fecha " + r.fecha.ToShortDateString();
                                        Helpers.Msg.Error(st);
                                        return;
                                    }
                                    x += 1;
                                }
                            }
                        }
                        Helpers.Msg.OK("TODO OK");
                        return;
                    }
                }
            }
        }

        public void AnalisisVentasDiaria()
        {
            if (!Sistema._ActivarComoSucursal)
            {
                _analisisGestion.setGestion(new Reportes.Analisis.VentaDiaria.Gestion());
                _analisisGestion.Inicializar();
                _analisisGestion.Inicia();
            }
        }

        public void AnalisisVentasPorCierre()
        {
            if (!Sistema._ActivarComoSucursal)
            {
                _analisisGestion.setGestion(new Reportes.Analisis.VentaPorCierre.Gestion());
                _analisisGestion.Inicializar();
                _analisisGestion.Inicia();
            }
        }

        public void ReporteResumenVentaporCliente()
        {
            _filtroGestion.Inicializa();
            if (Sistema._ActivarComoSucursal)
            {
                _filtroGestion.setHabilitarSucursal(false);
                _filtroGestion.setHabilitarDeposito(false);
            }
            else
            {
                _filtroGestion.setHabilitarSucursal(true);
                _filtroGestion.setHabilitarDeposito(false);
            }

            _filtroGestion.setHabilitarPorFecha(true);
            _filtroGestion.setHabilitarPorNumeroCierre(false);
            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorCliente.Filtro()
                {
                    desdeFecha = _filtroGestion.desdeFecha,
                    hastaFecha = _filtroGestion.hastaFecha,
                };

                var sucursalNombre = "";
                if (Sistema._ActivarComoSucursal)
                {
                    var r00 = Sistema.MyData.Sucursal_GetPrincipal();
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    sucursalNombre = r00.Entidad.nombre;
                    filtro.codigoSucursal = r00.Entidad.codigo;
                }
                else
                {
                    sucursalNombre = "GENERAL";
                    if (_filtroGestion.autoSucursal != "")
                    {
                        var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                        if (r00.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r00.Mensaje);
                            return;
                        }
                        filtro.codigoSucursal = r00.Entidad.codigo;
                        sucursalNombre = r00.Entidad.nombre;
                    }
                }

                var r01 = Sistema.MyData.Reporte_ResumenVentaPorClient(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() +
                    Environment.NewLine + "Sucursal: " + sucursalNombre;
                var rp1 = new Reportes.Movimientos.VentaPorCliente.GestionRep(r01.Lista, filtros);
                rp1.Generar();
            }
        }

        public void ReporteUtilidadGeneral()
        {
            _filtroGestion.Inicializa();
            _filtroGestion.setHabilitarPorFecha(true);
            _filtroGestion.setHabilitarSucursal(false);
            _filtroGestion.setHabilitarDeposito(false);
            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Utilidad.General.Filtro()
                {
                    desde = _filtroGestion.desdeFecha,
                    hasta = _filtroGestion.hastaFecha,
                };
                var r01 = Sistema.MyData.Reporte_Utilidad_General(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString();
                var rp1 = new Reportes.Utilidad.General.Gestion(r01.Lista, filtros);
                rp1.Generar();
            }
        }
        public void ReporteAnalisisVentasPorTasa()
        {
            _filtroGestion.Inicializa();
            _filtroGestion.setHabilitarPorFecha(true);
            _filtroGestion.setHabilitarSucursal(false);
            _filtroGestion.setHabilitarDeposito(false);
            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                var filtro = new OOB.LibCajaBanco.Reporte.Analisis.VentaPorTasa.Filtro()
                {
                    desde = _filtroGestion.desdeFecha,
                    hasta = _filtroGestion.hastaFecha,
                };
                var r01 = Sistema.MyData.Reporte_Analisis_VentaPorTasa(filtro);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString();
                var rp1 = new Reportes.Analisis.VentaPorTasa.Gestion(r01.Lista, filtros);
                rp1.Generar();
            }
        }

        private src.Analisis.PorMetPago.IAnalMetPago _analisisMetPago;
        public void AnalisisVentasPorMedioPago()
        {
            if (_analisisMetPago == null)
            {
                _analisisMetPago = new src.Analisis.PorMetPago.ImpAnalMetPago();
            }
            _analisisMetPago.Inicializa();
            _analisisMetPago.Inicia();

            //_filtroGestion.Inicializa();
            //_filtroGestion.setHabilitarPorFecha(true);
            //_filtroGestion.setHabilitarSucursal(false);
            //_filtroGestion.setHabilitarDeposito(false);
            //_filtroGestion.Inicia();
            //if (_filtroGestion.IsFiltroOk)
            //{
            //    try
            //    {
            //        var filtro = new OOB.LibCajaBanco.Reporte.Analisis.PorMedioPago.Filtro()
            //        {
            //            desde = _filtroGestion.desdeFecha,
            //            hasta = _filtroGestion.hastaFecha,
            //        };
            //        var r01 = Sistema.MyData.Reporte_Analisis_PorMediosPago(filtro);
            //    }
            //    catch (Exception e)
            //    {
            //        Helpers.Msg.Error(e.Message);
            //        return;
            //    }
            //    //var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString();
            //    //var rp1 = new Reportes.Analisis.VentaPorTasa.Gestion(r01.Lista, filtros);
            //    //rp1.Generar();
            //}
        }

        public void AnalisisVentasAnuladas()
        {
            _filtroGestion.Inicializa();
            _filtroGestion.setHabilitarSucursal(true);
            _filtroGestion.setHabilitarPorFecha(true);
            _filtroGestion.setHabilitarDeposito(false);
            _filtroGestion.setHabilitarPorNumeroCierre(false);
            _filtroGestion.Inicia();
            if (_filtroGestion.IsFiltroOk)
            {
                try
                {
                    var sucursalNombre = "";
                    var r00 = Sistema.MyData.Sucursal_GetFicha(_filtroGestion.autoSucursal);
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        throw new Exception(r00.Mensaje);
                    }
                    var filtro = new OOB.LibCajaBanco.Reporte.Analisis.VentasAnuladas.Filtro()
                    {
                        desde = _filtroGestion.desdeFecha,
                        hasta = _filtroGestion.hastaFecha,
                    };
                    filtro.codSucursal = r00.Entidad.codigo;
                    sucursalNombre = r00.Entidad.nombre;

                    var r01 = Sistema.MyData.Reporte_Analisis_VentasAnuladas(filtro);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        throw new Exception(r01.Mensaje);
                    }

                    var filtros = "Desde: " + _filtroGestion.desdeFecha.ToShortDateString() + ", Hasta: " + _filtroGestion.hastaFecha.ToShortDateString() +
                        Environment.NewLine + sucursalNombre;
                    var rp1 = new Reportes.Analisis.VentasAnuladas.Gestion(r01.Entidad, filtros);
                    rp1.Procesar();
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }


        private bool cargarData()
        {
            try
            {
                var r01 = Sistema.MyData.Sistema_Empresa_GetFicha();
                if (r01.Result == OOB.Enumerados.EnumResult.isError )
                {
                    throw new Exception(r01.Mensaje);
                }
                Sistema.DatosEmpresa = r01.Entidad;
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private System.Drawing.Image logo()
        {
            if (Sistema.DatosEmpresa.logo.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(Sistema.DatosEmpresa.logo))
                {
                    Image image = Image.FromStream(ms);
                    return image;
                }
            }
            return null;
        }
    }
}
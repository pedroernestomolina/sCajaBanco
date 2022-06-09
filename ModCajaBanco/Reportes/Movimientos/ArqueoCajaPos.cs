using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Movimientos
{
    
    public class ArqueoCajaPos
    {
        
        private List<OOB.LibCajaBanco.Reporte.Movimiento.ArqueoCajaPos.Ficha> _arqueos;
        private string _filtros;


        public ArqueoCajaPos(List<OOB.LibCajaBanco .Reporte.Movimiento.ArqueoCajaPos.Ficha> list, string filtros)
        {
            _arqueos = list;
            _filtros = filtros;
        }
        
        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Movimientos\ArqueoVentaPos.rdlc";
            var ds = new dsMovimiento();
            foreach (var it in _arqueos.OrderBy(o=>o.fecha).ThenBy(o=>o.sucursal).ThenBy(o=>o.autoCierre).ToList())
            {
                DataRow r = ds.Tables["ArqueoVentaPos"].NewRow();
                r["cierre"] = it.autoCierre;
                r["sucursal"] = it.sucursal;
                r["equipo"] = it.equipo;
                r["fecha"] = it.fecha;
                r["usuario"] = it.codigoUsuario+"("+it.nombreUsuario+")";
                r["diferencia"] = it.diferencia;
                r["efectivo"] = it.efectivo ;
                r["divisa"] = it.divisa;
                r["cntdivisa"] = it.cntDivisa;
                r["tarjeta"] = it.tarjeta;
                r["otros"] = it.otros;
                r["firma"] = it.firma;
                r["devolucion"] = it.devolucion;
                r["mefectivo"] = it.mefectivo;
                r["mdivisa"] = it.mdivisa;
                r["mtarjeta"] = it.mtarjeta;
                r["motros"] = it.motros;
                ds.Tables["ArqueoVentaPos"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("Filtros",_filtros));
            Rds.Add(new ReportDataSource("ArqueoVentaPos", ds.Tables["ArqueoVentaPos"]));

            var frp = new Reporte();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}
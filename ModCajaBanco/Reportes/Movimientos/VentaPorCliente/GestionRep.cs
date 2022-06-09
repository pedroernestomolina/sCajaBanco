using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Movimientos.VentaPorCliente
{
    
    public class GestionRep
    {

        private List<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorCliente.Ficha> data;
        private string filtros;


        public GestionRep(List<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorCliente.Ficha> list, string filt)
        {
            this.data = list;
            this.filtros = filt;
        }

        public void Generar()
        {
            var _data = data.Where(w => w.telefono.Trim().Length >= 11).ToList();
            var _lst = _data.GroupBy(g => new { g.entidad, g.ciRif, g.dirFiscal, g.telefono, g.sucNombre}).
                Select(s => 
                {
                    var rg = new data(s.Key.entidad, s.Key.ciRif, s.Key.dirFiscal, s.Key.telefono, s.Key.sucNombre,
                        s.Sum(s1 => s1.monto * s1.signo), s.Sum(s2 => s2.montoDivisa  * s2.signo), s.Count());
                    return rg;
                }).ToList();


            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Movimientos\ResumenVentCliente.rdlc";
            var ds = new dsMovimiento();
            foreach (var it in _lst.OrderBy(o => o.entidad).ToList())
            {
                DataRow r = ds.Tables["ResumenVentCliente"].NewRow();
                r["entidad"] = it.ciRif + Environment.NewLine + it.entidad;
                r["cirif"] = it.ciRif;
                r["dirFiscal"] = it.dirFiscal;
                r["telefono"] = it.telefono;
                r["sucursal"] = it.sucursal;
                r["cnt"] = it.cnt;
                r["monto"] = it.monto;
                r["montoDivisa"] = it.montoDivisa ;
                ds.Tables["ResumenVentCliente"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("FILTRO", filtros+", CLIENTES CON NUMEROS DE TELEFONOS"));
            Rds.Add(new ReportDataSource("ResumenVentCliente", ds.Tables["ResumenVentCliente"]));

            var frp = new Reporte();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}
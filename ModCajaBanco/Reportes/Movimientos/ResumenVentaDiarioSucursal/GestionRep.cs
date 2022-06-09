using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Movimientos.ResumenVentaDiarioSucursal
{

    public class GestionRep
    {

        private List<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDiarioSucursal.Ficha> data;
        private string filtros;


        public GestionRep(List<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDiarioSucursal.Ficha> list, string filt)
        {
            this.data = list;
            this.filtros = filt;
        }

        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Movimientos\ResumenVentaDiarioSuc.rdlc";
            var ds = new dsMovimiento();
            foreach (var it in data.OrderBy(o => o.codigoSuc).ThenBy(o=>o.cierreNro).ToList())
            {
                DataRow r = ds.Tables["ResumenVentaSuc"].NewRow();
                r["sucursal"] = it.codigoSuc + Environment.NewLine + it.nombreSuc;
                r["cntMov"] = it.cntMov;
                r["monto"] = it.montoTotal ;
                r["montoDivisa"] = it.montoDivisa ;
                r["fecha"] = it.fecha;
                r["cierre"] = it.cierreNro;
                r["horaI"] = it.horaI;
                r["horaF"] = it.horaF;
                r["docI"] = it.docI;
                r["docF"] = it.docF;
                r["caja"] = it.caja;
                r["tipoDoc"] = it.tipoDocumento;
                ds.Tables["ResumenVentaSuc"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("FILTROS", filtros));
            Rds.Add(new ReportDataSource("ResumenVentaSuc", ds.Tables["ResumenVentaSuc"]));

            var frp = new Reporte();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }

}
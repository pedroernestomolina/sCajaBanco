using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Movimientos.VentaPorProducto
{
    
    public class GestionRep
    {

        private List<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorProducto.Ficha> data;
        private string filtros;


        public GestionRep(List<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaPorProducto.Ficha> list, string filt)
        {
            this.data = list;
            this.filtros = filt;
        }

        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Movimientos\ResumenVentaPrd.rdlc";
            var ds = new dsMovimiento();
            foreach (var it in data.OrderBy(o => o.nombrePrd).ToList())
            {
                DataRow r = ds.Tables["ResumenVentPrd"].NewRow();
                r["codigoPrd"] = it.codigoPrd;
                r["nombrePrd"] = it.nombrePrd;
                r["cantidad"] = it.cantidad;
                r["totalMonto"] = it.totalMonto*it.signo;
                r["totalMontoDivisa"] = it.totalMontoDivisa * it.signo;
                r["tipoDocumento"] = it.nombreDocumento;
                ds.Tables["ResumenVentPrd"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("Filtros", filtros));
            Rds.Add(new ReportDataSource("ResumenVentPrd", ds.Tables["ResumenVentPrd"]));

            var frp = new Reporte();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}
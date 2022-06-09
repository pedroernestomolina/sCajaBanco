using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Movimientos.VentaDetalle
{
    
    public class GestionRep
    {

        private List<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDetalle.Ficha> data;
        private string filtros;


        public GestionRep(List<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaDetalle.Ficha> list, string filt)
        {
            this.data = list;
            this.filtros = filt;
        }

        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Movimientos\ResumenVentaDetalle.rdlc";
            var ds = new dsMovimiento();
            foreach (var it in data.OrderBy(o => o.fecha).ThenBy(o => o.documento).ToList())
            {
                DataRow r = ds.Tables["ResumenVentDet"].NewRow();
                r["fechaHora"] = it.fecha.ToShortDateString() + ", " + it.hora;
                r["documentoNro"] = it.documento;
                r["documentoNombre"] = it.documentoNombre;
                r["usuarioEstacion"] = it.usuarioCodigo.Trim() + "(" + it.usuarioNombre.Trim() + "), " + Environment.NewLine + it.CajaEstacion;
                r["renglones"] = it.renglones.ToString("n0");
                r["total"] = it.total * it.signo;
                r["nombrePrd"] = it.nombreProducto ;
                r["cantidad"] = it.cantidadUnd.ToString("n"+it.decimales);
                r["precio"] = it.precioUnd;
                r["totalRenglon"] = it.totalRenglon*it.signo;
                ds.Tables["ResumenVentDet"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("Filtros", filtros));
            Rds.Add(new ReportDataSource("ResumenVentDet", ds.Tables["ResumenVentDet"]));

            var frp = new Reporte();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}
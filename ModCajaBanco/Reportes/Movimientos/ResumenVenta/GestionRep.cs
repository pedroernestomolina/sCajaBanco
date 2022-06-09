using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Movimientos.ResumenVenta
{
    
    public class GestionRep
    {

        private List<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVenta.Ficha> data;
        private string filtros;


        public GestionRep(List<OOB.LibCajaBanco .Reporte.Movimiento.ResumenVenta.Ficha> list, string filt)
        {
            this.data= list;
            this.filtros = filt;
        }
        
        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Movimientos\ResumenVenta.rdlc";
            var ds = new dsMovimiento();
            foreach (var it in data.OrderBy(o=>o.fecha).ThenBy(o=>o.documento).ToList())
            {
                DataRow r = ds.Tables["ResumenVent"].NewRow();
                r["fechaHora"] = it.fecha.ToShortDateString()+", "+it.hora;
                r["documentoNro"] = it.documento;
                r["documentoNombre"] = it.documentoNombre;
                r["usuarioEstacion"] = it.usuarioCodigo.Trim()+"("+it.usuarioNombre.Trim()+"), "+Environment.NewLine+it.estacion;
                r["cliente"] = it.clienteRif.Trim()+", "+it.clienteNombre.Trim();
                r["renglones"] = it.renglones.ToString("n0");
                r["descuento"] = it.descuento;
                r["total"] = it.total*it.signo;
                r["condicionPago"] = it.condicionPago;
                ds.Tables["ResumenVent"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("FILTROS", filtros));
            Rds.Add(new ReportDataSource("ResumenVent", ds.Tables["ResumenVent"]));

            var frp = new Reporte();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}
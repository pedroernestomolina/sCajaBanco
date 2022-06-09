using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Movimientos.VentaProductoSucursal
{
    
    public class GestionRep
    {

        private List<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaProductoSucursal.Ficha> data;
        private string filtros;


        public GestionRep(List<OOB.LibCajaBanco.Reporte.Movimiento.ResumenVentaProductoSucursal.Ficha> list, string filt)
        {
            this.data = list;
            this.filtros = filt;
        }

        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Movimientos\ResumenVentaPrdSuc.rdlc";
            var ds = new dsMovimiento();
            foreach (var it in data.ToList())
            {
                DataRow r = ds.Tables["ResumenVentPrdSuc"].NewRow();
                r["Producto"] = it.nombrePrd.Trim()+Environment.NewLine+it.codigoPrd;
                r["Sucursal"] = it.codigoSuc + Environment.NewLine + it.nombreSuc;
                r["cantidad"] = it.cantidad;
                r["totalMonto"] = it.totalMonto * it.signo;
                r["totalMontoDivisa"] = it.totalMontoDivisa * it.signo;
                r["tipoDocumento"] = it.nombreDocumento;
                ds.Tables["ResumenVentPrdSuc"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("Filtros", filtros));
            Rds.Add(new ReportDataSource("ResumenVentPrdSuc", ds.Tables["ResumenVentPrdSuc"]));

            var frp = new Reporte();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}
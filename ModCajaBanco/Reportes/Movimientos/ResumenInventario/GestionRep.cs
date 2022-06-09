using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Movimientos.ResumenInventario
{
    
    public class GestionRep
    {

        private List<OOB.LibCajaBanco.Reporte.Movimiento.ResumenInventario.Ficha> data;
        private string filtros;


        public GestionRep(List<OOB.LibCajaBanco .Reporte.Movimiento.ResumenInventario.Ficha> list, string filt)
        {
            this.data= list;
            this.filtros = filt;
        }
        
        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Movimientos\ResumenInventario.rdlc";
            var ds = new dsMovimiento();
            foreach (var it in data.OrderBy(o=>o.nombrePrd).ToList())
            {
                var saldoI=0.0m;
                var saldoF = 0.0m;
                var exito = true;
                saldoF = it.tEntradas - it.tSalidas;
                saldoI = saldoF + it.salidas - it.entradas - it.entradasOt;

                if (saldoI == 0.0m && it.entradas == 0.0m && it.entradasOt == 0.0m && it.salidas == 0.0m && saldoF == 0.0m)
                    exito = false;

                if (exito)
                {
                    DataRow r = ds.Tables["ResumenInv"].NewRow();
                    r["codigoPrd"] = it.codigoPrd;
                    r["nombrePrd"] = it.nombrePrd;
                    r["saldoI"] = saldoI.ToString("n" + it.decimales);
                    r["entrada"] = it.entradas.ToString("n" + it.decimales);
                    r["entradaOt"] = it.entradasOt.ToString("n" + it.decimales);
                    r["salida"] = it.salidas.ToString("n" + it.decimales);
                    r["saldoF"] = saldoF.ToString("n" + it.decimales);
                    ds.Tables["ResumenInv"].Rows.Add(r);
                }
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("Filtros", filtros));
            Rds.Add(new ReportDataSource("ResumenInv", ds.Tables["ResumenInv"]));

            var frp = new Reporte();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Hablador
{
    
    public class GestionRep
    {


        private List<Habladores.data> _data;


        public GestionRep(List<Habladores.data> list )
        {
            _data = list;
        }


        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Hablador\Hablador.rdlc";
            var ds = new dsHablador();
            foreach (var it in _data)
            {
                DataRow r = ds.Tables["Hablador"].NewRow();
                r["nombrePrd"] = it.codigoPrd + Environment.NewLine + it.nombrePrd + Environment.NewLine + it.precioFull.ToString("n2") + Environment.NewLine + "$" +it.divisaFull.ToString("n2");
                r["precio"] = it.precioFull;
                r["divisa"] = it.divisaFull;
                ds.Tables["Hablador"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            Rds.Add(new ReportDataSource("Hablador", ds.Tables["Hablador"]));

            var frp = new Reporte();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}
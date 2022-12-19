using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Analisis.VentaPorTasa
{
    
    public class Gestion
    {
        private List<OOB.LibCajaBanco.Reporte.Analisis.VentaPorTasa.Ficha> _lst;
        private string _filtro;


        public Gestion(List<OOB.LibCajaBanco.Reporte.Analisis.VentaPorTasa.Ficha> list, string filtro)
        {
            this._lst = list;
            this._filtro = filtro;
        }


        public bool CargarData()
        {
            var rt = true;
            return rt;
        }


        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Analisis\VentaPorTasa.rdlc";
            var ds = new dsAnalisis();

            foreach (var xg in _lst.OrderBy(o => o.descSuc).ToList())
            {
                DataRow r = ds.Tables["VentaPorTasa"].NewRow();
                r["sucursal"] = xg.descSuc.Trim() + "/" + xg.codSuc.Trim();
                r["monto"] = xg.monto;
                r["factor"] = xg.factor;
                r["cnt"] = xg.cnt;
                r["fecha"] = xg.fecha;
                ds.Tables["VentaPorTasa"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("Filtros", _filtro));
            Rds.Add(new ReportDataSource("VentaPorTasa", ds.Tables["VentaPorTasa"]));

            var frp = new Reporte();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

        public void Inicializar()
        {
            _filtro = "";
        }

    }

}
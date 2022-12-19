using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Utilidad.General
{

    public class Gestion 
    {

        private List<OOB.LibCajaBanco.Reporte.Utilidad.General.Ficha> list;
        private string _filtro;


        public Gestion()
        {
            _filtro = "";
        }

        public Gestion(List<OOB.LibCajaBanco.Reporte.Utilidad.General.Ficha> list, string p)
        {
            this.list = list;
            _filtro = p;
        }


        public bool CargarData()
        {
            var rt = true;
            return rt;
        }


        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Utilidad\UtGeneral.rdlc";
            var ds = new dsUtilidad();

            foreach (var xg in list.OrderBy(o => o.nombreSuc).ToList())
            {
                DataRow r = ds.Tables["general"].NewRow();
                r["sucursal"] = xg.nombreSuc.Trim() + "/" + xg.codSuc.Trim();
                r["venta"] = xg.venta;
                r["bono"] = xg.bono;
                r["costo"] = xg.costo;
                r["utilidad"] = xg.venta - (xg.bono + xg.costo);
                ds.Tables["general"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("Filtros", _filtro));
            Rds.Add(new ReportDataSource("general", ds.Tables["general"]));

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
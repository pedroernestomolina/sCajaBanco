using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Analisis.PorMetodosPago
{
    public class Gestion
    {
        private string _filtros;
        private List<src.Analisis.PorMetPago.data> _lst;


        public Gestion()
        {
            _filtros = "";
            _lst = new List<src.Analisis.PorMetPago.data>();
        }


        public void setData(List<src.Analisis.PorMetPago.data> list)
        {
            _lst.Clear();
            _lst = list;
        }
        public void setFiltros(string filtros)
        {
            _filtros = filtros;
        }


        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Analisis\PorMetodoPago.rdlc";
            var ds = new dsAnalisis();

            foreach (var xg in _lst.ToList())
            {
                DataRow r = ds.Tables["PorMetodoPago"].NewRow();
                r["sucursal"] = xg.DescSuc;
                r["montoMonLocal"] = xg.TotBs ;
                r["montoMonDivisa"] = xg.TotDiv;
                r["efectivoSist"] = xg.Ef_Sist;
                r["efectivoUsu"] = xg.Ef_Usu;
                r["tarjSist"] = xg.Tj_Sist;
                r["tarjUsu"] = xg.Tj_Usu;
                r["divisaSist"] = xg.Div_Sist;
                r["divisaUsu"] = xg.Div_Usu;
                r["cntDivisaSist"] = xg.CntDiv_Sist;
                r["cntDivisaUsu"] = xg.CntDiv_Usu;
                r["tasaCambio"] = xg.TasaPromedio;
                r["difMonLocal"] = (xg.Ef_Sist + xg.Tj_Sist + xg.Div_Sist) - (xg.Ef_Usu + xg.Tj_Usu + xg.Div_Usu);
                ds.Tables["PorMetodoPago"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("Filtros", _filtros));
            Rds.Add(new ReportDataSource("PorMetodoPago", ds.Tables["PorMetodoPago"]));

            var frp = new Reporte();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Analisis.VentasAnuladas
{
    public class Gestion: IGestion
    {
        private OOB.LibCajaBanco.Reporte.Analisis.VentasAnuladas.Ficha ficha;
        private string filtros;


        public Gestion(OOB.LibCajaBanco.Reporte.Analisis.VentasAnuladas.Ficha ficha, string filtros)
        {
            this.ficha = ficha;
            this.filtros = filtros;
        }


        public bool CargarData()
        {
            var rt = true;
            return rt;
        }

        public void Procesar()
        {
            GenerarReporte(ficha, filtros);
        }

        private void GenerarReporte(OOB.LibCajaBanco.Reporte.Analisis.VentasAnuladas.Ficha ficha, string filtro)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Analisis\VentasAnuladas.rdlc";
            var ds = new dsAnalisis();

            foreach (var xg in ficha.Documentos)
            {
                DataRow r = ds.Tables["VtaAnuladaDoc"].NewRow();
                r["docNum"] = xg.docNumero;
                r["docFecha"] = xg.docFecha.ToShortDateString()+Environment.NewLine+xg.docHora;
                r["docEntidad"] = xg.docEntidad;
                r["docTipo"] = xg.docNombre;
                r["docReng"] = xg.docRenglones;
                ds.Tables["VtaAnuladaDoc"].Rows.Add(r);
            }

            var _cntPrd = ficha.Detalles.GroupBy(g => g.autoPrd).Count();
            foreach (var xg in ficha.Detalles)
            {
                DataRow r = ds.Tables["VtaAnuladaDet"].NewRow();
                r["prdDesc"] = xg.prdDesc;
                r["cntEmp"] = xg.cntEmp;
                r["contEmp"] = xg.contEmp;
                r["cntUnd"] = xg.cntUnd;
                r["cntDocInvol"] = xg.cntDocInvol;
                ds.Tables["VtaAnuladaDet"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("Filtros", filtro));
            pmt.Add(new ReportParameter("CntDoc", ficha.Documentos.Count.ToString()));
            pmt.Add(new ReportParameter("CntArt", _cntPrd.ToString()));
            Rds.Add(new ReportDataSource("VtaAnuladaDet", ds.Tables["VtaAnuladaDet"]));
            Rds.Add(new ReportDataSource("VtaAnuladaDoc", ds.Tables["VtaAnuladaDoc"]));

            var frp = new Reporte();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

        public void Inicializar()
        {
        }


        public DateTime DesdeFecha { get { return DateTime.Now.Date; } }
        public DateTime HastaFecha { get { return DateTime.Now.Date; } }
        public bool IsOk { get { return true; } }
        public void setFechaDesde(DateTime fecha)
        {
        }
        public void setFechaHasta(DateTime fecha)
        {
        }
    }
}
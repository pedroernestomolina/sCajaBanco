using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Analisis.VentaPromedio
{

    public class Gestion : IGestion
    {

        private dataFiltro filtrar;
        private bool _isOk;


        public DateTime DesdeFecha { get { return filtrar.Desde; } }
        public DateTime HastaFecha { get { return filtrar.Hasta; } }
        public bool IsOk { get { return _isOk; } }


        public Gestion()
        {
            filtrar = new dataFiltro();
        }


        public bool CargarData()
        {
            var rt = true;
            return rt;
        }

        public void Procesar()
        {
            if (filtrar.isOk())
            {
                var filtroOOB = new OOB.LibCajaBanco.Reporte.Analisis.VentaPromedio.Filtro()
                {
                    desde = filtrar.Desde,
                    hasta = filtrar.Hasta,
                };
                var r01 = Sistema.MyData.Reporte_Analisis_VentaPromedio(filtroOOB);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }

                GenerarReporte(r01.Lista, filtrar.Texto());
                _isOk = true;
            }
        }

        public void setFechaDesde(DateTime fecha)
        {
            filtrar.setFechaDesde(fecha);
        }

        public void setFechaHasta(DateTime fecha)
        {
            filtrar.setFechaHasta(fecha);
        }

        private void GenerarReporte(List<OOB.LibCajaBanco.Reporte.Analisis.VentaPromedio.Ficha> list, string filtro)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Analisis\VentaPromedio.rdlc";
            var ds = new dsAnalisis();

            foreach (var xg in list.OrderByDescending(o=>o.fecha).ThenByDescending(o=>o.ventaDivisa).ToList())
            {
                DataRow r = ds.Tables["VentaPromedio"].NewRow();
                r["cntMov"] = xg.cntMov;
                r["cntMovPromedio"] = xg.cntMovPromedio;
                r["venta"] = xg.ventaDivisa;
                r["ventaPromedio"] = xg.ventaPromedio;
                r["sucursal"] = xg.sucursal ;
                r["fecha"] = xg.ano+"/"+xg.mes;
                r["dias"] = xg.dias;
                r["itemStock"] = xg.cntItemStock;
                r["costoStock"] = xg.costoStock;
                ds.Tables["VentaPromedio"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("Filtros", filtro));
            Rds.Add(new ReportDataSource("VentaPromedio", ds.Tables["VentaPromedio"]));

            var frp = new Reporte();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

        public void Inicializar()
        {
            _isOk = false;
            filtrar.Limpiar();
        }

    }

}
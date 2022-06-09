using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Analisis.VentaDiaria
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
                var filtroOOB = new OOB.LibCajaBanco.Reporte.Analisis.VentaDiaria.Filtro()
                {
                    desde = filtrar.Desde,
                    hasta = filtrar.Hasta,
                };
                var r01 = Sistema.MyData.Reporte_Analisis_VentaDiaria(filtroOOB);
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

        private void GenerarReporte(List<OOB.LibCajaBanco.Reporte.Analisis.VentaDiaria.Ficha> list, string filtro)
        {

            var ldata = list.GroupBy(g => new { g.nomSucursal, g.estacion, g.ano, g.mes, g.dia })
                .Select(g=> new data{ suc= g.Key.nomSucursal, estacion=g.Key.estacion, ano=g.Key.ano, mes=g.Key.mes, dia= g.Key.dia, cnt =g.Count()})
                .ToList();

            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Analisis\VentaDiaria.rdlc";
            var ds = new dsAnalisis();

            foreach (var xg in ldata.OrderBy(o=>o.suc).ThenBy(o=>o.ano).ThenBy(o=>o.mes).ThenBy(o=>o.dia).ToList())
            {
                DataRow r = ds.Tables["VentaDiaria"].NewRow();
                r["sucursal"] = xg.suc;
                r["estacion"] = xg.estacion;
                r["ano"] = xg.ano;
                r["mes"] = xg.mes;
                r["dia"] = xg.dia;
                r["cnt"] = xg.cnt;
                ds.Tables["VentaDiaria"].Rows.Add(r);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("Filtro", filtro));
            Rds.Add(new ReportDataSource("VentaDiaria", ds.Tables["VentaDiaria"]));

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
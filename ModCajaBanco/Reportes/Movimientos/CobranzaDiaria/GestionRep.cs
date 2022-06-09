using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.Reportes.Movimientos.CobranzaDiaria
{
    
    public class GestionRep
    {

        private OOB.LibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Ficha ficha;
        private string filtros;


        public GestionRep(OOB.LibCajaBanco.Reporte.Movimiento.CobranzaDiaria.Ficha data , string filt)
        {
            this.ficha = data;
            this.filtros = filt;
        }

        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Movimientos\CobranzaDiaria.rdlc";
            var ds = new dsMovimiento();

            var mcambio = 0.0m;

            var xdata = ficha.data.GroupBy(g => g.reciboNro).ToList();
            foreach (var xit in xdata) 
            {
                var sw = 1;
                foreach (var xg in xit)
                {
                    DataRow r = ds.Tables["CobranzaDiaria"].NewRow();
                    r["codSuc"] = xg.codSuc;
                    r["codEquipo"] = xg.codEstacion;
                    r["reciboNro"] = xg.reciboNro;
                    r["montoRecibido"] = xg.montoRecibido;
                    r["medioPago"] = xg.medioPagoDesc;
                    r["tipoDocumento"] = xg.tipoDocumento;
                    r["documentoNro"] = xg.documentoNro;
                    r["tipoOperacion"] = xg.operacion;

                    if (xg.medioPagoCod == "02")
                    {
                        r["cnt"] = decimal.Parse(xg.loteNro);
                        r["tasa"] = decimal.Parse(xg.refNro);
                    }
                    else 
                    {
                        r["lote"] = xg.loteNro;
                        r["ref"] = xg.refNro;
                    }
                    if (sw == 1)
                    {
                        r["fechaHora"] = xg.fecha.ToShortDateString() + ", " + xg.hora;
                        r["importe"] = xg.importe;
                        r["cliente"] = xg.ciRif + Environment.NewLine + xg.cliente;
                        r["cambio"] = xg.cambio;
                        mcambio += xg.cambio;
                        sw = 0;
                    }
                    ds.Tables["CobranzaDiaria"].Rows.Add(r);
                }
            }

            var xdataPagoRes = ficha.data.
                GroupBy(g => new { g.medioPagoCod, g.medioPagoDesc }).
                Select(s => new { cmp= s.Key.medioPagoCod, mp = s.Key.medioPagoDesc, monto = s.Sum(ss => ss.montoRecibido), cnt = s.Sum(ss => ss.cnt) }).ToList();

            var sw1 = 0;
            foreach (var xit in xdataPagoRes)
            {
                DataRow r = ds.Tables["CobranzaDiariaPagoRes"].NewRow();
                r["medioPago"] = xit.mp;
                r["cnt"] = xit.cnt;
                if (xit.cmp=="01")
                {
                    sw1 = 1;
                    r["monto"] = xit.monto - mcambio;
                }
                else
                    r["monto"] = xit.monto ;
                ds.Tables["CobranzaDiariaPagoRes"].Rows.Add(r);
            }
            if (sw1 == 0) 
            {
                DataRow r = ds.Tables["CobranzaDiariaPagoRes"].NewRow();
                r["medioPago"] = "Efectivo";
                r["cnt"] = 0;
                r["monto"] =  mcambio*(-1);
                ds.Tables["CobranzaDiariaPagoRes"].Rows.Add(r);
            }

            var xdataPagoDet = ficha.data.
                GroupBy(g => new { g.medioPagoCod, g.tasa, g.medioPagoDesc, g.lote }).
                Select(s => new { mp=s.Key.medioPagoDesc, lote=s.Key.lote, tasa= s.Key.tasa, monto = s.Sum(ss=>ss.montoRecibido), cnt= s.Sum(ss=>ss.cnt)}).ToList();
            foreach (var xit in xdataPagoDet.OrderBy(o=>o.mp).ThenBy(o=>o.tasa).ThenBy(o=>o.lote).ToList())
            {
                DataRow r = ds.Tables["CobranzaDiariaPagoDet"].NewRow();
                r["medioPago"] = xit.mp;
                r["cnt"] = xit.cnt;
                r["monto"] = xit.monto;
                r["tasa"] = xit.tasa;
                r["lote"] = xit.lote;
                ds.Tables["CobranzaDiariaPagoDet"].Rows.Add(r);
            }

            var xcierre = 0.0m;
            foreach (var xmov in ficha.movimiento)
            {
                var dmov="";
                switch (xmov.tipoDoc)
                {
                    case "01":
                        xcierre += xmov.monto;
                        dmov="Total Facturado";
                        break;
                    case "03":
                        xcierre -= xmov.monto;
                        dmov="Total Devoluciones";
                        break;
                }
                DataRow rr = ds.Tables["CobranzaDiariaMov"].NewRow();
                rr["movimiento"] = dmov;
                rr["monto"] = xmov.monto;
                ds.Tables["CobranzaDiariaMov"].Rows.Add(rr);
            }
            DataRow xrr = ds.Tables["CobranzaDiariaMov"].NewRow();
            xrr = ds.Tables["CobranzaDiariaMov"].NewRow();
            xrr["movimiento"] = "Cierre del Dia";
            xrr["monto"] = xcierre;
            ds.Tables["CobranzaDiariaMov"].Rows.Add(xrr);

            xrr = ds.Tables["CobranzaDiariaMov"].NewRow();
            xrr["movimiento"] = "Total Credito";
            xrr["monto"] = ficha.montoCredito;
            ds.Tables["CobranzaDiariaMov"].Rows.Add(xrr);
           
            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("FILTROS", filtros));
            pmt.Add(new ReportParameter("CAMBIO_DAR", mcambio.ToString("n2")));
            Rds.Add(new ReportDataSource("CobranzaDiaria", ds.Tables["CobranzaDiaria"]));
            Rds.Add(new ReportDataSource("CobranzaDiariaPagoDet", ds.Tables["CobranzaDiariaPagoDet"]));
            Rds.Add(new ReportDataSource("CobranzaDiariaPagoRes", ds.Tables["CobranzaDiariaPagoRes"]));
            Rds.Add(new ReportDataSource("CobranzaDiariaMov", ds.Tables["CobranzaDiariaMov"]));

            var frp = new Reporte();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}
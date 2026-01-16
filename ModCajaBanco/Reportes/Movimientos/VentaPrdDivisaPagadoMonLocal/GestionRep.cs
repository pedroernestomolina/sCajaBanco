using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModCajaBanco.Reportes.Movimientos.VentaPrdDivisaPagadoMonLocal
{
    public class GestionRep
    {
        private List<src.Consulta.VentaProductoDivisaPagoEnMonLocal.Domain.Models.Data> _data;
        //
        public void setData(List<src.Consulta.VentaProductoDivisaPagoEnMonLocal.Domain.Models.Data> data)
        {
            _data = data;
        }
        public void Generar()
        {
            var ds = new dsMovimiento();
            var _doc = _data.GroupBy(g => new { g.idDoc, g.docNumero, g.fechaEmision, g.entidadNombre, g.entidadCiRif, g.montoDivisa }).Select(s => new { s.Key, s }).ToList();
            foreach (var it in _doc.OrderBy(o => o.Key.fechaEmision).ThenBy(o => o.Key.docNumero).ToList())
            {
                DataRow r = ds.Tables["VentaPrdDivisaPagadoMonLocal"].NewRow();
                r["idDoc"] = it.Key.idDoc;
                r["docNumero"] = it.Key.docNumero;
                r["fechaEmision"] = it.Key.fechaEmision;
                r["entidadNombre"] = it.Key.entidadNombre.Trim();
                r["entidadCiRif"] = it.Key.entidadCiRif.Trim();
                r["montoDivisa"] = it.Key.montoDivisa;
                ds.Tables["VentaPrdDivisaPagadoMonLocal"].Rows.Add(r);
                //
                var _det = it.s.GroupBy(g => new { g.nombrePrd, g.cantidad, g.empqNombre, g.empqCont, g.isPrdDivisa }).Select(s => new { s.Key, s }).ToList();
                foreach (var d in _det)
                {
                    DataRow dt = ds.Tables["VentaPrdDivisaPagMonLocal_Detalle"].NewRow();
                    dt["idDoc"] = it.Key.idDoc;
                    dt["producto"] = d.Key.nombrePrd;
                    dt["cantidad"] = d.Key.cantidad;
                    dt["empq"] = d.Key.empqNombre;
                    dt["empqCont"] = d.Key.empqCont ;
                    dt["isPrdDivisa"] = d.Key.isPrdDivisa;
                    ds.Tables["VentaPrdDivisaPagMonLocal_Detalle"].Rows.Add(dt);
                }
                var _mp = it.s.GroupBy(g => new { g.nombreMp, g.codigoMp, g.codigoMonRecibe, g.montoMonRecibe, g.montoMonRecibeMonRef }).Select(s => new { s.Key, s }).ToList();
                foreach (var m in _mp)
                {
                    DataRow dt = ds.Tables["VentaPrdDivisaPagMonLocal_MP"].NewRow();
                    dt["idDoc"] = it.Key.idDoc;
                    dt["medioPago"] = m.Key.nombreMp+"/"+m.Key.codigoMp;
                    dt["codigoMon"] = m.Key.codigoMonRecibe;
                    dt["montoMonRecibe"] = m.Key.montoMonRecibe;
                    dt["montoMonRecibeMonRef"] = m.Key.montoMonRecibeMonRef;
                    ds.Tables["VentaPrdDivisaPagMonLocal_MP"].Rows.Add(dt);
                }
            }
            Frm frm;
            frm = new Frm();
            frm.setData(ds);
            frm.ShowDialog();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.src.Consulta.PorMetodoPago.Domain.UseCase
{
    public class UseCaseImpl: IUseCase
    {
        public DataTable
            CargarArqueoPorMetodosPago(DateTime desd, DateTime hast)
        {
            try
            {
                var filtroOOB = new OOB.LibCajaBanco.Consulta.Arqueo.PorMedioPago.Filtro()
                {
                    desde = desd,
                    hasta = hast
                };
                var rst = Sistema.MyData.Consulta_Arqueo_PorMedioPago(filtroOOB);
                if (rst.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(rst.Mensaje);
                }
                var lst = rst.Lista.OrderBy(o => o.nombreSuc).ToList();
                var cols = lst
                    .Select(s => new { col= s.descMP + " (" + s.simboloMon + ")" })
                    .Distinct()
                    .ToList();
                //
                DataTable dt = new DataTable();
                dt.Columns.Add("Sucursal", typeof(string));
                foreach (var xcol in cols) 
                {
                    //dt.Columns.Add(xcol.col + " Importe Bs", typeof(decimal));
                    dt.Columns.Add(xcol.col + " Segun Sistema", typeof(decimal));
                    dt.Columns.Add(xcol.col + " Segun Usuario", typeof(decimal));
                }
                dt.Columns.Add("DIFERENCIA", typeof(decimal));
                //
                var diffTotal = 0m;
                var grpSuc = lst.GroupBy(r => new { r.codigoSuc, r.nombreSuc, r.cierreNro, r.fecha }).ToList();
                foreach (var suc in grpSuc) 
                {
                    var diff = 0m;
                    DataRow dr = dt.NewRow();
                    dr["Sucursal"] = suc.Key.nombreSuc+", "+suc.Key.fecha.ToShortDateString()+", #"+suc.Key.cierreNro.ToString().Trim();
                    foreach (var item in suc) 
                    {
                        var cbase = item.descMP + " (" + item.simboloMon + ") ";
                        //dr[cbase + "Importe Bs"] = item.montoMonLocal;
                        dr[cbase + "Segun Sistema"] = item.montoSS;
                        dr[cbase + "Segun Usuario"] = item.montoSU;
                        diff += (item.importeSegunSistema-item.importeSegunUsuario);
                    }
                    dr["DIFERENCIA"] = diff;
                    dt.Rows.Add(dr);
                    diffTotal += diff;
                }
                //
                DataRow filaTotal = dt.NewRow();
                filaTotal["Sucursal"] = "TOTAL GENERAL";
                foreach (var xcol in cols)
                {
                    var cbaseSS = xcol.col +" Segun Sistema";
                    var cbaseSU = xcol.col +" Segun Usuario";
                    decimal ss= lst.Where(w => (w.descMP + " (" + w.simboloMon + ")"== xcol.col))
                        .Sum(s=> s.montoSS);
                    decimal su= lst.Where(w => (w.descMP + " (" + w.simboloMon + ")"== xcol.col))
                        .Sum(s=> s.montoSU);
                    filaTotal[cbaseSS] = ss;
                    filaTotal[cbaseSU] = su;
                }
                filaTotal["DIFERENCIA"] = diffTotal;
                dt.Rows.Add(filaTotal);
                //
                return dt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public DateTime 
            CargarFechaServidor()
        {
            try
            {
                var rst =  Sistema.MyData.FechaServidor();
                if (rst.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(rst.Mensaje);
                }
                return rst.Entidad;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

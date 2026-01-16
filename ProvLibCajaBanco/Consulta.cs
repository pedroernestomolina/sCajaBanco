using LibEntityCajaBanco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProvLibCajaBanco
{
    public partial class Provider : ILibCajaBanco.IProvider 
    {
        public DtoLib.ResultadoLista<DtoLibCajaBanco.Consulta.Arqueo.PorMedioPago.Ficha> 
            Consulta_Arqueo_PorMedioPago(DtoLibCajaBanco.Consulta.Arqueo.PorMedioPago.Filtro filtro)
        {
            var rt = new DtoLib.ResultadoLista<DtoLibCajaBanco.Consulta.Arqueo.PorMedioPago.Ficha>();
            //
            try
            {
                using (var cnn = new cajaBancoEntities(_cnCajBanco.ConnectionString))
                {
                    var _p1 = new MySql.Data.MySqlClient.MySqlParameter("@desde", filtro.desde);
                    var _p2 = new MySql.Data.MySqlClient.MySqlParameter("@hasta", filtro.hasta);
                    var _sql_1 = @"SELECT 
										arq.fecha as fecha,
                                        arq.cierre_numero as cierreNro,
	                                    mp.codigo_mediopago as codigoMP, 
                                        mp.desc_mediopago as descMP,
                                        mp.codigo_currencies as codigoMon,
                                        mp.desc_currencies as descMon,
                                        mp.simbolo_currencies as simboloMon,
                                        sum(mp.monto_segun_sistema) as montoSS,
                                        sum(mp.monto_segun_usuario) as montoSU,
                                        sum(mp.importe_mon_local) as importeSegunUsuario,
                                        sum(mp.monto_segun_sistema*mp.tasa_factor_ponderado) as importeSegunSistema,
                                        suc.codigo as codigoSuc,
                                        suc.nombre as nombreSuc
                                    FROM
	                                    pos_arqueo_metodos_pago as mp
                                    join
	                                    pos_arqueo as arq on arq.auto_cierre=mp.auto_cierre
                                    join
	                                    empresa_sucursal as suc on arq.codigo_sucursal=suc.codigo
                                    where
	                                    arq.fecha>=@desde
                                        AND arq.fecha<=@hasta
                                    group by
                                    	arq.fecha,
                                        arq.auto_cierre,
                                        arq.cierre_numero,
                                    	mp.codigo_mediopago,
                                        mp.desc_mediopago, 
                                        mp.codigo_currencies,
                                        mp.desc_currencies,
                                        mp.simbolo_currencies,
                                        suc.codigo,
                                        suc.nombre";
                    var _sql = _sql_1;
                    var _lst = cnn.Database.SqlQuery<DtoLibCajaBanco.Consulta.Arqueo.PorMedioPago.Ficha>(_sql, _p1, _p2).ToList();
                    rt.Lista = _lst;
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
        public DtoLib.ResultadoEntidad<DtoLibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Ficha>
            Consulta_Ventas_ProductoDivisaPagoEnMonLocal(DtoLibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Filtro filtro)
        {
            var rt = new DtoLib.ResultadoEntidad<DtoLibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Ficha>();
            //
            try
            {
                using (var cnn = new cajaBancoEntities(_cnCajBanco.ConnectionString))
                {
                    var _p1 = new MySql.Data.MySqlClient.MySqlParameter("@desde", filtro.desde);
                    var _p2 = new MySql.Data.MySqlClient.MySqlParameter("@hasta", filtro.hasta);
                    var _p3 = new MySql.Data.MySqlClient.MySqlParameter("@codigoSuc", filtro.codigoSuc);
                    var _p4 = new MySql.Data.MySqlClient.MySqlParameter("@codigoMon", filtro.codigoMon);
                    var _sql_1 = @"select DISTINCT
                                        s.*, 
                                        mp.codigo as codigoMp,
                                        mp.medio as nombreMp,  
                                        mp.codigo_mon_recibe as codigoMonRecibe,
                                        mp.monto_mon_recibe as montoMonRecibe,
                                        mp.monto_mon_referencia as montoMonRecibeMonRef
                                    from 
                                        (
                                            SELECT 
                                                v.auto as idDoc,
                                                v.documento as docNumero,
                                                v.fecha as fechaEmision,
                                                v.razon_social as entidadNombre,
                                                v.ci_rif as entidadCiRif,
                                                v.monto_divisa as montoDivisa,
                                                v.auto_recibo as idRecibo,    
                                                vd.nombre as nombrePrd,
                                                vd.cantidad as cantidad,
                                                vd.empaque as empqNombre,
                                                vd.contenido_empaque as empqCont,
                                                vd.estatus_divisa_prd as estatusPrdDivisa
                                            FROM ventas as v
                                            join ventas_detalle as vd on vd.auto_documento=v.auto 
                                            join cxc_medio_pago as mp on mp.auto_recibo=v.auto_recibo and mp.codigo_mon_recibe=@codigoMon
                                            where v.fecha>=@desde AND
                                            v.fecha<=@hasta AND
                                            v.tipo='01' AND
                                            v.estatus_anulado='0' AND
                                            v.codigo_sucursal=@codigoSuc AND 
                                            v.auto IN (
                                                SELECT DISTINCT auto_documento 
                                                FROM ventas_detalle 
                                                WHERE estatus_divisa_prd = '1')
                                        ) as s
                                    join cxc_medio_pago as mp on mp.auto_recibo=s.idRecibo";
                    var _sql = _sql_1;
                    var _lst= cnn.Database.SqlQuery<DtoLibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.DocDetalle>(_sql, _p1, _p2, _p3, _p4).ToList();
                    //
                    rt.Entidad = new DtoLibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Ficha()
                    {
                        docDetalle = _lst,
                    };
                }
            }
            catch (Exception e)
            {
                rt.Mensaje = e.Message;
                rt.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            //
            return rt;
        }
        public DtoLib.ResultadoEntidad<string> 
            Configuracion_MonedaLocal()
        {
            var result = new DtoLib.ResultadoEntidad<string>();
            //
            try
            {
                using (var cnn = new cajaBancoEntities(_cnCajBanco.ConnectionString))
                {
                    var _sql = "select usuario from sistema_configuracion where codigo='GLOBAL68'";
                    var ent1 = cnn.Database.SqlQuery<string>(_sql).FirstOrDefault();
                    if (ent1 == null)
                    {
                        throw new Exception("[ ID ] CONFIGURACION GLOBAL NO ENCONTRADO");
                    }
                    if (ent1.ToString().Trim() == "")
                    {
                        throw new Exception("[ ID ] NO CONFIGURADO");
                    }
                    result.Entidad = ent1;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }
    }
}
//        public DtoLib.ResultadoEntidad<DtoLibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Ficha> 
//            Consulta_Ventas_ProductoDivisaPagoEnMonLocal(DtoLibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Filtro filtro)
//        {
//            var rt = new DtoLib.ResultadoEntidad<DtoLibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Ficha>();
//            //
//            try
//            {
//                using (var cnn = new cajaBancoEntities(_cnCajBanco.ConnectionString))
//                {
//                    var _p1 = new MySql.Data.MySqlClient.MySqlParameter("@desde", filtro.desde);
//                    var _p2 = new MySql.Data.MySqlClient.MySqlParameter("@hasta", filtro.hasta);
//                    var _p3 = new MySql.Data.MySqlClient.MySqlParameter("@codigoSuc", filtro.codigoSuc);
//                    var _p4 = new MySql.Data.MySqlClient.MySqlParameter("@codigoMon", filtro.codigoMon);
//                    var _sql_1 = @"select    
//                                        doc.idDocVta,
//                                        mp.auto_recibo as idRecibo,
//	                                    mp.auto_medio_pago as idMedioPago,
//                                        mp.medio as nombreMedioPago,
//                                        mp.codigo_mon_recibe as codigoMonedaRecibe,
//                                        mp.simbolo_mon_recibe as simboloMonedaRecibe,
//                                        mp.monto_mon_recibe as montoMonedaRecibe,
//                                        mp.monto_mon_referencia as montoMonedaReferencia
//                                    from (
//                                        SELECT DISTINCT
//	                                        v.auto as idDocVta,
//                                            v.auto_recibo as idRecibo
//                                        FROM ventas_detalle as vd
//                                        join ventas as v on v.auto=vd.auto_documento
//                                        join cxc_recibos as rec on rec.auto= v.auto_recibo 
//                                        join cxc_medio_pago as mp on mp.auto_recibo=rec.auto
//                                        where
//	                                        vd.estatus_divisa_prd='1' and
//                                            v.fecha>=@desde and 
//                                            v.fecha<=@hasta and 
//                                            v.codigo_sucursal=@codigoSuc and 
//                                            v.estatus_anulado='0' and 
//                                            v.tipo='01' and 
//                                            mp.codigo_mon_recibe=@codigoMon
//                                        ) as doc
//                                    join cxc_recibos as rec on rec.auto= doc.idRecibo
//                                    join cxc_medio_pago as mp on mp.auto_recibo=rec.auto
//                                    where mp.monto_mon_recibe>0";
//                    var _sql = _sql_1;
//                    var _lstMedioPago = cnn.Database.SqlQuery<DtoLibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.MedioPago>(_sql, _p1, _p2, _p3, _p4).ToList();
//                    //
//                    _p1 = new MySql.Data.MySqlClient.MySqlParameter("@desde", filtro.desde);
//                    _p2 = new MySql.Data.MySqlClient.MySqlParameter("@hasta", filtro.hasta);
//                    _p3 = new MySql.Data.MySqlClient.MySqlParameter("@codigoSuc", filtro.codigoSuc);
//                    _p4 = new MySql.Data.MySqlClient.MySqlParameter("@codigoMon", filtro.codigoMon);
//                    _sql_1 = @"SELECT 
//                                    v.auto as idDocVta,
//                                    v.razon_social as entidad,
//                                    v.fecha as fecha,
//                                    v.total importeDoc,
//                                    v.monto_divisa as importeDocDivisa,
//                                    v.factor_cambio as factorCambio,
//                                    vd.nombre as nombrePrd,
//                                    vd.cantidad as cant,
//                                    vd.empaque as empq,
//                                    vd.contenido_empaque as contEmp,
//                                    vd.estatus_divisa_prd as estatusDivisaProducto,
//                                    vd.total_neto as importeItem,
//                                    vd.total_neto/v.factor_cambio as importeItemDivisa
//                                from
//                                    (
//                                        SELECT DISTINCT
//	                                        v.auto
//                                        FROM ventas_detalle as vd
//                                        join ventas as v on v.auto=vd.auto_documento
//                                        join cxc_recibos as rec on rec.auto= v.auto_recibo 
//                                        join cxc_medio_pago as mp on mp.auto_recibo=rec.auto
//                                        where
//	                                        vd.estatus_divisa_prd='1' and 
//                                            v.fecha>=@desde and 
//                                            v.fecha<=@hasta and 
//                                            v.codigo_sucursal=@codigoSuc and 
//                                            v.estatus_anulado='0' and 
//                                            v.tipo='01' and 
//                                            mp.codigo_mon_recibe=@codigoMon
//                                    ) as doc
//                                join ventas as v on v.auto=doc.auto
//                                join ventas_detalle as vd on vd.auto_documento=v.auto";
//                    _sql = _sql_1;
//                    var _lstDocDetalle = cnn.Database.SqlQuery<DtoLibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.DocDetalle>(_sql, _p1, _p2, _p3, _p4).ToList();
//                    //
//                    rt.Entidad = new DtoLibCajaBanco.Consulta.Ventas.ProductoDivisaPagoEnMonLocal.Ficha()
//                    {
//                        docDetalle = _lstDocDetalle,
//                        mediosPago = _lstMedioPago
//                    };
//                }
//            }
//            catch (Exception e)
//            {
//                rt.Mensaje = e.Message;
//                rt.Result = DtoLib.Enumerados.EnumResult.isError;
//            }
//            //
//            return rt;
//        }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.src.Consulta.VentaProductoDivisaPagoEnMonLocal.vm
{
    public class ConsultaImpl: IConsulta
    {
        private DateTime _desde;
        private DateTime _hasta;
        private string _idSucursal;
        private Domain.UseCase.IUseCase _uc;
        //
        public ConsultaImpl()
        {
        }
        void setFechaDesde(DateTime fecha)
        {
            _desde=fecha;
        }
        void setFechaHasta(DateTime fecha)
        {
            _hasta=fecha;
        }
        void setSucursal(string id)
        {
            _idSucursal = id;
        }
        public void setFiltro(Filtro filtro)
        {
            setFechaDesde(filtro.desde);
            setFechaHasta(filtro.hasta);
            setSucursal(filtro.idSucursal);
        }
        public void Invoke()
        {
            try
            {
                _uc.ObtenerMonedaLocal();
                var data = _uc.ConsultarVentasProductoDivisaConPagoEnMonLocal(_desde, _hasta, _idSucursal, "VES");
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}
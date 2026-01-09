using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.src.Consulta.VentaProductoDivisaPagoEnMonLocal.Domain.UseCase
{
    public interface IUseCase
    {
        Models.Data
            ConsultarVentasProductoDivisaConPagoEnMonLocal(DateTime desde, DateTime hasta, string codigoSuc, string codigoMon);
        void ObtenerMonedaLocal();
    }
}
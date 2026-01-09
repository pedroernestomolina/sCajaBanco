using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.src.Consulta.VentaProductoDivisaPagoEnMonLocal.vm
{
    public class Filtro
    {
        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }
        public string idSucursal { get; set; }
    }
    public interface IConsulta
    {
        void setFiltro(Filtro filtro);
        void Invoke();
    }
}

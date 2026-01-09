using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.src.Consulta.PorMetodoPago.vm
{
    public interface IConsulta
    {
        DateTime Get_Desde { get; }
        DateTime Get_Hasta { get; }
        object Get_DataSource { get; }
        //
        void Invoke();
        //
        void setDesde(DateTime fecha);
        void setHasta(DateTime fecha);
        //
        void AccionBuscar();
        void AccionLimpiarConsulta();
        void AccionReporteExportar();
    }
}
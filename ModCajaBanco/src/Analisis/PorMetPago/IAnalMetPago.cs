using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCajaBanco.src.Analisis.PorMetPago
{
    public interface IAnalMetPago: IGestion
    {
        BindingSource Data_GetSource { get; }
        BindingSource Totales_GetSource { get; }
        DateTime GetFecha_Desde { get; }
        DateTime GetFecha_Hasta { get; }
        enumerados.EnumModo ModoActivo { get; }

        void setFechaDesde(DateTime fecha);
        void setFechaHasta(DateTime fecha);
        void setSucursalEstatus(bool estatus);
        void setHabilitarSucursalAmbos(bool isChecked);
        void setModoUsuario();
        void setModoSistema();
        void setModoAmbos();

        void ActivarBusqueda();
        void Limpiar();

    }
}
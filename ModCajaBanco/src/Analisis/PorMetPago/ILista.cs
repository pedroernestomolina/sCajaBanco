using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCajaBanco.src.Analisis.PorMetPago
{
    public interface ILista
    {
        BindingSource GetSource { get; }
        BindingSource GetTotales { get; }
        List<data> GetLista { get; }
        void Inicializa();
        void setModoUsuario();
        void setModoSistema();
        void setData(List<data> lst);
        void Limpiar();
        void InactivarItem();
        void ActivarItemModoSist();
        void ActivarItemModoUsu();
        void ActivarItemModoAmbos();
        void setModoAmbos();
    }
}
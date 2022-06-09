using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCajaBanco.Habladores
{
    
    public class Gestion
    {


        private List<data> lista;
        private BindingList<data> bl;
        private BindingSource bs;


        public BindingSource Source { get { return bs; } }
        public int TItems { get { return bl.Count; } }


        public Gestion()
        {
            lista = new List<data>();
            bl = new BindingList<data>(lista);
            bs = new BindingSource();
            bs.DataSource = bl;
        }


        Habladores.HabladoresFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData()) 
            {
                frm = new HabladoresFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private void Limpiar()
        {
            bl.Clear();
            bs.CurrencyManager.Refresh();
        }

        private bool CargarData()
        {
            var rt = true;

            return rt;
        }

        public void Buscar()
        {
            var r01 = Sistema.MyData.Sucursal_GetPrincipal();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return ;
            }

            var r02 = Sistema.MyData.EmpresaGrupo_GetFicha(r01.Entidad.autoGrupoEmpresa);
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return ;
            }

            var filtro = new OOB.LibCajaBanco.Reporte.Habladores.Filtro();
            var r03 = Sistema.MyData.Reporte_Habladores(filtro);
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return ;
            }
            bl.Clear();
            foreach (var rg in r03.Lista.OrderBy(o=>o.nombrePrd).ToList()) 
            {
                bl.Add(new data(rg, r02.Entidad.idPrecio));
            }
            bs.CurrencyManager.Refresh();
        }

        public void LimpiarData()
        {
            if (bl.Count > 0)
            {
                var msg = MessageBox.Show("Limpiar Data ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    bl.Clear();
                    bs.CurrencyManager.Refresh();
                }
            }
        }

        public void EliminarItem()
        {
            if (bs.Current != null)
            {
                var it = (data) bs.Current;
                if (bl.Count > 0)
                {
                    var msg = MessageBox.Show("Eliminar Item ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msg == DialogResult.Yes)
                    {
                        bl.Remove(it);
                        bs.CurrencyManager.Refresh();
                    }
                }
            }
        }

        public void ImprimirHablador()
        {
            if (bl.Count > 0) 
            {
                var rp = new Reportes.Hablador.GestionRep(lista.Where(w=>w.imprimir).ToList());
                rp.Generar();
            }
        }

        public void MarcarTodos()
        {
            if (bl.Count > 0)
            {
                foreach (var it in bl)
                {
                    it.Marcar(true);
                }
                bs.CurrencyManager.Refresh();
            }
        }

        public void DesMarcarTodos()
        {
            if (bl.Count > 0)
            {
                foreach (var it in bl)
                {
                    it.Marcar(false);
                }
                bs.CurrencyManager.Refresh();
            }
        }

    }

}
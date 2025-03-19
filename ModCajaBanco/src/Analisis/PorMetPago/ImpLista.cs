using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCajaBanco.src.Analisis.PorMetPago
{
    public class ImpLista: ILista
    {
        private List<data> _lst;
        private List<dataTot> _lstTot;
        private BindingList<data> _bl;
        private BindingSource _bs;
        private BindingSource _bsTot;


        public BindingSource GetSource { get { return _bs; } }
        public BindingSource GetTotales { get { return _bsTot; } }
        public List<data> GetLista { get { return _bl.Where(w=>w.isChecked).ToList(); } }


        public ImpLista()
        {
            _lst = new List<data>();
            _lstTot = new List<dataTot>();
            _bl = new BindingList<data>(_lst);
            _bs = new BindingSource();
            _bsTot = new BindingSource();
            _bs.DataSource = _bl;
            _bs.CurrencyManager.Refresh();
            _bsTot = new BindingSource();
            _bsTot.DataSource = _lstTot;
            _bsTot.CurrencyManager.Refresh();
        }


        public void Inicializa()
        {
            _bl.Clear();
            _lstTot.Clear();
        }


        public void setModoUsuario()
        {
            foreach (var rg in _lst) 
            {
                if (rg.isChecked) 
                {
                    rg.setModoUsuario();
                }
            }
            ActualizaTotales();
        }
        public void setModoSistema()
        {
            foreach (var rg in _lst)
            {
                if (rg.isChecked)
                {
                    rg.setModoSistema();
                }
            }
            ActualizaTotales();
        }
        public void setModoAmbos()
        {
            foreach (var rg in _lst)
            {
                if (rg.isChecked)
                {
                    rg.setModoAmbos();
                }
            }
            ActualizaTotales();
        }
        public void setData(List<data> xlst)
        {
            _lst.Clear();
            _lst.AddRange(xlst);
            _bl.ResetBindings();
            ActualizaTotales();
        }
        public void Limpiar()
        {
            _lst.Clear();
            _bl.ResetBindings();
            ActualizaTotales();
        }
        public void InactivarItem()
        {
            if (_bs.Current != null)
            {
                var _item = (data)_bs.Current;
                _item.InactivarItem();
                ActualizaTotales();
            }
        }
        public void ActivarItemModoSist()
        {
            if (_bs.Current != null)
            {
                var _item = (data)_bs.Current;
                _item.ActivarItemModoSist();
                ActualizaTotales();
            }
        }
        public void ActivarItemModoUsu()
        {
            if (_bs.Current != null)
            {
                var _item = (data)_bs.Current;
                _item.ActivarItemModoUsu();
                ActualizaTotales();
            }
        }
        public void ActivarItemModoAmbos()
        {
            if (_bs.Current != null)
            {
                var _item = (data)_bs.Current;
                _item.ActivarItemModoAmbos();
                ActualizaTotales();
            }
        }


        private void ActualizaTotales()
        {
            var nr = new dataTot()
            {
                CntDivisa = _lst.Where(w => w.isChecked).Sum(s => s.CntDivisa),
                descripcion = "",
                Divisa = _lst.Where(w => w.isChecked).Sum(s => s.Divisa),
                Efectivo = _lst.Where(w => w.isChecked).Sum(s => s.Efectivo),
                SumaBs = _lst.Where(w => w.isChecked).Sum(s => s.SumaBs),
                Tarjeta = _lst.Where(w => w.isChecked).Sum(s => s.Tarjeta),
                TotEnBs = _lst.Where(w => w.isChecked).Sum(s => s.TotBs),
                TotEnDiv = _lst.Where(w => w.isChecked).Sum(s => s.TotDiv),
            };
            _lstTot.Clear();
            _lstTot.Add(nr);
            _bsTot.DataSource = _lstTot;
            _bsTot.CurrencyManager.Refresh();
        }
    }
}
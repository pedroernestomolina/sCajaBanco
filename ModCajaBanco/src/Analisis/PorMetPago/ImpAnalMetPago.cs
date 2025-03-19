using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCajaBanco.src.Analisis.PorMetPago
{
    public class ImpAnalMetPago: IAnalMetPago
    {
        private DateTime _desde;
        private DateTime _hasta;
        private enumerados.EnumModo _modoAct;
        private ILista _lista;


        public BindingSource Data_GetSource { get { return _lista.GetSource; } }
        public BindingSource Totales_GetSource { get { return _lista.GetTotales; } }
        public DateTime GetFecha_Desde { get { return _desde; } }
        public DateTime GetFecha_Hasta { get { return _hasta; } }
        public enumerados.EnumModo ModoActivo { get { return _modoAct; } }


        public ImpAnalMetPago()
        {
            _desde = DateTime.Now.Date;
            _hasta = DateTime.Now.Date;
            _modoAct = enumerados.EnumModo.SegunSist;
            _lista = new ImpLista();
        }

        public void Inicializa()
        {
            _desde = DateTime.Now.Date;
            _hasta = DateTime.Now.Date;
            _modoAct = enumerados.EnumModo.SegunSist;
            _lista.Inicializa();
        }
        Frm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null)
                {
                    frm = new Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public void setFechaDesde(DateTime fecha)
        {
            _desde = fecha;
        }
        public void setFechaHasta(DateTime fecha)
        {
            _hasta = fecha;
        }
        public void setSucursalEstatus(bool estatus)
        {
            if (!estatus) 
            {
                switch (_modoAct) 
                {
                    case enumerados.EnumModo.SegunSist:
                        _lista.ActivarItemModoSist();
                        break;
                    case enumerados.EnumModo.SegunUsu:
                        _lista.ActivarItemModoUsu();
                        break;
                    case enumerados.EnumModo.Ambos:
                        _lista.ActivarItemModoAmbos();
                        break;
                }
            }
            else
            {
                _lista.InactivarItem();
            }
        }
        public void setHabilitarSucursalAmbos(bool isChecked)
        {
            //if (_bsSuc.Current != null)
            //{
            //    var _suc = (dataSuc)_bsSuc.Current;
            //    _suc.setHabilitar(!isChecked);
            //}
            //_bsSuc.CurrencyManager.Refresh();
        }
        public void setModoUsuario()
        {
            _modoAct = enumerados.EnumModo.SegunUsu;
            _lista.setModoUsuario();
        }
        public void setModoSistema()
        {
            _modoAct = enumerados.EnumModo.SegunSist;
            _lista.setModoSistema();
        }
        public void setModoAmbos()
        {
            _modoAct = enumerados.EnumModo.Ambos;
            _lista.setModoAmbos();
        }


        public void Limpiar()
        {
            _modoAct = enumerados.EnumModo.SegunSist;
            _desde = DateTime.Now.Date;
            _hasta = DateTime.Now.Date;
            _lista.Limpiar();
            _lista.setModoSistema();
        }
        public void ActivarBusqueda()
        {
            try
            {
                if (_desde > _hasta)
                {
                    throw new Exception("PROBLEMAS CON FECHAS INCORRECTAS");
                }
                var filtro = new OOB.LibCajaBanco.Reporte.Analisis.PorMedioPago.Filtro()
                {
                    desde = _desde,
                    hasta = _hasta,
                };
                var r01 = Sistema.MyData.Reporte_Analisis_PorMediosPago(filtro);
                var _lst = new List<data>();
                foreach (var rg in r01.Lista.OrderBy(o => o.descSuc).ToList())
                {
                    var nrd = new data(rg.autoSuc, rg.codigoSuc, rg.descSuc,
                        rg.efectivo, rg.efectivoUsu,
                        rg.divisa, rg.divisaUsu,
                        rg.debito, rg.debitoUsu,
                        rg.otros, rg.otrosUsu,
                        rg.cntDivisa, rg.cntDivisaUsu);
                    _lst.Add(nrd);
                }
                _lista.setData(_lst);
                switch (_modoAct)
                {
                    case enumerados.EnumModo.SegunSist:
                        _lista.setModoSistema();
                        break;
                    case enumerados.EnumModo.SegunUsu:
                        _lista.setModoUsuario();
                        break;
                    case enumerados.EnumModo.Ambos:
                        _lista.setModoAmbos();
                        break;
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return;
            }
        }


        private bool CargarData()
        {
            return true;
        }


        public void Reportes()
        {
            if (_lista.GetLista.Count > 0)
            {
                var _gestRep = new Reportes.Analisis.PorMetodosPago.Gestion();
                _gestRep.setData(_lista.GetLista);
                _gestRep.setFiltros("Desde La Fecha: " + _desde.ToShortDateString() + ", Hasta La Fecha: " + _hasta.ToShortDateString());
                _gestRep.Generar();
            }
        }
    }
}
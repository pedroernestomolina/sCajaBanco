using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCajaBanco.src.Analisis.PorMetPago
{
    public class data
    {
        private bool _estatus;
        private string _idSuc;
        private string _codSuc;
        private string _desSuc;
        private decimal _ef_sist;
        private decimal _ef_usu;
        private decimal _div_sist;
        private decimal _div_usu;
        private decimal _tj_sist;
        private decimal _tj_usu;
        private decimal _ot_sist;
        private decimal _ot_usu;
        private decimal _cntDiv_sist;
        private decimal _cntDiv_usu;
        //
        private decimal _ef;
        private decimal _div;
        private decimal _tj;
        private decimal _ot;
        private decimal _cntDiv;
        private decimal _tasaPromedio;
        //
        private decimal _efUsu;
        private decimal _divUsu;
        private decimal _tjUsu;
        private decimal _otUsu;
        private decimal _cntDivUsu;


        public bool isChecked { get { return _estatus; } }
        public string IdSuc { get { return _idSuc; } }
        public string CodigoSuc { get { return _codSuc; } }
        public string DescSuc { get { return _desSuc; } }
        public decimal Ef_Sist { get { return _ef_sist ; } }
        public decimal Ef_Usu { get { return _ef_usu; } }
        public decimal Div_Sist { get { return _div_sist; } }
        public decimal Div_Usu { get { return _div_usu; } }
        public decimal Tj_Sist { get { return _tj_sist; } }
        public decimal Tj_Usu { get { return _tj_usu; } }
        public decimal Ot_Sist { get { return _ot_sist; } }
        public decimal Ot_Usu { get { return _ot_usu; } }
        public decimal CntDiv_Sist { get { return _cntDiv_sist; } }
        public decimal CntDiv_Usu { get { return _cntDiv_usu; } }
        //
        public string Descripcion { get { return _desSuc; } }
        public decimal Efectivo { get { return _ef; } }
        public decimal Divisa { get { return _div; } }
        public decimal Tarjeta { get { return _tj; } }
        public decimal Otro { get { return _ot; } }
        public decimal CntDivisa { get { return _cntDiv; } }
        public decimal TotBs { get { return _ef + _tj + _div; } }
        public decimal SumaBs { get { return _ef + _tj; } }
        public decimal TasaPromedio  {get {return _tasaPromedio;}}
        public decimal TotDiv
        {
            get
            {
                var r = 0m;
                if (_tasaPromedio > 0m)
                {
                    r = (_ef + _tj + _div) / _tasaPromedio;
                }
                return r;
            }
        }
        //
        public decimal EfectivoUsu { get { return _efUsu; } }
        public decimal DivisaUsu { get { return _divUsu; } }
        public decimal TarjetaUsu { get { return _tjUsu; } }
        public decimal OtroUsu { get { return _otUsu; } }
        public decimal CntDivisaUsu { get { return _cntDivUsu; } }
        //
        public decimal DifBs { get { return (_ef + _div + _tj) - (_efUsu + _divUsu + _tjUsu); } }


        public data(string idSuc, string codigoSuc, string descSuc, 
            decimal efSist, decimal efUsu, 
            decimal divSist, decimal divUsu,
            decimal tjSist, decimal tjUsu,
            decimal otSist, decimal otUsu,
            decimal cntDivSist, decimal cntDivUsu)
        {
            _estatus = true;
            _idSuc = idSuc;
            _codSuc = codigoSuc;
            _desSuc=descSuc;
            _ef_sist = efSist;
            _ef_usu = efUsu;
            _div_sist = divSist;
            _div_usu = divUsu;
            _tj_sist = tjSist;
            _tj_usu = tjUsu;
            _ot_sist = otSist;
            _ot_usu = otUsu;
            _cntDiv_sist = cntDivSist;
            _cntDiv_usu = cntDivUsu;
        }

        public void setModoUsuario()
        {
            _ef = _ef_usu;
            _div = _div_usu;
            _tj = _tj_usu;
            _ot = _ot_usu;
            _cntDiv = _cntDiv_usu;
            CalculaTasaPromedio();
        }
        public void setModoSistema()
        {
            _ef = _ef_sist;
            _div = _div_sist;
            _tj = _tj_sist;
            _ot = _ot_sist;
            _cntDiv = _cntDiv_sist;
            CalculaTasaPromedio();
        }
        public void setModoAmbos()
        {
            _ef = _ef_sist;
            _div = _div_sist;
            _tj = _tj_sist;
            _ot = _ot_sist;
            _cntDiv = _cntDiv_sist;
            //
            _efUsu = _ef_usu;
            _divUsu = _div_usu;
            _tjUsu = _tj_usu;
            _otUsu = _ot_usu;
            _cntDivUsu = _cntDiv_usu;
        }

        public void InactivarItem()
        {
            _estatus = false;
            _ef = 0m;
            _div = 0m;
            _tj = 0m;
            _ot = 0m;
            _cntDiv = 0m;
            //
            _efUsu = 0m;
            _divUsu = 0m;
            _tjUsu = 0m;
            _otUsu = 0m;
            _cntDivUsu = 0m;
            //
            CalculaTasaPromedio();
        }
        public void ActivarItemModoSist()
        {
            _estatus = true;
            setModoSistema();
        }
        public void ActivarItemModoUsu()
        {
            _estatus = true;
            setModoUsuario();
        }
        public void ActivarItemModoAmbos()
        {
            _estatus = true;
            setModoAmbos();
        }


        private void CalculaTasaPromedio()
        {
            _tasaPromedio = 0m;
            if (_cntDiv > 0m)
            {
                _tasaPromedio = _div / _cntDiv;
            }
            _tasaPromedio = Math.Round(_tasaPromedio, 4, MidpointRounding.AwayFromZero);
        }
    }
}
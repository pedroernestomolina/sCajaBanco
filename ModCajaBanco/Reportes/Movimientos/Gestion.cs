using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCajaBanco.Reportes.Movimientos
{

    public class Gestion
    {

        private BindingSource bs_Sucursal;
        private BindingSource bs_Deposito;
        private List<OOB.LibCajaBanco.Sucursal.Ficha> lSucursal;
        private List<OOB.LibCajaBanco.Deposito.Ficha> lDeposito;
        private bool _validarPorSucursal;
        private bool _validarPorDeposito;


        public BindingSource _bsSucursal { get { return bs_Sucursal; } }
        public BindingSource _bsDeposito { get { return bs_Deposito; } }


        public string autoSucursal { get; set; }
        public string autoDeposito { get; set; }
        public DateTime desdeFecha { get; set; }
        public DateTime hastaFecha { get; set; }
        public int desdeNumero { get; set; }
        public int hastaNumero { get; set; }
        public bool IsFiltroOk { get; set; }
        public bool HabilitarSucursal { get; set; }
        public bool HabilitarDeposito { get; set; }
        public bool HabilitarDesdeNumero { get; set; }
        public bool HabilitarHastaNumero { get; set; }
        public bool HabilitarDesdeFecha { get; set; }
        public bool HabilitarHastaFecha { get; set; }


        public Gestion()
        {
            Limpiar();
            lSucursal = new List<OOB.LibCajaBanco.Sucursal.Ficha>();
            bs_Sucursal = new BindingSource();
            bs_Sucursal.DataSource = lSucursal;

            lDeposito= new List<OOB.LibCajaBanco.Deposito.Ficha>();
            bs_Deposito= new BindingSource();
            bs_Deposito.DataSource = lDeposito;
        }


        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                var frm = new FiltroFrm ();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private void Limpiar()
        {
            IsFiltroOk = false;
            autoSucursal = "";
            autoDeposito = "";
            desdeFecha = DateTime.Now.Date;
            hastaFecha = DateTime.Now.Date;
            desdeNumero = 1;
            hastaNumero = 1;
        }

        private bool CargarData()
        {
            var rt = true;

            var rt1 = Sistema.MyData.Sucursal_GetLista();
            if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return false;
            }
            lSucursal.Clear();
            lSucursal.AddRange(rt1.Lista.OrderBy(o=>o.nombre).ToList());

            var rt2 = Sistema.MyData.Deposito_GetLista ();
            if (rt2.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt2.Mensaje);
                return false;
            }
            lDeposito.Clear();
            lDeposito.AddRange(rt2.Lista.OrderBy(o=>o.nombre).ToList());

            return rt;
        }

        public void Procesar()
        {
            if (hastaNumero < desdeNumero) 
            {
                Helpers.Msg.Error("Desde - Hasta , Incorrecto");
                IsFiltroOk = false;
                return;
            }

            if (hastaFecha < desdeFecha)
            {
                Helpers.Msg.Error("Desde - Hasta , Incorrecto");
                IsFiltroOk = false;
                return;
            }

            if (_validarPorSucursal) 
            {
                if (autoSucursal == "") 
                {
                    Helpers.Msg.Error("Sucursal No Definida");
                    IsFiltroOk = false;
                    return;
                }
            }

            if (_validarPorDeposito)
            {
                if (autoDeposito == "")
                {
                    Helpers.Msg.Error("Deposito No Definido");
                    IsFiltroOk = false;
                    return;
                }
            }

            IsFiltroOk = true;
        }

        public void LimpiarSucursal()
        {
            autoSucursal = "";
            autoDeposito = "";
        }


        public void setHabilitarSucursal(bool p)
        {
            HabilitarSucursal = p;
        }

        public void setHabilitarDeposito(bool p)
        {
            HabilitarDeposito = p;
        }

        public void setHabilitarPorNumeroCierre (bool p)
        {
            HabilitarDesdeNumero = p;
            HabilitarHastaNumero = p;
        }

        public void setHabilitarPorFecha(bool p)
        {
            HabilitarDesdeFecha= p;
            HabilitarHastaFecha = p;
        }

        public void setDesdeNumero(decimal p)
        {
            desdeNumero = (int)p;
        }

        public void setHastaNumero(decimal p)
        {
            hastaNumero = (int)p;
        }

        public void setValidarPorSucursal(bool p)
        {
            _validarPorSucursal = p;
        }

        public void Inicializa()
        {
            _validarPorSucursal =false;
            _validarPorDeposito = false;
        }

        public void setValidarDeposito(bool p)
        {
            _validarPorDeposito = p;
        }

    }

}
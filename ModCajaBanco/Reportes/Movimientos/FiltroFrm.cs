using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCajaBanco.Reportes.Movimientos
{

    public partial class FiltroFrm : Form
    {

        private Gestion _controlador;

        public FiltroFrm()
        {
            InitializeComponent();
        }

        private void FiltroFrm_Load(object sender, EventArgs e)
        {
            Inicializar();
            CB_SUCURSAL.Enabled = _controlador.HabilitarSucursal;
            CB_DEPOSITO.Enabled = _controlador.HabilitarDeposito;

            desdeNumero.Enabled = _controlador.HabilitarDesdeNumero;
            hastaNumero.Enabled = _controlador.HabilitarHastaNumero;

            DTP_DESDE.Enabled = _controlador.HabilitarDesdeFecha;
            DTP_HASTA.Enabled = _controlador.HabilitarHastaFecha;
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void Inicializar()
        {
            CB_SUCURSAL.DisplayMember = "Nombre";
            CB_SUCURSAL.ValueMember = "auto";
            CB_SUCURSAL.DataSource = _controlador._bsSucursal;

            CB_DEPOSITO.DisplayMember = "Nombre";
            CB_DEPOSITO.ValueMember = "auto";
            CB_DEPOSITO.DataSource = _controlador._bsDeposito;
        }

        private void CB_SUCURSAL_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.autoSucursal = "";
            if (CB_SUCURSAL.SelectedIndex != -1)
            {
                _controlador.autoSucursal = CB_SUCURSAL.SelectedValue.ToString();
            }
        }

        private void CB_DEPOSITO_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controlador.autoDeposito = "";
            if (CB_DEPOSITO.SelectedIndex != -1)
            {
                _controlador.autoDeposito = CB_DEPOSITO.SelectedValue.ToString();
            }
        }

        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            _controlador.desdeFecha = DTP_DESDE.Value.Date;
        }

        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            _controlador.hastaFecha = DTP_HASTA.Value.Date;
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            ProcesarReporte();
        }

        private void ProcesarReporte()
        {
            _controlador.Procesar();
            if (_controlador.IsFiltroOk)
                Salir();
        }

        private void L_SUCURSAL_Click(object sender, EventArgs e)
        {
            LimpiarSucursal();
        }

        private void LimpiarSucursal()
        {
            _controlador.LimpiarSucursal();
            CB_SUCURSAL.SelectedIndex = -1;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void desdeNumero_Leave(object sender, EventArgs e)
        {
            _controlador.setDesdeNumero(desdeNumero.Value);
        }

        private void hastaNumero_Leave(object sender, EventArgs e)
        {
            _controlador.setHastaNumero(hastaNumero.Value);
        }

    }

}
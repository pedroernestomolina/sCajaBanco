using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCajaBanco.Reportes.Analisis
{

    public partial class FiltrarFrm : Form
    {


        private Gestion _controlador;


        public FiltrarFrm()
        {
            InitializeComponent();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }

        private void BT_PROCESAR_Click(object sender, EventArgs e)
        {
            Procesar();
        }

        private void Procesar()
        {
            _controlador.Procesar();
        }

        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            _controlador.setFechaDesde(DTP_DESDE.Value);
        }

        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            _controlador.setFechaHasta(DTP_HASTA.Value);
        }

        private void FiltrarFrm_Load(object sender, EventArgs e)
        {
            DTP_DESDE.Value = _controlador.DesdeFecha;
            DTP_HASTA.Value=_controlador.HastaFecha;
        }

        public void Cerrar()
        {
            Salir();
        }

    }

}
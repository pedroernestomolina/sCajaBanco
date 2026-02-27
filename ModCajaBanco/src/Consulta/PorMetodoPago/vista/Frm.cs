using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCajaBanco.src.Consulta.PorMetodoPago.vista
{
    public partial class Frm : Form
    {
        private enum modoMostrar { SegunSistema = 1, SegunUsuario, Ambos };
        private vm.IConsulta _controlador;
        //
        private void InicializaDGV()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);
            var fCab = new Font("Serif", 6, FontStyle.Bold);

            //
            DGV.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            DGV.RowHeadersVisible = false;
            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;
            DGV.ReadOnly = true;


            if (DGV.DataSource == null || DGV.Columns.Count == 0)
                return;

            foreach (DataGridViewColumn col in DGV.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = fCab;

                // Identificamos las columnas numéricas por su nombre (contienen las palabras clave)
                bool esColumnaNumerica = col.HeaderText.Contains("Segun Sistema") ||
                                          col.HeaderText.Contains("Segun Usuario") ||
                                          col.HeaderText.Contains("DIFERENCIA");

                if (esColumnaNumerica)
                {
                    // 1. Alineación a la derecha
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    // 2. Formato de número/moneda (opcional, pero recomendado para montos)
                    // Usaremos "N2" para formato de número con separador de miles y 2 decimales.
                    // Si quieres moneda local, usa "C2".
                    col.DefaultCellStyle.Format = "N2";

                    // 3. Establecer como de solo lectura (aunque ReadOnly = true ya lo hace)
                    col.ReadOnly = true;
                }
                else
                {
                    // Alineación a la izquierda o centro para las columnas de texto (Sucursal)
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    col.MinimumWidth = 200;
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }
        //
        public Frm()
        {
            InitializeComponent();
        }
        public void setControlador(vm.IConsulta ctr)
        {
            _controlador = ctr;
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Get_DataSource;
            DTP_DESDE.Value = _controlador.Get_Desde;
            DTP_HASTA.Value = _controlador.Get_Hasta;
            CHB_MODO_DETALLE.Checked = _controlador.Get_IsModoDetalle;
        }
        private void DTP_DESDE_Leave(object sender, EventArgs e)
        {
            _controlador.setDesde(DTP_DESDE.Value.Date);
        }
        private void DTP_HASTA_Leave(object sender, EventArgs e)
        {
            _controlador.setHasta(DTP_HASTA.Value.Date);
        }
        private void DTP_DESDE_ValueChanged(object sender, EventArgs e)
        {
            _controlador.setDesde(DTP_DESDE.Value.Date);
        }
        private void DTP_HASTA_ValueChanged(object sender, EventArgs e)
        {
            _controlador.setHasta(DTP_HASTA.Value.Date);
        }
        private void RB_USU_CheckedChanged(object sender, EventArgs e)
        {
            modoSolo(modoMostrar.SegunUsuario);
        }
        private void RB_SIST_CheckedChanged(object sender, EventArgs e)
        {
            modoSolo(modoMostrar.SegunSistema);
        }
        private void RB_AMBOS_CheckedChanged(object sender, EventArgs e)
        {
            modoSolo(modoMostrar.Ambos);
        }
        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            _controlador.AccionBuscar();
            //
            DGV.AutoGenerateColumns = true;
            DGV.AllowUserToAddRows = true;
            DGV.AllowUserToDeleteRows = true;
            //
            DGV.DataSource = _controlador.Get_DataSource;
            InicializaDGV();
        }
        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            _controlador.AccionLimpiarConsulta();
            RB_SIST.Checked = false;
            RB_USU.Checked = false;
            RB_AMBOS.Checked = false;
            DTP_DESDE.Value = _controlador.Get_Desde;
            DTP_HASTA.Value = _controlador.Get_Hasta;
            DGV.Refresh();
        }
        private void BT_REPORTE_Click(object sender, EventArgs e)
        {
            Reportes();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //
        private void Reportes()
        {
            _controlador.AccionReporteExportar();
        }
        private void modoSolo(modoMostrar modo) 
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);
            var fCab = new Font("Serif", 6, FontStyle.Bold);

            if (DGV.DataSource == null || DGV.Columns.Count == 0)
                return;

            foreach (DataGridViewColumn col in DGV.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = fCab;

                // Identificamos las columnas numéricas por su nombre (contienen las palabras clave)
                bool esColumnaNumerica = col.HeaderText.Contains("Segun Sistema") ||
                                          col.HeaderText.Contains("Segun Usuario") ||
                                          col.HeaderText.Contains("DIFERENCIA");
                bool esVisible = false;
                switch (modo) 
                {
                    case modoMostrar.SegunSistema:
                        esVisible = col.HeaderText.Contains("Segun Sistema");
                        break;
                    case modoMostrar.SegunUsuario:
                        esVisible = col.HeaderText.Contains("Segun Usuario");
                        break;
                    default: 
                        esVisible = true;
                        break;
                }

                if (esColumnaNumerica)
                {
                    // 1. Alineación a la derecha
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    // 2. Formato de número/moneda (opcional, pero recomendado para montos)
                    // Usaremos "N2" para formato de número con separador de miles y 2 decimales.
                    // Si quieres moneda local, usa "C2".
                    col.DefaultCellStyle.Format = "N2";

                    // 3. Establecer como de solo lectura (aunque ReadOnly = true ya lo hace)
                    col.ReadOnly = true;

                    col.Visible = esVisible;
                }
                else
                {
                    // Alineación a la izquierda o centro para las columnas de texto (Sucursal)
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    col.MinimumWidth = 200;
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        private void CHB_MODO_DETALLE_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setIsModoDetalle(CHB_MODO_DETALLE.Checked);
        }
    }
}
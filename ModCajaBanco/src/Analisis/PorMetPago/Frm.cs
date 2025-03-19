using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCajaBanco.src.Analisis.PorMetPago
{
    public partial class Frm : Form
    {
        private IAnalMetPago _controlador;


        public Frm()
        {
            InitializeComponent();
            InicializaDGV();
            InicializaDGV_2();
            InicializaDGV_A1();
        }
        private void InicializaDGV()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

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

            var c1 = new DataGridViewCheckBoxColumn();
            c1.DataPropertyName = "isChecked";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 40;
            c1.ReadOnly = false;
            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Descripcion";
            c2.HeaderText = "Sucursal";
            c2.Visible = true;
            c2.MinimumWidth = 120;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.ReadOnly = true;
            var a1 = new DataGridViewTextBoxColumn();
            a1.DataPropertyName = "TotBs";
            a1.HeaderText = "Tot/(Bs)";
            a1.Visible = true;
            a1.Width = 120;
            a1.HeaderCell.Style.Font = f;
            a1.DefaultCellStyle.Font = f1;
            a1.DefaultCellStyle.Format = "n2";
            a1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var a2 = new DataGridViewTextBoxColumn();
            a2.DataPropertyName = "TotDiv";
            a2.HeaderText = "Tot/($)";
            a2.Visible = true;
            a2.Width = 100;
            a2.HeaderCell.Style.Font = f;
            a2.DefaultCellStyle.Font = f1;
            a2.DefaultCellStyle.Format = "n2";
            a2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Efectivo";
            c3.HeaderText = "Efectivo";
            c3.Visible = true;
            c3.Width = 120;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Format = "n2";
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Divisa";
            c4.HeaderText = "Divisa";
            c4.Visible = true;
            c4.Width = 120;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Format = "n2";
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "CntDivisa";
            c5.HeaderText = "Cnt/($)";
            c5.Visible = true;
            c5.Width = 100;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Format = "n1";
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Tarjeta";
            c6.HeaderText = "Tarjeta";
            c6.Visible = true;
            c6.Width = 120;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Format = "n2";
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "SumaBs";
            c7.HeaderText = "Efec+Tarj";
            c7.Visible = true;
            c7.Width = 120;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Format = "n2";
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var c8 = new DataGridViewTextBoxColumn();
            c8.DataPropertyName = "TasaPromedio";
            c8.HeaderText = "Tasa";
            c8.Visible = true;
            c8.Width = 60;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f;
            c8.DefaultCellStyle.Format = "n4";
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(a1);
            DGV.Columns.Add(a2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c6);
            DGV.Columns.Add(c7);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
            DGV.Columns.Add(c8);
        }
        private void InicializaDGV_2()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 10, FontStyle.Regular);

            DGV_2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            DGV_2.RowHeadersVisible = false;
            DGV_2.AllowUserToAddRows = false;
            DGV_2.AllowUserToDeleteRows = false;
            DGV_2.AutoGenerateColumns = false;
            DGV_2.AllowUserToResizeRows = false;
            DGV_2.AllowUserToResizeColumns = false;
            DGV_2.AllowUserToOrderColumns = false;
            DGV_2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_2.MultiSelect = false;
            DGV_2.ReadOnly = true;

            var c1 = new  DataGridViewTextBoxColumn();
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 40;
            c1.ReadOnly = false;
            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Descripcion";
            c2.HeaderText = "";
            c2.Visible = true;
            c2.MinimumWidth = 120;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.ReadOnly = true;
            var a1 = new DataGridViewTextBoxColumn();
            a1.DataPropertyName = "TotEnBs";
            a1.HeaderText = "Tot/(Bs)";
            a1.Visible = true;
            a1.Width = 120;
            a1.HeaderCell.Style.Font = f;
            a1.DefaultCellStyle.Font = f;
            a1.DefaultCellStyle.Format = "n2";
            a1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var a2 = new DataGridViewTextBoxColumn();
            a2.DataPropertyName = "TotEnDiv";
            a2.HeaderText = "Tot/($)";
            a2.Visible = true;
            a2.Width = 100;
            a2.HeaderCell.Style.Font = f;
            a2.DefaultCellStyle.Font = f1;
            a2.DefaultCellStyle.Format = "n2";
            a2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Efectivo";
            c3.HeaderText = "Efectivo";
            c3.Visible = true;
            c3.Width = 120;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f;
            c3.DefaultCellStyle.Format = "n2";
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Divisa";
            c4.HeaderText = "Divisa";
            c4.Visible = true;
            c4.Width = 120;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f;
            c4.DefaultCellStyle.Format = "n2";
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "CntDivisa";
            c5.HeaderText = "Cnt/($)";
            c5.Visible = true;
            c5.Width = 100;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Format = "n1";
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Tarjeta";
            c6.HeaderText = "Tarjeta";
            c6.Visible = true;
            c6.Width = 120;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f;
            c6.DefaultCellStyle.Format = "n2";
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "SumaBs";
            c7.HeaderText = "Efec+Tarj";
            c7.Visible = true;
            c7.Width = 120;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f;
            c7.DefaultCellStyle.Format = "n2";
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var c8 = new DataGridViewTextBoxColumn();
            c8.Visible = true;
            c8.Width = 60;
            c8.HeaderCell.Style.Font = f;
            c8.DefaultCellStyle.Font = f;
            c8.DefaultCellStyle.Format = "n4";
            c8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            DGV_2.Columns.Add(c1);
            DGV_2.Columns.Add(c2);
            DGV_2.Columns.Add(a1);
            DGV_2.Columns.Add(a2);
            DGV_2.Columns.Add(c3);
            DGV_2.Columns.Add(c6);
            DGV_2.Columns.Add(c7);
            DGV_2.Columns.Add(c4);
            DGV_2.Columns.Add(c5);
            DGV_2.Columns.Add(c8);
        }
        private void InicializaDGV_A1()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);

            DGV_A1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            DGV_A1.RowHeadersVisible = false;
            DGV_A1.AllowUserToAddRows = false;
            DGV_A1.AllowUserToDeleteRows = false;
            DGV_A1.AutoGenerateColumns = false;
            DGV_A1.AllowUserToResizeRows = false;
            DGV_A1.AllowUserToResizeColumns = false;
            DGV_A1.AllowUserToOrderColumns = false;
            DGV_A1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_A1.MultiSelect = false;
            DGV_A1.ReadOnly = true;

            var c1 = new DataGridViewCheckBoxColumn();
            c1.DataPropertyName = "isChecked";
            c1.Visible = true;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.Width = 30;
            c1.ReadOnly = false;
            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Descripcion";
            c2.HeaderText = "Sucursal";
            c2.Visible = true;
            c2.MinimumWidth = 180;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.ReadOnly = true;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Efectivo";
            c3.HeaderText = "Efectivo/Sist";
            c3.Name = "MEfectivo";
            c3.Visible = true;
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Format = "n2";
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var c33 = new DataGridViewTextBoxColumn();
            c33.DataPropertyName = "EfectivoUsu";
            c33.HeaderText = "Efectivo/Usu";
            c33.Name = "MEfectivoUsu";
            c33.Visible = true;
            c33.Width = 100;
            c33.HeaderCell.Style.Font = f;
            c33.DefaultCellStyle.Font = f1;
            c33.DefaultCellStyle.Format = "n2";
            c33.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "Divisa";
            c4.HeaderText = "Divisa/Sist";
            c4.Name = "MDivisa";
            c4.Visible = true;
            c4.Width = 110;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Format = "n2";
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var c44 = new DataGridViewTextBoxColumn();
            c44.DataPropertyName = "DivisaUsu";
            c44.HeaderText = "Divisa/Usu";
            c44.Name = "MDivisaUsu";
            c44.Visible = true;
            c44.Width = 110;
            c44.HeaderCell.Style.Font = f;
            c44.DefaultCellStyle.Font = f1;
            c44.DefaultCellStyle.Format = "n2";
            c44.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "CntDivisa";
            c5.HeaderText = "Cnt($)/Sist";
            c5.Name = "CntDivisa";
            c5.Visible = true;
            c5.Width = 80;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Format = "n1";
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var c55 = new DataGridViewTextBoxColumn();
            c55.DataPropertyName = "CntDivisaUsu";
            c55.HeaderText = "Cnt($)/Usu";
            c55.Name = "CntDivisaUsu";
            c55.Visible = true;
            c55.Width = 80;
            c55.HeaderCell.Style.Font = f;
            c55.DefaultCellStyle.Font = f1;
            c55.DefaultCellStyle.Format = "n1";
            c55.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            var c6 = new DataGridViewTextBoxColumn();
            c6.DataPropertyName = "Tarjeta";
            c6.HeaderText = "Tarjeta/Sist";
            c6.Name = "MTarjeta";
            c6.Visible = true;
            c6.Width = 110;
            c6.HeaderCell.Style.Font = f;
            c6.DefaultCellStyle.Font = f1;
            c6.DefaultCellStyle.Format = "n2";
            c6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var c66 = new DataGridViewTextBoxColumn();
            c66.DataPropertyName = "TarjetaUsu";
            c66.HeaderText = "Tarjeta/Usu";
            c66.Name = "MTarjetaUsu";
            c66.Visible = true;
            c66.Width = 110;
            c66.HeaderCell.Style.Font = f;
            c66.DefaultCellStyle.Font = f1;
            c66.DefaultCellStyle.Format = "n2";
            c66.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            var c7 = new DataGridViewTextBoxColumn();
            c7.DataPropertyName = "DifBs";
            c7.HeaderText = "DifBs";
            c7.Visible = true;
            c7.Width = 70;
            c7.HeaderCell.Style.Font = f;
            c7.DefaultCellStyle.Font = f1;
            c7.DefaultCellStyle.Format = "n2";
            c7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            DGV_A1.Columns.Add(c1);
            DGV_A1.Columns.Add(c2);
            DGV_A1.Columns.Add(c3);
            DGV_A1.Columns.Add(c33);
            DGV_A1.Columns.Add(c6);
            DGV_A1.Columns.Add(c66);
            DGV_A1.Columns.Add(c4);
            DGV_A1.Columns.Add(c44);
            DGV_A1.Columns.Add(c5);
            DGV_A1.Columns.Add(c55);
            DGV_A1.Columns.Add(c7);
        }


        public void setControlador(IAnalMetPago ctr)
        {
            _controlador = ctr;
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Data_GetSource;
            DGV_2.DataSource = _controlador.Totales_GetSource;
            DGV_A1.DataSource = _controlador.Data_GetSource;
            DTP_DESDE.Value = _controlador.GetFecha_Desde;
            DTP_HASTA.Value = _controlador.GetFecha_Hasta;
            switch (_controlador.ModoActivo) 
            {
                case enumerados.EnumModo.SegunSist:
                    RB_SIST.Checked=true;
                    break;
                case enumerados.EnumModo.SegunUsu:
                    RB_USU.Checked = true;
                    break;
                case enumerados.EnumModo.Ambos:
                    RB_AMBOS.Checked = true;
                    break;
            }
        }
        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex != -1)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)DGV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                bool isChecked = (bool)checkCell.Value;
                _controlador.setSucursalEstatus(isChecked);
                DGV.Refresh();
                DGV_2.Refresh();
            }
        }
        private void DGV_A1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGV_A1.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn && e.RowIndex != -1)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)DGV_A1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                bool isChecked = (bool)checkCell.Value;
                _controlador.setSucursalEstatus(isChecked);
                DGV_A1.Refresh();
            }
        }
        private void DGV_A1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == DGV_A1.Columns["MEfectivoUsu"].Index)
            {
                decimal efectivo1 = Convert.ToDecimal(DGV_A1.Rows[e.RowIndex].Cells["MEfectivo"].Value);
                decimal efectivo2 = Convert.ToDecimal(DGV_A1.Rows[e.RowIndex].Cells["MEfectivoUsu"].Value);
                if (efectivo1 == efectivo2)
                {
                    e.CellStyle.BackColor = Color.Green;
                    e.CellStyle.ForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
            if (e.ColumnIndex == DGV_A1.Columns["MTarjetaUsu"].Index)
            {
                decimal efectivo1 = Convert.ToDecimal(DGV_A1.Rows[e.RowIndex].Cells["MTarjeta"].Value);
                decimal efectivo2 = Convert.ToDecimal(DGV_A1.Rows[e.RowIndex].Cells["MTarjetaUsu"].Value);
                if (efectivo1 == efectivo2)
                {
                    e.CellStyle.BackColor = Color.Green;
                    e.CellStyle.ForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
            if (e.ColumnIndex == DGV_A1.Columns["MDivisaUsu"].Index)
            {
                decimal efectivo1 = Convert.ToDecimal(DGV_A1.Rows[e.RowIndex].Cells["MDivisa"].Value);
                decimal efectivo2 = Convert.ToDecimal(DGV_A1.Rows[e.RowIndex].Cells["MDivisaUsu"].Value);
                if (efectivo1 == efectivo2)
                {
                    e.CellStyle.BackColor = Color.Green;
                    e.CellStyle.ForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
            if (e.ColumnIndex == DGV_A1.Columns["CntDivisaUsu"].Index)
            {
                decimal efectivo1 = Convert.ToDecimal(DGV_A1.Rows[e.RowIndex].Cells["CntDivisa"].Value);
                decimal efectivo2 = Convert.ToDecimal(DGV_A1.Rows[e.RowIndex].Cells["CntDivisaUsu"].Value);
                if (efectivo1 == efectivo2)
                {
                    e.CellStyle.BackColor = Color.Green;
                    e.CellStyle.ForeColor = Color.White;
                }
                else
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }


        private void DTP_DESDE_Leave(object sender, EventArgs e)
        {
            _controlador.setFechaDesde(DTP_DESDE.Value.Date);
        }
        private void DTP_HASTA_Leave(object sender, EventArgs e)
        {
            _controlador.setFechaHasta(DTP_HASTA.Value.Date);
        }

        private void RB_USU_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setModoUsuario();
            DGV.Visible = true;
            DGV_2.Visible = true;
            DGV_A1.Visible = false;
            DGV.Refresh();
            DGV_2.Refresh();
        }
        private void RB_SIST_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setModoSistema();
            DGV.Visible = true;
            DGV_2.Visible = true;
            DGV_A1.Visible = false;
            DGV.Refresh();
            DGV_2.Refresh();
        }
        private void RB_AMBOS_CheckedChanged(object sender, EventArgs e)
        {
            _controlador.setModoAmbos();
            DGV.Visible = false;
            DGV_2.Visible = false;
            DGV_A1.Visible = true;
            DGV_A1.Refresh();
        }

        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            _controlador.ActivarBusqueda();
            DGV.Refresh();
            DGV_2.Refresh();
            DGV_A1.Refresh();
        }
        private void BT_LIMPIAR_Click(object sender, EventArgs e)
        {
            _controlador.Limpiar();
            DTP_DESDE.Value = _controlador.GetFecha_Desde;
            DTP_HASTA.Value = _controlador.GetFecha_Hasta;
            DGV.Visible = true;
            DGV_2.Visible = true;
            DGV_A1.Visible = false;
            DGV.Refresh();
            DGV_2.Refresh();
            switch (_controlador.ModoActivo)
            {
                case enumerados.EnumModo.SegunSist:
                    RB_SIST.Checked = true;
                    break;
                case enumerados.EnumModo.SegunUsu:
                    RB_USU.Checked = true;
                    break;
            }
        }
        private void BT_REPORTE_Click(object sender, EventArgs e)
        {
            Reportes();
        }
        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Reportes()
        {
            _controlador.Reportes();
        }
    }
}
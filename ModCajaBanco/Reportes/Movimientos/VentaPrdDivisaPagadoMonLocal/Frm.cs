using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModCajaBanco.Reportes.Movimientos.VentaPrdDivisaPagadoMonLocal
{
    public partial class Frm : Form
    {
        public Frm()
        {
            InitializeComponent();
            InicializaGrid();
            InicializaGrid_DT();
            InicializaGrid_MP();
        }
        private void InicializaGrid()
        {
            var f = new Font("Serif", 7, FontStyle.Bold);
            var f1 = new Font("Serif", 7, FontStyle.Regular);
            //
            DGV_1.AllowUserToAddRows = false;
            DGV_1.AllowUserToDeleteRows = false;
            DGV_1.AutoGenerateColumns = false;
            DGV_1.AllowUserToResizeRows = false;
            DGV_1.AllowUserToResizeColumns = false;
            DGV_1.AllowUserToOrderColumns = false;
            DGV_1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_1.MultiSelect = false;
            DGV_1.ReadOnly = true;
            DGV_1.RowHeadersVisible = false;
            //
            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "FechaEmision";
            c1.HeaderText = "Fecha";
            c1.Visible = true;
            c1.Width = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "DocNumero";
            c3.HeaderText = "Documento";
            c3.Visible = true;
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "EntidadNombre";
            c2.HeaderText = "Entidad";
            c2.Visible = true;
            c2.MinimumWidth = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "EntidadCiRif";
            c4.HeaderText = "CiRif";
            c4.Visible = true;
            c4.Width = 100;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //
            var c5 = new DataGridViewTextBoxColumn();
            c5.DataPropertyName = "MontoDivisa";
            c5.HeaderText = "Importe($)";
            c5.Visible = true;
            c5.Width = 100;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            DGV_1.Columns.Add(c1);
            DGV_1.Columns.Add(c3);
            DGV_1.Columns.Add(c2);
            DGV_1.Columns.Add(c4);
            DGV_1.Columns.Add(c5);
        }
        private void InicializaGrid_DT()
        {
            var f = new Font("Serif", 7, FontStyle.Bold);
            var f1 = new Font("Serif", 7, FontStyle.Regular);
            //
            DGV_2.AllowUserToAddRows = false;
            DGV_2.AllowUserToDeleteRows = false;
            DGV_2.AutoGenerateColumns = false;
            DGV_2.AllowUserToResizeRows = false;
            DGV_2.AllowUserToResizeColumns = false;
            DGV_2.AllowUserToOrderColumns = false;
            DGV_2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_2.MultiSelect = false;
            DGV_2.ReadOnly = true;
            DGV_2.RowHeadersVisible = false;
            //
            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "Producto";
            c1.HeaderText = "Descripcion";
            c1.Visible = true;
            c1.MinimumWidth = 150;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "Cantidad";
            c3.HeaderText = "Cnt";
            c3.Visible = true;
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format= "n2";
            //
            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "Empq";
            c2.HeaderText = "Empaque";
            c2.Visible = true;
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "EmpqCont";
            c4.HeaderText = "Cont";
            c4.Visible = true;
            c4.Width = 100;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Format = "n1";
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            var c5 = new DataGridViewCheckBoxColumn(); 
            c5.DataPropertyName = "IsPrdDivisa";
            c5.HeaderText = "Divisa";
            c5.Visible = true;
            c5.Width = 60;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            DGV_2.Columns.Add(c1);
            DGV_2.Columns.Add(c3);
            DGV_2.Columns.Add(c2);
            DGV_2.Columns.Add(c4);
            DGV_2.Columns.Add(c5);
        }
        private void InicializaGrid_MP()
        {
            var f = new Font("Serif", 7, FontStyle.Bold);
            var f1 = new Font("Serif", 7, FontStyle.Regular);
            //
            DGV_3.AllowUserToAddRows = false;
            DGV_3.AllowUserToDeleteRows = false;
            DGV_3.AutoGenerateColumns = false;
            DGV_3.AllowUserToResizeRows = false;
            DGV_3.AllowUserToResizeColumns = false;
            DGV_3.AllowUserToOrderColumns = false;
            DGV_3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV_3.MultiSelect = false;
            DGV_3.ReadOnly = true;
            DGV_3.RowHeadersVisible = false;
            //
            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "MedioPago";
            c1.HeaderText = "Medio Pago";
            c1.Visible = true;
            c1.MinimumWidth = 100;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            c1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //
            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "CodigoMon";
            c3.HeaderText = "Moneda";
            c3.Visible = true;
            c3.Width = 100;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "MontoMonRecibe";
            c2.HeaderText = "Monto Recibe";
            c2.Visible = true;
            c2.Width = 100;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.DefaultCellStyle.Format = "n2";
            c2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "MontoMonRecibeMonRef";
            c4.HeaderText = "$";
            c4.Visible = true;
            c4.Width = 100;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.DefaultCellStyle.Format = "n2";
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            DGV_3.Columns.Add(c1);
            DGV_3.Columns.Add(c3);
            DGV_3.Columns.Add(c2);
            DGV_3.Columns.Add(c4);
        }

        public void setData(dsMovimiento ds)
        {
            // 2. Configurar el enlace Maestro
            BindingSource masterBS = new BindingSource();
            masterBS.DataSource = ds;
            masterBS.DataMember = "VentaPrdDivisaPagadoMonLocal";
            DGV_1.DataSource = masterBS;

            // 3. Configurar el enlace Detalle usando la RELACIÓN
            BindingSource detailsBS = new BindingSource();
            detailsBS.DataSource = masterBS; // Se enlaza al BindingSource maestro
            detailsBS.DataMember = "VentaPrdDivisaPagadoMonLocal_VentaPrdDivisaPagMonLocal_Detalle"; // Nombre exacto de la relación en el DataSet
            DGV_2.DataSource = detailsBS;

            // 3. Configurar el enlace Detalle usando la RELACIÓN
            BindingSource detailsMP = new BindingSource();
            detailsMP.DataSource = masterBS; // Se enlaza al BindingSource maestro
            detailsMP.DataMember = "Rel_VentaPrdDivisaPagadoMonLocal_MP"; // Nombre exacto de la relación en el DataSet
            DGV_3.DataSource = detailsMP;
        }
        private void Frm_Load(object sender, EventArgs e)
        {
        }
    }
}

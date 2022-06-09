using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCajaBanco.Habladores
{

    public partial class HabladoresFrm : Form
    {


        private Gestion _controlador; 


        public HabladoresFrm()
        {
            InitializeComponent();
            InicializarGrid();
        }

        private void InicializarGrid()
        {
            var f = new Font("Serif", 8, FontStyle.Bold);
            var f1 = new Font("Serif", 8, FontStyle.Regular);

            DGV.AllowUserToAddRows = false;
            DGV.AllowUserToDeleteRows = false;
            DGV.AutoGenerateColumns = false;
            DGV.AllowUserToResizeRows = false;
            DGV.AllowUserToResizeColumns = false;
            DGV.AllowUserToOrderColumns = false;
            DGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGV.MultiSelect = false;
            DGV.ReadOnly = false;

            var c1 = new DataGridViewTextBoxColumn();
            c1.DataPropertyName = "CodigoPrd";
            c1.HeaderText = "Codigo";
            c1.Visible = true;
            c1.Width = 110;
            c1.HeaderCell.Style.Font = f;
            c1.DefaultCellStyle.Font = f1;
            c1.ReadOnly = true;

            var c2 = new DataGridViewTextBoxColumn();
            c2.DataPropertyName = "NombrePrd";
            c2.HeaderText = "Descripcion";
            c2.Visible = true;
            c2.MinimumWidth = 200;
            c2.HeaderCell.Style.Font = f;
            c2.DefaultCellStyle.Font = f1;
            c2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            c2.ReadOnly = true;

            var c3 = new DataGridViewTextBoxColumn();
            c3.DataPropertyName = "PrecioFull";
            c3.HeaderText = "Precio";
            c3.Visible = true;
            c3.Width = 90;
            c3.HeaderCell.Style.Font = f;
            c3.DefaultCellStyle.Font = f1;
            c3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c3.DefaultCellStyle.Format = "n2";
            c3.ReadOnly = true;

            var c4 = new DataGridViewTextBoxColumn();
            c4.DataPropertyName = "DivisaFull";
            c4.HeaderText = "Divisa";
            c4.Visible = true;
            c4.HeaderCell.Style.Font = f;
            c4.DefaultCellStyle.Font = f1;
            c4.Width = 90;
            c4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c4.DefaultCellStyle.Format="n2" ;
            c4.ReadOnly = true;

            var c5 = new DataGridViewCheckBoxColumn();
            c5.DataPropertyName = "Imprimir";
            c5.HeaderText = "Imprime";
            c5.Visible = true;
            c5.HeaderCell.Style.Font = f;
            c5.DefaultCellStyle.Font = f1;
            c5.Width = 60;
            c5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            c5.ReadOnly=false;

            DGV.Columns.Add(c1);
            DGV.Columns.Add(c2);
            DGV.Columns.Add(c3);
            DGV.Columns.Add(c4);
            DGV.Columns.Add(c5);
        }


        private void BT_BUSCAR_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            _controlador.Buscar();
            Actualizar();
        }

        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void HabladoresFrm_Load(object sender, EventArgs e)
        {
            DGV.DataSource = _controlador.Source;
            Actualizar();
        }

        private void Actualizar()
        {
            L_ITEMS.Text = "Items Encontrados: " + _controlador.TItems.ToString("n0");
        }

        private void BT_LIMPIAR_DATA_Click(object sender, EventArgs e)
        {
            LimpiarData();
        }

        private void LimpiarData()
        {
            _controlador.LimpiarData();
            Actualizar();
        }

        private void BT_ANULAR_Click(object sender, EventArgs e)
        {
            EliminarItem();
        }

        private void EliminarItem()
        {
            _controlador.EliminarItem();
            Actualizar();
        }

        private void BT_IMPRIMIR_Click(object sender, EventArgs e)
        {
            ImprimirHablador();
        }

        private void ImprimirHablador()
        {
            _controlador.ImprimirHablador();
        }

        private void BT_MARCAR_TODOS_Click(object sender, EventArgs e)
        {
            MarcarTodos();
        }

        private void MarcarTodos()
        {
            _controlador.MarcarTodos();
        }

        private void BT_DESMARCAR_TODOS_Click(object sender, EventArgs e)
        {
            DesMarcarTodos();
        }

        private void DesMarcarTodos()
        {
            _controlador.DesMarcarTodos();
        }

    }

}
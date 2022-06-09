using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCajaBanco
{

    public partial class Form1 : Form
    {

        private Gestion _controlador;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            L_VERSION.Text = _controlador.Version;
            L_HOST.Text = _controlador.Host;
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            this.Close();
        }


        public void setControlador(Gestion ctr)
        {
            _controlador = ctr;
        }

        private void TSM_REPORTES_ArqueoCajaPos_Click(object sender, EventArgs e)
        {
            ArqueoCajaPos();
        }

        private void ArqueoCajaPos()
        {
            _controlador.ArqueoCajaPos();
        }

        private void TSM_REPORTES_INVENTARIO_RESUMEN_Click(object sender, EventArgs e)
        {
            ReporteResumenInventario();
        }

        private void ReporteResumenInventario()
        {
            _controlador.ReporteResumenInventario();
        }

        private void TSM_REPORTES_VENTA_RESUMEN_Click(object sender, EventArgs e)
        {
            ReporteResumenVenta();
        }

        private void ReporteResumenVenta()
        {
            _controlador.ReporteResumenVenta();
        }

        private void TSM_REPORTES_HABLADORES_Click(object sender, EventArgs e)
        {
            ReporteHabladores();
        }

        private void ReporteHabladores()
        {
            _controlador.ReporteHabladores();
        }

        private void TSM_REPORTES_VENTA_DETALLE_Click(object sender, EventArgs e)
        {
            ReporteResumenVentaDetalle();
        }

        private void ReporteResumenVentaDetalle()
        {
            _controlador.ReporteResumenVentaDetalle();
        }

        private void TSM_REPORTES_VENTA_POR_PRODUCTO_Click(object sender, EventArgs e)
        {
            ReporteResumenVentaporProducto();
        }

        private void ReporteResumenVentaporProducto()
        {
            _controlador.ReporteResumenVentaporProducto();
        }

        private void TSM_REPORTES_RESUMEN_VENTA_SUCURSAL_Click(object sender, EventArgs e)
        {
            ReporteResumenVentaSucursal();
        }

        private void ReporteResumenVentaSucursal()
        {
            _controlador.ReporteResumenVentaSucursal();
        }

        private void TSM_REPORTES_VENTA_POR_PRODUCTO_SUCURSAL_Click(object sender, EventArgs e)
        {
            ReporteResumenVentaProductoSucursal();
        }

        private void ReporteResumenVentaProductoSucursal()
        {
            _controlador.ReporteResumenVentaProductoSucursal();
        }

        private void TSM_REPORTES_CobranzaDiaria_Click(object sender, EventArgs e)
        {
            CobranzaDiaria();
        }

        private void CobranzaDiaria()
        {
            _controlador.CobranzaDiaria();
        }

        private void TSM_REPORTES_RESUMEN_VENTA_DIARIO_SUCURSAL_Click(object sender, EventArgs e)
        {
            ReporteResumenVentaDiarioSucursal();
        }

        private void ReporteResumenVentaDiarioSucursal()
        {
            _controlador.ReporteResumenVentaDiarioSucursal();
        }

        private void TSM_REPORTES_CobranzaDiaria_CIERRE_Click(object sender, EventArgs e)
        {
            CobranzaDiariaPorCierre();
        }

        private void CobranzaDiariaPorCierre()
        {
            _controlador.CobranzaDiariaPorCierre();
        }

        private void TSM_ANALISIS_Ventas_PROMEDIO_Click(object sender, EventArgs e)
        {
            AnalisisVentasPromedio();
        }

        private void AnalisisVentasPromedio()
        {
            _controlador.AnalisisVentasPromedio();
        }

        private void TSM_ANALISIS_Ventas_PRODUCTO_Click(object sender, EventArgs e)
        {
            AnalisisVentasProducto();
        }

        private void AnalisisVentasProducto()
        {
            _controlador.AnalisisVentasProducto();
        }

        private void TSM_REPORTES_VENTA_RESUMEN_SALTO_FACT_Click(object sender, EventArgs e)
        {
            ReporteResumenVentaSaltoFactura();
        }

        private void ReporteResumenVentaSaltoFactura()
        {
            _controlador.ReporteResumenVentaSaltoFactura();
        }

        private void TSM_ANALISIS_Ventas_Diaria_Click(object sender, EventArgs e)
        {
            AnalisisVentasDiaria();
        }

        private void AnalisisVentasDiaria()
        {
            _controlador.AnalisisVentasDiaria();
        }

        private void TSM_ANALISIS_Ventas_Por_Cierre_Click(object sender, EventArgs e)
        {
            AnalisisVentasPorCierre();
        }

        private void AnalisisVentasPorCierre()
        {
            _controlador.AnalisisVentasPorCierre();
        }

        private void TSM_REPORTES_VENTA_POR_CLIENTE_Click(object sender, EventArgs e)
        {
            ReporteResumenVentaporCliente();
        }

        private void ReporteResumenVentaporCliente()
        {
            _controlador.ReporteResumenVentaporCliente();
        }
    
    }

}
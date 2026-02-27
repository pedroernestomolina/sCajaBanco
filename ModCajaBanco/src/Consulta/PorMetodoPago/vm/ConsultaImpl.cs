using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.Data;
using System.IO; // Asegúrate de tener la referencia al ensamblado de la versión 4.1.1


namespace ModCajaBanco.src.Consulta.PorMetodoPago.vm
{
    public class ConsultaImpl : IConsulta, IGestion
    {
        private DateTime _fechaServidor;
        private DateTime _desde;
        private DateTime _hasta;
        private BindingSource _bs;
        private Domain.UseCase.IUseCase _uc;
        private bool _isModoDetalle;
        //
        public DateTime Get_Desde { get { return _desde; } }
        public DateTime Get_Hasta { get { return _hasta; } }
        public bool Get_IsModoDetalle { get { return _isModoDetalle; } }
        public object Get_DataSource { get { return _bs; } }
        //
        public ConsultaImpl()
        {
            _fechaServidor = DateTime.Now.Date;
            _desde = DateTime.Now.Date;
            _hasta = DateTime.Now.Date;
            _bs = new BindingSource();
            _uc = new Domain.UseCase.UseCaseImpl();
            _isModoDetalle = false;
        }
        public void Invoke()
        {
            Inicializa();
            Inicia();
        }
        public void Inicializa()
        {
            _bs.DataSource = null;
            _desde = DateTime.Now.Date;
            _hasta = DateTime.Now.Date;
            _isModoDetalle = false;
        }
        private vista.Frm frm;
        public void Inicia()
        {
            if (cargarData())
            {
                if (frm == null)
                {
                    frm = new vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        //
        public void setDesde(DateTime fecha)
        {
            _desde = fecha.Date;
        }
        public void setHasta(DateTime fecha)
        {
            _hasta = fecha.Date;
        }
        //
        public void AccionBuscar()
        {
            try
            {
                _bs.DataSource = _uc.CargarArqueoPorMetodosPago(_desde, _hasta, _isModoDetalle);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        public void AccionLimpiarConsulta()
        {
            _bs.DataSource = null;
            _desde = _fechaServidor.Date;
            _hasta = _fechaServidor.Date;
        }
        public void AccionReporteExportar()
        {
            DataTable dt = (DataTable)_bs.DataSource;
            if (dt != null) 
            {
                exportar(dt);
            }
        }
        //
        private bool cargarData()
        {
            try
            {
                _fechaServidor = _uc.CargarFechaServidor();
                _desde = _fechaServidor.Date;
                _hasta = _fechaServidor.Date;
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void exportar(DataTable tablaPivotada)
        {
            try
            {
                // NO necesitas la línea LicenseContext para la versión 4.1.1 (LGPL)
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Arqueo Pivoteado");
                    // Carga la tabla pivotada directamente a la hoja de cálculo
                    // El segundo argumento 'true' indica que se incluyan los encabezados
                    worksheet.Cells["A1"].LoadFromDataTable(tablaPivotada, true);

                    // Opcional: Aplicar formato y estilo
                    int lastRow = worksheet.Dimension.End.Row;

                    // Fila de totales en negrita
                    worksheet.Row(lastRow).Style.Font.Bold = true;

                    // Formato de números para las celdas (ej. de la columna 3 en adelante)
                    worksheet.Cells[2, 3, lastRow, worksheet.Dimension.End.Column].Style.Numberformat.Format = "#,##0.00";

                    // Ajuste automático de columnas para mejor visualización
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Guardar el archivo
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(sfd.FileName, excelPackage.GetAsByteArray());
                        Helpers.Msg.OK("Reporte generado con éxito en Excel");
                    }
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        public void setIsModoDetalle(bool modo)
        {
            _isModoDetalle = modo;
        }
    }
}
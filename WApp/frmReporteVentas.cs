using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WApp.Util;
using CapaEntidad;
using CapaNegocio;
using System.Data;
using ClosedXML.Excel;

namespace WApp
{
    public partial class frmReporteVentas : Form
    {
        public frmReporteVentas()
        {
            InitializeComponent();
        }

        private void frmReporteVentas_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dgvData.Columns)
            {
                cboBusqueda.Items.Add(new ItemsCombobox() { Valor = column.Name, Texto = column.HeaderText });
            }

            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<ReporteVenta> listaReporteVenta = new List<ReporteVenta>();

            string fechaInicio = dtpFechaInicio.Value.Date.ToString("yyyy/MM/dd");
            string fechaFin = dtpFechaFin.Value.Date.ToString("yyyy/MM/dd");

            listaReporteVenta = new BLL_Reporte().Venta(fechaInicio, fechaFin);

            dgvData.Rows.Clear();

            foreach (ReporteVenta item in listaReporteVenta)
            {
                dgvData.Rows.Add(new object[]
                {
                    item.FechaCreacion,
                    item.TipoDocumento,
                    item.NumeroDocumento,
                    item.MontoTotal,
                    item.UsuarioRegistro,
                    item.DocumentoCliente,
                    item.NombreCliente,
                    item.CodigoProducto,
                    item.NombreProducto,
                    item.Categoria,
                    item.PrecioVenta,
                    item.Cantidad,
                    item.SubTotal
                 });
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((ItemsCombobox)cboBusqueda.SelectedItem).Valor.ToString();
            string textoBusqueda = txtBusqueda.Text.Trim().ToUpper();

            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow r in dgvData.Rows)
                {
                    if (r.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(textoBusqueda))
                    {
                        r.Visible = true;
                    }
                    else
                    {
                        r.Visible = false;
                    }
                }
            }
        }

        private void btnDescargarExcel_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar.", "Ocurrio un Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();

                foreach (DataGridViewColumn column in dgvData.Columns)
                {
                    dt.Columns.Add(column.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    if (row.Visible)
                    {
                        dt.Rows.Add(new object[]{
                                row.Cells[0].Value.ToString(),
                                row.Cells[1].Value.ToString(),
                                row.Cells[2].Value.ToString(),
                                row.Cells[3].Value.ToString(),
                                row.Cells[4].Value.ToString(),
                                row.Cells[5].Value.ToString(),
                                row.Cells[6].Value.ToString(),
                                row.Cells[7].Value.ToString(),
                                row.Cells[8].Value.ToString(),
                                row.Cells[9].Value.ToString(),
                                row.Cells[10].Value.ToString(),
                                row.Cells[11].Value.ToString(),
                                row.Cells[12].Value.ToString()
                            });
                    }
                }

                SaveFileDialog saveFile = new SaveFileDialog();

                saveFile.FileName = string.Format("ReporteVentas_{0}.xlsx", DateTime.Now.ToString("ddMMyyyHHmmss"));
                saveFile.Filter = "Excel Files | *.xlsx";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var sheet = wb.Worksheets.Add(dt, "Informe");
                        sheet.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(saveFile.FileName);

                        MessageBox.Show("Reporte Generado", "Reporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Reporte Generado", "Reporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";

            foreach (DataGridViewRow r in dgvData.Rows)
            {
                r.Visible = true;
            }
        }
    }
}

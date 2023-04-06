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
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new ItemsCombobox() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new ItemsCombobox() { Valor = 0, Texto = "No Activo" });

            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

            List<Categoria> listaCategoria = new BLL_Categoria().Listar();

            foreach (Categoria item in listaCategoria)
            {
                cboCategoria.Items.Add(new ItemsCombobox() { Valor = item.IdCategoria, Texto = item.Descripcion });
            }

            cboCategoria.DisplayMember = "Texto";
            cboCategoria.ValueMember = "Valor";
            cboCategoria.SelectedIndex = 0;

            foreach (DataGridViewColumn column in dgvData.Columns)
            {
                if (column.Visible == true && column.Name != "btnSeleccionar")
                {
                    cboBusqueda.Items.Add(new ItemsCombobox() { Valor = column.Name, Texto = column.HeaderText });
                }
            }

            cboBusqueda.DisplayMember = "Texto";
            cboBusqueda.ValueMember = "Valor";
            cboBusqueda.SelectedIndex = 0;

            List<Producto> listaProductos = new BLL_Producto().Listar();

            foreach (Producto item in listaProductos)
            {
                dgvData.Rows.Add(new object[] {
                "",
                item.IdProducto,
                item.Codigo,
                item.Nombre,
                item.Descripcion,
                item.oCategoria.IdCategoria,
                item.oCategoria.Descripcion,
                item.Stock,
                item.PrecioCompra,
                item.PrecioVenta,
                item.Estado == true ? 1:0,
                item.Estado == true ? "Activo":"No Activo"
            });
            }

            cboCategoria.DisplayMember = "Texto";
            cboCategoria.ValueMember = "Valor";
            cboCategoria.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string indice = txtIndice.Text;
            string id = txtId.Text;
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            ItemsCombobox itemCategoria = (ItemsCombobox)cboCategoria.SelectedItem; 
            ItemsCombobox itemEstado = (ItemsCombobox)cboEstado.SelectedItem;

            Producto oProducto = new Producto()
            {
                IdProducto = Convert.ToInt32(id),
                Codigo = codigo,
                Nombre = nombre,
                Descripcion = descripcion,
                oCategoria = new Categoria() { IdCategoria = (int)itemCategoria.Valor, Descripcion = itemCategoria.Texto },
                Estado = (int)itemEstado.Valor == 1 ? true : false
            };

            string mensaje = string.Empty;

            if (oProducto.IdProducto == 0)
            {
                int idProducto = new BLL_Producto().Registrar(oProducto, out mensaje);

                if (idProducto != 0)
                {
                    dgvData.Rows.Add(new object[] {
                        "",
                        idProducto,
                        codigo,
                        nombre,
                        descripcion,
                        itemCategoria.Valor.ToString(),
                        itemCategoria.Texto.ToString(),
                        "0",
                        "0.00",
                        "0.00",
                        itemEstado.Valor.ToString(),
                        itemEstado.Texto.ToString()
                    });

                    LimpiarControles();
                }
                else
                {
                    MessageBox.Show(mensaje, "Ocurrio un Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                bool productoModificadoConExito = new BLL_Producto().Editar(oProducto, out mensaje);

                if (productoModificadoConExito)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(indice)];
                    row.Cells["Id"].Value = id;
                    row.Cells["Codigo"].Value = codigo;
                    row.Cells["Nombre"].Value = nombre;
                    row.Cells["Descripcion"].Value = descripcion;
                    row.Cells["IdCategoria"].Value = itemCategoria.Valor.ToString();
                    row.Cells["Categoria"].Value = itemCategoria.Texto.ToString();
                    row.Cells["Stock"].Value = "0";
                    row.Cells["PrecioCompra"].Value = "0.00";
                    row.Cells["PrecioCompra"].Value = "0.00";
                    row.Cells["EstadoValor"].Value = itemEstado.Valor.ToString();
                    row.Cells["Estado"].Value = itemEstado.Texto.ToString();

                    LimpiarControles();

                }
                else
                {
                    MessageBox.Show(mensaje, "Ocurrio un Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiarControles()
        {
            txtId.Text = "0";
            txtIndice.Text = "-1";
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            cboCategoria.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;

            txtCodigo.Select();
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
                if (e.RowIndex < 0)
                {
                    return;
                }

                if (e.ColumnIndex == 0)
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                    var widthIcon = Properties.Resources.check.Width;
                    var heightIcon = Properties.Resources.check.Height;

                    var x = e.CellBounds.Left + (e.CellBounds.Width - widthIcon) / 2;
                    var y = e.CellBounds.Top + (e.CellBounds.Height - heightIcon) / 2;

                    e.Graphics.DrawImage(Properties.Resources.check, new Rectangle(x, y, widthIcon, heightIcon));
                    e.Handled = true;
                }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
                {
                    int index = e.RowIndex;

                    if (index >= 0)
                    {
                        txtIndice.Text = index.ToString();
                        txtId.Text = dgvData.Rows[index].Cells["Id"].Value.ToString();
                        txtCodigo.Text = dgvData.Rows[index].Cells["Codigo"].Value.ToString();
                        txtNombre.Text = dgvData.Rows[index].Cells["Nombre"].Value.ToString();
                        txtDescripcion.Text = dgvData.Rows[index].Cells["Descripcion"].Value.ToString();

                        foreach (ItemsCombobox item in cboCategoria.Items)
                        {
                            if (Convert.ToInt32(item.Valor) == Convert.ToInt32(dgvData.Rows[index].Cells["IdCategoria"].Value))
                            {
                                int indexComboRol = cboCategoria.Items.IndexOf(item);
                                cboCategoria.SelectedIndex = indexComboRol;
                                break;
                            }
                        }

                        foreach (ItemsCombobox item in cboEstado.Items)
                        {
                            if (Convert.ToInt32(item.Valor) == Convert.ToInt32(dgvData.Rows[index].Cells["EstadoValor"].Value))
                            {
                                int indexComboEstado = cboEstado.Items.IndexOf(item);
                                cboEstado.SelectedIndex = indexComboEstado;
                                break;
                            }
                        }

                    }
                }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
                string id = txtId.Text;
                string indice = txtIndice.Text;

                if (Convert.ToInt32(id) != 0)
                {
                    if (MessageBox.Show("¿Desea eliminar el Producto?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        Producto oProducto = new Producto()
                        {
                            IdProducto = Convert.ToInt32(id)
                        };

                        string mensaje = string.Empty;

                        bool productoEliminadoConExito = new BLL_Producto().Eliminar(oProducto, out mensaje);

                        if (productoEliminadoConExito)
                        {
                            dgvData.Rows.RemoveAt(Convert.ToInt32(indice));
                            LimpiarControles();
                        }
                        else
                        {
                            MessageBox.Show(mensaje, "Ocurrio un Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
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

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
                txtBusqueda.Text = "";

                foreach (DataGridViewRow r in dgvData.Rows)
                {
                    r.Visible = true;
                }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
                LimpiarControles();
        }

        private void btnDescargarExcel_Click(object sender, EventArgs e)
        {
            if (dgvData.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();

                foreach(DataGridViewColumn column in dgvData.Columns)
                {
                    if(column.HeaderText != "" && column.Visible)
                    {
                        dt.Columns.Add(column.HeaderText, typeof(string));
                    }
                }

                foreach(DataGridViewRow row in dgvData.Rows)
                {
                    if(row.Visible)
                    {
                        dt.Rows.Add(new object[]{
                                row.Cells[2].Value.ToString(),
                                row.Cells[3].Value.ToString(),
                                row.Cells[4].Value.ToString(),
                                row.Cells[6].Value.ToString(),
                                row.Cells[7].Value.ToString(),
                                row.Cells[8].Value.ToString(),
                                row.Cells[9].Value.ToString(),
                                row.Cells[11].Value.ToString()
                            });
                    }
                }

                SaveFileDialog saveFile = new SaveFileDialog();

                saveFile.FileName = string.Format("ReporteProducto_{0}.xlsx", DateTime.Now.ToString("ddMMyyyHHmmss"));
                saveFile.Filter = "Excel Files | *.xlsx";

                if(saveFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var sheet = wb.Worksheets.Add(dt,"Informe");
                        sheet.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(saveFile.FileName);

                        MessageBox.Show("Reporte Generado", "Reporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Reporte Generado", "Reporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WApp.Util;
using CapaEntidad;
using CapaNegocio;
using WApp.Modales;
using System.Linq;
using System.Data;

namespace WApp
{
    public partial class frmCompras : Form
    {
        private Usuario oUsuario;
        public frmCompras(Usuario usuario = null)
        {
            InitializeComponent();
            oUsuario = usuario;
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            cboTipoDocumento.Items.Add(new ItemsCombobox() { Valor = "Boleta", Texto = "Boleta" });
            cboTipoDocumento.Items.Add(new ItemsCombobox() { Valor = "Factura", Texto = "Factura" });
            cboTipoDocumento.DisplayMember = "Texto";
            cboTipoDocumento.ValueMember = "Valor";
            cboTipoDocumento.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtIdProducto.Text = "0";
            txtIdProveedor.Text = "0";
            numericUpDownCantidad.Value = 1;


        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            using(var frmPopUp = new frmProveedorPopUp())
            {
                var result = frmPopUp.ShowDialog();

                if(result == DialogResult.OK)
                {
                    txtIdProveedor.Text = frmPopUp.oProveedor.IdProveedor.ToString();
                    txtNumeroDocumento.Text = frmPopUp.oProveedor.Documento;
                    txtRazonSocial.Text = frmPopUp.oProveedor.RazonSocial;
                }
                else
                {
                    txtNumeroDocumento.Select();
                }
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var frmPopUp = new frmProductoPopUp())
            {
                var result = frmPopUp.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProducto.Text = frmPopUp.oProducto.IdProducto.ToString();
                    txtCodigoProducto.Text = frmPopUp.oProducto.Codigo;
                    txtProducto.Text = frmPopUp.oProducto.Nombre;
                    txtPrecioCompra.Text = frmPopUp.oProducto.PrecioCompra.ToString();
                    txtPrecioVenta.Text = frmPopUp.oProducto.PrecioVenta.ToString();
                }
                else
                {
                    txtCodigoProducto.Select();
                }
            }
        }

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                string codigoProducto = txtCodigoProducto.Text;
                Producto oProducto = new BLL_Producto().Listar().Where(p => p.Codigo == codigoProducto && p.Estado == true).FirstOrDefault();

                if(oProducto != null)
                {
                    txtCodigoProducto.BackColor = Color.Honeydew;
                    txtIdProducto.Text = oProducto.IdProducto.ToString();
                    txtProducto.Text = oProducto.Nombre;
                    txtPrecioCompra.Select();
                }
                else
                {
                    txtCodigoProducto.BackColor = Color.MistyRose;
                    txtIdProducto.Text = "0";
                    txtProducto.Text = "";
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idProducto = string.Empty;
            string producto = string.Empty;
            string precioCompra = string.Empty;
            string precioVenta = string.Empty;
            string cantidad = string.Empty;
            string mensaje = string.Empty;

            idProducto = txtIdProducto.Text;
            producto = txtProducto.Text;
            precioCompra = txtPrecioCompra.Text;
            precioVenta = txtPrecioVenta.Text;
            cantidad = numericUpDownCantidad.Value.ToString();

            bool CheckProducto = new BLL_Producto().CheckProducto(idProducto, out mensaje, precioCompra: precioCompra, precioVenta: precioVenta);

            if (CheckProducto)
            {
                bool idProductoNuevo = false;

                foreach (DataGridViewRow fila in dgvData.Rows)
                {

                    if (fila.Cells["IdProducto"].Value.ToString() == idProducto)
                    {
                        idProductoNuevo = true;
                        break;
                    }

                }

                if (!idProductoNuevo)
                {
                    dgvData.Rows.Add(new object[]
                    {
                        idProducto,
                        producto,
                        decimal.Parse(precioCompra).ToString("0.00"),
                        decimal.Parse(precioVenta).ToString("0.00"),
                        cantidad,
                        (decimal.Parse(cantidad) * decimal.Parse(precioCompra)).ToString("0.00")
                    });

                    CalcularTotal();
                    LimpiarProduco();
                    txtCodigoProducto.Select();
                }
            }
            else
            {
                MessageBox.Show(mensaje, "Ocurrio un Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarProduco()
        {
            txtIdProducto.Text = "0";
            txtCodigoProducto.BackColor = Color.White;
            txtCodigoProducto.Text = "";
            txtProducto.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            numericUpDownCantidad.Value = 1;
        }

        private void CalcularTotal()
        {
            decimal total = 0;

            if(dgvData.Rows.Count > 0)
            {
                foreach(DataGridViewRow fila in dgvData.Rows)
                {
                    total += Convert.ToDecimal(fila.Cells["SubTotal"].Value.ToString());
                }

                txtTotalPagar.Text = total.ToString("0.00");
            }
            else
            {
                txtTotalPagar.Text = total.ToString("0.00");
            }
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == 6)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var widthIcon = Properties.Resources.Close.Width;
                var heightIcon = Properties.Resources.Close.Height;

                var x = e.CellBounds.Left + (e.CellBounds.Width - widthIcon) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - heightIcon) / 2;

                //e.Graphics.DrawImage(Properties.Resources.Close, new Rectangle(x, y, widthIcon, heightIcon));
                e.Handled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnEliminar")
            {
                int index = e.RowIndex;

                if (index >= 0)
                {
                    dgvData.Rows.RemoveAt(index);
                    CalcularTotal();
                }
            }
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if(txtPrecioCompra.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if(char.IsControl(e.KeyChar)|| e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecioVenta.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string idProveedor = txtIdProveedor.Text;
            int numeroDeCompras = dgvData.Rows.Count;
            
            DataTable dt = new DataTable();

            dt.Columns.Add("IdProducto",typeof(int));
            dt.Columns.Add("PrecioCompra", typeof(decimal));
            dt.Columns.Add("PrecioVenta", typeof(decimal));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("MontoTotal", typeof(decimal));

            foreach(DataGridViewRow fila in dgvData.Rows)
            {
                dt.Rows.Add(new object[]
                {
                    Convert.ToInt32(fila.Cells["IdProducto"].Value.ToString()),
                    fila.Cells["PrecioCompra"].Value.ToString(),
                    fila.Cells["PrecioVenta"].Value.ToString(),
                    fila.Cells["Cantidad"].Value.ToString(),
                    fila.Cells["SubTotal"].Value.ToString()
                });
            }

            int idCompra = new BLL_Compra().GenerarNuevoIdCompra();

            string numeroDocumento = string.Format("{0:00000}",idCompra);

            Compra oCompra = new Compra()
            {
                oUsuario = new Usuario() { IdUsuario = oUsuario.IdUsuario },
                oProveedor = new Proveedor() { IdProveedor = Convert.ToInt32(idProveedor) },
                TipoDocumento = ((ItemsCombobox)cboTipoDocumento.SelectedItem).Texto,
                NumeroDocumento = numeroDocumento,
                MontoTotal = Convert.ToDecimal(txtTotalPagar.Text)
            };

            string mensaje = string.Empty;
            bool compraRegistradaConExito = new BLL_Compra().Registrar(idProveedor, numeroDeCompras, oCompra, dt, out mensaje);

            if(compraRegistradaConExito)
            {
                var result = MessageBox.Show("Número de Compra Generado:\n" + numeroDocumento + "\n\n¿Desea copiar el Número de Documento al Portapapeles?", "Nueva Compra Registrada", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                
                if(result == DialogResult.Yes)
                {
                    Clipboard.SetText(numeroDocumento);
                }

                LimpiarControles();
            }
            else
            {
                MessageBox.Show(mensaje, "Ocurrio un Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarControles()
        {
            txtIdProveedor.Text = "0";
            txtNumeroDocumento.Text = "";
            txtRazonSocial.Text = "";
            dgvData.Rows.Clear();
            CalcularTotal();
        }
    }
}

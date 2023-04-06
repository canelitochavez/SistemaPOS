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
    public partial class frmVentas : Form
    {
        private Usuario oUsuario;
        public frmVentas(Usuario usuario = null)
        {
            InitializeComponent();
            oUsuario = usuario;
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            cboTipoDocumento.Items.Add(new ItemsCombobox() { Valor = "Boleta", Texto = "Boleta" });
            cboTipoDocumento.Items.Add(new ItemsCombobox() { Valor = "Factura", Texto = "Factura" });
            cboTipoDocumento.DisplayMember = "Texto";
            cboTipoDocumento.ValueMember = "Valor";
            cboTipoDocumento.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
            txtIdProducto.Text = "0";
            
            txtEfectivo.Text = "";
            txtCambio.Text = "";
            txtTotalPagar.Text = "0";
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            using (var frmPopUp = new frmClientePopUp())
            {
                var result = frmPopUp.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtNumeroDocumento.Text = frmPopUp.oCliente.Documento;
                    txtNombreCompleto.Text = frmPopUp.oCliente.NombreCompleto;
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
                    txtPrecioVenta.Text = frmPopUp.oProducto.PrecioVenta.ToString();
                    txtStock.Text = frmPopUp.oProducto.Stock.ToString();
                    numericUpDownCantidad.Select();
                }
                else
                {
                    txtCodigoProducto.Select();
                }
            }
        }

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string codigoProducto = txtCodigoProducto.Text;
                Producto oProducto = new BLL_Producto().Listar().Where(p => p.Codigo == codigoProducto && p.Estado == true).FirstOrDefault();

                if (oProducto != null)
                {
                    txtCodigoProducto.BackColor = Color.Honeydew;
                    txtIdProducto.Text = oProducto.IdProducto.ToString();
                    txtProducto.Text = oProducto.Nombre;
                    txtPrecioVenta.Text = oProducto.PrecioVenta.ToString("0.00");
                    txtStock.Text = oProducto.Stock.ToString();
                    numericUpDownCantidad.Select();
                }
                else
                {
                    txtCodigoProducto.BackColor = Color.MistyRose;
                    txtIdProducto.Text = "0";
                    txtProducto.Text = "";
                    txtPrecioVenta.Text = "";
                    txtStock.Text = "";
                    numericUpDownCantidad.Value = 1;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idProducto = string.Empty;
            string producto = string.Empty;
            string precioVenta = string.Empty;
            string cantidad = string.Empty;
            string stock = string.Empty;
            string mensaje = string.Empty;

            idProducto = txtIdProducto.Text;
            producto = txtProducto.Text;
            precioVenta = txtPrecioVenta.Text;
            cantidad = numericUpDownCantidad.Value.ToString();
            stock = txtStock.Text;

            bool CheckProducto = new BLL_Producto().CheckProducto(idProducto, out mensaje,precioVenta: precioVenta,stock:stock,cantidad:cantidad);

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

                    bool respuesta = new BLL_Venta().RestarStock(Convert.ToInt32(idProducto), Convert.ToInt32(cantidad));

                    if(respuesta)
                    {
                        dgvData.Rows.Add(new object[]
{
                        idProducto,
                        producto,
                        decimal.Parse(precioVenta).ToString("0.00"),
                        cantidad,
                        (decimal.Parse(cantidad) * decimal.Parse(precioVenta)).ToString("0.00")
});

                        CalcularTotal();
                        LimpiarProduco();
                        txtCodigoProducto.Select();
                    }
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
            txtStock.Text = "";
            txtPrecioVenta.Text = "";
            numericUpDownCantidad.Value = 1;
        }

        private void CalcularTotal()
        {
            decimal total = 0;

            if (dgvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in dgvData.Rows)
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
                    int dgvData_IdProducto = Convert.ToInt32(dgvData.Rows[index].Cells["IdProducto"].Value.ToString());
                    int dgvData_Cantidad = Convert.ToInt32(dgvData.Rows[index].Cells["Cantidad"].Value.ToString());

                    bool respuesta = new BLL_Venta().SumarStock(dgvData_IdProducto, dgvData_Cantidad);

                    if(respuesta)
                    {
                        dgvData.Rows.RemoveAt(index);
                        CalcularTotal();
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

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtEfectivo.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void CalcularCambio()
        {
            if(txtTotalPagar.Text.Trim() == "")
            {
                MessageBox.Show("Agregar Productos a la venta...", "Ocurrio un Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal efectivo;
            decimal total = Convert.ToDecimal(txtTotalPagar.Text);

            if (txtEfectivo.Text.Trim() == "")
            {
                txtEfectivo.Text = "0";
            }

            if(decimal.TryParse(txtEfectivo.Text.Trim(),out efectivo))
            {
                if(efectivo < total)
                {
                    txtCambio.Text = "0.00";
                }
                else
                {
                    decimal cambio = efectivo - total;
                    txtCambio.Text = cambio.ToString("0.00");
                }
            }
        }

        private void txtEfectivo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                CalcularCambio();
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string numeroDocumentoCliente = txtNumeroDocumento.Text;
            string nombreCliente = txtNombreCompleto.Text;
            int numeroDeVentas = dgvData.Rows.Count;

            DataTable dt = new DataTable();

            dt.Columns.Add("IdProducto", typeof(int));
            dt.Columns.Add("PrecioVenta", typeof(decimal));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("SubTotal", typeof(decimal));

            foreach (DataGridViewRow fila in dgvData.Rows)
            {
                dt.Rows.Add(new object[]
                {
                    Convert.ToInt32(fila.Cells["IdProducto"].Value.ToString()),
                    fila.Cells["PrecioVenta"].Value.ToString(),
                    fila.Cells["Cantidad"].Value.ToString(),
                    fila.Cells["SubTotal"].Value.ToString()
                });
            }

            int idVenta = new BLL_Venta().GenerarNuevoIdVenta();

            string numeroDocumento = string.Format("{0:00000}", idVenta);

            CalcularCambio();

            Venta oVenta = new Venta()
            {
                oUsuario = new Usuario() { IdUsuario = oUsuario.IdUsuario },
                TipoDocumento = ((ItemsCombobox)cboTipoDocumento.SelectedItem).Texto,
                NumeroDocumento = numeroDocumento,
                DocumentoCliente = txtNumeroDocumento.Text,
                NombreCliente = txtNombreCompleto.Text,
                MontoPago = Convert.ToDecimal(txtEfectivo.Text),
                MontoCambio = Convert.ToDecimal(txtCambio.Text),
                MontoTotal = Convert.ToDecimal(txtTotalPagar.Text)
            };

            string mensaje = string.Empty;
            bool ventaRegistradaConExito = new BLL_Venta().Registrar(numeroDocumentoCliente, nombreCliente, numeroDeVentas, oVenta, dt, out mensaje);

            if (ventaRegistradaConExito)
            {
                var result = MessageBox.Show("Número de Venta Generado:\n" + numeroDocumento + "\n\n¿Desea copiar el Número de Documento al Portapapeles?", "Nueva Venta Registrada", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
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
            txtNumeroDocumento.Text = "";
            txtNumeroDocumento.Text = "";
            txtNombreCompleto.Text = "";
            dgvData.Rows.Clear();
            CalcularTotal();
            txtEfectivo.Text = "";
            txtCambio.Text = "";
        }
    }
}

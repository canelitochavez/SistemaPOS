using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WApp.Util;
using CapaEntidad;
using CapaNegocio;

namespace WApp
{
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new ItemsCombobox() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new ItemsCombobox() { Valor = 0, Texto = "No Activo" });

            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

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

            List<Proveedor> listaProveedores = new BLL_Proveedor().Listar();

            foreach (Proveedor item in listaProveedores)
            {
                dgvData.Rows.Add(new object[] {
                "",
                item.IdProveedor,
                item.Documento,
                item.RazonSocial,
                item.Correo,
                item.Telefono,
                item.Estado == true ? 1:0,
                item.Estado == true ? "Activo":"No Activo"
            });
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string indice = txtIndice.Text;
            string id = txtId.Text;
            string documento = txtNumeroDocumento.Text;
            string razonSocial = txtRazonSocial.Text;
            string correo = txtCorreo.Text;
            string telefono = txtTelefono.Text;
            ItemsCombobox itemEstado = (ItemsCombobox)cboEstado.SelectedItem;

            Proveedor oProveedor = new Proveedor()
            {
                IdProveedor = Convert.ToInt32(id),
                Documento = documento,
                RazonSocial = razonSocial,
                Correo = correo,
                Telefono = telefono,
                Estado = (int)itemEstado.Valor == 1 ? true : false
            };

            string mensaje = string.Empty;

            if (oProveedor.IdProveedor == 0)
            {
                int idProveedor = new BLL_Proveedor().Registrar(oProveedor, out mensaje);

                if (idProveedor != 0)
                {
                    dgvData.Rows.Add(new object[] {
                        "",
                        idProveedor,
                        documento,
                        razonSocial,
                        correo,
                        telefono,
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
                bool proveedorModificadoConExito = new BLL_Proveedor().Editar(oProveedor, out mensaje);

                if (proveedorModificadoConExito)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(indice)];
                    row.Cells["Id"].Value = id;
                    row.Cells["Documento"].Value = documento;
                    row.Cells["RazonSocial"].Value = razonSocial;
                    row.Cells["Correo"].Value = correo;
                    row.Cells["Telefono"].Value = telefono;
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
            txtNumeroDocumento.Text = "";
            txtRazonSocial.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            cboEstado.SelectedIndex = 0;

            txtNumeroDocumento.Select();
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
                    txtNumeroDocumento.Text = dgvData.Rows[index].Cells["Documento"].Value.ToString();
                    txtRazonSocial.Text = dgvData.Rows[index].Cells["RazonSocial"].Value.ToString();
                    txtCorreo.Text = dgvData.Rows[index].Cells["Correo"].Value.ToString();
                    txtTelefono.Text = dgvData.Rows[index].Cells["Telefono"].Value.ToString();


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
                if (MessageBox.Show("¿Desea eliminar el Proveedor?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    Proveedor oProveedor = new Proveedor()
                    {
                        IdProveedor = Convert.ToInt32(id)
                    };

                    string mensaje = string.Empty;

                    bool proveedorEliminadoConExito = new BLL_Proveedor().Eliminar(oProveedor, out mensaje);

                    if (proveedorEliminadoConExito)
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
    }
}

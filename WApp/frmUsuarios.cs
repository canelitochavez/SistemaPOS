using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WApp.Util;
using CapaEntidad;
using CapaNegocio;

namespace WApp
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new ItemsCombobox() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new ItemsCombobox() { Valor = 0, Texto = "No Activo" });

            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

            List<Rol> listaRol = new BLL_Rol().Listar();

            foreach (Rol item in listaRol)
            {
                cboRol.Items.Add(new ItemsCombobox() { Valor = item.IdRol, Texto = item.Descripcion });
            }

            cboRol.DisplayMember = "Texto";
            cboRol.ValueMember = "Valor";
            cboRol.SelectedIndex = 0;

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

            List<Usuario> listaUsuarios = new BLL_Usuario().Listar();

            foreach (Usuario item in listaUsuarios)
            {
                dgvData.Rows.Add(new object[] {
                "",
                item.IdUsuario,
                item.Documento,
                item.NombreCompleto,
                item.Correo,
                item.Clave,
                item.oRol.IdRol,
                item.oRol.Descripcion,
                item.Estado == true ? 1:0,
                item.Estado == true ? "Activo":"No Activo"
            });
            }

            cboRol.DisplayMember = "Texto";
            cboRol.ValueMember = "Valor";
            cboRol.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            string indice = txtIndice.Text;
            string id = txtId.Text;
            string documento = txtNumeroDocumento.Text;
            string nombreCompleto = txtNombreCompleto.Text;
            string correo = txtCorreo.Text;
            string clave = txtClave.Text;
            ItemsCombobox itemRol = (ItemsCombobox)cboRol.SelectedItem;
            ItemsCombobox itemEstado = (ItemsCombobox)cboEstado.SelectedItem;

            Usuario oUsuario = new Usuario()
            {
                IdUsuario = Convert.ToInt32(id),
                Documento = documento,
                NombreCompleto = nombreCompleto,
                Correo = correo,
                Clave = clave,
                oRol = new Rol() { IdRol = (int)itemRol.Valor, Descripcion = itemRol.Texto },
                Estado = (int)itemEstado.Valor == 1 ? true:false
            };

            string mensaje = string.Empty;

            if (oUsuario.IdUsuario == 0)
            {
                int idUsuario = new BLL_Usuario().Registrar(oUsuario, out mensaje);

                if (idUsuario != 0)
                {
                    dgvData.Rows.Add(new object[] {
                        "",
                        idUsuario,
                        documento,
                        nombreCompleto,
                        correo,
                        clave,
                        itemRol.Valor.ToString(),
                        itemRol.Texto.ToString(),
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
                bool usuarioModificadoConExito = new BLL_Usuario().Editar(oUsuario, out mensaje);

                if(usuarioModificadoConExito)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(indice)];
                    row.Cells["Id"].Value = id;
                    row.Cells["Documento"].Value = documento;
                    row.Cells["NombreCompleto"].Value = nombreCompleto;
                    row.Cells["Correo"].Value = correo;
                    row.Cells["Clave"].Value = clave;
                    row.Cells["IdRol"].Value = itemRol.Valor.ToString();
                    row.Cells["Rol"].Value = itemRol.Texto.ToString();
                    row.Cells["EstadoValor"].Value = itemEstado.Valor.ToString();
                    row.Cells["Estado"].Value = itemEstado.Texto.ToString();

                    LimpiarControles();

                }
                else
                {
                    MessageBox.Show(mensaje, "Ocurrio un Error!!!", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiarControles()
        {
            txtId.Text = "0";
            txtIndice.Text = "-1";
            txtNumeroDocumento.Text = "";
            txtNombreCompleto.Text = "";
            txtCorreo.Text = "";
            txtClave.Text = "";
            txtConfirmarClave.Text = "";
            cboRol.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;

            txtNumeroDocumento.Select();
        }

        private void dgvData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if(e.RowIndex < 0)
            {
                return;
            }

            if(e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var widthIcon = Properties.Resources.check.Width;
                var heightIcon = Properties.Resources.check.Height;

                var x = e.CellBounds.Left + (e.CellBounds.Width - widthIcon) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - heightIcon) / 2;

                e.Graphics.DrawImage(Properties.Resources.check,new Rectangle(x,y,widthIcon,heightIcon));
                e.Handled = true;
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int index = e.RowIndex;

                if(index >= 0)
                {
                    txtIndice.Text = index.ToString();
                    txtId.Text = dgvData.Rows[index].Cells["Id"].Value.ToString();
                    txtNumeroDocumento.Text = dgvData.Rows[index].Cells["Documento"].Value.ToString();
                    txtNombreCompleto.Text = dgvData.Rows[index].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dgvData.Rows[index].Cells["Correo"].Value.ToString();
                    txtClave.Text = dgvData.Rows[index].Cells["Clave"].Value.ToString();
                    txtConfirmarClave.Text = dgvData.Rows[index].Cells["Clave"].Value.ToString();

                    foreach(ItemsCombobox item in cboRol.Items)
                    {
                        if (Convert.ToInt32(item.Valor) == Convert.ToInt32(dgvData.Rows[index].Cells["IdRol"].Value))
                        {
                            int indexComboRol = cboRol.Items.IndexOf(item);
                            cboRol.SelectedIndex = indexComboRol;
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
                if (MessageBox.Show("¿Desea eliminar el Usuario?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    Usuario oUsuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(id)
                    };

                    string mensaje = string.Empty;

                    bool usuarioEliminadoConExito = new BLL_Usuario().Eliminar(oUsuario,out mensaje);

                    if(usuarioEliminadoConExito)
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

            if(dgvData.Rows.Count > 0)
            {
                foreach(DataGridViewRow r in dgvData.Rows)
                {
                    if(r.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(textoBusqueda))
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

            foreach(DataGridViewRow r in dgvData.Rows)
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

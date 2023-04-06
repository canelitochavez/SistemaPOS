using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WApp.Util;
using CapaEntidad;
using CapaNegocio;

namespace WApp.Modales
{
    public partial class frmProveedorPopUp : Form
    {
        public Proveedor oProveedor { get; set; }
        public frmProveedorPopUp()
        {
            InitializeComponent();
        }

        private void frmProveedorPopUp_Load(object sender, EventArgs e)
        {
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
                item.IdProveedor,
                item.Documento,
                item.RazonSocial
                });
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

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indiceFila = e.RowIndex;
            int indiceColumna = e.ColumnIndex;

            if(indiceFila >= 0 && indiceColumna > 0)
            {
                oProveedor = new Proveedor()
                {
                    IdProveedor = Convert.ToInt32(dgvData.Rows[indiceFila].Cells["Id"].Value.ToString()),
                    Documento = dgvData.Rows[indiceFila].Cells["Documento"].Value.ToString(),
                    RazonSocial = dgvData.Rows[indiceFila].Cells["RazonSocial"].Value.ToString()
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}

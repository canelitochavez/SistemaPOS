
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using WApp.Modales;

namespace WApp
{
    public partial class frmMain : Form
    {
        private static Usuario currentUserLogin;
        private static IconMenuItem currentMenuActive = null;
        private static Form currentFormActive = null;
        public frmMain(Usuario loginuser)
        {
            currentUserLogin = loginuser;
            InitializeComponent();
        }

        private void frmMain_Load(object sender, System.EventArgs e)
        {
            List<Permiso> ListaPermisos = new BLL_Permiso().Listar(currentUserLogin.IdUsuario);
           
            foreach(IconMenuItem iconMenu in menuSecundario.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.NombreMenu == iconMenu.Name);

                if(encontrado==false)
                {
                    iconMenu.Visible = false;
                }
            }

            lblUsuarioLogeado.Text = currentUserLogin.NombreCompleto;
        }

        private void OpenForm(IconMenuItem menu,Form form)
        {
            if(currentMenuActive != null)
            {
                currentMenuActive.BackColor = Color.White;
            }

            menu.BackColor = Color.Silver;
            currentMenuActive = menu;

            if(currentFormActive != null)
            {
                currentFormActive.Close();
            }

            currentFormActive = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.BackColor = Color.SteelBlue;
            
            panelContenedor.Controls.Add(form);
            form.Show();
        }
        private void menuUsuarios_Click(object sender, System.EventArgs e)
        {
            OpenForm((IconMenuItem)sender, new frmUsuarios());
        }

        private void subMenuCategoria_Click(object sender, System.EventArgs e)
        {
            OpenForm(menuMantenedor, new frmCategoria());
        }

        private void subMenuProducto_Click(object sender, System.EventArgs e)
        {
            OpenForm(menuMantenedor, new frmProducto());
        }

        private void subMenuRegistrarVenta_Click(object sender, System.EventArgs e)
        {
            OpenForm(menuVentas, new frmVentas(currentUserLogin));
        }

        private void subMenuVerDetalleVenta_Click(object sender, System.EventArgs e)
        {
            OpenForm(menuVentas, new frmDetalleVenta());
        }

        private void subMenuRegistrarCompra_Click(object sender, System.EventArgs e)
        {
            OpenForm(menuCompras, new frmCompras(currentUserLogin));
        }

        private void subMenuVerDetalleCompra_Click(object sender, System.EventArgs e)
        {
            OpenForm(menuCompras, new frmDetalleCompra());
        }

        private void menuClientes_Click(object sender, System.EventArgs e)
        {
            OpenForm((IconMenuItem)sender, new frmClientes());
        }

        private void menuProvedores_Click(object sender, System.EventArgs e)
        {
            OpenForm((IconMenuItem)sender, new frmProveedores());
        }

        private void subMenuNegocio_Click(object sender, System.EventArgs e)
        {
            OpenForm(menuMantenedor, new frmNegocio());
        }

        private void subMenuReporteCompra_Click(object sender, System.EventArgs e)
        {
            OpenForm(menuReportes, new frmReporteCompras());
        }

        private void subMenuReporteVentas_Click(object sender, System.EventArgs e)
        {
            OpenForm(menuReportes, new frmReporteVentas());
        }

        private void menuAcercaDe_Click(object sender, System.EventArgs e)
        {
            frmAcercaDe acercaDe = new frmAcercaDe();
            acercaDe.ShowDialog();
        }
    }
}

using System;
using System.Windows.Forms;
using System.Linq;
using CapaNegocio;
using CapaEntidad;

namespace WApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            //TODO: Validar los campos del formulario...

            string sDocumento = txtNumeroDocumento.Text;
            string sClave = txtContrasenia.Text;
            
            BLL_Usuario bll = new BLL_Usuario();

            Usuario oUsuario = bll.Listar().Where(u => u.Documento == sDocumento && u.Clave == sClave).FirstOrDefault();

            if(oUsuario != null)
            {
                frmMain frmPrincipal = new frmMain(oUsuario);
                frmPrincipal.Show();
                this.Hide();
                frmPrincipal.FormClosing += FrmPrincipal_FormClosing;
            }
            else
            {
                MessageBox.Show("Ocurrio un error...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtNumeroDocumento.Text = "";
            txtContrasenia.Text = "";
            this.Show();

        }
    }
}

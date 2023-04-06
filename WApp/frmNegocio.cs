using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WApp.Util;
using CapaEntidad;
using CapaNegocio;
using System.IO;

namespace WApp
{
    public partial class frmNegocio : Form
    {
        public frmNegocio()
        {
            InitializeComponent();
        }

        private void frmNegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] imagen = new BLL_Negocio().ObtenerLogo(out obtenido);

            if (obtenido)
            {
                picLogo.Image = ByteToImage(imagen);
            }

            Negocio oNegocio = new BLL_Negocio().ObtenerNegocio();

            txtNombreNegocio.Text = oNegocio.Nombre;
            txtRUC.Text = oNegocio.RUC;
            txtDireccion.Text = oNegocio.Direccion;
        }

        public Image ByteToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image imagen = new Bitmap(ms);
            return imagen;
        }

        private void btnUploadLogo_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            OpenFileDialog uploadImageDialog = new OpenFileDialog();
            uploadImageDialog.FileName = "Files|*.jpg;*.jpeg;*.png";

            if(uploadImageDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] image = File.ReadAllBytes(uploadImageDialog.FileName);
                bool respuesta = new BLL_Negocio().ActualizarLogo(image,out mensaje);

                if(respuesta)
                {
                    picLogo.Image = ByteToImage(image);
                }
                else
                {
                    MessageBox.Show(mensaje,"Ocurrio un ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Negocio oNegocio = new Negocio()
            {
                Nombre = txtNombreNegocio.Text,
                RUC = txtRUC.Text,
                Direccion = txtDireccion.Text
            };

            bool respuesta = new BLL_Negocio().GuardarDatos(oNegocio, out mensaje);

            if(respuesta)
            {
                MessageBox.Show("Los cambios fueron guardados con Exito!!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(mensaje, "Ocurrio un ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

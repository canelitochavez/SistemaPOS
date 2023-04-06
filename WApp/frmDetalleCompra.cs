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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;

namespace WApp
{
    public partial class frmDetalleCompra : Form
    {
        public frmDetalleCompra()
        {
            InitializeComponent();
        }

        private void btnBuscarDetalleCompra_Click(object sender, EventArgs e)
        {
            string searchCompra = txtNumeroDocumento.Text;
            Compra oCompra = new BLL_Compra().ObtenerCompra(searchCompra);

            if(oCompra.IdCompra != 0)
            {
                txtNumeroDocumentoCompra.Text = oCompra.NumeroDocumento;
                txtFecha.Text = oCompra.FechaCreacion;
                txtTipoDocumento.Text = oCompra.TipoDocumento;
                txtUsuario.Text = oCompra.oUsuario.NombreCompleto;
                txtNumeroDocumentoProveedor.Text = oCompra.oProveedor.Documento;
                txtRazonSocial.Text = oCompra.oProveedor.RazonSocial;
                
                dgvData.Rows.Clear();

                foreach(DetalleCompra dc in oCompra.oDetalleCompra)
                {
                    dgvData.Rows.Add(new object[] { dc.oProducto.Nombre, dc.PrecioCompra, dc.Cantidad, dc.MontoTotal });
                }

                txtMontoTotal.Text = oCompra.MontoTotal.ToString("0.00");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFecha.Text = "";
            txtTipoDocumento.Text = "";
            txtUsuario.Text = "";
            txtNumeroDocumentoProveedor.Text = "";
            txtRazonSocial.Text = "";

            dgvData.Rows.Clear();
            txtMontoTotal.Text = "0.00";
        }

        private void btnDescargarPDF_Click(object sender, EventArgs e)
        {
            if (txtTipoDocumento.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Ocurrio un Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string textoHTML = Properties.Resources.PlantillaCompra.ToString();
            Negocio oDatosNegocio = new BLL_Negocio().ObtenerNegocio();
            
            textoHTML = textoHTML.Replace("@nombrenegocio", oDatosNegocio.Nombre.ToUpper());
            textoHTML = textoHTML.Replace("@docnegocio", oDatosNegocio.RUC);
            textoHTML = textoHTML.Replace("@direcnegocio", oDatosNegocio.Direccion);

            textoHTML = textoHTML.Replace("@tipodocumento", txtTipoDocumento.Text.ToUpper());
            textoHTML = textoHTML.Replace("@numerodocumento", txtNumeroDocumentoCompra.Text);

            textoHTML = textoHTML.Replace("@docproveedor", txtNumeroDocumentoProveedor.Text);
            textoHTML = textoHTML.Replace("@nombreproveedor", txtRazonSocial.Text);
            textoHTML = textoHTML.Replace("@fecharegistro", txtFecha.Text);
            textoHTML = textoHTML.Replace("@usuarioregistro", txtUsuario.Text);

            string filas = string.Empty;

            foreach(DataGridViewRow row in dgvData.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["Producto"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["PrecioCompra"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["Cantidad"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["SubTotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }


            textoHTML = textoHTML.Replace("@filas", filas);
            textoHTML = textoHTML.Replace("@montototal", txtMontoTotal.Text);

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = string.Format("Compra_{0}.pdf",txtNumeroDocumento.Text);
            saveFile.Filter = "Pdf Files|*.pdf";

            if(saveFile.ShowDialog() == DialogResult.OK)
            {
                using(FileStream streamPDF = new FileStream(saveFile.FileName, FileMode.Create))
                {
                    Document docPDF = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writerPDF = PdfWriter.GetInstance(docPDF, streamPDF);
                    docPDF.Open();

                    bool seObtuvoElLogo = true;
                    byte[] byteImage = new BLL_Negocio().ObtenerLogo(out seObtuvoElLogo);

                    if(seObtuvoElLogo)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(docPDF.Left,docPDF.GetTop(51));
                        docPDF.Add(img);
                    }

                    using (StringReader sr = new StringReader(textoHTML))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writerPDF, docPDF, sr);
                    }

                    docPDF.Close();
                    streamPDF.Close();
                    MessageBox.Show("Documento PDF Generado", "Mensaje!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}

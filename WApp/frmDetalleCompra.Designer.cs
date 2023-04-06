
namespace WApp
{
    partial class frmDetalleCompra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSuperiorDetalleCompras = new System.Windows.Forms.Label();
            this.lblNumeroDocumentoSearch = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.btnBuscarDetalleCompra = new FontAwesome.Sharp.IconButton();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.groupBoxInformacionDeCompra = new System.Windows.Forms.GroupBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtTipoDocumento = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.groupBoxInformacionProveedor = new System.Windows.Forms.GroupBox();
            this.txtNumeroDocumentoCompra = new System.Windows.Forms.TextBox();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.txtNumeroDocumentoProveedor = new System.Windows.Forms.TextBox();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.lblNumeroDocumentoProveedor = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.txtMontoTotal = new System.Windows.Forms.TextBox();
            this.btnDescargarPDF = new System.Windows.Forms.Button();
            this.groupBoxInformacionDeCompra.SuspendLayout();
            this.groupBoxInformacionProveedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSuperiorDetalleCompras
            // 
            this.panelSuperiorDetalleCompras.BackColor = System.Drawing.Color.White;
            this.panelSuperiorDetalleCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelSuperiorDetalleCompras.Location = new System.Drawing.Point(7, 23);
            this.panelSuperiorDetalleCompras.Name = "panelSuperiorDetalleCompras";
            this.panelSuperiorDetalleCompras.Size = new System.Drawing.Size(907, 466);
            this.panelSuperiorDetalleCompras.TabIndex = 21;
            this.panelSuperiorDetalleCompras.Text = "Detalle Compra";
            // 
            // lblNumeroDocumentoSearch
            // 
            this.lblNumeroDocumentoSearch.AutoSize = true;
            this.lblNumeroDocumentoSearch.BackColor = System.Drawing.Color.White;
            this.lblNumeroDocumentoSearch.Location = new System.Drawing.Point(167, 58);
            this.lblNumeroDocumentoSearch.Name = "lblNumeroDocumentoSearch";
            this.lblNumeroDocumentoSearch.Size = new System.Drawing.Size(105, 13);
            this.lblNumeroDocumentoSearch.TabIndex = 22;
            this.lblNumeroDocumentoSearch.Text = "Número Documento:";
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(278, 51);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(154, 20);
            this.txtNumeroDocumento.TabIndex = 23;
            // 
            // btnBuscarDetalleCompra
            // 
            this.btnBuscarDetalleCompra.BackColor = System.Drawing.Color.White;
            this.btnBuscarDetalleCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarDetalleCompra.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscarDetalleCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarDetalleCompra.ForeColor = System.Drawing.Color.White;
            this.btnBuscarDetalleCompra.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscarDetalleCompra.IconColor = System.Drawing.Color.Black;
            this.btnBuscarDetalleCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarDetalleCompra.IconSize = 16;
            this.btnBuscarDetalleCompra.Location = new System.Drawing.Point(455, 51);
            this.btnBuscarDetalleCompra.Name = "btnBuscarDetalleCompra";
            this.btnBuscarDetalleCompra.Size = new System.Drawing.Size(42, 21);
            this.btnBuscarDetalleCompra.TabIndex = 26;
            this.btnBuscarDetalleCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarDetalleCompra.UseVisualStyleBackColor = false;
            this.btnBuscarDetalleCompra.Click += new System.EventHandler(this.btnBuscarDetalleCompra_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnLimpiar.IconColor = System.Drawing.Color.Black;
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.IconSize = 16;
            this.btnLimpiar.Location = new System.Drawing.Point(512, 48);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(41, 23);
            this.btnLimpiar.TabIndex = 27;
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // groupBoxInformacionDeCompra
            // 
            this.groupBoxInformacionDeCompra.BackColor = System.Drawing.Color.White;
            this.groupBoxInformacionDeCompra.Controls.Add(this.txtUsuario);
            this.groupBoxInformacionDeCompra.Controls.Add(this.txtTipoDocumento);
            this.groupBoxInformacionDeCompra.Controls.Add(this.txtFecha);
            this.groupBoxInformacionDeCompra.Controls.Add(this.lblUsuario);
            this.groupBoxInformacionDeCompra.Controls.Add(this.lblTipoDocumento);
            this.groupBoxInformacionDeCompra.Controls.Add(this.lblFecha);
            this.groupBoxInformacionDeCompra.Location = new System.Drawing.Point(12, 78);
            this.groupBoxInformacionDeCompra.Name = "groupBoxInformacionDeCompra";
            this.groupBoxInformacionDeCompra.Size = new System.Drawing.Size(541, 68);
            this.groupBoxInformacionDeCompra.TabIndex = 28;
            this.groupBoxInformacionDeCompra.TabStop = false;
            this.groupBoxInformacionDeCompra.Text = "Información de Compra";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(384, 38);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(139, 20);
            this.txtUsuario.TabIndex = 34;
            // 
            // txtTipoDocumento
            // 
            this.txtTipoDocumento.Location = new System.Drawing.Point(213, 40);
            this.txtTipoDocumento.Name = "txtTipoDocumento";
            this.txtTipoDocumento.ReadOnly = true;
            this.txtTipoDocumento.Size = new System.Drawing.Size(124, 20);
            this.txtTipoDocumento.TabIndex = 33;
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(22, 40);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(124, 20);
            this.txtFecha.TabIndex = 32;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.BackColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(381, 20);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 13);
            this.lblUsuario.TabIndex = 29;
            this.lblUsuario.Text = "Usuario:";
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.BackColor = System.Drawing.Color.White;
            this.lblTipoDocumento.Location = new System.Drawing.Point(210, 21);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(89, 13);
            this.lblTipoDocumento.TabIndex = 30;
            this.lblTipoDocumento.Text = "Tipo Documento:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.White;
            this.lblFecha.Location = new System.Drawing.Point(19, 23);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 31;
            this.lblFecha.Text = "Fecha:";
            // 
            // groupBoxInformacionProveedor
            // 
            this.groupBoxInformacionProveedor.BackColor = System.Drawing.Color.White;
            this.groupBoxInformacionProveedor.Controls.Add(this.txtNumeroDocumentoCompra);
            this.groupBoxInformacionProveedor.Controls.Add(this.txtRazonSocial);
            this.groupBoxInformacionProveedor.Controls.Add(this.txtNumeroDocumentoProveedor);
            this.groupBoxInformacionProveedor.Controls.Add(this.lblRazonSocial);
            this.groupBoxInformacionProveedor.Controls.Add(this.lblNumeroDocumentoProveedor);
            this.groupBoxInformacionProveedor.Location = new System.Drawing.Point(12, 152);
            this.groupBoxInformacionProveedor.Name = "groupBoxInformacionProveedor";
            this.groupBoxInformacionProveedor.Size = new System.Drawing.Size(541, 74);
            this.groupBoxInformacionProveedor.TabIndex = 35;
            this.groupBoxInformacionProveedor.TabStop = false;
            this.groupBoxInformacionProveedor.Text = "Información de Proveedor";
            // 
            // txtNumeroDocumentoCompra
            // 
            this.txtNumeroDocumentoCompra.Location = new System.Drawing.Point(444, 15);
            this.txtNumeroDocumentoCompra.Name = "txtNumeroDocumentoCompra";
            this.txtNumeroDocumentoCompra.Size = new System.Drawing.Size(79, 20);
            this.txtNumeroDocumentoCompra.TabIndex = 36;
            this.txtNumeroDocumentoCompra.Visible = false;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(213, 43);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(310, 20);
            this.txtRazonSocial.TabIndex = 33;
            // 
            // txtNumeroDocumentoProveedor
            // 
            this.txtNumeroDocumentoProveedor.Location = new System.Drawing.Point(22, 44);
            this.txtNumeroDocumentoProveedor.Name = "txtNumeroDocumentoProveedor";
            this.txtNumeroDocumentoProveedor.ReadOnly = true;
            this.txtNumeroDocumentoProveedor.Size = new System.Drawing.Size(124, 20);
            this.txtNumeroDocumentoProveedor.TabIndex = 32;
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.BackColor = System.Drawing.Color.White;
            this.lblRazonSocial.Location = new System.Drawing.Point(210, 27);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(73, 13);
            this.lblRazonSocial.TabIndex = 30;
            this.lblRazonSocial.Text = "Razon Social:";
            // 
            // lblNumeroDocumentoProveedor
            // 
            this.lblNumeroDocumentoProveedor.AutoSize = true;
            this.lblNumeroDocumentoProveedor.BackColor = System.Drawing.Color.White;
            this.lblNumeroDocumentoProveedor.Location = new System.Drawing.Point(19, 27);
            this.lblNumeroDocumentoProveedor.Name = "lblNumeroDocumentoProveedor";
            this.lblNumeroDocumentoProveedor.Size = new System.Drawing.Size(105, 13);
            this.lblNumeroDocumentoProveedor.TabIndex = 31;
            this.lblNumeroDocumentoProveedor.Text = "Número Documento:";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.PrecioCompra,
            this.Cantidad,
            this.SubTotal});
            this.dgvData.Location = new System.Drawing.Point(12, 247);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(882, 187);
            this.dgvData.TabIndex = 36;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 400;
            // 
            // PrecioCompra
            // 
            this.PrecioCompra.HeaderText = "Precio Compra";
            this.PrecioCompra.Name = "PrecioCompra";
            this.PrecioCompra.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "Sub Total";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.BackColor = System.Drawing.Color.White;
            this.lblMontoTotal.Location = new System.Drawing.Point(584, 213);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(67, 13);
            this.lblMontoTotal.TabIndex = 37;
            this.lblMontoTotal.Text = "Monto Total:";
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.Location = new System.Drawing.Point(649, 206);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.ReadOnly = true;
            this.txtMontoTotal.Size = new System.Drawing.Size(112, 20);
            this.txtMontoTotal.TabIndex = 38;
            this.txtMontoTotal.Text = "0";
            // 
            // btnDescargarPDF
            // 
            this.btnDescargarPDF.Location = new System.Drawing.Point(767, 203);
            this.btnDescargarPDF.Name = "btnDescargarPDF";
            this.btnDescargarPDF.Size = new System.Drawing.Size(117, 23);
            this.btnDescargarPDF.TabIndex = 39;
            this.btnDescargarPDF.Text = "Descargar en PDF";
            this.btnDescargarPDF.UseVisualStyleBackColor = true;
            this.btnDescargarPDF.Click += new System.EventHandler(this.btnDescargarPDF_Click);
            // 
            // frmDetalleCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 498);
            this.Controls.Add(this.btnDescargarPDF);
            this.Controls.Add(this.txtMontoTotal);
            this.Controls.Add(this.lblMontoTotal);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.groupBoxInformacionProveedor);
            this.Controls.Add(this.groupBoxInformacionDeCompra);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscarDetalleCompra);
            this.Controls.Add(this.txtNumeroDocumento);
            this.Controls.Add(this.lblNumeroDocumentoSearch);
            this.Controls.Add(this.panelSuperiorDetalleCompras);
            this.Name = "frmDetalleCompra";
            this.Text = "frmDetalleCompra";
            this.groupBoxInformacionDeCompra.ResumeLayout(false);
            this.groupBoxInformacionDeCompra.PerformLayout();
            this.groupBoxInformacionProveedor.ResumeLayout(false);
            this.groupBoxInformacionProveedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label panelSuperiorDetalleCompras;
        private System.Windows.Forms.Label lblNumeroDocumentoSearch;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private FontAwesome.Sharp.IconButton btnBuscarDetalleCompra;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private System.Windows.Forms.GroupBox groupBoxInformacionDeCompra;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtTipoDocumento;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox groupBoxInformacionProveedor;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.TextBox txtNumeroDocumentoProveedor;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.Label lblNumeroDocumentoProveedor;
        private System.Windows.Forms.TextBox txtNumeroDocumentoCompra;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.TextBox txtMontoTotal;
        private System.Windows.Forms.Button btnDescargarPDF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
    }
}

namespace WApp
{
    partial class frmDetalleVenta
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
            this.panelSuperiorDetalleVenta = new System.Windows.Forms.Label();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.btnBuscarDetalleVenta = new FontAwesome.Sharp.IconButton();
            this.txtNumeroDocumento = new System.Windows.Forms.TextBox();
            this.lblNumeroDocumentoSearch = new System.Windows.Forms.Label();
            this.groupBoxInformacionDeVenta = new System.Windows.Forms.GroupBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtTipoDocumento = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.groupBoxInformacionCliente = new System.Windows.Forms.GroupBox();
            this.txtNumeroDocumentoVenta = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtNumeroDocumentoCliente = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblNumeroDocumentoCliente = new System.Windows.Forms.Label();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMontoTotal = new System.Windows.Forms.TextBox();
            this.lblMontoTotal = new System.Windows.Forms.Label();
            this.txtMontoPagado = new System.Windows.Forms.TextBox();
            this.lblMontoPagado = new System.Windows.Forms.Label();
            this.txtMontoCambio = new System.Windows.Forms.TextBox();
            this.lblMontoCambio = new System.Windows.Forms.Label();
            this.btnDescargarPDF = new System.Windows.Forms.Button();
            this.groupBoxInformacionDeVenta.SuspendLayout();
            this.groupBoxInformacionCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSuperiorDetalleVenta
            // 
            this.panelSuperiorDetalleVenta.BackColor = System.Drawing.Color.White;
            this.panelSuperiorDetalleVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelSuperiorDetalleVenta.Location = new System.Drawing.Point(7, 9);
            this.panelSuperiorDetalleVenta.Name = "panelSuperiorDetalleVenta";
            this.panelSuperiorDetalleVenta.Size = new System.Drawing.Size(907, 466);
            this.panelSuperiorDetalleVenta.TabIndex = 22;
            this.panelSuperiorDetalleVenta.Text = "Detalle Venta";
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
            this.btnLimpiar.Location = new System.Drawing.Point(494, 35);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(41, 23);
            this.btnLimpiar.TabIndex = 31;
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscarDetalleVenta
            // 
            this.btnBuscarDetalleVenta.BackColor = System.Drawing.Color.White;
            this.btnBuscarDetalleVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarDetalleVenta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscarDetalleVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarDetalleVenta.ForeColor = System.Drawing.Color.White;
            this.btnBuscarDetalleVenta.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscarDetalleVenta.IconColor = System.Drawing.Color.Black;
            this.btnBuscarDetalleVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarDetalleVenta.IconSize = 16;
            this.btnBuscarDetalleVenta.Location = new System.Drawing.Point(437, 38);
            this.btnBuscarDetalleVenta.Name = "btnBuscarDetalleVenta";
            this.btnBuscarDetalleVenta.Size = new System.Drawing.Size(42, 21);
            this.btnBuscarDetalleVenta.TabIndex = 30;
            this.btnBuscarDetalleVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarDetalleVenta.UseVisualStyleBackColor = false;
            this.btnBuscarDetalleVenta.Click += new System.EventHandler(this.btnBuscarDetalleVenta_Click);
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(260, 38);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(154, 20);
            this.txtNumeroDocumento.TabIndex = 29;
            // 
            // lblNumeroDocumentoSearch
            // 
            this.lblNumeroDocumentoSearch.AutoSize = true;
            this.lblNumeroDocumentoSearch.BackColor = System.Drawing.Color.White;
            this.lblNumeroDocumentoSearch.Location = new System.Drawing.Point(149, 45);
            this.lblNumeroDocumentoSearch.Name = "lblNumeroDocumentoSearch";
            this.lblNumeroDocumentoSearch.Size = new System.Drawing.Size(105, 13);
            this.lblNumeroDocumentoSearch.TabIndex = 28;
            this.lblNumeroDocumentoSearch.Text = "Número Documento:";
            // 
            // groupBoxInformacionDeVenta
            // 
            this.groupBoxInformacionDeVenta.BackColor = System.Drawing.Color.White;
            this.groupBoxInformacionDeVenta.Controls.Add(this.txtUsuario);
            this.groupBoxInformacionDeVenta.Controls.Add(this.txtTipoDocumento);
            this.groupBoxInformacionDeVenta.Controls.Add(this.txtFecha);
            this.groupBoxInformacionDeVenta.Controls.Add(this.lblUsuario);
            this.groupBoxInformacionDeVenta.Controls.Add(this.lblTipoDocumento);
            this.groupBoxInformacionDeVenta.Controls.Add(this.lblFecha);
            this.groupBoxInformacionDeVenta.Location = new System.Drawing.Point(15, 78);
            this.groupBoxInformacionDeVenta.Name = "groupBoxInformacionDeVenta";
            this.groupBoxInformacionDeVenta.Size = new System.Drawing.Size(541, 68);
            this.groupBoxInformacionDeVenta.TabIndex = 32;
            this.groupBoxInformacionDeVenta.TabStop = false;
            this.groupBoxInformacionDeVenta.Text = "Información de Venta";
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
            // groupBoxInformacionCliente
            // 
            this.groupBoxInformacionCliente.BackColor = System.Drawing.Color.White;
            this.groupBoxInformacionCliente.Controls.Add(this.txtNumeroDocumentoVenta);
            this.groupBoxInformacionCliente.Controls.Add(this.txtNombre);
            this.groupBoxInformacionCliente.Controls.Add(this.txtNumeroDocumentoCliente);
            this.groupBoxInformacionCliente.Controls.Add(this.lblNombre);
            this.groupBoxInformacionCliente.Controls.Add(this.lblNumeroDocumentoCliente);
            this.groupBoxInformacionCliente.Location = new System.Drawing.Point(15, 164);
            this.groupBoxInformacionCliente.Name = "groupBoxInformacionCliente";
            this.groupBoxInformacionCliente.Size = new System.Drawing.Size(541, 74);
            this.groupBoxInformacionCliente.TabIndex = 36;
            this.groupBoxInformacionCliente.TabStop = false;
            this.groupBoxInformacionCliente.Text = "Información de Cliente";
            // 
            // txtNumeroDocumentoVenta
            // 
            this.txtNumeroDocumentoVenta.Location = new System.Drawing.Point(444, 15);
            this.txtNumeroDocumentoVenta.Name = "txtNumeroDocumentoVenta";
            this.txtNumeroDocumentoVenta.Size = new System.Drawing.Size(79, 20);
            this.txtNumeroDocumentoVenta.TabIndex = 36;
            this.txtNumeroDocumentoVenta.Visible = false;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(213, 43);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(310, 20);
            this.txtNombre.TabIndex = 33;
            // 
            // txtNumeroDocumentoCliente
            // 
            this.txtNumeroDocumentoCliente.Location = new System.Drawing.Point(22, 44);
            this.txtNumeroDocumentoCliente.Name = "txtNumeroDocumentoCliente";
            this.txtNumeroDocumentoCliente.ReadOnly = true;
            this.txtNumeroDocumentoCliente.Size = new System.Drawing.Size(124, 20);
            this.txtNumeroDocumentoCliente.TabIndex = 32;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(210, 27);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 30;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblNumeroDocumentoCliente
            // 
            this.lblNumeroDocumentoCliente.AutoSize = true;
            this.lblNumeroDocumentoCliente.BackColor = System.Drawing.Color.White;
            this.lblNumeroDocumentoCliente.Location = new System.Drawing.Point(19, 27);
            this.lblNumeroDocumentoCliente.Name = "lblNumeroDocumentoCliente";
            this.lblNumeroDocumentoCliente.Size = new System.Drawing.Size(105, 13);
            this.lblNumeroDocumentoCliente.TabIndex = 31;
            this.lblNumeroDocumentoCliente.Text = "Número Documento:";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Producto,
            this.PrecioVenta,
            this.Cantidad,
            this.SubTotal});
            this.dgvData.Location = new System.Drawing.Point(12, 261);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(882, 187);
            this.dgvData.TabIndex = 37;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 400;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.HeaderText = "Precio Venta";
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.ReadOnly = true;
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
            // txtMontoTotal
            // 
            this.txtMontoTotal.Location = new System.Drawing.Point(639, 157);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.ReadOnly = true;
            this.txtMontoTotal.Size = new System.Drawing.Size(112, 20);
            this.txtMontoTotal.TabIndex = 40;
            this.txtMontoTotal.Text = "0";
            // 
            // lblMontoTotal
            // 
            this.lblMontoTotal.AutoSize = true;
            this.lblMontoTotal.BackColor = System.Drawing.Color.White;
            this.lblMontoTotal.Location = new System.Drawing.Point(574, 164);
            this.lblMontoTotal.Name = "lblMontoTotal";
            this.lblMontoTotal.Size = new System.Drawing.Size(67, 13);
            this.lblMontoTotal.TabIndex = 39;
            this.lblMontoTotal.Text = "Monto Total:";
            // 
            // txtMontoPagado
            // 
            this.txtMontoPagado.Location = new System.Drawing.Point(639, 184);
            this.txtMontoPagado.Name = "txtMontoPagado";
            this.txtMontoPagado.ReadOnly = true;
            this.txtMontoPagado.Size = new System.Drawing.Size(112, 20);
            this.txtMontoPagado.TabIndex = 42;
            this.txtMontoPagado.Text = "0";
            // 
            // lblMontoPagado
            // 
            this.lblMontoPagado.AutoSize = true;
            this.lblMontoPagado.BackColor = System.Drawing.Color.White;
            this.lblMontoPagado.Location = new System.Drawing.Point(562, 191);
            this.lblMontoPagado.Name = "lblMontoPagado";
            this.lblMontoPagado.Size = new System.Drawing.Size(80, 13);
            this.lblMontoPagado.TabIndex = 41;
            this.lblMontoPagado.Text = "Monto Pagado:";
            // 
            // txtMontoCambio
            // 
            this.txtMontoCambio.Location = new System.Drawing.Point(639, 218);
            this.txtMontoCambio.Name = "txtMontoCambio";
            this.txtMontoCambio.ReadOnly = true;
            this.txtMontoCambio.Size = new System.Drawing.Size(112, 20);
            this.txtMontoCambio.TabIndex = 44;
            this.txtMontoCambio.Text = "0";
            // 
            // lblMontoCambio
            // 
            this.lblMontoCambio.AutoSize = true;
            this.lblMontoCambio.BackColor = System.Drawing.Color.White;
            this.lblMontoCambio.Location = new System.Drawing.Point(564, 225);
            this.lblMontoCambio.Name = "lblMontoCambio";
            this.lblMontoCambio.Size = new System.Drawing.Size(78, 13);
            this.lblMontoCambio.TabIndex = 43;
            this.lblMontoCambio.Text = "Monto Cambio:";
            // 
            // btnDescargarPDF
            // 
            this.btnDescargarPDF.Location = new System.Drawing.Point(777, 216);
            this.btnDescargarPDF.Name = "btnDescargarPDF";
            this.btnDescargarPDF.Size = new System.Drawing.Size(117, 23);
            this.btnDescargarPDF.TabIndex = 45;
            this.btnDescargarPDF.Text = "Descargar en PDF";
            this.btnDescargarPDF.UseVisualStyleBackColor = true;
            this.btnDescargarPDF.Click += new System.EventHandler(this.btnDescargarPDF_Click);
            // 
            // frmDetalleVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 483);
            this.Controls.Add(this.btnDescargarPDF);
            this.Controls.Add(this.txtMontoCambio);
            this.Controls.Add(this.lblMontoCambio);
            this.Controls.Add(this.txtMontoPagado);
            this.Controls.Add(this.lblMontoPagado);
            this.Controls.Add(this.txtMontoTotal);
            this.Controls.Add(this.lblMontoTotal);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.groupBoxInformacionCliente);
            this.Controls.Add(this.groupBoxInformacionDeVenta);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscarDetalleVenta);
            this.Controls.Add(this.txtNumeroDocumento);
            this.Controls.Add(this.lblNumeroDocumentoSearch);
            this.Controls.Add(this.panelSuperiorDetalleVenta);
            this.Name = "frmDetalleVenta";
            this.Text = "frmDetalleVenta";
            this.groupBoxInformacionDeVenta.ResumeLayout(false);
            this.groupBoxInformacionDeVenta.PerformLayout();
            this.groupBoxInformacionCliente.ResumeLayout(false);
            this.groupBoxInformacionCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label panelSuperiorDetalleVenta;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private FontAwesome.Sharp.IconButton btnBuscarDetalleVenta;
        private System.Windows.Forms.TextBox txtNumeroDocumento;
        private System.Windows.Forms.Label lblNumeroDocumentoSearch;
        private System.Windows.Forms.GroupBox groupBoxInformacionDeVenta;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtTipoDocumento;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox groupBoxInformacionCliente;
        private System.Windows.Forms.TextBox txtNumeroDocumentoVenta;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtNumeroDocumentoCliente;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblNumeroDocumentoCliente;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.TextBox txtMontoTotal;
        private System.Windows.Forms.Label lblMontoTotal;
        private System.Windows.Forms.TextBox txtMontoPagado;
        private System.Windows.Forms.Label lblMontoPagado;
        private System.Windows.Forms.TextBox txtMontoCambio;
        private System.Windows.Forms.Label lblMontoCambio;
        private System.Windows.Forms.Button btnDescargarPDF;
    }
}
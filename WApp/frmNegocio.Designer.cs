
namespace WApp
{
    partial class frmNegocio
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
            this.lblpanelIzquierdo = new System.Windows.Forms.Label();
            this.groupBoxNegocio = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtRUC = new System.Windows.Forms.TextBox();
            this.lblRUC = new System.Windows.Forms.Label();
            this.txtNombreNegocio = new System.Windows.Forms.TextBox();
            this.lblNombreNegocio = new System.Windows.Forms.Label();
            this.btnUploadLogo = new FontAwesome.Sharp.IconButton();
            this.lblLogo = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.groupBoxNegocio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblpanelIzquierdo
            // 
            this.lblpanelIzquierdo.BackColor = System.Drawing.Color.White;
            this.lblpanelIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblpanelIzquierdo.ForeColor = System.Drawing.Color.White;
            this.lblpanelIzquierdo.Location = new System.Drawing.Point(0, 0);
            this.lblpanelIzquierdo.Name = "lblpanelIzquierdo";
            this.lblpanelIzquierdo.Size = new System.Drawing.Size(367, 242);
            this.lblpanelIzquierdo.TabIndex = 1;
            // 
            // groupBoxNegocio
            // 
            this.groupBoxNegocio.BackColor = System.Drawing.Color.White;
            this.groupBoxNegocio.Controls.Add(this.btnGuardar);
            this.groupBoxNegocio.Controls.Add(this.txtDireccion);
            this.groupBoxNegocio.Controls.Add(this.lblDireccion);
            this.groupBoxNegocio.Controls.Add(this.txtRUC);
            this.groupBoxNegocio.Controls.Add(this.lblRUC);
            this.groupBoxNegocio.Controls.Add(this.txtNombreNegocio);
            this.groupBoxNegocio.Controls.Add(this.lblNombreNegocio);
            this.groupBoxNegocio.Controls.Add(this.btnUploadLogo);
            this.groupBoxNegocio.Controls.Add(this.lblLogo);
            this.groupBoxNegocio.Controls.Add(this.picLogo);
            this.groupBoxNegocio.Location = new System.Drawing.Point(12, 22);
            this.groupBoxNegocio.Name = "groupBoxNegocio";
            this.groupBoxNegocio.Size = new System.Drawing.Size(345, 201);
            this.groupBoxNegocio.TabIndex = 2;
            this.groupBoxNegocio.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 16;
            this.btnGuardar.Location = new System.Drawing.Point(217, 163);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(111, 23);
            this.btnGuardar.TabIndex = 23;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(159, 127);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(169, 20);
            this.txtDireccion.TabIndex = 22;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(158, 102);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(55, 13);
            this.lblDireccion.TabIndex = 21;
            this.lblDireccion.Text = "Direccion:";
            // 
            // txtRUC
            // 
            this.txtRUC.Location = new System.Drawing.Point(159, 74);
            this.txtRUC.Name = "txtRUC";
            this.txtRUC.Size = new System.Drawing.Size(169, 20);
            this.txtRUC.TabIndex = 20;
            // 
            // lblRUC
            // 
            this.lblRUC.AutoSize = true;
            this.lblRUC.Location = new System.Drawing.Point(156, 57);
            this.lblRUC.Name = "lblRUC";
            this.lblRUC.Size = new System.Drawing.Size(33, 13);
            this.lblRUC.TabIndex = 19;
            this.lblRUC.Text = "RUC:";
            // 
            // txtNombreNegocio
            // 
            this.txtNombreNegocio.Location = new System.Drawing.Point(159, 32);
            this.txtNombreNegocio.Name = "txtNombreNegocio";
            this.txtNombreNegocio.Size = new System.Drawing.Size(169, 20);
            this.txtNombreNegocio.TabIndex = 18;
            // 
            // lblNombreNegocio
            // 
            this.lblNombreNegocio.AutoSize = true;
            this.lblNombreNegocio.Location = new System.Drawing.Point(156, 16);
            this.lblNombreNegocio.Name = "lblNombreNegocio";
            this.lblNombreNegocio.Size = new System.Drawing.Size(90, 13);
            this.lblNombreNegocio.TabIndex = 17;
            this.lblNombreNegocio.Text = "Nombre Negocio:";
            // 
            // btnUploadLogo
            // 
            this.btnUploadLogo.BackColor = System.Drawing.Color.ForestGreen;
            this.btnUploadLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUploadLogo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnUploadLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadLogo.ForeColor = System.Drawing.Color.White;
            this.btnUploadLogo.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.btnUploadLogo.IconColor = System.Drawing.Color.White;
            this.btnUploadLogo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUploadLogo.IconSize = 16;
            this.btnUploadLogo.Location = new System.Drawing.Point(23, 163);
            this.btnUploadLogo.Name = "btnUploadLogo";
            this.btnUploadLogo.Size = new System.Drawing.Size(106, 23);
            this.btnUploadLogo.TabIndex = 16;
            this.btnUploadLogo.Text = "Guardar";
            this.btnUploadLogo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUploadLogo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUploadLogo.UseVisualStyleBackColor = false;
            this.btnUploadLogo.Click += new System.EventHandler(this.btnUploadLogo_Click);
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Location = new System.Drawing.Point(20, 14);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(31, 13);
            this.lblLogo.TabIndex = 1;
            this.lblLogo.Text = "Logo";
            // 
            // picLogo
            // 
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.Location = new System.Drawing.Point(23, 30);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(115, 117);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // frmNegocio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 242);
            this.Controls.Add(this.groupBoxNegocio);
            this.Controls.Add(this.lblpanelIzquierdo);
            this.Name = "frmNegocio";
            this.Text = "frmNegocio";
            this.Load += new System.EventHandler(this.frmNegocio_Load);
            this.groupBoxNegocio.ResumeLayout(false);
            this.groupBoxNegocio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblpanelIzquierdo;
        private System.Windows.Forms.GroupBox groupBoxNegocio;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.PictureBox picLogo;
        private FontAwesome.Sharp.IconButton btnUploadLogo;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtRUC;
        private System.Windows.Forms.Label lblRUC;
        private System.Windows.Forms.TextBox txtNombreNegocio;
        private System.Windows.Forms.Label lblNombreNegocio;
        private FontAwesome.Sharp.IconButton btnGuardar;
    }
}
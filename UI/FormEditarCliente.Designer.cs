namespace UI
{
    partial class FormEditarCliente
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblCuit = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTipoClienteId = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.comboTipoCliente = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(150, 30);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 22);
            this.txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(150, 70);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(200, 22);
            this.txtApellido.TabIndex = 3;
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(150, 110);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(200, 22);
            this.txtCuit.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(150, 150);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 22);
            this.txtEmail.TabIndex = 7;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(150, 190);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(200, 22);
            this.txtDireccion.TabIndex = 9;
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(30, 30);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(100, 22);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            this.lblApellido.Location = new System.Drawing.Point(30, 70);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(100, 22);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido";
            // 
            // lblCuit
            // 
            this.lblCuit.Location = new System.Drawing.Point(30, 110);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(100, 22);
            this.lblCuit.TabIndex = 4;
            this.lblCuit.Text = "Cuit";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(30, 150);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(100, 22);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email";
            // 
            // lblDireccion
            // 
            this.lblDireccion.Location = new System.Drawing.Point(30, 190);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(100, 22);
            this.lblDireccion.TabIndex = 8;
            this.lblDireccion.Text = "Direccion";
            this.lblDireccion.Click += new System.EventHandler(this.lblDireccion_Click);
            // 
            // lblTipoClienteId
            // 
            this.lblTipoClienteId.Location = new System.Drawing.Point(30, 230);
            this.lblTipoClienteId.Name = "lblTipoClienteId";
            this.lblTipoClienteId.Size = new System.Drawing.Size(100, 22);
            this.lblTipoClienteId.TabIndex = 10;
            this.lblTipoClienteId.Text = "Tipo cliente";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(249, 270);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(101, 30);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Aceptar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(33, 277);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // comboTipoCliente
            // 
            this.comboTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTipoCliente.Location = new System.Drawing.Point(150, 230);
            this.comboTipoCliente.Name = "comboTipoCliente";
            this.comboTipoCliente.Size = new System.Drawing.Size(200, 24);
            this.comboTipoCliente.TabIndex = 11;
            // 
            // FormEditarCliente
            // 
            this.ClientSize = new System.Drawing.Size(400, 330);
            this.Controls.Add(this.comboTipoCliente);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblTipoClienteId);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblCuit);
            this.Controls.Add(this.txtCuit);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombre);
            this.Name = "FormEditarCliente";
            this.Text = "Editar Cliente";
            this.Load += new System.EventHandler(this.FormEditarCliente_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTipoClienteId;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox comboTipoCliente;
    }
}

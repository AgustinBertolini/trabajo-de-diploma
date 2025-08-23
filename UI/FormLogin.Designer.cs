namespace UI
{
    partial class FormLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label_ingresar_email = new System.Windows.Forms.Label();
            this.label_ingresar_contraseña = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.Location = new System.Drawing.Point(326, 300);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(134, 23);
            this.btnIniciarSesion.TabIndex = 0;
            this.btnIniciarSesion.Tag = "label_iniciar_sesion";
            this.btnIniciarSesion.Text = "Iniciar sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = true;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(286, 138);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(214, 22);
            this.txtEmail.TabIndex = 1;
            // 
            // label_ingresar_email
            // 
            this.label_ingresar_email.AutoSize = true;
            this.label_ingresar_email.Location = new System.Drawing.Point(283, 109);
            this.label_ingresar_email.Name = "label_ingresar_email";
            this.label_ingresar_email.Size = new System.Drawing.Size(92, 16);
            this.label_ingresar_email.TabIndex = 2;
            this.label_ingresar_email.Tag = "label_ingresar_email";
            this.label_ingresar_email.Text = "Ingresar email";
            this.label_ingresar_email.Click += new System.EventHandler(this.D_Click);
            // 
            // label_ingresar_contraseña
            // 
            this.label_ingresar_contraseña.AutoSize = true;
            this.label_ingresar_contraseña.Location = new System.Drawing.Point(283, 200);
            this.label_ingresar_contraseña.Name = "label_ingresar_contraseña";
            this.label_ingresar_contraseña.Size = new System.Drawing.Size(126, 16);
            this.label_ingresar_contraseña.TabIndex = 4;
            this.label_ingresar_contraseña.Tag = "label_ingresar_contraseña";
            this.label_ingresar_contraseña.Text = "Ingresar contraseña";
            this.label_ingresar_contraseña.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(286, 229);
            this.txtContraseña.MaxLength = 8;
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(214, 22);
            this.txtContraseña.TabIndex = 3;
            this.txtContraseña.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_ingresar_contraseña);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.label_ingresar_email);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnIniciarSesion);
            this.Name = "FormLogin";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label_ingresar_email;
        private System.Windows.Forms.Label label_ingresar_contraseña;
        private System.Windows.Forms.TextBox txtContraseña;
    }
}


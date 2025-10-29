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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIniciarSesion.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnIniciarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSesion.ForeColor = System.Drawing.SystemColors.Control;
            this.btnIniciarSesion.Location = new System.Drawing.Point(312, 290);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(155, 68);
            this.btnIniciarSesion.TabIndex = 4;
            this.btnIniciarSesion.Tag = "label_iniciar_sesion";
            this.btnIniciarSesion.Text = "Iniciar sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = false;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(286, 130);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(214, 22);
            this.txtEmail.TabIndex = 1;
            // 
            // label_ingresar_email
            // 
            this.label_ingresar_email.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ingresar_email.AutoSize = true;
            this.label_ingresar_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ingresar_email.Location = new System.Drawing.Point(283, 109);
            this.label_ingresar_email.Name = "label_ingresar_email";
            this.label_ingresar_email.Size = new System.Drawing.Size(45, 18);
            this.label_ingresar_email.TabIndex = 0;
            this.label_ingresar_email.Tag = "label_ingresar_email";
            this.label_ingresar_email.Text = "Email";
            this.label_ingresar_email.Click += new System.EventHandler(this.D_Click);
            // 
            // label_ingresar_contraseña
            // 
            this.label_ingresar_contraseña.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ingresar_contraseña.AutoSize = true;
            this.label_ingresar_contraseña.Location = new System.Drawing.Point(283, 200);
            this.label_ingresar_contraseña.Name = "label_ingresar_contraseña";
            this.label_ingresar_contraseña.Size = new System.Drawing.Size(76, 16);
            this.label_ingresar_contraseña.TabIndex = 2;
            this.label_ingresar_contraseña.Tag = "label_ingresar_contraseña";
            this.label_ingresar_contraseña.Text = "Contraseña";
            this.label_ingresar_contraseña.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContraseña.Location = new System.Drawing.Point(286, 219);
            this.txtContraseña.MaxLength = 8;
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(214, 22);
            this.txtContraseña.TabIndex = 3;
            this.txtContraseña.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(331, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bienvenido!";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(282, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Inicia sesión para continuar.";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_ingresar_contraseña);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.label_ingresar_email);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnIniciarSesion);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar sesión";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


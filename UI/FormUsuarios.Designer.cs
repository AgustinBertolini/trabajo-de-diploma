namespace UI
{
    partial class FormUsuarios
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnAsignarPermiso = new System.Windows.Forms.Button();
            this.btnDesasignarPermiso = new System.Windows.Forms.Button();
            this.btnCopiarCartera = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 28);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(967, 286);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 6;
            this.label1.Tag = "label_usuarios";
            this.label1.Text = "Usuarios";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddUser.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAddUser.Location = new System.Drawing.Point(12, 331);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(129, 37);
            this.btnAddUser.TabIndex = 0;
            this.btnAddUser.Tag = "label_agregar_usuario";
            this.btnAddUser.Text = "Agregar usuario";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEditUser.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEditUser.Location = new System.Drawing.Point(147, 331);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(128, 37);
            this.btnEditUser.TabIndex = 1;
            this.btnEditUser.Tag = "label_editar_usuario";
            this.btnEditUser.Text = "Editar usuario";
            this.btnEditUser.UseVisualStyleBackColor = false;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDeleteUser.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDeleteUser.Location = new System.Drawing.Point(597, 331);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(177, 37);
            this.btnDeleteUser.TabIndex = 4;
            this.btnDeleteUser.Tag = "label_borrar_usuario";
            this.btnDeleteUser.Text = "Borrar usuario";
            this.btnDeleteUser.UseVisualStyleBackColor = false;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnAsignarPermiso
            // 
            this.btnAsignarPermiso.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAsignarPermiso.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAsignarPermiso.Location = new System.Drawing.Point(281, 331);
            this.btnAsignarPermiso.Name = "btnAsignarPermiso";
            this.btnAsignarPermiso.Size = new System.Drawing.Size(139, 37);
            this.btnAsignarPermiso.TabIndex = 2;
            this.btnAsignarPermiso.Tag = "label_asignar_permiso";
            this.btnAsignarPermiso.Text = "Asignar permiso";
            this.btnAsignarPermiso.UseVisualStyleBackColor = false;
            this.btnAsignarPermiso.Click += new System.EventHandler(this.btnAsignarPermiso_Click);
            // 
            // btnDesasignarPermiso
            // 
            this.btnDesasignarPermiso.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDesasignarPermiso.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDesasignarPermiso.Location = new System.Drawing.Point(426, 331);
            this.btnDesasignarPermiso.Name = "btnDesasignarPermiso";
            this.btnDesasignarPermiso.Size = new System.Drawing.Size(165, 37);
            this.btnDesasignarPermiso.TabIndex = 3;
            this.btnDesasignarPermiso.Tag = "label_desasignar_permiso";
            this.btnDesasignarPermiso.Text = "Desasignar permisos";
            this.btnDesasignarPermiso.UseVisualStyleBackColor = false;
            this.btnDesasignarPermiso.Click += new System.EventHandler(this.btnDesasignarPermiso_Click);
            // 
            // btnCopiarCartera
            // 
            this.btnCopiarCartera.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCopiarCartera.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCopiarCartera.Location = new System.Drawing.Point(780, 331);
            this.btnCopiarCartera.Name = "btnCopiarCartera";
            this.btnCopiarCartera.Size = new System.Drawing.Size(199, 37);
            this.btnCopiarCartera.TabIndex = 7;
            this.btnCopiarCartera.Tag = "label_copiar_cartera";
            this.btnCopiarCartera.Text = "Copiar cartera de clientes";
            this.btnCopiarCartera.UseVisualStyleBackColor = false;
            this.btnCopiarCartera.Click += new System.EventHandler(this.btnCopiarCartera_Click);
            // 
            // FormUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(996, 380);
            this.Controls.Add(this.btnCopiarCartera);
            this.Controls.Add(this.btnDesasignarPermiso);
            this.Controls.Add(this.btnAsignarPermiso);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnEditUser);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormUsuarios";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.FormUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnAsignarPermiso;
        private System.Windows.Forms.Button btnDesasignarPermiso;
        private System.Windows.Forms.Button btnCopiarCartera;
    }
}
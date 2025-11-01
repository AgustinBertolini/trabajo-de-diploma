namespace UI
{
    partial class FormPermisos
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
            this.btnDeletePermiso = new System.Windows.Forms.Button();
            this.btnEditPermiso = new System.Windows.Forms.Button();
            this.btnAddPermiso = new System.Windows.Forms.Button();
            this.btnVincularPermisos = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // btnDeletePermiso
            // 
            this.btnDeletePermiso.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDeletePermiso.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnDeletePermiso.Location = new System.Drawing.Point(715, 342);
            this.btnDeletePermiso.Name = "btnDeletePermiso";
            this.btnDeletePermiso.Size = new System.Drawing.Size(177, 45);
            this.btnDeletePermiso.TabIndex = 4;
            this.btnDeletePermiso.Tag = "label_borrar_permiso";
            this.btnDeletePermiso.Text = "Borrar permiso";
            this.btnDeletePermiso.UseVisualStyleBackColor = false;
            this.btnDeletePermiso.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnEditPermiso
            // 
            this.btnEditPermiso.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEditPermiso.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEditPermiso.Location = new System.Drawing.Point(715, 160);
            this.btnEditPermiso.Name = "btnEditPermiso";
            this.btnEditPermiso.Size = new System.Drawing.Size(177, 47);
            this.btnEditPermiso.TabIndex = 2;
            this.btnEditPermiso.Tag = "label_editar_permiso";
            this.btnEditPermiso.Text = "Editar permiso";
            this.btnEditPermiso.UseVisualStyleBackColor = false;
            this.btnEditPermiso.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnAddPermiso
            // 
            this.btnAddPermiso.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddPermiso.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAddPermiso.Location = new System.Drawing.Point(715, 64);
            this.btnAddPermiso.Name = "btnAddPermiso";
            this.btnAddPermiso.Size = new System.Drawing.Size(177, 47);
            this.btnAddPermiso.TabIndex = 1;
            this.btnAddPermiso.Tag = "label_agregar_permiso";
            this.btnAddPermiso.Text = "Agregar permiso";
            this.btnAddPermiso.UseVisualStyleBackColor = false;
            this.btnAddPermiso.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnVincularPermisos
            // 
            this.btnVincularPermisos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnVincularPermisos.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnVincularPermisos.Location = new System.Drawing.Point(715, 252);
            this.btnVincularPermisos.Name = "btnVincularPermisos";
            this.btnVincularPermisos.Size = new System.Drawing.Size(177, 50);
            this.btnVincularPermisos.TabIndex = 3;
            this.btnVincularPermisos.Tag = "label_vincular_permisos";
            this.btnVincularPermisos.Text = "Vincular permisos";
            this.btnVincularPermisos.UseVisualStyleBackColor = false;
            this.btnVincularPermisos.Click += new System.EventHandler(this.btnVincularPermisos_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.treeView1.Location = new System.Drawing.Point(28, 64);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(649, 323);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // FormPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(942, 443);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnVincularPermisos);
            this.Controls.Add(this.btnDeletePermiso);
            this.Controls.Add(this.btnEditPermiso);
            this.Controls.Add(this.btnAddPermiso);
            this.Name = "FormPermisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permisos";
            this.Load += new System.EventHandler(this.FormPermisos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDeletePermiso;
        private System.Windows.Forms.Button btnEditPermiso;
        private System.Windows.Forms.Button btnAddPermiso;
        private System.Windows.Forms.Button btnVincularPermisos;
        private System.Windows.Forms.TreeView treeView1;
    }
}
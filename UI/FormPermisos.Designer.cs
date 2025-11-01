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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarIdiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presupuestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnVincularPermisos = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
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
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sesiónToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.cambiarIdiomaToolStripMenuItem,
            this.bitacoraToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.presupuestosToolStripMenuItem,
            this.ventasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(942, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // sesiónToolStripMenuItem
            // 
            this.sesiónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesiónToolStripMenuItem});
            this.sesiónToolStripMenuItem.Name = "sesiónToolStripMenuItem";
            this.sesiónToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.sesiónToolStripMenuItem.Tag = "label_sesion";
            this.sesiónToolStripMenuItem.Text = "Sesión";
            this.sesiónToolStripMenuItem.Click += new System.EventHandler(this.sesiónToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.cerrarSesiónToolStripMenuItem.Tag = "label_cerrar_sesion";
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.usuariosToolStripMenuItem.Tag = "label_usuarios";
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.productosToolStripMenuItem.Tag = "label_productos";
            this.productosToolStripMenuItem.Text = "Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
            // 
            // cambiarIdiomaToolStripMenuItem
            // 
            this.cambiarIdiomaToolStripMenuItem.Name = "cambiarIdiomaToolStripMenuItem";
            this.cambiarIdiomaToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.cambiarIdiomaToolStripMenuItem.Tag = "label_traducciones";
            this.cambiarIdiomaToolStripMenuItem.Text = "Traducciones";
            this.cambiarIdiomaToolStripMenuItem.Click += new System.EventHandler(this.cambiarIdiomaToolStripMenuItem_Click_1);
            // 
            // bitacoraToolStripMenuItem
            // 
            this.bitacoraToolStripMenuItem.Name = "bitacoraToolStripMenuItem";
            this.bitacoraToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.bitacoraToolStripMenuItem.Tag = "label_bitacora";
            this.bitacoraToolStripMenuItem.Text = "Bitacora";
            this.bitacoraToolStripMenuItem.Click += new System.EventHandler(this.bitacoraToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.clientesToolStripMenuItem.Tag = "label_clientes";
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // presupuestosToolStripMenuItem
            // 
            this.presupuestosToolStripMenuItem.Name = "presupuestosToolStripMenuItem";
            this.presupuestosToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.presupuestosToolStripMenuItem.Tag = "label_presupuestos";
            this.presupuestosToolStripMenuItem.Text = "Presupuestos";
            this.presupuestosToolStripMenuItem.Click += new System.EventHandler(this.presupuestosToolStripMenuItem_Click);
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.ventasToolStripMenuItem.Tag = "label_ventas";
            this.ventasToolStripMenuItem.Text = "Ventas";
            this.ventasToolStripMenuItem.Click += new System.EventHandler(this.ventasToolStripMenuItem_Click);
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
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormPermisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Permisos";
            this.Load += new System.EventHandler(this.FormPermisos_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeletePermiso;
        private System.Windows.Forms.Button btnEditPermiso;
        private System.Windows.Forms.Button btnAddPermiso;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.Button btnVincularPermisos;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarIdiomaToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem bitacoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presupuestosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
    }
}
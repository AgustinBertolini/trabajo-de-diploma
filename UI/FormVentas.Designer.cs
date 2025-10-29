namespace UI
{
    partial class FormVentas
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarIdiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presupuestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCrearVenta = new System.Windows.Forms.Button();
            this.btnVerVenta = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sesiónToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.permisosToolStripMenuItem,
            this.cambiarIdiomaToolStripMenuItem,
            this.bitacoraToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.presupuestosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 4;
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
            // permisosToolStripMenuItem
            // 
            this.permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            this.permisosToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.permisosToolStripMenuItem.Tag = "label_permisos";
            this.permisosToolStripMenuItem.Text = "Permisos";
            this.permisosToolStripMenuItem.Click += new System.EventHandler(this.permisosToolStripMenuItem_Click);
            // 
            // cambiarIdiomaToolStripMenuItem
            // 
            this.cambiarIdiomaToolStripMenuItem.Name = "cambiarIdiomaToolStripMenuItem";
            this.cambiarIdiomaToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.cambiarIdiomaToolStripMenuItem.Tag = "label_traducciones";
            this.cambiarIdiomaToolStripMenuItem.Text = "Traducciones";
            this.cambiarIdiomaToolStripMenuItem.Click += new System.EventHandler(this.cambiarIdiomaToolStripMenuItem_Click);
            // 
            // bitacoraToolStripMenuItem
            // 
            this.bitacoraToolStripMenuItem.Name = "bitacoraToolStripMenuItem";
            this.bitacoraToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.bitacoraToolStripMenuItem.Tag = "label_bitacora";
            this.bitacoraToolStripMenuItem.Text = "Bitacora";
            this.bitacoraToolStripMenuItem.Click += new System.EventHandler(this.bitacoraToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.productosToolStripMenuItem.Tag = "label_productos";
            this.productosToolStripMenuItem.Text = "Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
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
            this.presupuestosToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.presupuestosToolStripMenuItem.Text = "Presupuesto";
            this.presupuestosToolStripMenuItem.Click += new System.EventHandler(this.presupuestosToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ventas";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 61);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(739, 279);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnCrearVenta
            // 
            this.btnCrearVenta.Location = new System.Drawing.Point(15, 380);
            this.btnCrearVenta.Name = "btnCrearVenta";
            this.btnCrearVenta.Size = new System.Drawing.Size(118, 23);
            this.btnCrearVenta.TabIndex = 2;
            this.btnCrearVenta.Text = "Crear venta";
            this.btnCrearVenta.UseVisualStyleBackColor = true;
            this.btnCrearVenta.Click += new System.EventHandler(this.btnCrearVenta_Click);
            // 
            // btnVerVenta
            // 
            this.btnVerVenta.Location = new System.Drawing.Point(659, 380);
            this.btnVerVenta.Name = "btnVerVenta";
            this.btnVerVenta.Size = new System.Drawing.Size(95, 23);
            this.btnVerVenta.TabIndex = 3;
            this.btnVerVenta.Text = "Ver venta";
            this.btnVerVenta.UseVisualStyleBackColor = true;
            this.btnVerVenta.Click += new System.EventHandler(this.btnVerVenta_Click);
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVerVenta);
            this.Controls.Add(this.btnCrearVenta);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormVentas";
            this.Text = "FormVentas";
            this.Load += new System.EventHandler(this.FormVentas_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarIdiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitacoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presupuestosToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCrearVenta;
        private System.Windows.Forms.Button btnVerVenta;
    }
}
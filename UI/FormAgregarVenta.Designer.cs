namespace UI
{
    partial class FormAgregarVenta
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
            this.numericSubTotal = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.comboClientes = new System.Windows.Forms.ComboBox();
            this.labelTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCrearPresupuesto = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAñadirProducto = new System.Windows.Forms.Button();
            this.numericCantidad = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.comboProductos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colProductoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericSubTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericSubTotal
            // 
            this.numericSubTotal.Location = new System.Drawing.Point(618, 245);
            this.numericSubTotal.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.numericSubTotal.Name = "numericSubTotal";
            this.numericSubTotal.Size = new System.Drawing.Size(169, 22);
            this.numericSubTotal.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(615, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Subtotal";
            // 
            // comboClientes
            // 
            this.comboClientes.FormattingEnabled = true;
            this.comboClientes.Location = new System.Drawing.Point(16, 33);
            this.comboClientes.Name = "comboClientes";
            this.comboClientes.Size = new System.Drawing.Size(201, 24);
            this.comboClientes.TabIndex = 1;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(60, 386);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(11, 16);
            this.labelTotal.TabIndex = 12;
            this.labelTotal.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 385);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Total:";
            // 
            // btnCrearPresupuesto
            // 
            this.btnCrearPresupuesto.Location = new System.Drawing.Point(618, 414);
            this.btnCrearPresupuesto.Name = "btnCrearPresupuesto";
            this.btnCrearPresupuesto.Size = new System.Drawing.Size(161, 23);
            this.btnCrearPresupuesto.TabIndex = 10;
            this.btnCrearPresupuesto.Tag = "label_crear_presupuesto";
            this.btnCrearPresupuesto.Text = "Crear venta";
            this.btnCrearPresupuesto.UseVisualStyleBackColor = true;
            this.btnCrearPresupuesto.Click += new System.EventHandler(this.btnCrearPresupuesto_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(16, 414);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Tag = "label_cancelar";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAñadirProducto
            // 
            this.btnAñadirProducto.Location = new System.Drawing.Point(658, 286);
            this.btnAñadirProducto.Name = "btnAñadirProducto";
            this.btnAñadirProducto.Size = new System.Drawing.Size(71, 23);
            this.btnAñadirProducto.TabIndex = 8;
            this.btnAñadirProducto.Tag = "label_agregar";
            this.btnAñadirProducto.Text = "Agregar";
            this.btnAñadirProducto.UseVisualStyleBackColor = true;
            this.btnAñadirProducto.Click += new System.EventHandler(this.btnAñadirProducto_Click);
            // 
            // numericCantidad
            // 
            this.numericCantidad.Location = new System.Drawing.Point(618, 191);
            this.numericCantidad.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.numericCantidad.Name = "numericCantidad";
            this.numericCantidad.Size = new System.Drawing.Size(169, 22);
            this.numericCantidad.TabIndex = 5;
            this.numericCantidad.ValueChanged += new System.EventHandler(this.numericCantidad_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(615, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 4;
            this.label4.Tag = "label_cantidad";
            this.label4.Text = "Cantidad";
            // 
            // comboProductos
            // 
            this.comboProductos.FormattingEnabled = true;
            this.comboProductos.Location = new System.Drawing.Point(618, 137);
            this.comboProductos.Name = "comboProductos";
            this.comboProductos.Size = new System.Drawing.Size(169, 24);
            this.comboProductos.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(615, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 2;
            this.label3.Tag = "label_producto";
            this.label3.Text = "Producto";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductoId,
            this.colNombre,
            this.colPrecio,
            this.colCantidad,
            this.colSubTotal});
            this.dataGridView1.Location = new System.Drawing.Point(16, 117);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(572, 240);
            this.dataGridView1.TabIndex = 14;
            // 
            // colProductoId
            // 
            this.colProductoId.HeaderText = "Id";
            this.colProductoId.MinimumWidth = 6;
            this.colProductoId.Name = "colProductoId";
            this.colProductoId.ReadOnly = true;
            this.colProductoId.Width = 50;
            // 
            // colNombre
            // 
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.MinimumWidth = 6;
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            this.colNombre.Width = 120;
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.MinimumWidth = 6;
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            this.colPrecio.Width = 80;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.MinimumWidth = 6;
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            this.colCantidad.Width = 80;
            // 
            // colSubTotal
            // 
            this.colSubTotal.HeaderText = "Subtotal";
            this.colSubTotal.MinimumWidth = 6;
            this.colSubTotal.Name = "colSubTotal";
            this.colSubTotal.ReadOnly = true;
            this.colSubTotal.Width = 90;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 13;
            this.label2.Tag = "label_productos";
            this.label2.Text = "Productos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Tag = "label_cliente";
            this.label1.Text = "Cliente";
            // 
            // FormAgregarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numericSubTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboClientes);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCrearPresupuesto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAñadirProducto);
            this.Controls.Add(this.numericCantidad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboProductos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormAgregarVenta";
            this.Text = "Agregar venta";
            this.Load += new System.EventHandler(this.FormAgregarVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericSubTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericSubTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboClientes;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCrearPresupuesto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAñadirProducto;
        private System.Windows.Forms.NumericUpDown numericCantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboProductos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
namespace UI
{
    partial class FormAgregarPresupuesto
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.comboProductos = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAñadirProducto = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnCrearPresupuesto = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.comboClientes = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericSubTotal = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSubTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Tag = "label_cliente";
            this.label1.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 2;
            this.label2.Tag = "label_productos";
            this.label2.Text = "Productos";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 123);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(369, 150);
            this.dataGridView1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(424, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 3;
            this.label3.Tag = "label_producto";
            this.label3.Text = "Producto";
            // 
            // comboProductos
            // 
            this.comboProductos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProductos.FormattingEnabled = true;
            this.comboProductos.Location = new System.Drawing.Point(427, 143);
            this.comboProductos.Name = "comboProductos";
            this.comboProductos.Size = new System.Drawing.Size(173, 24);
            this.comboProductos.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(424, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 5;
            this.label4.Tag = "label_cantidad";
            this.label4.Text = "Cantidad";
            // 
            // numericCantidad
            // 
            this.numericCantidad.Location = new System.Drawing.Point(427, 197);
            this.numericCantidad.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.numericCantidad.Name = "numericCantidad";
            this.numericCantidad.Size = new System.Drawing.Size(173, 22);
            this.numericCantidad.TabIndex = 6;
            this.numericCantidad.ValueChanged += new System.EventHandler(this.numericCantidad_ValueChanged);
            // 
            // btnAñadirProducto
            // 
            this.btnAñadirProducto.Location = new System.Drawing.Point(467, 292);
            this.btnAñadirProducto.Name = "btnAñadirProducto";
            this.btnAñadirProducto.Size = new System.Drawing.Size(75, 23);
            this.btnAñadirProducto.TabIndex = 9;
            this.btnAñadirProducto.Tag = "label_agregar";
            this.btnAñadirProducto.Text = "Agregar";
            this.btnAñadirProducto.UseVisualStyleBackColor = true;
            this.btnAñadirProducto.Click += new System.EventHandler(this.btnAñadirProducto_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(30, 346);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Tag = "label_cancelar";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnCrearPresupuesto
            // 
            this.btnCrearPresupuesto.Location = new System.Drawing.Point(450, 346);
            this.btnCrearPresupuesto.Name = "btnCrearPresupuesto";
            this.btnCrearPresupuesto.Size = new System.Drawing.Size(150, 23);
            this.btnCrearPresupuesto.TabIndex = 11;
            this.btnCrearPresupuesto.Tag = "label_crear_presupuesto";
            this.btnCrearPresupuesto.Text = "Crear presupuesto";
            this.btnCrearPresupuesto.UseVisualStyleBackColor = true;
            this.btnCrearPresupuesto.Click += new System.EventHandler(this.btnCrearPresupuesto_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Total:";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(74, 300);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(11, 16);
            this.labelTotal.TabIndex = 14;
            this.labelTotal.Text = "-";
            // 
            // comboClientes
            // 
            this.comboClientes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboClientes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboClientes.FormattingEnabled = true;
            this.comboClientes.Location = new System.Drawing.Point(30, 39);
            this.comboClientes.Name = "comboClientes";
            this.comboClientes.Size = new System.Drawing.Size(201, 24);
            this.comboClientes.TabIndex = 1;
            this.comboClientes.SelectedIndexChanged += new System.EventHandler(this.comboClientes_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(424, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Subtotal";
            // 
            // numericSubTotal
            // 
            this.numericSubTotal.Location = new System.Drawing.Point(427, 251);
            this.numericSubTotal.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.numericSubTotal.Name = "numericSubTotal";
            this.numericSubTotal.Size = new System.Drawing.Size(173, 22);
            this.numericSubTotal.TabIndex = 8;
            // 
            // FormAgregarPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 389);
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
            this.Name = "FormAgregarPresupuesto";
            this.Text = "Agregar presupuesto";
            this.Load += new System.EventHandler(this.FormAgregarPresupuesto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSubTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboProductos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericCantidad;
        private System.Windows.Forms.Button btnAñadirProducto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnCrearPresupuesto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.ComboBox comboClientes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericSubTotal;
    }
}
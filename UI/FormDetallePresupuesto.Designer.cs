namespace UI
{
    partial class FormDetallePresupuesto
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
            this.label3 = new System.Windows.Forms.Label();
            this.labelCliente = new System.Windows.Forms.Label();
            this.labelCorreo = new System.Windows.Forms.Label();
            this.labelDireccion = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Direccion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Correo:";
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Location = new System.Drawing.Point(38, 58);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(11, 16);
            this.labelCliente.TabIndex = 1;
            this.labelCliente.Text = "-";
            // 
            // labelCorreo
            // 
            this.labelCorreo.AutoSize = true;
            this.labelCorreo.Location = new System.Drawing.Point(38, 97);
            this.labelCorreo.Name = "labelCorreo";
            this.labelCorreo.Size = new System.Drawing.Size(11, 16);
            this.labelCorreo.TabIndex = 7;
            this.labelCorreo.Text = "-";
            // 
            // labelDireccion
            // 
            this.labelDireccion.AutoSize = true;
            this.labelDireccion.Location = new System.Drawing.Point(200, 58);
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Size = new System.Drawing.Size(11, 16);
            this.labelDireccion.TabIndex = 3;
            this.labelDireccion.Text = "-";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(41, 143);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(627, 241);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Productos";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(41, 438);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(81, 23);
            this.btnVolver.TabIndex = 12;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(532, 438);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Convertir en venta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(327, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Fecha presupuesto";
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Location = new System.Drawing.Point(327, 58);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(11, 16);
            this.labelFecha.TabIndex = 5;
            this.labelFecha.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 398);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Total:";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(78, 398);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(11, 16);
            this.labelTotal.TabIndex = 11;
            this.labelTotal.Text = "-";
            // 
            // FormDetallePresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 479);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelDireccion);
            this.Controls.Add(this.labelCorreo);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormDetallePresupuesto";
            this.Text = "Detalle de presupuesto";
            this.Load += new System.EventHandler(this.FormDetallePresupuesto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Label labelCorreo;
        private System.Windows.Forms.Label labelDireccion;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelTotal;
    }
}
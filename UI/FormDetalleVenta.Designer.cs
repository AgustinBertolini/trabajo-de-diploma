namespace UI
{
    partial class FormDetalleVenta
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
            this.labelTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelDireccion = new System.Windows.Forms.Label();
            this.labelCorreo = new System.Windows.Forms.Label();
            this.labelCliente = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioBtnPreparacion = new System.Windows.Forms.RadioButton();
            this.radioBtnCamino = new System.Windows.Forms.RadioButton();
            this.radioBtnEntregado = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTotal
            // 
            this.labelTotal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(70, 376);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(11, 16);
            this.labelTotal.TabIndex = 13;
            this.labelTotal.Text = "-";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 376);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Total:";
            // 
            // labelFecha
            // 
            this.labelFecha.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelFecha.AutoSize = true;
            this.labelFecha.Location = new System.Drawing.Point(204, 36);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(11, 16);
            this.labelFecha.TabIndex = 3;
            this.labelFecha.Text = "-";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Fecha presupuesto";
            // 
            // btnVolver
            // 
            this.btnVolver.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnVolver.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnVolver.Location = new System.Drawing.Point(33, 395);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(95, 44);
            this.btnVolver.TabIndex = 14;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Productos";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 121);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(627, 241);
            this.dataGridView1.TabIndex = 15;
            // 
            // labelDireccion
            // 
            this.labelDireccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelDireccion.AutoSize = true;
            this.labelDireccion.Location = new System.Drawing.Point(552, 36);
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Size = new System.Drawing.Size(0, 16);
            this.labelDireccion.TabIndex = 19;
            // 
            // labelCorreo
            // 
            this.labelCorreo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelCorreo.AutoSize = true;
            this.labelCorreo.Location = new System.Drawing.Point(30, 75);
            this.labelCorreo.Name = "labelCorreo";
            this.labelCorreo.Size = new System.Drawing.Size(11, 16);
            this.labelCorreo.TabIndex = 9;
            this.labelCorreo.Text = "-";
            // 
            // labelCliente
            // 
            this.labelCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelCliente.AutoSize = true;
            this.labelCliente.Location = new System.Drawing.Point(30, 36);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(11, 16);
            this.labelCliente.TabIndex = 1;
            this.labelCliente.Text = "-";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Correo:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Estado de envio:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente:";
            // 
            // radioBtnPreparacion
            // 
            this.radioBtnPreparacion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioBtnPreparacion.AutoSize = true;
            this.radioBtnPreparacion.Location = new System.Drawing.Point(555, 36);
            this.radioBtnPreparacion.Name = "radioBtnPreparacion";
            this.radioBtnPreparacion.Size = new System.Drawing.Size(120, 20);
            this.radioBtnPreparacion.TabIndex = 5;
            this.radioBtnPreparacion.TabStop = true;
            this.radioBtnPreparacion.Text = "En preparación";
            this.radioBtnPreparacion.UseVisualStyleBackColor = true;
            this.radioBtnPreparacion.CheckedChanged += new System.EventHandler(this.radioBtnPreparacion_CheckedChanged);
            // 
            // radioBtnCamino
            // 
            this.radioBtnCamino.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioBtnCamino.AutoSize = true;
            this.radioBtnCamino.Location = new System.Drawing.Point(555, 62);
            this.radioBtnCamino.Name = "radioBtnCamino";
            this.radioBtnCamino.Size = new System.Drawing.Size(91, 20);
            this.radioBtnCamino.TabIndex = 6;
            this.radioBtnCamino.TabStop = true;
            this.radioBtnCamino.Text = "En camino";
            this.radioBtnCamino.UseVisualStyleBackColor = true;
            this.radioBtnCamino.CheckedChanged += new System.EventHandler(this.radioBtnCamino_CheckedChanged);
            // 
            // radioBtnEntregado
            // 
            this.radioBtnEntregado.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.radioBtnEntregado.AutoSize = true;
            this.radioBtnEntregado.Location = new System.Drawing.Point(555, 88);
            this.radioBtnEntregado.Name = "radioBtnEntregado";
            this.radioBtnEntregado.Size = new System.Drawing.Size(91, 20);
            this.radioBtnEntregado.TabIndex = 7;
            this.radioBtnEntregado.TabStop = true;
            this.radioBtnEntregado.Text = "Entregado";
            this.radioBtnEntregado.UseVisualStyleBackColor = true;
            this.radioBtnEntregado.CheckedChanged += new System.EventHandler(this.radioBtnEntregado_CheckedChanged);
            // 
            // FormDetalleVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.radioBtnEntregado);
            this.Controls.Add(this.radioBtnCamino);
            this.Controls.Add(this.radioBtnPreparacion);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelDireccion);
            this.Controls.Add(this.labelCorreo);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormDetalleVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle de venta";
            this.Load += new System.EventHandler(this.FormDetalleVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelDireccion;
        private System.Windows.Forms.Label labelCorreo;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioBtnPreparacion;
        private System.Windows.Forms.RadioButton radioBtnCamino;
        private System.Windows.Forms.RadioButton radioBtnEntregado;
    }
}
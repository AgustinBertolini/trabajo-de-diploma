namespace UI
{
    partial class FormReportes
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTicketPromedio = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelRecaudacionTotal = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelVentasTotales = new System.Windows.Forms.Label();
            this.chartVentasPorVendedor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRecaudacionPorVendedor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartProductosMasVendidos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRecaudacionPorProducto = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasPorVendedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRecaudacionPorVendedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProductosMasVendidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRecaudacionPorProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(157, 455);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Productos mas vendidos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(964, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ticket promedio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(711, 455);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Recaudacion por producto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(708, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Recaudacion por vendedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(164, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ventas por vendedor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(535, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Recaudacion total";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(88, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Ventas totales";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.labelTicketPromedio);
            this.panel1.Location = new System.Drawing.Point(927, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 106);
            this.panel1.TabIndex = 7;
            // 
            // labelTicketPromedio
            // 
            this.labelTicketPromedio.AutoSize = true;
            this.labelTicketPromedio.BackColor = System.Drawing.SystemColors.Control;
            this.labelTicketPromedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTicketPromedio.Location = new System.Drawing.Point(3, 37);
            this.labelTicketPromedio.Name = "labelTicketPromedio";
            this.labelTicketPromedio.Size = new System.Drawing.Size(79, 29);
            this.labelTicketPromedio.TabIndex = 0;
            this.labelTicketPromedio.Text = "label8";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Controls.Add(this.labelRecaudacionTotal);
            this.panel2.Location = new System.Drawing.Point(505, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 106);
            this.panel2.TabIndex = 8;
            // 
            // labelRecaudacionTotal
            // 
            this.labelRecaudacionTotal.AutoSize = true;
            this.labelRecaudacionTotal.BackColor = System.Drawing.SystemColors.Control;
            this.labelRecaudacionTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecaudacionTotal.Location = new System.Drawing.Point(3, 37);
            this.labelRecaudacionTotal.Name = "labelRecaudacionTotal";
            this.labelRecaudacionTotal.Size = new System.Drawing.Size(79, 29);
            this.labelRecaudacionTotal.TabIndex = 0;
            this.labelRecaudacionTotal.Text = "label8";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel3.Controls.Add(this.labelVentasTotales);
            this.panel3.Location = new System.Drawing.Point(42, 36);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(186, 106);
            this.panel3.TabIndex = 9;
            // 
            // labelVentasTotales
            // 
            this.labelVentasTotales.AutoSize = true;
            this.labelVentasTotales.BackColor = System.Drawing.SystemColors.Control;
            this.labelVentasTotales.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVentasTotales.Location = new System.Drawing.Point(3, 37);
            this.labelVentasTotales.Name = "labelVentasTotales";
            this.labelVentasTotales.Size = new System.Drawing.Size(79, 29);
            this.labelVentasTotales.TabIndex = 0;
            this.labelVentasTotales.Text = "label8";
            this.labelVentasTotales.Click += new System.EventHandler(this.label9_Click);
            // 
            // chartVentasPorVendedor
            // 
            chartArea5.Name = "ChartArea1";
            this.chartVentasPorVendedor.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartVentasPorVendedor.Legends.Add(legend5);
            this.chartVentasPorVendedor.Location = new System.Drawing.Point(12, 190);
            this.chartVentasPorVendedor.Name = "chartVentasPorVendedor";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.chartVentasPorVendedor.Series.Add(series5);
            this.chartVentasPorVendedor.Size = new System.Drawing.Size(460, 225);
            this.chartVentasPorVendedor.TabIndex = 1;
            this.chartVentasPorVendedor.Text = "chart1";
            // 
            // chartRecaudacionPorVendedor
            // 
            chartArea6.Name = "ChartArea1";
            this.chartRecaudacionPorVendedor.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chartRecaudacionPorVendedor.Legends.Add(legend6);
            this.chartRecaudacionPorVendedor.Location = new System.Drawing.Point(515, 190);
            this.chartRecaudacionPorVendedor.Name = "chartRecaudacionPorVendedor";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chartRecaudacionPorVendedor.Series.Add(series6);
            this.chartRecaudacionPorVendedor.Size = new System.Drawing.Size(569, 225);
            this.chartRecaudacionPorVendedor.TabIndex = 10;
            this.chartRecaudacionPorVendedor.Text = "chart2";
            // 
            // chartProductosMasVendidos
            // 
            chartArea7.Name = "ChartArea1";
            this.chartProductosMasVendidos.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chartProductosMasVendidos.Legends.Add(legend7);
            this.chartProductosMasVendidos.Location = new System.Drawing.Point(12, 482);
            this.chartProductosMasVendidos.Name = "chartProductosMasVendidos";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chartProductosMasVendidos.Series.Add(series7);
            this.chartProductosMasVendidos.Size = new System.Drawing.Size(460, 230);
            this.chartProductosMasVendidos.TabIndex = 11;
            this.chartProductosMasVendidos.Text = "chart1";
            // 
            // chartRecaudacionPorProducto
            // 
            chartArea8.Name = "ChartArea1";
            this.chartRecaudacionPorProducto.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chartRecaudacionPorProducto.Legends.Add(legend8);
            this.chartRecaudacionPorProducto.Location = new System.Drawing.Point(505, 482);
            this.chartRecaudacionPorProducto.Name = "chartRecaudacionPorProducto";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chartRecaudacionPorProducto.Series.Add(series8);
            this.chartRecaudacionPorProducto.Size = new System.Drawing.Size(579, 230);
            this.chartRecaudacionPorProducto.TabIndex = 12;
            this.chartRecaudacionPorProducto.Text = "chart1";
            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1166, 724);
            this.Controls.Add(this.chartRecaudacionPorProducto);
            this.Controls.Add(this.chartProductosMasVendidos);
            this.Controls.Add(this.chartRecaudacionPorVendedor);
            this.Controls.Add(this.chartVentasPorVendedor);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.FormReportes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentasPorVendedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRecaudacionPorVendedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProductosMasVendidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRecaudacionPorProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTicketPromedio;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelRecaudacionTotal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelVentasTotales;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentasPorVendedor;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRecaudacionPorVendedor;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProductosMasVendidos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRecaudacionPorProducto;
    }
}
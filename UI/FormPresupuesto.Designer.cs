namespace UI
{
    partial class FormPresupuesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPresupuesto));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCrearPresupuesto = new System.Windows.Forms.Button();
            this.btnVerPresupuesto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Tag = "label_presupuesto";
            // 
            // btnCrearPresupuesto
            // 
            resources.ApplyResources(this.btnCrearPresupuesto, "btnCrearPresupuesto");
            this.btnCrearPresupuesto.Name = "btnCrearPresupuesto";
            this.btnCrearPresupuesto.Tag = "label_crear_presupuesto";
            this.btnCrearPresupuesto.UseVisualStyleBackColor = true;
            this.btnCrearPresupuesto.Click += new System.EventHandler(this.btnCrearPresupuesto_Click);
            // 
            // btnVerPresupuesto
            // 
            resources.ApplyResources(this.btnVerPresupuesto, "btnVerPresupuesto");
            this.btnVerPresupuesto.Name = "btnVerPresupuesto";
            this.btnVerPresupuesto.Tag = "label_ver_presupuesto";
            this.btnVerPresupuesto.UseVisualStyleBackColor = true;
            this.btnVerPresupuesto.Click += new System.EventHandler(this.btnVerPresupuesto_Click);
            // 
            // FormPresupuesto
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.btnVerPresupuesto);
            this.Controls.Add(this.btnCrearPresupuesto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormPresupuesto";
            this.Load += new System.EventHandler(this.FormPresupuesto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCrearPresupuesto;
        private System.Windows.Forms.Button btnVerPresupuesto;
    }
}
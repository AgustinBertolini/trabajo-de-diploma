namespace UI
{
    partial class FormTraducciones
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
            this.agregarIdiomaBtn = new System.Windows.Forms.Button();
            this.editarIdiomaBtn = new System.Windows.Forms.Button();
            this.borrarIdiomaBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnEditarTraduccion = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // agregarIdiomaBtn
            // 
            this.agregarIdiomaBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.agregarIdiomaBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.agregarIdiomaBtn.Location = new System.Drawing.Point(317, 51);
            this.agregarIdiomaBtn.Name = "agregarIdiomaBtn";
            this.agregarIdiomaBtn.Size = new System.Drawing.Size(161, 32);
            this.agregarIdiomaBtn.TabIndex = 0;
            this.agregarIdiomaBtn.Tag = "label_agregar_idioma";
            this.agregarIdiomaBtn.Text = "Agregar Idioma";
            this.agregarIdiomaBtn.UseVisualStyleBackColor = false;
            this.agregarIdiomaBtn.Click += new System.EventHandler(this.tag_Click);
            // 
            // editarIdiomaBtn
            // 
            this.editarIdiomaBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.editarIdiomaBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.editarIdiomaBtn.Location = new System.Drawing.Point(317, 114);
            this.editarIdiomaBtn.Name = "editarIdiomaBtn";
            this.editarIdiomaBtn.Size = new System.Drawing.Size(161, 34);
            this.editarIdiomaBtn.TabIndex = 1;
            this.editarIdiomaBtn.Tag = "label_editar_idioma";
            this.editarIdiomaBtn.Text = "Editar Idioma";
            this.editarIdiomaBtn.UseVisualStyleBackColor = false;
            this.editarIdiomaBtn.Click += new System.EventHandler(this.editarIdiomaBtn_Click);
            // 
            // borrarIdiomaBtn
            // 
            this.borrarIdiomaBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.borrarIdiomaBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.borrarIdiomaBtn.Location = new System.Drawing.Point(317, 174);
            this.borrarIdiomaBtn.Name = "borrarIdiomaBtn";
            this.borrarIdiomaBtn.Size = new System.Drawing.Size(161, 33);
            this.borrarIdiomaBtn.TabIndex = 2;
            this.borrarIdiomaBtn.Tag = "label_borrar_idioma";
            this.borrarIdiomaBtn.Text = "Borrar Idioma";
            this.borrarIdiomaBtn.UseVisualStyleBackColor = false;
            this.borrarIdiomaBtn.Click += new System.EventHandler(this.borrarIdiomaBtn_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 10;
            this.label1.Tag = "label_idiomas";
            this.label1.Text = "Idiomas";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(29, 254);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(592, 268);
            this.dataGridView2.TabIndex = 7;
            // 
            // btnEditarTraduccion
            // 
            this.btnEditarTraduccion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEditarTraduccion.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnEditarTraduccion.Location = new System.Drawing.Point(627, 254);
            this.btnEditarTraduccion.Name = "btnEditarTraduccion";
            this.btnEditarTraduccion.Size = new System.Drawing.Size(161, 42);
            this.btnEditarTraduccion.TabIndex = 5;
            this.btnEditarTraduccion.Tag = "label_editar_traduccion";
            this.btnEditarTraduccion.Text = "Editar traducción";
            this.btnEditarTraduccion.UseVisualStyleBackColor = false;
            this.btnEditarTraduccion.Click += new System.EventHandler(this.btnEditarTraduccion_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 16);
            this.label2.TabIndex = 8;
            this.label2.Tag = "label_traducciones_idioma";
            this.label2.Text = "Traducciones del idioma seleccionado";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 51);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(261, 156);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button1.Location = new System.Drawing.Point(627, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 46);
            this.button1.TabIndex = 6;
            this.button1.Tag = "label_historico";
            this.button1.Text = "Historico";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormTraducciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(796, 617);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEditarTraduccion);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.borrarIdiomaBtn);
            this.Controls.Add(this.editarIdiomaBtn);
            this.Controls.Add(this.agregarIdiomaBtn);
            this.Name = "FormTraducciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traducciones";
            this.Load += new System.EventHandler(this.FormTraducciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button agregarIdiomaBtn;
        private System.Windows.Forms.Button editarIdiomaBtn;
        private System.Windows.Forms.Button borrarIdiomaBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnEditarTraduccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
    }
}
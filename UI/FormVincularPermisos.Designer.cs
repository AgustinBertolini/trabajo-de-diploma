namespace UI
{
    partial class FormVincularPermisos
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
            this.comboPadre = new System.Windows.Forms.ComboBox();
            this.comboHijo = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnVincular = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Permiso padre";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Permiso hijo";
            // 
            // comboPadre
            // 
            this.comboPadre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboPadre.FormattingEnabled = true;
            this.comboPadre.Location = new System.Drawing.Point(35, 45);
            this.comboPadre.Name = "comboPadre";
            this.comboPadre.Size = new System.Drawing.Size(220, 24);
            this.comboPadre.TabIndex = 1;
            // 
            // comboHijo
            // 
            this.comboHijo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboHijo.FormattingEnabled = true;
            this.comboHijo.Location = new System.Drawing.Point(35, 112);
            this.comboHijo.Name = "comboHijo";
            this.comboHijo.Size = new System.Drawing.Size(217, 24);
            this.comboHijo.TabIndex = 3;
            this.comboHijo.SelectedIndexChanged += new System.EventHandler(this.comboHijo_SelectedIndexChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCancelar.Location = new System.Drawing.Point(38, 181);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 37);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Tag = "label_cancelar";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVincular
            // 
            this.btnVincular.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnVincular.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnVincular.Location = new System.Drawing.Point(156, 181);
            this.btnVincular.Name = "btnVincular";
            this.btnVincular.Size = new System.Drawing.Size(90, 37);
            this.btnVincular.TabIndex = 5;
            this.btnVincular.Tag = "label_vincular";
            this.btnVincular.Text = "Vincular";
            this.btnVincular.UseVisualStyleBackColor = false;
            this.btnVincular.Click += new System.EventHandler(this.btnVincular_Click);
            // 
            // FormVincularPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(284, 245);
            this.Controls.Add(this.btnVincular);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.comboHijo);
            this.Controls.Add(this.comboPadre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormVincularPermisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vincular permisos";
            this.Load += new System.EventHandler(this.FormVincularPermisos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboPadre;
        private System.Windows.Forms.ComboBox comboHijo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnVincular;
    }
}
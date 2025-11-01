namespace UI
{
    partial class FormConversaciones
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
            this.flowPanelConversaciones = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowPanelConversaciones
            // 
            this.flowPanelConversaciones.AutoScroll = true;
            this.flowPanelConversaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelConversaciones.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelConversaciones.Location = new System.Drawing.Point(0, 0);
            this.flowPanelConversaciones.Name = "flowPanelConversaciones";
            this.flowPanelConversaciones.Size = new System.Drawing.Size(800, 450);
            this.flowPanelConversaciones.TabIndex = 0;
            this.flowPanelConversaciones.WrapContents = false;
            // 
            // FormConversaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowPanelConversaciones);
            this.Name = "FormConversaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tus conversaciones";
            this.Load += new System.EventHandler(this.FormConversaciones_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowPanelConversaciones;
    }
}
using BLL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormConversacion : Form
    {
        private Timer mensajeTimer;
        ConversacionBLL conversacionBLL = new ConversacionBLL();
        int idConversacion;
        public FormConversacion(int? idConversacion)
        {
            InitializeComponent();
            this.idConversacion = idConversacion ?? 0;
        }

        private void FormConversacion_Load(object sender, EventArgs e)
        {
            flowPanelMensajes.FlowDirection = FlowDirection.TopDown;
            flowPanelMensajes.WrapContents = false;
            flowPanelMensajes.AutoScroll = true;
            flowPanelMensajes.BackColor = Color.WhiteSmoke;

            textBox1.MaxLength = 240;

            CargarMensajesDeConversacion();

            mensajeTimer = new Timer();
            mensajeTimer.Interval = 5000;
            mensajeTimer.Tick += (s, ev) => CargarMensajesDeConversacion();
            mensajeTimer.Start();
        }

        private void CargarMensajesDeConversacion()
        {
            flowPanelMensajes.Controls.Clear();

            List<Mensaje> mensajes = conversacionBLL.GetMensajesByConversacion(idConversacion);
            int usuarioActualId = SessionManager.GetInstance.Usuario.Id;

            foreach (var mensaje in mensajes)
            {
                bool esPropio = mensaje.IdEmisor == usuarioActualId;

                Panel burbuja = new Panel();
                burbuja.AutoSize = true;
                burbuja.MaximumSize = new Size(flowPanelMensajes.Width - 250, 0);
                burbuja.Padding = new Padding(10);
                burbuja.Margin = new Padding(10, 5, 10, 5);
                burbuja.BackColor = esPropio
                    ? Color.FromArgb(0, 132, 255)  
                    : Color.FromArgb(230, 230, 230); 

                Label lblMensaje = new Label();
                lblMensaje.AutoSize = true;
                lblMensaje.MaximumSize = new Size(flowPanelMensajes.Width - 250, 0);
                lblMensaje.Text = mensaje.Texto;
                lblMensaje.Font = new Font("Segoe UI", 10);
                lblMensaje.ForeColor = esPropio ? Color.White : Color.Black;
                lblMensaje.TextAlign = ContentAlignment.MiddleLeft;

                Label lblFecha = new Label();
                lblFecha.AutoSize = true;
                lblFecha.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                lblFecha.ForeColor = esPropio ? Color.WhiteSmoke : Color.Gray;
                lblFecha.Text = mensaje.FechaEnvio.ToString("dd/MM/yy HH:mm");

                var layoutInterno = new FlowLayoutPanel();
                layoutInterno.FlowDirection = FlowDirection.TopDown;
                layoutInterno.WrapContents = false;
                layoutInterno.AutoSize = true;
                layoutInterno.BackColor = Color.Transparent;
                layoutInterno.Controls.Add(lblMensaje);
                layoutInterno.Controls.Add(lblFecha);

                burbuja.Controls.Add(layoutInterno);

                if (esPropio)
                {
                    burbuja.Anchor = AnchorStyles.Right;
                    burbuja.Margin = new Padding(flowPanelMensajes.Width / 3, 5, 10, 5);
                }
                else
                {
                    burbuja.Anchor = AnchorStyles.Left;
                    burbuja.Margin = new Padding(10, 5, flowPanelMensajes.Width / 3, 5);
                }

                flowPanelMensajes.Controls.Add(burbuja);
                flowPanelMensajes.SetFlowBreak(burbuja, true);
            }

            if (flowPanelMensajes.Controls.Count > 0)
                flowPanelMensajes.ScrollControlIntoView(
                    flowPanelMensajes.Controls[flowPanelMensajes.Controls.Count - 1]);
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mensaje = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(mensaje))
            {
                Mensaje mensajeEntidad = new Mensaje
                {
                    Texto = mensaje,
                    FechaEnvio = DateTime.Now,
                    IdConversacion = idConversacion,
                    IdEmisor = SessionManager.GetInstance.Usuario.Id
                };
                conversacionBLL.EnviarMensaje(mensajeEntidad);
                textBox1.Clear();
                CargarMensajesDeConversacion();

            }
            else
            {
                MessageBox.Show("El mensaje no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class FormConversaciones : Form
    {
        private ConversacionBLL conversacionBLL = new ConversacionBLL();
        private UsuarioBLL usuarioBLL = new UsuarioBLL();

        public FormConversaciones()
        {
            InitializeComponent();
        }

        private void FormConversaciones_Load(object sender, EventArgs e)
        {
            flowPanelConversaciones.FlowDirection = FlowDirection.TopDown;
            flowPanelConversaciones.WrapContents = false;
            flowPanelConversaciones.AutoScroll = true;
            flowPanelConversaciones.BackColor = Color.WhiteSmoke;

            CargarConversacionesDelUsuario();
        }

        private void CargarConversacionesDelUsuario()
        {
            flowPanelConversaciones.Controls.Clear();

            int idUsuarioActual = SessionManager.GetInstance.Usuario.Id;
            List<Conversacion> conversaciones = conversacionBLL.GetConversacionesByUsuario(idUsuarioActual);
            List<Usuario> usuarios = usuarioBLL.GetUsuarios();

            foreach (var conv in conversaciones)
            {
                Usuario otroUsuario = usuarios.FirstOrDefault(x=>x.Id == conv.IdUsuario);

                Mensaje ultimoMensaje = conversacionBLL.GetMensajesByConversacion(conv.Id).OrderByDescending(x => x.FechaEnvio).FirstOrDefault();

                Panel card = new Panel();
                card.Width = flowPanelConversaciones.Width - 40;
                card.Height = 70;
                card.Margin = new Padding(10);
                card.BackColor = Color.White;
                card.BorderStyle = BorderStyle.FixedSingle;
                card.Cursor = Cursors.Hand;

                Label lblNombre = new Label();
                lblNombre.Text = $"{otroUsuario.Nombre} {otroUsuario.Apellido}";
                lblNombre.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                lblNombre.Location = new Point(10, 10);
                lblNombre.AutoSize = true;

                Label lblMensaje = new Label();
                string textoMensaje = ultimoMensaje != null ? ultimoMensaje.Texto : "(Sin mensajes aún)";
                if (textoMensaje.Length > 40)
                    textoMensaje = textoMensaje.Substring(0, 40) + "...";

                lblMensaje.Text = textoMensaje;
                lblMensaje.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                lblMensaje.ForeColor = Color.DimGray;
                lblMensaje.Location = new Point(10, 35);
                lblMensaje.AutoSize = true;

                Label lblFecha = new Label();
                lblFecha.Text = ultimoMensaje != null
                    ? ultimoMensaje.FechaEnvio.ToString("dd/MM/yy HH:mm")
                    : "";
                lblFecha.Font = new Font("Segoe UI", 8, FontStyle.Italic);
                lblFecha.ForeColor = Color.Gray;
                lblFecha.Anchor = AnchorStyles.Right;
                lblFecha.AutoSize = true;
                lblFecha.Location = new Point(card.Width - 120, 10);

                card.Controls.Add(lblNombre);
                card.Controls.Add(lblMensaje);
                card.Controls.Add(lblFecha);

                card.Click += (s, e) =>
                {
                    FormConversacion formChat = new FormConversacion(conv.Id);
                    formChat.Show();
                    this.Hide();
                };

                flowPanelConversaciones.Controls.Add(card);
            }

            if (conversaciones.Count == 0)
            {
                Label lblVacio = new Label();
                lblVacio.Text = "No tenés conversaciones todavía.";
                lblVacio.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                lblVacio.ForeColor = Color.Gray;
                lblVacio.Dock = DockStyle.Top;
                flowPanelConversaciones.Controls.Add(lblVacio);
            }
        }
    }
}

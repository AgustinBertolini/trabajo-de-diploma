using BLL;
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
    public partial class FormInicioAdmin : Form
    {
        public FormInicioAdmin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FormUsuarios formUsuarios = new FormUsuarios();
            formUsuarios.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FormUsuarios formUsuarios = new FormUsuarios();
            formUsuarios.Show();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            FormUsuarios formUsuarios = new FormUsuarios();
            formUsuarios.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            FormProductos formProductos = new FormProductos();
            formProductos.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FormProductos formProductos = new FormProductos();
            formProductos.Show();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            FormProductos formProductos = new FormProductos();
            formProductos.Show();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            FormTraducciones formTraducciones= new FormTraducciones();
            formTraducciones.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            FormTraducciones formTraducciones = new FormTraducciones();
            formTraducciones.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            FormTraducciones formTraducciones = new FormTraducciones();
            formTraducciones.Show();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            FormVentas formVentas = new FormVentas();
            formVentas.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            FormVentas formVentas = new FormVentas();
            formVentas.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            FormVentas formVentas = new FormVentas();
            formVentas.Show();
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            FormBitacora formBitacora = new FormBitacora();
            formBitacora.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            FormBitacora formBitacora = new FormBitacora();
            formBitacora.Show();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            FormBitacora formBitacora = new FormBitacora();
            formBitacora.Show();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            Application.Exit();

            //UsuarioBLL usuarioBLL = new UsuarioBLL();

            //usuarioBLL.Logout();

            //FormLogin formLogin = new FormLogin();
            //formLogin.Show();

            //this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Application.Exit();

            //UsuarioBLL usuarioBLL = new UsuarioBLL();

            //usuarioBLL.Logout();

            //FormLogin formLogin = new FormLogin();
            //formLogin.Show();

            //this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();

            //UsuarioBLL usuarioBLL = new UsuarioBLL();

            //usuarioBLL.Logout();

            //FormLogin formLogin = new FormLogin();
            //formLogin.Show();

            //this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            FormConversaciones formConversaciones = new FormConversaciones();
            formConversaciones.Show();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            FormConversaciones formConversaciones = new FormConversaciones();
            formConversaciones.Show();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            FormConversaciones formConversaciones = new FormConversaciones();
            formConversaciones.Show();
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            FormPermisos formPermisos = new FormPermisos();
            formPermisos.Show();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            FormPermisos formPermisos = new FormPermisos();
            formPermisos.Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            FormPermisos formPermisos = new FormPermisos();
            formPermisos.Show();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            FormReportes formReportes = new FormReportes();
            formReportes.Show();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            FormReportes formReportes = new FormReportes();
            formReportes.Show();
        }

        private void panel9_Click(object sender, EventArgs e)
        {
            FormReportes formReportes = new FormReportes();
            formReportes.Show();
        }
    }
}

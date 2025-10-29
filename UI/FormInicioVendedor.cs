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
    public partial class FormInicioVendedor : Form
    {
        public FormInicioVendedor()
        {
            InitializeComponent();
        }

        private void FormInicioVendedor_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                ctrl.Click += (s, ev) => panel1_Click(panel5, EventArgs.Empty);
            }

            foreach (Control ctrl in panel2.Controls)
            {
                ctrl.Click += (s, ev) => panel2_Click(panel5, EventArgs.Empty);
            }

            foreach (Control ctrl in panel3.Controls)
            {
                ctrl.Click += (s, ev) => panel3_Click(panel5, EventArgs.Empty);
            }

            foreach (Control ctrl in panel4.Controls)
            {
                ctrl.Click += (s, ev) => panel4_Click(panel5, EventArgs.Empty);
            }

            foreach (Control ctrl in panel5.Controls)
            {
                ctrl.Click += (s, ev) => panel5_Click(panel5, EventArgs.Empty);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Click(object sender, EventArgs e)
        {
            UsuarioBLL usuarioBLL = new UsuarioBLL();

            usuarioBLL.Logout();

            FormLogin formLogin = new FormLogin();
            formLogin.Show();

            this.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            FormVentas form = new FormVentas();
            form.Show();

        }

        private void panel3_Click(object sender, EventArgs e)
        {
            FormPresupuesto form = new FormPresupuesto();
            form.Show();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            FormProductos form = new FormProductos();
            form.Show();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            FormClientes form = new FormClientes();
            form.Show();
        }
    }
}

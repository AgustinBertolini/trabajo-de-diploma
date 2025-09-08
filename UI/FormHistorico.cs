using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entidades;
using Servicios;

namespace UI
{
    public partial class FormHistorico : Form
    {
        public FormHistorico()
        {
            InitializeComponent();
            Traducir();
            dataGridView1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No hay una traduccion seleccionada");
                return;
            }

            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Se tiene que seleccionar una unica traduccion");
                return;
            }


            int idTraduccion = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IdTraduccion"].Value);
            string valorViejo = dataGridView1.SelectedRows[0].Cells["ValorViejo"].Value.ToString() ;

            Traductor.EditarTraduccion(idTraduccion, valorViejo);

            FormTraducciones form = new FormTraducciones();
            form.Show();

            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormTraducciones form = new FormTraducciones();
            form.Show();

            this.Hide();
        }

        public void Traducir()
        {
            var idioma = SessionManager.GetInstance.Usuario.Idioma;

            var traducciones = Traductor.GetTraducciones(idioma.Id);

            foreach (Control control in this.Controls)
            {
                if (control.Tag != null)
                {
                    var tag = control.Tag.ToString();
                    var traduccion = traducciones.FirstOrDefault(x => x.Tag == tag);
                    if (traduccion != null)
                        control.Text = traduccion.Valor;
                }
            }

        }

        private void FormHistorico_Load(object sender, EventArgs e)
        {
            TraduccionHistoricoBLL traduccionHistoricoBLL = new TraduccionHistoricoBLL();

            if (!(SessionManager.TienePermiso("Bitacora") || SessionManager.TienePermiso("Listar Bitacora")))
            {
                MessageBox.Show("No tenes permisos suficientes para ver la bitacora");
                return;
            }

            IdiomaBLL idiomaBll = new IdiomaBLL();

            var data = traduccionHistoricoBLL.GetHistoricos().Select(historico=> new
            {
                Fecha = historico.Fecha,
                ValorViejo = historico.ValorViejo,
                ValorNuevo = historico.ValorNuevo,
                IdTraduccion = historico.IdTraduccion,
                Traduccion = Traductor.GetTraduccion(historico.IdTraduccion).Tag,
                Idioma = idiomaBll.GetIdioma(Traductor.GetTraduccion(historico.IdTraduccion).IdIdioma).Nombre
            }).OrderByDescending(b => b.Fecha).ToList();

            var dataSource = data;

            dataGridView1.DataSource = dataSource;
            dataGridView1.Columns["ValorViejo"].Width = 180;
            dataGridView1.Columns["ValorNuevo"].Width = 180;
            dataGridView1.Columns["IdTraduccion"].Visible = false;
        }
    }
}

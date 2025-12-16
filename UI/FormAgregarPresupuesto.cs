using BLL;
using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{

    public partial class FormAgregarPresupuesto : Form
    {
        internal class PresupuestoItemGrid
        {
            public int ProductoId { get; set; }
            public string Nombre { get; set; } = "";
            public decimal PrecioUnitario { get; set; }
            public int Cantidad { get; set; }
            public decimal SubTotal => PrecioUnitario * Cantidad;
        }
        private List<PresupuestoItemGrid> _items = new List<PresupuestoItemGrid>();
        private BindingSource _bs = new BindingSource();

        public FormAgregarPresupuesto()
        {
            InitializeComponent();

            numericSubTotal.Enabled = false;

            numericCantidad.Minimum = 0;
            numericCantidad.Maximum = 100;
        }

        private void CargarProductosEnComboBox()
        {
            ProductoBLL productoBLL = new ProductoBLL();
            var productos = productoBLL.GetProductosByUserId(SessionManager.GetInstance.Usuario.Id);
            comboProductos.DataSource = productos;
            comboProductos.DisplayMember = "Nombre";
            comboProductos.ValueMember = "Id";
        }

        private void CargarClientesEnComboBox()
        {
            ClienteBLL clienteBLL = new ClienteBLL();
            var clientes = clienteBLL.GetClientes().Where(x => x.UserId == SessionManager.GetInstance.Usuario.Id && x.Activo == true).ToList();
            comboClientes.DataSource = clientes;
            comboClientes.DisplayMember = "Nombre";
            comboClientes.ValueMember = "Id";
        }

        private void CalcularSubTotal()
        {
            if (comboProductos.SelectedItem is Entidades.Producto producto)
            {
                int cantidad = (int)numericCantidad.Value;
                decimal precio = Convert.ToDecimal(producto.Precio);
                decimal subTotal = precio * cantidad;
                numericSubTotal.Value = subTotal >= numericSubTotal.Minimum && subTotal <= numericSubTotal.Maximum
                    ? subTotal
                    : numericSubTotal.Minimum;
            }
        }

        private void AgregarProductoAlDataGridView()
        {
            try
            {
                if (comboProductos.SelectedItem is Entidades.Producto producto)
                {
                    int cantidadNueva = (int)numericCantidad.Value;
                    if (cantidadNueva <= 0)
                    {
                        MessageBox.Show("La cantidad debe ser mayor a 0.");
                        return;
                    }

                    var existente = _items.FirstOrDefault(i => i.ProductoId == producto.Id);
                    if (existente != null)
                    {
                        existente.Cantidad += cantidadNueva;
                    }
                    else
                    {
                        _items.Add(new PresupuestoItemGrid
                        {
                            ProductoId = producto.Id,
                            Nombre = producto.Nombre,
                            PrecioUnitario = Convert.ToDecimal(producto.Precio),
                            Cantidad = cantidadNueva
                        });
                    }

                    _bs.ResetBindings(false);
                }
                else
                {
                    MessageBox.Show("Seleccione un producto válido.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo agregar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularLabelTotal()
        {
            decimal total = _items.Sum(i => i.SubTotal);
            CultureInfo culturaArgentina = new CultureInfo("es-AR");
            labelTotal.Text = total.ToString("C", culturaArgentina);
        }

        private void LimpiarSelecciones()
        {
            comboProductos.SelectedIndex = -1;
            numericCantidad.Value = 0;
            numericSubTotal.Value = 0;
        }

        private void FormAgregarPresupuesto_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = _items;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.Columns["ProductoId"].Visible = false;
            _bs.DataSource = _items;
            dataGridView1.DataSource = _bs;

            numericCantidad.Maximum = 999999;

            

            comboClientes.DropDownStyle = ComboBoxStyle.DropDown;
            comboClientes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboClientes.AutoCompleteSource = AutoCompleteSource.ListItems;

            comboProductos.DropDownStyle = ComboBoxStyle.DropDown;
            comboProductos.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboProductos.AutoCompleteSource = AutoCompleteSource.ListItems;

            CargarProductosEnComboBox();
            CargarClientesEnComboBox();
        }

        private void FormAgregarPresupuesto_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormPresupuesto form = new FormPresupuesto();
            form.Show();

            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormPresupuesto form = new FormPresupuesto();
            form.Show();
            this.Hide();
        }

        private void numericCantidad_ValueChanged(object sender, EventArgs e)
        {
            CalcularSubTotal();
        }

        private void btnAñadirProducto_Click(object sender, EventArgs e)
        {
            AgregarProductoAlDataGridView();
            CalcularLabelTotal();
            LimpiarSelecciones();
        }

        private async void btnCrearPresupuesto_Click(object sender, EventArgs e)
        {
            if (_items.Count < 1)
            {
                MessageBox.Show("Debe agregar al menos un producto al presupuesto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboClientes.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un cliente para enviar el presupuesto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            DialogResult resultado = MessageBox.Show(
                "¿Estás seguro de querer enviar este presupuesto?\n\n" +
                "Esto le enviará un correo al cliente informándole los ítems seleccionados.\n" +
                "Tenés 48 horas para pasar este presupuesto a una venta efectiva.",
                "Confirmar envío de presupuesto",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    PresupuestoBLL presupuestoBLL = new PresupuestoBLL();

                    List<PresupuestoItem> items = _items.Select(i => new PresupuestoItem
                    {
                        IdProducto = i.ProductoId,
                        Cantidad = i.Cantidad,
                        PrecioUnitario = i.PrecioUnitario
                    }).ToList();

                    Presupuesto presupuesto = new Presupuesto
                    {
                        FechaCreacion = DateTime.Now,
                        IdCliente = (comboClientes.SelectedItem as Cliente)?.Id ?? 0,
                        Items = items
                    };

                    presupuestoBLL.AltaPresupuesto(presupuesto, items);

                    MessageBox.Show("Presupuesto enviado correctamente al cliente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormPresupuesto form = new FormPresupuesto();
                    form.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al enviar el correo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Envío cancelado.", "Operación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormPresupuesto form = new FormPresupuesto();
                form.Show();
                this.Hide();
            }
        }

        private void comboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCrearPresupuesto_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_items.Count < 1)
                {
                    MessageBox.Show("Debe agregar al menos un producto al presupuesto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboClientes.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un cliente para enviar el presupuesto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                DialogResult resultado = MessageBox.Show(
                    "¿Estás seguro de querer enviar este presupuesto?\n\n" +
                    "Esto le enviará un correo al cliente informándole los ítems seleccionados.\n" +
                    "Tenés 48 horas para pasar este presupuesto a una venta efectiva.",
                    "Confirmar envío de presupuesto",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        PresupuestoBLL presupuestoBLL = new PresupuestoBLL();

                        List<PresupuestoItem> items = _items.Select(i => new PresupuestoItem
                        {
                            IdProducto = i.ProductoId,
                            Cantidad = i.Cantidad,
                            PrecioUnitario = i.PrecioUnitario
                        }).ToList();

                        Presupuesto presupuesto = new Presupuesto
                        {
                            FechaCreacion = DateTime.Now,
                            IdCliente = (comboClientes.SelectedItem as Cliente)?.Id ?? 0,
                            Items = items
                        };

                        presupuestoBLL.AltaPresupuesto(presupuesto, items);

                        MessageBox.Show("Presupuesto enviado correctamente al cliente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        FormPresupuesto form = new FormPresupuesto();
                        form.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al enviar el correo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Envío cancelado.", "Operación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormPresupuesto form = new FormPresupuesto();
                    form.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}

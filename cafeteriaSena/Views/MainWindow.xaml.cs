using cafeteriaSena.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cafeteriaSena.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     
       
        public MainWindow()
        {
            InitializeComponent();
            llenarCmbEstado();
            llenarCmbCategoria();
        }

        public void llenarCmbEstado()
        {
            using (var db = new GestioncafeteriaContext())
            {
                var consulta = from estado in db.TEstadoProductos
                               select estado;

                cmbEstado.SelectedValuePath = "Id";
                cmbEstado.DisplayMemberPath = "Estado";
                cmbEstado.ItemsSource = consulta.ToList();
            }
        }

        public void llenarCmbCategoria()
        {
            using (var db = new GestioncafeteriaContext())
            {
                var consulta = from categoria in db.TCategorias
                               select categoria;

              

                cmbCategoria.SelectedValuePath = "Id";
                cmbCategoria.DisplayMemberPath = "Nombre";
                cmbCategoria.ItemsSource = consulta.ToList();
            }
        }

        public bool llenarCampos()
        {
            if (!string.IsNullOrEmpty(txtReferencia.Text) &&
                !string.IsNullOrEmpty(txtNombre.Text) &&
                !string.IsNullOrEmpty(txtPrecio.Text) &&
                !string.IsNullOrEmpty(txtCantidad.Text) &&
                !string.IsNullOrEmpty(txtDescripcion.Text) &&
                cmbCategoria.SelectedIndex != -1 &&
                cmbEstado.SelectedIndex != -1 &&
                dtpFechaVencimiento.SelectedDate.HasValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void limpiarCajas()
        {
            cmbCategoria.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            txtReferencia.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            dtpFechaVencimiento.SelectedDate = null;
        }

        public void guardarProducto()
        {
            try
            {
                if (llenarCampos())
                {
                    using (var db = new GestioncafeteriaContext())
                    {
                        TProducto producto = new TProducto();
                        producto.Referencia = txtReferencia.Text;
                        producto.Nombre = txtNombre.Text;
                        producto.Precio = int.Parse(txtPrecio.Text);
                        producto.Cantidad = int.Parse(txtCantidad.Text);
                        producto.Descripcion = txtDescripcion.Text;
                        producto.IdEstado = int.Parse(cmbEstado.SelectedValue.ToString());
                        producto.IdCategoria = int.Parse(cmbCategoria.SelectedValue.ToString());
                        producto.FechaVencimiento = DateOnly.Parse(dtpFechaVencimiento.Text);

                        db.TProductos.Add(producto);
                        db.SaveChanges();
                        MessageBox.Show("¡Guardado con éxito!", "REGISTRO EXITOSO", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        limpiarCajas();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor llene todos los campos.", "COMPLETAR CAMPOS", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el producto: " + ex, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            guardarProducto();
        }
    }
}
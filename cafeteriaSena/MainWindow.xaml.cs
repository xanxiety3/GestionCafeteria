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

namespace cafeteriaSena
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
            Close();
        }

       

        //public void llenarCmbEstado()
        //{
        //    using (var db = new GestioncafeteriaContext())
        //    {
        //        var consulta = from estado in db.TEstadoProductos
        //                       select estado;

        //        cmbEstado.SelectedValuePath = "Id";
        //        cmbEstado.DisplayMemberPath = "Estado";
        //        cmbEstado.ItemsSource = consulta.ToList();
        //    }
        //}

        //public void llenarCmbCategoria()
        //{
        //    using (var db = new GestioncafeteriaContext())
        //    {
        //        var consulta = from categoria in db.TCategorias
        //                       select categoria;

        //        cmbCategoria.SelectedValuePath = "Id";
        //        cmbCategoria.DisplayMemberPath = "Nombre";
        //        cmbCategoria.ItemsSource = consulta.ToList();
        //    }
        //}

        //public void guardarProducto()
        //{
        //    using (var db = new GestioncafeteriaContext())
        //    {
        //        TProducto producto = new TProducto();
        //        producto.Referencia = txtReferencia.Text;
        //        producto.Nombre = txtNombre.Text;
        //        producto.Precio = int.Parse(txtPrecio.Text);
        //        producto.Descripcion = txtDescripcion.Text;
        //        producto.IdEstado = int.Parse(cmbEstado.SelectedValue.ToString());
        //        producto.IdCategoria = int.Parse(cmbCategoria.SelectedValue.ToString());
        //        //producto.FechaVencimiento = dtpFechaVencimiento.SelectedDate;


        //        //db.TProductos.Add(producto);
        //        //db.SaveChanges();
        //        //MessageBox.Show("¡Guardado con éxito!", "REGISTRO EXITOSO", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        //    }
        //}
    }
}
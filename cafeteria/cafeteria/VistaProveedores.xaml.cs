using cafeteria.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace cafeteria
{
    /// <summary>
    /// Lógica de interacción para VistaProveedores.xaml
    /// </summary>
    public partial class VistaProveedores : Window
    {
        public VistaProveedores()
        {
            InitializeComponent();
            llenarTabla();
        }

        public class modeloProveedor
        {
            public int Id { get; set; }
            public string NIT { get; set; }
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public string Contacto { get; set; }
        }

        public void llenarTabla()
        {
            using (var db = new GestioncafeteriaContext())
            {
                var consulta = from proveedor in db.TProveedores
                               select new modeloProveedor
                               {
                                   Id = proveedor.Id,
                                   NIT = proveedor.Nit.ToString(),
                                   Nombre = proveedor.Nombre,
                                   Direccion = proveedor.Direccion,
                                   Contacto = proveedor.Contacto.ToString(),

                               };

                dgProveedores.ItemsSource = consulta.ToList();
            }
        }

        public void filtrarProveedor(string busqueda)
        {
            using (var db = new GestioncafeteriaContext())
            {
                var consulta = from proveedor in db.TProveedores
                               where proveedor.Nombre.Contains(busqueda) ||
                                     proveedor.Nit.ToString().Contains(busqueda)
                               select new modeloProveedor
                               {
                                   Id = proveedor.Id,
                                   NIT = proveedor.Nit.ToString(),
                                   Nombre = proveedor.Nombre,
                                   Direccion = proveedor.Direccion,
                                   Contacto = proveedor.Contacto.ToString(),
                               };

                dgProveedores.ItemsSource = consulta.ToList();
            }
        }

        public void numeroResultados()
        {
            string busqueda = txtBusqueda.Text;
            int numResultado = dgProveedores.Items.Count;
            lblCantidadRegistro.Content = "No hay resultados";

            if (numResultado > 0)
            {
                lblCantidadRegistro.Visibility = Visibility.Visible;
                lblCantidadRegistro.Content = $"{numResultado} Resultados";
            }

            if (numResultado > 0 && numResultado < 2)
            {
                lblCantidadRegistro.Visibility = Visibility.Visible;
                lblCantidadRegistro.Content = $"{numResultado} Resultado";
            }

            if (busqueda.IsNullOrEmpty())
            {
                lblCantidadRegistro.Visibility = Visibility.Collapsed;
            }

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new GestioncafeteriaContext())
            {
                int idProveedor = (int)((Button)sender).CommandParameter;
                var proveedor = db.TProveedores.Find(idProveedor);

                if (proveedor != null)
                {
                    var resultado = MessageBox.Show($"¿ Estas seguro de eliminar a {proveedor.Nombre} ?", "Confirmacion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resultado == MessageBoxResult.Yes)
                    {
                        db.TProveedores.Remove(proveedor);
                        db.SaveChanges();
                        llenarTabla();
                    }
                }
            }
        }

        private void txtBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            string busqueda = txtBusqueda.Text;
            filtrarProveedor(busqueda);
            numeroResultados();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Proveedores proveedores = new Proveedores();
            proveedores.Show();
        }
    }
}


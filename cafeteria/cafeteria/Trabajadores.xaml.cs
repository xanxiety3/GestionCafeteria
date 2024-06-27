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
    /// Lógica de interacción para Trabajadores.xaml
    /// </summary>
    public partial class Trabajadores : Window
    {
        public Trabajadores()
        {
            InitializeComponent();
            llenarTabla();
        }

        public class modeloTrabajador
        {
            public int Id { get; set; }
            public string TipoDocumento { get; set; }
            public string Documento { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
            public string Estado { get; set; }
            public string Usuario { get; set; }
            public string Contrasenia { get; set; }
            public string Rol { get; set; }
        }


        public void llenarTabla()
        {
            using (var db = new GestioncafeteriaContext())
            {
                var consulta = from trabajador in db.TTrabajadores
                               join tipoDoc in db.TTiposDocs on trabajador.IdTipoDoc equals tipoDoc.Id
                               join rol in db.TRoles on trabajador.IdRol equals rol.Id
                               select new modeloTrabajador
                               {
                                   Id = trabajador.Id,
                                   TipoDocumento = tipoDoc.Nombre,
                                   Documento = trabajador.NumDocumento.ToString(),
                                   Nombre = trabajador.Nombre,
                                   Apellido = trabajador.Apellido,
                                   Direccion = trabajador.Direccion,
                                   Telefono = trabajador.Telefono.ToString(),
                                   Estado = trabajador.Estado.ToString(),
                                   Usuario = trabajador.Usuario,
                                   Contrasenia = trabajador.Contrasenia,
                                   Rol = rol.Nombre

                               };

                dgTrabajadores.ItemsSource = consulta.ToList();
            }
        }

        public void filtrarTrabajador(string busqueda)
        {
            using (var db = new GestioncafeteriaContext())
            {
                var consulta = from trabajador in db.TTrabajadores
                               join tipoDoc in db.TTiposDocs on trabajador.IdTipoDoc equals tipoDoc.Id
                               join rol in db.TRoles on trabajador.IdRol equals rol.Id
                               where trabajador.Nombre.Contains(busqueda) ||
                                     trabajador.Apellido.Contains(busqueda) ||
                                     trabajador.NumDocumento.ToString().Contains(busqueda)
                               select new modeloTrabajador
                               {
                                   Id = trabajador.Id,
                                   TipoDocumento = tipoDoc.Nombre,
                                   Documento = trabajador.NumDocumento.ToString(),
                                   Nombre = trabajador.Nombre,
                                   Apellido = trabajador.Apellido,
                                   Direccion = trabajador.Direccion,
                                   Telefono = trabajador.Telefono.ToString(),
                                   Estado = trabajador.Estado.ToString(),
                                   Usuario = trabajador.Usuario,
                                   Contrasenia = trabajador.Contrasenia,
                                   Rol = rol.Nombre
                               };

                dgTrabajadores.ItemsSource = consulta.ToList();
            }
        }



        public void numeroResultados()
        {
            string busqueda = txtBusqueda.Text;
            int numResultado = dgTrabajadores.Items.Count;
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
                int idTrabajador = (int)((Button)sender).CommandParameter;
                var trabajador = db.TTrabajadores.Find(idTrabajador);

                if (trabajador != null)
                {
                    var resultado = MessageBox.Show($"¿ Estas seguro de eliminar a {trabajador.Nombre + " " + trabajador.Apellido} ?", "Confirmacion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resultado == MessageBoxResult.Yes)
                    {
                        db.TTrabajadores.Remove(trabajador);
                        db.SaveChanges();
                        llenarTabla();
                    }
                }
            }
        }

        private void txtBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            string busqueda = txtBusqueda.Text;
            filtrarTrabajador(busqueda);
            numeroResultados();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }

}

using cafeteria.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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

namespace cafeteria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            llenar_tipodoc();
            llenar_rol();
            llenar_estado();
        }

        public void limpiarCajas()
        {
           
            cmEstado.SelectedIndex = -1;
            cmRol.SelectedIndex= -1;
            cmDoc.SelectedIndex= -1;
            txtApellidos.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtNumdoc .Text = "";
            txtTelefono.Text = "";
           txtUsuario.Text = "";
            txtContra.Text = "";

        }


        public void llenar_tipodoc()
        {
            using (var db = new GestioncafeteriaContext())

            {

                var consulta = from tipo in db.TTiposDocs
                               select new { tipo.Id, tipo.Nombre };

                cmDoc.ItemsSource = consulta.ToList();
                cmDoc.DisplayMemberPath = "Nombre";
                cmDoc.SelectedValuePath = "Id";

            }

        }
        public void llenar_rol()
        {
            using (var db = new GestioncafeteriaContext())

            {

                var consulta = from rol in db.TRoles
                               select new { rol.Id, rol.Nombre };

                cmRol.ItemsSource = consulta.ToList(); 
                cmRol.DisplayMemberPath = "Nombre";
                cmRol.SelectedValuePath = "Id";

            }

        }

        public void llenar_estado()
        {
            cmEstado.Items.Add("Inactivo");
            cmEstado.Items.Add("Activo");



        }





        public bool llenarCampos()
        {
            if (!string.IsNullOrEmpty(txtApellidos.Text) &&
                !string.IsNullOrEmpty(txtNombre.Text) &&
                !string.IsNullOrEmpty(txtContra.Text) &&
                !string.IsNullOrEmpty(txtUsuario.Text) &&
                !string.IsNullOrEmpty(txtDireccion.Text) &&
                !string.IsNullOrEmpty(txtNumdoc.Text) &&
                !string.IsNullOrEmpty(txtTelefono.Text) &&
                cmDoc.SelectedIndex != -1 &&
                cmEstado.SelectedIndex != -1 &&
                cmRol.SelectedIndex != -1 
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Trabajadores trabajadores = new Trabajadores();
            
            guardarTrabajador();
            limpiarCajas();
            trabajadores.llenarTabla();
            this.Close();
            trabajadores.Show();
            

        }

       

        public void guardarTrabajador()
        {
            try
            {
                if (llenarCampos())
                {
                    using (var db = new GestioncafeteriaContext())
                    {
                        TTrabajadore trabajador = new TTrabajadore();
                        trabajador.Nombre = txtNombre.Text;
                        trabajador.Apellido = txtApellidos.Text;
                        trabajador.IdTipoDoc = int.Parse(cmDoc.SelectedValue.ToString());
                        trabajador.NumDocumento = int.Parse(txtNumdoc.Text);
                        trabajador.Direccion= txtDireccion.Text;
                        trabajador.Telefono= int.Parse(txtTelefono.Text);
                        trabajador.Estado= int.Parse(cmEstado.SelectedIndex.ToString());
                        trabajador.Usuario= txtUsuario.Text;
                        trabajador.Contrasenia= txtContra.Text;
                        trabajador.IdRol= int.Parse(cmRol.SelectedValue.ToString());    


                        db.TTrabajadores.Add(trabajador);
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

        private void btnprov_Click(object sender, RoutedEventArgs e)
        {
            Proveedores prov = new Proveedores();
            prov.Show();
            this.Close();
        }
    }
}
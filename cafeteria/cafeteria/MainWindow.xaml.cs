using cafeteria.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Converters;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static cafeteria.Trabajadores;

namespace cafeteria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ModoOperacion modo;

        public MainWindow(ModoOperacion modo)
        {
            InitializeComponent();
            this.modo = modo;
            llenar_tipodoc();
            llenar_rol();
            llenar_estado();
            DataContext = new Trabajadores();

            if(modo == ModoOperacion.Editar)
            {
                lbBtn.Content = "EDITAR";
            }

        }

       


        public enum ModoOperacion
        {
            Guardar,
            Editar
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


        public void accion()
        {
            try
            {
                if (modo == ModoOperacion.Guardar)
                {
                    GuardarTrabajador();
                }
                else if (modo == ModoOperacion.Editar)
                {
                   
                    EditarTrabajador();
                }
                else
                {
                    MessageBox.Show("Modo de operación no reconocido.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la acción: " + ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GuardarTrabajador()
        {
            if (llenarCampos())
            {
                using (var db = new GestioncafeteriaContext())
                {
                    TTrabajadore trabajador = new TTrabajadore
                    {
                        Nombre = txtNombre.Text,
                        Apellido = txtApellidos.Text,
                        IdTipoDoc = int.Parse(cmDoc.SelectedValue.ToString()),
                        NumDocumento = int.Parse(txtNumdoc.Text),
                        Direccion = txtDireccion.Text,
                        Telefono = int.Parse(txtTelefono.Text),
                        Estado = cmEstado.SelectedIndex,
                        Usuario = txtUsuario.Text,
                        Contrasenia = txtContra.Text,
                        IdRol = int.Parse(cmRol.SelectedValue.ToString())
                    };

                    db.TTrabajadores.Add(trabajador);
                    db.SaveChanges();

                    MessageBox.Show("¡Guardado con éxito!", "REGISTRO EXITOSO", MessageBoxButton.OK, MessageBoxImage.Information);
                    limpiarCajas();
                }
            }
            else
            {
                MessageBox.Show("Por favor llene todos los campos.", "COMPLETAR CAMPOS", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void EditarTrabajador()
        {
            if (llenarCampos())
            {
                var trabajadores = (Trabajadores)DataContext;
                if (trabajadores.dgTrabajadores.SelectedItem != null)
                {
                    TTrabajadore trabajadorSeleccionado = (TTrabajadore)trabajadores.dgTrabajadores.SelectedItem;

                    using (var db = new GestioncafeteriaContext())
                    {
                        var trabajador = db.TTrabajadores.FirstOrDefault(t => t.Id == trabajadorSeleccionado.Id);

                        if (trabajador != null && trabajadores.dgTrabajadores.SelectedItem != null)
                        {
                            trabajador.Nombre = txtNombre.Text;
                            trabajador.Apellido = txtApellidos.Text;
                            trabajador.IdTipoDoc = int.Parse(cmDoc.SelectedValue.ToString());
                            trabajador.NumDocumento = int.Parse(txtNumdoc.Text);
                            trabajador.Direccion = txtDireccion.Text;
                            trabajador.Telefono = int.Parse(txtTelefono.Text);
                            trabajador.Estado = cmEstado.SelectedIndex;
                            trabajador.Usuario = txtUsuario.Text;
                            trabajador.Contrasenia = txtContra.Text;
                            trabajador.IdRol = int.Parse(cmRol.SelectedValue.ToString());

                            db.SaveChanges();
                            MessageBox.Show("¡Cambios guardados con éxito!", "EDICIÓN TERMINADA", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el trabajador en la base de datos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un trabajador para editar.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor llene todos los campos.", "COMPLETAR CAMPOS", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

    

      


        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            accion();

        }


        private void btnprov_Click(object sender, RoutedEventArgs e)
        {
            Proveedores prov = new Proveedores();
            prov.Show();
            this.Close();
        }
    }
}
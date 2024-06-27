using cafeteria.Models;
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
    /// Lógica de interacción para Proveedores.xaml
    /// </summary>
    public partial class Proveedores : Window
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        public void limpiarCajas()
        {

           
            txtnit.Text = "";
            txtnombre.Text = "";
            txtdireccion.Text = "";
            txttel.Text = "";

        }




        public bool llenarCampos()
        {
            if (!string.IsNullOrEmpty(txtnit.Text) &&
                !string.IsNullOrEmpty(txtnombre.Text) &&
                !string.IsNullOrEmpty(txtdireccion.Text) &&
                !string.IsNullOrEmpty(txttel.Text) 
                
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void guardarProovedor()
        {
            try
            {
                if (llenarCampos())
                {
                    using (var db = new GestioncafeteriaContext())
                    {
                        TProveedore provedor = new TProveedore();
                        provedor.Nit = int.Parse(txtnit.Text);
                        provedor.Nombre = txtnombre.Text;
                        provedor.Direccion = txtdireccion.Text;
                        provedor.Contacto = txttel.Text;
                        

                        db.TProveedores.Add(provedor);
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
            guardarProovedor();
            limpiarCajas();

        }

        private void btnprov_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

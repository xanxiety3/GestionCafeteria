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
    /// Lógica de interacción para Menus.xaml
    /// </summary>
    public partial class Menus : Window
    {
        public Menus()
        {
            InitializeComponent();
        }

        private void btnproveedores_Click(object sender, RoutedEventArgs e)
        {
            Proveedores proveedores = new Proveedores();
            proveedores.Show();
        }

        private void btntrabajadores_Click(object sender, RoutedEventArgs e)
        {

          Trabajadores trabajadores = new Trabajadores();
            trabajadores.Show();
        }

        private void btnsalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btninventario_Click(object sender, RoutedEventArgs e)
        {
            Productos productos = new Productos();
            productos.Show();
        }
    }
}

using cafeteriaSena.Models;
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

namespace cafeteriaSena
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            using (GestioncafeteriaContext db = new GestioncafeteriaContext())
            {
                string usuario = "luis";
                string contra = "1234";

                if (usuario == txtusuario.Text && contra == txtcontraseña.Text)
                {
                    MessageBox.Show("Bienvenido" + usuario);
                }
                else
                {
                    MessageBox.Show("Usuario incorrecto");
                }
            }


        }

    }


    
}

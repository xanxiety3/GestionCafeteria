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
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (GestioncafeteriaContext db = new GestioncafeteriaContext())
            {
                TTrabajadore trabajador = new TTrabajadore();
                string usu = txtusuario.Text;
                string con = txtcontraseña.Password;

                if (string.IsNullOrEmpty(usu))
                {
                    MessageBox.Show("Ingrese Usuario");
                }
                else if (string.IsNullOrEmpty(con))
                {
                    MessageBox.Show("Ingrese Contraseña");
                }
                else
                {
                    var query = (from trabajadores in db.TTrabajadores
                                 where trabajadores.Usuario == usu && trabajadores.Contrasenia == con
                                 select trabajadores)
                                .FirstOrDefault();

                    if (query != null)
                    {
                        MessageBox.Show("Bienvenido " + usu);
                        Menus men = new Menus();
                        men.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Credenciales incorretas");
                    }
                }

                txtcontraseña.Password = "";
                txtusuario.Text = "";
            }
        }
    }
    }



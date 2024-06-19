using cafeteriaSena.Models;
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

namespace cafeteriaSena.Views
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
            public string TipoDocumento { get; set; }
            public string Documento { get; set; }
            public string Nombre { get; set; }
            public string Apellido {  get; set; }   
            public string Direccion {  get; set; }
            public string Telefono { get; set; }
            public string Estado {  get; set; }
            public string Usuario { get; set; }
            public string Contrasenia { get; set; }
            public string Rol {  get; set; }
        }


        public void llenarTabla()
        {
            using(var db = new GestioncafeteriaContext())
            {
                var consulta = from trabajador in db.TTrabajadores
                               join tipoDoc in db.TTiposDocs on trabajador.IdTipoDoc equals tipoDoc.Id
                               join rol in db.TRoles on trabajador.IdRol equals rol.Id
                               select new modeloTrabajador
                               {
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

    }
}

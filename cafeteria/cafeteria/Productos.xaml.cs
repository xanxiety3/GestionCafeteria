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
    /// Lógica de interacción para Productos.xaml
    /// </summary>
    public partial class Productos : Window
    {
        public Productos()
        {
            InitializeComponent();
            cargarProductos();

        }
        public class ModeloProductos
        {
            public int id { get; set; }
            public string referencia { get; set; }
            public string producto { get; set; }
            public string valor { get; set; }
            public string cantidad { get; set; }
            public string detalle { get; set; }
            public string estado { get; set; }
            public string categoria { get; set; }
            public string fechaVencimiento { get; set; }

        }

        public void cargarProductos()
        {
            using (var db = new GestioncafeteriaContext())
            {
                var consulta = from p in db.TProductos
                               join ep in db.TEstadoProductos on p.IdEstado equals ep.Id
                               join cp in db.TCategorias on p.IdCategoria equals cp.Id
                               select new ModeloProductos
                               {

                                   id = p.Id,
                                   referencia = p.Referencia,
                                   producto = p.Nombre,
                                   valor = p.Precio.ToString(),
                                   cantidad = p.Cantidad.ToString(),
                                   detalle = p.Descripcion,
                                   estado = p.IdEstado.ToString(),
                                   categoria = p.IdCategoria.ToString(),
                                   fechaVencimiento = p.FechaVencimiento.ToString()

                               };


                datagProductos.ItemsSource = consulta.ToList();
            }
        }


    }
}


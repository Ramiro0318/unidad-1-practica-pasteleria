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

namespace unidad_1_practica_pasteleria
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Pasteleria p = new();

        private void btnPagar_Click(object sender, RoutedEventArgs e)
        {
            //p.Vender();
            //lstLista.Items = p.Panes.ToList();
            //txtCantidad.Text = p.CantidadComprar.ToString();
            //lblTotal.Text = p.Total.ToString();
            //lblError.Text = p.Error.ToString();
        }

        private void btnMas_Click(object sender, RoutedEventArgs e)
        {
            
            //txtCantidad.Text = p.CantidadComprar.ToString();
        }

        private void btnMenos_Click(object sender, RoutedEventArgs e)
        {
            
            //txtCantidad.Text = p.CantidadComprar.ToString();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
using ProyectoWPF_Acceso.vistamodelo;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ProyectoWPF_Acceso.vistas
{
    /// <summary>
    /// Lógica de interacción para Inicio.xaml
    /// </summary>
    public partial class Inicio : UserControl
    {
        InicioVM vm = new InicioVM();
        public Inicio()
        {
            var bc = new BrushConverter();
            InitializeComponent();
            this.DataContext = vm;
            this.Background = (Brush)bc.ConvertFrom("#dadedf");
            mediaElement.Source = new Uri(@"/img/loading.mp4", UriKind.RelativeOrAbsolute);
            Loading();
            vm.Comprobar();
        }

        DispatcherTimer timer = new DispatcherTimer();

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {

        }

        private void timer_tick(object sender, EventArgs e)
        {
            timer.Stop();
            mediaElement.Visibility = Visibility.Hidden;
            canvas.Visibility = Visibility.Visible;

        }

        void Loading()
        {
            timer.Tick += timer_tick;
            timer.Interval = new TimeSpan(0, 0, 4);
            timer.Start();
        }
    }
}

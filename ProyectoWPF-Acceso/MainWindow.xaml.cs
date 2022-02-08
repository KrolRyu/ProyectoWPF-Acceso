﻿using ProyectoWPF_Acceso.vistas;
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

namespace ProyectoWPF_Acceso
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var bc = new BrushConverter();
            InitializeComponent();
            this.Background = (Brush)bc.ConvertFrom("#dadedf");
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new Inicio();
            boton.IsEnabled = false;
        }
    }
}

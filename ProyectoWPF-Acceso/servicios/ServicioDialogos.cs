using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoWPF_Acceso.servicios
{
    /// <summary>
    /// Clase para manejar los diversos dialogos tales como para seleccionar una imagen o abrir un MessageBox
    /// </summary>
    static class ServicioDialogos
    {
        public static string ArchivoSeleccionado { get; set; }


        /// <summary>
        /// Metodo para abrir un dialogo para seleccionar una imagen del ordenador
        /// </summary>
        /// <returns>
        /// Devuelve el archivo seleccionado
        /// </returns>
        public static string ExaminarImagen()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;"
            };


            bool? resultado = openFileDialog.ShowDialog();

            if (resultado == true)
            {
                ArchivoSeleccionado = openFileDialog.FileName;
                ServicioMessageBox($"Imagen cargada correctamente", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                return ArchivoSeleccionado;
            }
            else
            {
                ServicioMessageBox($"Error al cargar la imagen", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return "";
            }

        }

        /// <summary>
        /// Método para generar un MessageBox 
        /// </summary>
        /// <param name="mensaje">
        /// Mensaje del MessajeBox
        /// </param>
        /// <param name="titulo">
        /// Titulo del MessageBox
        /// </param>
        /// <param name="boxButton">
        /// Boton del MessageBox
        /// </param>
        /// <param name="messageBoxImage">
        /// Imagen del MessageBox
        /// </param>
        public static void ServicioMessageBox(string mensaje, string titulo, MessageBoxButton boxButton, MessageBoxImage messageBoxImage)
        {
            MessageBox.Show(mensaje, titulo, boxButton, messageBoxImage);
        }

    }
}

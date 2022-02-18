using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoWPF_Acceso.servicios
{
    /// <summary>
    /// Clase para subir las imagenes al contenedor de Azure
    /// </summary>
    static class ServicioImgs
    {

        /// <summary>
        /// Método encargado de subir la imagen al contenedor de Azure
        /// </summary>
        /// <param name="rutaImagen">
        /// ruta de la imagen en local
        /// </param>
        /// <returns>
        /// Devuelve la URL de la imagen en Azure o cadena vacía si da algun error
        /// </returns>
        public static String SubirImagenAAzure(string rutaImagen)
        {
            try
            {
                //Cambiar a la configuracion del proyecto
                string cadenaDeConexion = Properties.Settings.Default.EndpointImgs;
                string nombreContenedorBlobs = "imgs-proyecto-parking";

                var clienteBlobService = new BlobServiceClient(cadenaDeConexion);
                var clienteContenedor = clienteBlobService.GetBlobContainerClient(nombreContenedorBlobs);
                Stream streamImagen = File.OpenRead(rutaImagen);
                string nombreImagen = Path.GetFileName(rutaImagen);
                clienteContenedor.DeleteBlobIfExists(nombreImagen);
                clienteContenedor.UploadBlob(nombreImagen, streamImagen);

                var clienteBlobImagen = clienteContenedor.GetBlobClient(nombreImagen);
                string urlImagen = clienteBlobImagen.Uri.AbsoluteUri;
                return urlImagen;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}

using Microsoft.Toolkit.Mvvm.ComponentModel;
using ProyectoWPF_Acceso.ClasesModelo;
using ProyectoWPF_Acceso.servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoWPF_Acceso.vistamodelo
{
    class InicioVM : ObservableObject
    {
        private bool result;

        public bool Result
        {
            get { return result; }
            set { result = value; }
        }

        public InicioVM()
        {

        }

        public bool Comprobar()
        {
            Result = true;
            string img = ServicioDialogos.ExaminarImagen();
            int id = 2;

            string url = ServicioImgs.SubirImagenAAzure(img);

            string tipo = ServicioDetectarVehiculo.ComprobarVehiculo(url);
            string matricula = ServicioMatricula.SacarMatricula(url, tipo);

            ObservableCollection<Estacionamiento> lista = ServicioDatabase.GetEstacionamientos();

            foreach (Estacionamiento e in lista)
            {
                if (e.Matricula == matricula)
                {
                    Result = false;
                }
                id = e.Id_estacionamientos;
            }
            if (result)
            {
                Estacionamiento e = new Estacionamiento(id, url);
                if (e.Id_vehiculo != null)
                {
                    ServicioDatabase.InsertarEstacionamiento(e);
                }
                else
                {
                    ServicioDatabase.InsertarEstacionamientoNoCliente(e);
                }
                
            }
            
            return result;
        }
    }
}

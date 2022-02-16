using Microsoft.Toolkit.Mvvm.ComponentModel;
using ProyectoWPF_Acceso.ClasesModelo;
using ProyectoWPF_Acceso.servicios;
using System;
using System.Collections.Generic;
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

        public bool Comprobar(string img)
        {
            Result = true;
            img = "/img/CarLongPlate43.jpg";
            int id = 0;

            string tipo = ServicioDetectarVehiculo.ComprobarVehiculo(img);
            string matricula = ServicioMatricula.SacarMatricula(img, tipo);

            foreach (Estacionamiento e in ServicioDatabase.GetEstacionamientos())
            {
                if (e.Matricula == matricula)
                {
                    //Result = false;
                }
                id = e.Id_estacionamientos;
            }
            if (result)
            {
                Estacionamiento e = new Estacionamiento(id, img);
                ServicioDatabase.InsertarEstacionamiento(e);
            }
            
            return result;
        }
    }
}

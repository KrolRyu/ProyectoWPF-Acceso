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
        private int plazasCoche;

        public int PlazasCoche
        {
            get { return plazasCoche; }
            set { plazasCoche = value; }
        }

        private int plazasMoto;

        public int PlazasMoto
        {
            get { return plazasMoto; }
            set { plazasMoto = value; }
        }


        private bool result;

        public bool Result
        {
            get { return result; }
            set { SetProperty(ref result ,value); }
        }

        public InicioVM()
        {
            PlazasMoto = ServicioDatabase.GetEstacionamientosMotos().Count;
            PlazasCoche = ServicioDatabase.GetEstacionamientosCoches().Count;
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
            Estacionamiento estacionamiento = new Estacionamiento(id, url);
            if (result)
            {
                switch (estacionamiento.Tipo)
                {
                    case "coche":
                        Result = PlazasCoche > 0;
                        break;
                    case "moto":
                        Result = PlazasMoto > 0;
                        break;
                    default:
                        break;
                }
            }
            if (result)
            {           
                if (estacionamiento.Id_vehiculo != null)
                {
                    ServicioDatabase.InsertarEstacionamiento(estacionamiento);
                }else
                {
                    ServicioDatabase.InsertarEstacionamientoNoCliente(estacionamiento);
                }
                
            }
            
            return result;
        }
    }
}

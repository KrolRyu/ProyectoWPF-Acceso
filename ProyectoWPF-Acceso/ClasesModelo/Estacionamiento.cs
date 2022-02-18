using Microsoft.Toolkit.Mvvm.ComponentModel;
using ProyectoWPF_Acceso.servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoWPF_Acceso.ClasesModelo
{
    public class Estacionamiento : ObservableObject
    {
        //Propiedades

        private int id_estacionamientos;

        public int Id_estacionamientos
        {
            get { return id_estacionamientos; }
            set { SetProperty(ref id_estacionamientos, value); }
        }

        private int? id_vehiculo;

        public int? Id_vehiculo
        {
            get { return id_vehiculo; }
            set { SetProperty(ref id_vehiculo, value); }
        }

        private string matricula;

        public string Matricula
        {
            get { return matricula; }
            set { SetProperty(ref matricula, value); }
        }

        private string entrada;

        public string Entrada
        {
            get { return entrada; }
            set { SetProperty(ref entrada, value); }
        }

        private string salida;

        public string Salida
        {
            get { return salida; }
            set { SetProperty(ref salida, value); }
        }

        private double importe;

        public double Importe
        {
            get { return importe; }
            set { SetProperty(ref importe, value); }
        }

        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { SetProperty(ref tipo, value); }
        }

        //Constructores

        public Estacionamiento() { }

        public Estacionamiento(int id_estacionamientos, int id_vehiculo, string matricula, string entrada, string salida, double importe, string tipo)
        {
            this.id_estacionamientos = id_estacionamientos;
            this.id_vehiculo = id_vehiculo;
            this.Matricula = matricula;
            this.Entrada = entrada;
            this.Salida = salida;
            this.Importe = importe;
            this.Tipo = tipo;
        }

        //Este es el contructor para hacer con una foto
        public Estacionamiento(int id_estacionamientos, int id_vehiculo, string foto)
        {
            this.Id_estacionamientos = id_estacionamientos;
            this.Id_vehiculo = id_vehiculo;
            this.Tipo = ServicioDetectarVehiculo.ComprobarVehiculo(foto);
            this.Matricula = ServicioMatricula.GetMatricula(foto, Tipo);
            this.Entrada = DateTime.Now.ToLongTimeString();
            this.salida = null;
            this.Importe = default;
        }

        public Estacionamiento(int id_estacionamientos, string foto)
        {
            this.Id_estacionamientos = id_estacionamientos;
            this.Tipo = ServicioDetectarVehiculo.ComprobarVehiculo(foto);
            this.Matricula = ServicioMatricula.SacarMatricula(foto, Tipo);
            foreach (Vehiculo v in ServicioDatabase.GetVehiculos())
            {
                if (v.Matricula == Matricula)
                {
                    this.Id_vehiculo = v.IdVehiculo;
                }
                else
                {
                    this.Id_vehiculo = null;
                }

            }
            this.Entrada = DateTime.Now.ToString();
            this.salida = "";
            this.Importe = default;
        }

    }
}

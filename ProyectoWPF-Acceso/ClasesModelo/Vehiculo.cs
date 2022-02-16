using Microsoft.Toolkit.Mvvm.ComponentModel;
using ProyectoWPF_Acceso.servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoWPF_Acceso.ClasesModelo
{
    public class Vehiculo : ObservableObject
    {
        private int idVehiculo;

        public int IdVehiculo
        {
            get { return idVehiculo; }
            set { SetProperty(ref idVehiculo, value); }
        }

        private int idCliente;

        public int IdCliente
        {
            get { return idCliente; }
            set { SetProperty(ref idCliente, value); }
        }

        private string matricula;

        public string Matricula
        {
            get { return matricula; }
            set { SetProperty(ref matricula, value); }
        }

        private int idMarca;

        public int IdMarca
        {
            get { return idMarca; }
            set { SetProperty(ref idMarca, value); }
        }

        private string modelo;

        public string Modelo
        {
            get { return modelo; }
            set { SetProperty(ref modelo, value); }
        }

        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { SetProperty(ref tipo, value); }
        }

        public Vehiculo() { }

        public Vehiculo(int idVehiculo, int idCliente, string matricula, int idMarca, string modelo, string tipo)
        {
            this.IdVehiculo = idVehiculo;
            this.IdCliente = idCliente;
            this.Matricula = matricula;
            this.IdMarca = idMarca;
            this.Modelo = modelo;
            this.Tipo = tipo;
        }

        public Vehiculo(int idVehiculo, int idCliente, string foto, string modelo, int marca)
        {
            this.IdVehiculo = idVehiculo;
            this.IdCliente = idCliente;
            this.Tipo = ServicioDetectarVehiculo.ComprobarVehiculo(foto);
            this.Matricula = ServicioMatricula.SacarMatricula(foto, Tipo);
            this.Modelo = modelo;
            this.idMarca = marca;

        }

    }
}

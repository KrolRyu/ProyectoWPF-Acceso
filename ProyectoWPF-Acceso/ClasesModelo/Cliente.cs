using Microsoft.Toolkit.Mvvm.ComponentModel;
using ProyectoWPF_Acceso.servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProyectoWPF_Acceso.servicios.ServicioComprobarCara;

namespace ProyectoWPF_Acceso.ClasesModelo
{
    public class Cliente : ObservableObject
    {

        //Propiedades
        private int idCliente;

        public int IdCliente
        {
            get { return idCliente; }
            set { SetProperty(ref idCliente, value); }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { SetProperty(ref nombre, value); }
        }

        private string documento;

        public string Documento
        {
            get { return documento; }
            set { SetProperty(ref documento, value); }
        }

        private string foto;

        public string Foto
        {
            get { return foto; }
            set { SetProperty(ref foto, value); }
        }

        private int edad;

        public int Edad
        {
            get { return edad; }
            set { SetProperty(ref edad, value); }
        }

        private string genero;

        public string Genero
        {
            get { return genero; }
            set { SetProperty(ref genero, value); }
        }

        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { SetProperty(ref telefono, value); }
        }

        //Constructores
        public Cliente() { }

        public Cliente(string nombre, string documento, string foto, string telefono)
        {
            this.Nombre = nombre;
            this.Documento = documento;
            this.Foto = foto;
            FaceAttributes respuesta = ServicioComprobarCara.ComprobarCara(foto);
            this.Edad = (int)respuesta.age;
            this.Genero = respuesta.gender;
            this.Telefono = telefono;
        }

        public Cliente(int id, string nombre, string documento, string foto, int edad, string genero, string telefono)
        {
            this.IdCliente = id;
            this.Nombre = nombre;
            this.Documento = documento;
            this.Foto = foto;
            this.Edad = edad;
            this.Genero = genero;
            this.Telefono = telefono;
        }

        //Metodos

        public override string ToString()
        {
            return IdCliente + ", " + Nombre + ", " + Documento + ", " + Foto + ", " + Edad + ", " + Genero + ", " + Telefono;
        }
    }
}

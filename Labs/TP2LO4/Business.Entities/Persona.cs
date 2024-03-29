﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    class Persona: BusinessEntity
    {


        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Apellido;
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        private string _Direccion;
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        private string _Email;

        public string  Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _Telefono;

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        private DateTime _Fecha_Nac;

        public DateTime Fecha_Nac
        {
            get { return _Fecha_Nac; }
            set { _Fecha_Nac = value; }
        }

        private int _Legajo;

        public int Legajo
        {
            get { return _Legajo; }
            set { _Legajo = value; }
        }

        private int _TipoPersona;

        public int TipoPersona
        {
            get { return _TipoPersona; }
            set { _TipoPersona = value; }
        }

        private int _IDPlan;

        public int IDPlan
        {
            get { return _IDPlan; }
            set { _IDPlan = value; }
        }


    }
}

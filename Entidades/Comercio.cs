using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Comercio
    {
        protected int _cantidadDeEmpleados;
        protected Comerciante _comerciante;
        protected static Random _generadorDeEmpleados;
        protected string _nombre;
        protected float _precioAlquiler;

        static Comercio()
        {
            _generadorDeEmpleados = new Random();
        }
        public Comercio()
        {
        }

        public Comercio(float precioAlquiler, string nombreComercio, string nombre, string apellido)
        {
            this._precioAlquiler = precioAlquiler;
            this._nombre = nombreComercio;
            this._comerciante = new Comerciante(nombre, apellido);
        }


        public Comercio(string nombre, Comerciante comerciante, float precioAlquiler)
        {
            this._nombre = nombre;
            this._comerciante = comerciante;
            this._precioAlquiler = precioAlquiler;
        }

        public int CantidadDeEmpleados
        {
            get
            {
                if (_cantidadDeEmpleados == 0)
                {
                    _cantidadDeEmpleados = _generadorDeEmpleados.Next(1, 101);
                }
                return _cantidadDeEmpleados;
            }
        }
        public Comerciante Comerciante
        {
            get { return _comerciante; }
            set { _comerciante = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public float PrecioAlquiler
        {
            get { return _precioAlquiler; }
            set { _precioAlquiler = value; }
        }

        private string Mostrar()
        {
            return $"Nombre: {_nombre} \nComerciante: {(string)_comerciante} \nCantidad de Empleados: {CantidadDeEmpleados}";
        }

        public static bool operator ==(Comercio c1, Comercio c2 )
        {
            if (c1._nombre == c2._nombre && c1._comerciante == c2._comerciante)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Comercio c1, Comercio c2)
        {
            return !(c1 == c2);
        }

        public static explicit operator string(Comercio comercio)
        {
            return comercio.Mostrar();
        }

        public override bool Equals(object obj)
        {
            return obj is Comercio comercio && this == comercio;
        }

    }
}

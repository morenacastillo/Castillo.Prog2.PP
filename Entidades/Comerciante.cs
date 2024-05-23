using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comerciante
    {
        private string _nombre;
        private string _apellido;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public Comerciante()
        {
        }

        public Comerciante(string nombre, string apellido)
        {
            _nombre = nombre;
            _apellido = apellido;
        }

        public static bool operator ==(Comerciante c1, Comerciante c2)
        {
            if(c1._nombre == c2._nombre && c1._apellido == c2._apellido)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Comerciante c1, Comerciante c2) 
        {
            return !(c1 == c2);
        }

        public static implicit operator string(Comerciante c)
        {
            return $"Comerciante: {c._nombre}, {c._apellido}";
        }

    }
}

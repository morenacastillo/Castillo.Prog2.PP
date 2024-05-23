using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Importador : Comercio
    {
        private EPaises _paisOrigen;

        public Importador()
        {

        }

        public Importador(string nombre, float precioAlquiler, Comerciante comerciante, EPaises pais) : base(nombre, comerciante, precioAlquiler)
        {
            this._paisOrigen = pais;
        }

        public string Mostrar()
        {
            return (string)(Comercio)this + $"\nPaís de Origen: {_paisOrigen}";
        }

        public static bool operator ==(Importador i1, Importador i2)
        {
            return i1._nombre == i2._nombre && i1._paisOrigen == i2._paisOrigen;
        }
        public static bool operator !=(Importador i1, Importador i2)
        {
            return !(i1 == i2);
        }

        public static implicit operator EPaises(Importador importador)
        {
            return importador._paisOrigen;
        }
    }
}

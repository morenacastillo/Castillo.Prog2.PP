using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Exportador : Comercio
    {
        private ETipoProducto _tipo;

        public Exportador()
        {

        }

        public Exportador(string nombre, float precioAlquiler, Comerciante comerciante, ETipoProducto tipo)
            : base(nombre, comerciante, precioAlquiler)
        {
            this._tipo = tipo;
        }

        public string Mostrar()
        {
            return (string)(Comercio)this + $"\nTipo de Producto: {_tipo}";
        }

        public static bool operator ==(Exportador e1, Exportador e2)
        {
            return e1._nombre == e2._nombre && e1._tipo == e2._tipo;
        }

        public static bool operator !=(Exportador e1, Exportador e2)
        {
            return !(e1 == e2);
        }

        public static implicit operator ETipoProducto(Exportador exportador)
        {
            return exportador._tipo;
        }

    }
}

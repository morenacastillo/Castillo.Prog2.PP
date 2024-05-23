using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Importador))]
    [XmlInclude(typeof(Exportador))]
    public class Shopping
    {
        private int _capacidadMaxima;
        private List<Comercio> _comercios;

        /// <summary>
        /// Propiedad de capacidad del shopping
        /// </summary>
        public int CapacidadMaxima
        {
            get { return _capacidadMaxima; }
            set { _capacidadMaxima = value; }
        }

        /// <summary>
        /// Lista donde almacena los comercios
        /// </summary>
        public List<Comercio> Comercios
        {
            get { return _comercios; }
            set { _comercios = value; }
        }

        /// <summary>
        /// Constructor del Shopping que iniciliza la lista comercio
        /// </summary>
        private Shopping()
        {
            _comercios = new List<Comercio>();
        }


        private Shopping(int capacidadMaxima) : this()
        {
            this._capacidadMaxima = capacidadMaxima;
        }

        public static implicit operator Shopping(int capacidadMaxima)
        {
            return new Shopping(capacidadMaxima);
        }

        public static bool operator ==(Shopping shopping, Comercio comercio)
        {
            return shopping._comercios.Contains(comercio);
        }

        public static bool operator !=(Shopping shopping, Comercio comercio)
        {
            return !(shopping == comercio);
        }

        public static Shopping operator +(Shopping shopping, Comercio comercio)
        {
            if (shopping != comercio && shopping._comercios.Count < shopping._capacidadMaxima)
            {
                shopping._comercios.Add(comercio);
                
            }
            else
            {
                Console.WriteLine("El comercio no puede ser agregado al shopping.");
                
            }
            return shopping;
        }


        private double ObtenerPrecio(EComercios tipo)
        {
            double precioTotal = 0;
            foreach (Comercio comercio in _comercios)
            {
                switch (tipo)
                {
                    case EComercios.Exportador:
                        if (comercio is Exportador)
                        {
                            precioTotal += comercio.PrecioAlquiler;
                        }
                        break;
                    case EComercios.Importador:
                        if (comercio is Importador)
                        {
                            precioTotal += comercio.PrecioAlquiler;
                        }
                        break;
                    case EComercios.Ambos:
                        precioTotal += comercio.PrecioAlquiler;
                        break;
                }
            }
            return precioTotal;
        }

        public double PrecioDeExportadores
        {
            get 
            { 
                return ObtenerPrecio(EComercios.Exportador); 
            }
            set 
            { 
            }
        }

        public double PrecioDeImportadores
        {
            get 
            { 
                return ObtenerPrecio(EComercios.Importador); 
            }
            set 
            {
            } 
        }

        public double PrecioTotal
        {
            get 
            { 
                return ObtenerPrecio(EComercios.Ambos); 
            }
            set 
            {
            } 
        }


        public static string Mostrar(Shopping shopping)
        {
            string infoShopping = $"Capacidad del Shopping: {shopping.CapacidadMaxima}\nTotal por Importadores: ${shopping.PrecioDeImportadores}\nTotal por Exportadores: ${shopping.PrecioDeExportadores}\n Comercios en el Shopping:\n";

            foreach (Comercio comercio in shopping.Comercios)
            {
                infoShopping += $"{(string)comercio}\n";
            }

            return infoShopping;
        }

        public void GuardarShopping(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
            {
                using (FileStream fileStream = File.Create(rutaArchivo))
                {
                    fileStream.Close();
                }
            }
            using (StreamWriter streamWriter = new StreamWriter(rutaArchivo))
            {
                streamWriter.WriteLine(Mostrar(this));
            }
        }




        public void SerializarShopping(string rutaArchivo)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Shopping));
            using (StreamWriter streamWriter = new StreamWriter(rutaArchivo))
            {
                xmlSerializer.Serialize(streamWriter, this);
            }
        }


        public static Shopping DeserializarShopping(string rutaArchivo)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Shopping));
            using (StreamReader streamReader = new StreamReader(rutaArchivo))
            {
                return (Shopping)xmlSerializer.Deserialize(streamReader);
            }
        }




    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializacionDemo
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Identidad { get; set; }

        public Persona()
        {

        }
        public Persona(string nombre, string identidad)
        {
            this.Nombre = nombre;
            this.Identidad = identidad;
        }

        public override string ToString()
        {
            return $"{this.Nombre} ({this.Identidad})";
        }
    }
}

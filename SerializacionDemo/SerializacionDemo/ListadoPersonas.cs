using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializacionDemo
{
    public class ListadoPersonas
    {
        public Persona[] Lista;
        private const string RUTA = "ListaPersonas.xml";

        public ListadoPersonas()
        {
            Lista = new Persona[5];

            Lista[0] = new Persona("Clark Gable", "081012389232");
            Lista[1] = new Persona("Ava Gardner", "050620234340");
            Lista[2] = new Persona("Antonio Machado", "0810813943");
            Lista[3] = new Persona("William Faulkner", "41103123056");
            Lista[4] = new Persona("Clementina Suarez", "34523056");            
        }

        public void Serializar()
        {
            XmlSerializer xmls = new XmlSerializer(typeof(Persona[]));
            using (TextWriter writer = new StreamWriter(RUTA))
            {
                xmls.Serialize(writer, this.Lista);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Se ha serializado...");            
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public void Deserializar()
        {
            XmlSerializer xmls = new XmlSerializer(typeof(Persona[]));
            using (TextReader reader = new StreamReader(RUTA))
            {
                this.Lista = xmls.Deserialize(reader) as Persona[];
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Objetos deserilizados...");

            foreach (var item in this.Lista)
            {
                Console.WriteLine(item);
            }            
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }
}

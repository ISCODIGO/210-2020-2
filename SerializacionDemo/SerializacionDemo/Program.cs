using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;

namespace SerializacionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcion;
            Persona persona = new Persona("Frank Miller", "001154640");
            ListadoPersonas personas = new ListadoPersonas();

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("OPCIONES...");
                Console.WriteLine("[0] Salir");
                Console.WriteLine("[1] Serializar una persona");
                Console.WriteLine("[2] Serializar varias personas");
                Console.WriteLine("[3] Deserializar una persona");
                Console.WriteLine("[4] Deserializar varias personas");

                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Serializar(persona);
                        break;
                    case "2":
                        personas.Serializar();
                        break;
                    case "3":
                        Deserializar();
                        break;
                    case "4":
                        personas.Deserializar();
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n==========================================\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
            } while (opcion != "0");
        }       

        static void Serializar(Persona p)
        {
            try
            {
                XmlSerializer xmls = new XmlSerializer(typeof(Persona));
                using (TextWriter writer = new StreamWriter("Persona.xml"))
                {
                    xmls.Serialize(writer, p);
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Se ha serializado...");
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }

        static void Deserializar()
        {
            try
            {
                XmlSerializer xmls = new XmlSerializer(typeof(Persona));
                using (TextReader reader = new StreamReader("Persona.xml"))
                {
                    Persona p = xmls.Deserialize(reader) as Persona;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Persona deserializada... {p}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            } catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }
    }
}

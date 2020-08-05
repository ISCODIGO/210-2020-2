using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    class Tarea
    {
        private String descripcion;
        private bool finalizado;
        private DateTime fechaCreacion;

        public Tarea(String descripcion)
        {
            // this: referencia al propio objeto
            this.descripcion = descripcion;
            finalizado = false;
            fechaCreacion = DateTime.Now;
        }

        // Setter: permite modificar un atributo.
        public void SetDescripcion(String descripcion)
        {
            this.descripcion = descripcion;
        }

        // Getter: permite visualizar un atributo.
        public String GetDescripcion()
        {
            return this.descripcion;
        }

        // Propiedad: puede parecer un atributo pero se comporta como un getter y/o un setter.
        public bool Finalizado
        {
            get
            {
                return this.finalizado;
            }
            set
            {
                this.finalizado = value;
            }
        }

        public DateTime FechaCreacion
        {
            get
            {
                return this.fechaCreacion;
            }

            set
            {
                // Solo podrá modificarse si el valor es superior al instante actual
                if (value > DateTime.Now)
                {
                    this.fechaCreacion = value;
                }
            }
        }

        public String Descripcion
        {
            get;
            set;
        }

        /**
         *  Tarea t1 = new Tarea("Ir al supermercado");
         *  t1.SetDescripcion("Ir al mayoreo");
         *  t1.Finalizado = true;
         *  Console.Write(t1.FechaCreacion);
         *  t1.fechaCreacion // Error, porque es private.
         *  t1.FechaCreacion = DateTime.now;// Error.
         *  t1.Descripcion = "Ir al Paiz";
         */ 

    }
}

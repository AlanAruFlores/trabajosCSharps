using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopaAmerica
{
    public class Usuario
    {
        private static int contadorId = 0;
        private int id;
        private string nombre;
        private string apellido;
        private string esMayor;
        private Ticket entrada;
        private string metodoPago;
        private double importeTotal;
        public Usuario(string nombre, string apellido,bool esMayor,Ticket entrada)
        {
            this.id = ++contadorId;
            this.nombre = nombre;
            this.apellido = apellido;
            setMayor(esMayor);
            this.entrada = entrada;
        }
        private void setMayor(bool esMayor)
        {
            if (esMayor)
            {
                this.esMayor = "SI";
            }
            else
            {
                this.esMayor = "NO";
            }
        }
        public void setImporteTotal(double importe)
        {
            this.importeTotal = importe;
        }
        public void setMetodoPago(string metodoPago)
        {
            this.metodoPago = metodoPago;
        }
        public Ticket getTicket()
        {
            return this.entrada;
        }

        override
        public string ToString()
        {
            return id + "    |   " + nombre + " " + apellido + "     |    " + esMayor + "     |   " + metodoPago + "       |       $" + importeTotal;
        }


    }
}

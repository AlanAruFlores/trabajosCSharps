using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CopaAmerica
{
    public class Ticket
    {
        private int idTicket;
        private string nombreTicket;
        private int stock;
        private double precio;

        public Ticket(int stock)
        {
            this.idTicket = 1;
            this.nombreTicket = "Maracanazzo";
            this.stock = stock;
            this.precio = 200;
        }

        public int getStock()
        {
            return this.stock;
        }
        public void setStock(int stock)
        {
            if(stock <= this.stock)
            {
                this.stock = this.stock - stock;
            }
            else
            {
                MessageBox.Show("Error: no hay suficiente stock");
            }
        }
        public double getPrecio()
        {
            return this.precio;
        }

        override
        public string ToString()
        {
            return "\nNombre: " + nombreTicket + "\nPrecio (USD): $" + precio+ "\nCantidad Disponible: "+this.stock;
        }
    }
}

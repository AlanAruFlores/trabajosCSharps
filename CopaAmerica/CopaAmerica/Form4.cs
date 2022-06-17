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
    public partial class Form4 : Form
    {
        public Form4(Ticket entradas)
        {
            InitializeComponent();
            establecerLabel();
        }
        public void establecerLabel()
        {
            labelInformacionTicket.BackColor = Color.Transparent;
            labelInformacionTicket.ForeColor = Color.OldLace; 
            labelInformacionTicket.Text = Form3.entradas.ToString();
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cantidadSeleccionada = 0;
            try
            {
                if (textBoxCantidad.Text.Length > 0)
                {
                    cantidadSeleccionada = int.Parse(textBoxCantidad.Text);
                    registrandoUsuario(cantidadSeleccionada);
                }
                else
                {
                    MessageBox.Show("Error :Verifique los campos");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Verifique los datos ingresados en el inicio sesion");
            }
        }
        private void registrandoUsuario(int cantidadSeleccionada)
        {
            double importeTotal = 0;
            string metodoPago = "";
            if (Form3.entradas.getStock() >= cantidadSeleccionada)
            {
                Form3.entradas.setStock(cantidadSeleccionada);
                Usuario usuario = new Usuario(textUsuario.Text, textApellido.Text, radioSi.Checked, new Ticket(cantidadSeleccionada));

                if (radioContado.Checked)
                {
                    importeTotal = usuario.getTicket().getStock() * (Form3.entradas.getPrecio() * 0.5);
                    metodoPago = "C";
                }
                else
                {
                    if (radioMP.Checked)
                    {
                        importeTotal = usuario.getTicket().getStock() * (Form3.entradas.getPrecio() * 0.25);
                        metodoPago = "MP";

                    }
                    else
                    {
                        importeTotal = usuario.getTicket().getStock() * (Form3.entradas.getPrecio());
                        metodoPago = "TC";

                    }
                }
                usuario.setImporteTotal(importeTotal);
                usuario.setMetodoPago(metodoPago);
                MessageBox.Show("Se vendio con Exito");
                Form3.setUsuario(usuario);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error: Cantidad de stock no disponible");
            }
        }
        int x, y;

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void textBoxCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                MessageBox.Show("Error: No se puede poner caracteres");
            }
        }
        

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
            }
            else
            {
                this.Left += e.X - x;
                this.Top += e.Y - y;
            }
        }
    }
}

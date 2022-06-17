using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace CopaAmerica
{
    public partial class Form3 : Form
    {
        public static Ticket entradas = new Ticket(2000);
        private Form1 menuInicio;
        private static Form4 ventanaComprar;
        private static Form2 ventanaInformacion;

        private static List<Usuario> listaUsuario = new List<Usuario>();
        private static SmtpClient vendedor;
        private static string mailVendedor;

        public Form3(SmtpClient usuario)
        {
            InitializeComponent();
            Form3.vendedor = usuario;

        }
        public void setMail(string mailVendedor)
        {
            Form3.mailVendedor = mailVendedor;
        }
        public static void setUsuario(Usuario user)
        {
            listaUsuario.Add(user);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            menuInicio = new Form1();
            menuInicio.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void botonComprar_Click(object sender, EventArgs e)
        {
            ventanaComprar = new Form4(entradas);
            ventanaComprar.Show();
        }
        private void botonEnviarMail_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mensaje = new MailMessage();
                mensaje.To.Add(mailVendedor);
                mensaje.Subject = "Entradas Vendidas";
                mensaje.Body = setBody();
                mensaje.IsBodyHtml = true;
                mensaje.From = new MailAddress(mailVendedor);

                Form3.vendedor.Send(mensaje);
                MessageBox.Show("Mensaje Enviado");
                mensaje.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Error:Verifique si el hotmail esta bien registrado");
            }

        }
        private string setBody()
        {
            string cuerpoMensaje="";
            if (listaUsuario.Count <= 0)
            {
                cuerpoMensaje = "NO SE VENDIO NADA AUN";
            }
            else
            {
                cuerpoMensaje += "ID |  NOMBRE Y APELLIDO  | ¿ES MAYOR?  | METODO  | IMPORTE<br>";
                foreach (Usuario user in listaUsuario)
                {
                    cuerpoMensaje += user + "<br>";
                }
            }
            return cuerpoMensaje;
        }
        private void botonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int x, y;

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ventanaInformacion = new Form2(vendedor, mailVendedor);
            ventanaInformacion.Show();
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
                this.Top += e.Y -y;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace CopaAmerica
{
    public partial class Form2 : Form
    {
        private static SmtpClient usuario;
        private static string mail;
        public Form2(SmtpClient usuario, string mail)
        {
            InitializeComponent();
            Form2.usuario = usuario;
            Form2.mail = mail;
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void botonInicio_Click(object sender, EventArgs e)
        {

            
            try
            {
                MailMessage mensaje = new MailMessage();
                mensaje.To.Add("alanaruquipa242@hotmail.com");
                mensaje.Subject = textBoxAsunto.Text;
                mensaje.Body = textBoxMensaje.Text;
                mensaje.IsBodyHtml = true;
                mensaje.From = new MailAddress(mail);
                Form2.usuario.Send(mensaje);
                MessageBox.Show("Mensaje Enviado");
                mensaje.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Verifique si los datos ingresados en el inicio de sesion son correcto o si el mail receptor es correcto");
            }
            
        }

        int x, y;

        private void Form2_Load(object sender, EventArgs e)
        {

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

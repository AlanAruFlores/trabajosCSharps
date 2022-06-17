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
    public partial class Form1 : Form
    {
        static Form3 menu;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelUsuario.BackColor = Color.Transparent;
        }


        int x, y;
        private void botonInicio_Click(object sender, EventArgs e)
        {

            if (textBoxUsuario.Text.Contains("@hotmail.com") && textBoxContraseña.Text.Length>0)
            {
                SmtpClient usuario = new SmtpClient("smtp-mail.outlook.com", 587);
                usuario.UseDefaultCredentials = false;
                usuario.EnableSsl = true; //Seguridad
                usuario.Credentials = new NetworkCredential(textBoxUsuario.Text, textBoxContraseña.Text);
                menu = new Form3(usuario);
                menu.setMail(textBoxUsuario.Text);
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error: Verifique el Hotmail o la contraseña");
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            int idPerro = ObtenerIdPerro(); // Implementar cómo se obtiene el idPerro
            Listar listarControl = new Listar(panel7);
            PantallaEdicion listarControles = new PantallaEdicion(panel7);
            Regresar regresar = new Regresar(panel7, idPerro); 
        }


        private int ObtenerIdPerro()
        {
            return 1; // Valor de ejemplo
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }




        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Location = new Point(203, 330);

            PantallaEdicion PantallaControl = new PantallaEdicion(panel7);
            if (panel7.Contains(PantallaControl) == false)
            {
                panel7.Controls.Add(PantallaControl);
                PantallaControl.Dock = DockStyle.Fill;
                PantallaControl.BringToFront();
            }

        }


        private void button5_Click(object sender, EventArgs e)
        {
            button5.Font = new Font(button5.Font, FontStyle.Underline);
            button1.Font = new Font(button1.Font, button1.Font.Style & ~FontStyle.Underline);
            button2.Font = new Font(button2.Font, button2.Font.Style & ~FontStyle.Underline);
            button3.Font = new Font(button3.Font, button3.Font.Style & ~FontStyle.Underline);
            button4.Font = new Font(button4.Font, button4.Font.Style & ~FontStyle.Underline); panel4.Location = new Point(203, 206);
            Paciente pacienteControl = new Paciente();
            if(panel7.Contains(pacienteControl) == false) {
                panel7.Controls.Add(pacienteControl);
                pacienteControl.Dock = DockStyle.Fill;
                pacienteControl.BringToFront();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Font = new Font(button3.Font, FontStyle.Underline);
            button1.Font = new Font(button1.Font, button1.Font.Style & ~FontStyle.Underline);
            button2.Font = new Font(button2.Font, button2.Font.Style & ~FontStyle.Underline);
            button5.Font = new Font(button5.Font, button3.Font.Style & ~FontStyle.Underline);
            button4.Font = new Font(button4.Font, button4.Font.Style & ~FontStyle.Underline); panel4.Location = new Point(203, 144);
            Main MainControl = new Main();
            if (panel7.Contains(MainControl) == false)
            {
                panel7.Controls.Add(MainControl);
                MainControl.Dock = DockStyle.Fill;
                MainControl.BringToFront();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Font = new Font(button4.Font, FontStyle.Underline);
            panel4.Location = new Point(203, 392);
            Application.Exit();
        }

        private void main1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel4.Location = new Point(203, 268);
            button1.Font = new Font(button1.Font, FontStyle.Underline);
            button5.Font = new Font(button5.Font, button1.Font.Style & ~FontStyle.Underline);
            button2.Font = new Font(button2.Font, button2.Font.Style & ~FontStyle.Underline);
            button3.Font = new Font(button3.Font, button3.Font.Style & ~FontStyle.Underline);
            button4.Font = new Font(button4.Font, button4.Font.Style & ~FontStyle.Underline);
            Listar MainControl = new Listar(panel7);
            if (panel7.Contains(MainControl) == false)
            {
                panel7.Controls.Add(MainControl);
                MainControl.Dock = DockStyle.Fill;
                MainControl.BringToFront();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel4.Location = new Point(203, 330);
            button2.Font = new Font(button2.Font, FontStyle.Underline);
            button1.Font = new Font(button1.Font, button1.Font.Style & ~FontStyle.Underline);
            button5.Font = new Font(button5.Font, button5.Font.Style & ~FontStyle.Underline);
            button3.Font = new Font(button3.Font, button3.Font.Style & ~FontStyle.Underline);
            button4.Font = new Font(button4.Font, button4.Font.Style & ~FontStyle.Underline);
            ListaVacunas PantallaControl = new ListaVacunas();
            if (panel7.Contains(PantallaControl) == false)
            {
                panel7.Controls.Add(PantallaControl);
                PantallaControl.Dock = DockStyle.Fill;
                PantallaControl.BringToFront();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       //Boton Creditos
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programa creado por: Rene Sandoval, Stephany Flores, y Emma Serrano");
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{

    public partial class Regresar : UserControl
    {
        private Panel panel7;

        public Regresar(Panel panel)
        {
            InitializeComponent();
            this.panel7 = panel;

        }


        //Boton Regresar
        private void button2_Click(object sender, EventArgs e)
        {
            PantallaEdicion pantallaControles = new PantallaEdicion(panel7);

            if (!panel7.Controls.Contains(pantallaControles))
            {
                panel7.Controls.Add(pantallaControles);
                pantallaControles.Dock = DockStyle.Fill;
                pantallaControles.BringToFront();
            }
        }

        //Panel
        private void Regresar_Load(object sender, EventArgs e)
        {

        }

        //Imagen Vacunas
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        //ComboBox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //DateTimePicker
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        //Boton SuministraVacnua
        private void button4_Click(object sender, EventArgs e)
        {

        }

        //Boton AgendarVacuna
        private void button1_Click(object sender, EventArgs e)
        {

        }

        //TextBox Vacuna
        private void label3_Click(object sender, EventArgs e)
        {

        }

        //TextBox Fecha
        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

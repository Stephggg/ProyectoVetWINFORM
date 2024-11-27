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
    public partial class TarjetaVacunas : UserControl
    {
        private Panel panel7;

        public TarjetaVacunas(Panel panel)
        {
            InitializeComponent();
            this.panel7 = panel;

        }

        //Texto VS
        private void label3_Click(object sender, EventArgs e)
        {

        }

        //Texto VA
        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Panel
        private void TarjetaVacunas_Load(object sender, EventArgs e)
        {

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


        //DataGrid Vacunas Suministradas
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //DataGrid Vacunas Agendadas
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Boton Suministrar Vacuna
        private void button3_Click(object sender, EventArgs e)
        {

        }

        //Boton Eliminar Vacuna
        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}

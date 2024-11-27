using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{

    public partial class Regresar : UserControl
    {
        private Panel panel7;

        private int perroID; // Variable para almacenar el ID del perro

        public Regresar(Panel panel, int idPerro)
        {
            InitializeComponent();
            this.panel7 = panel;
            this.perroID = idPerro; // Asigna el ID del perro seleccionado

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

            // Obtener la fecha seleccionada en el DateTimePicker
            DateTime fechaSeleccionada = dateTimePicker1.Value;

            // Validar si la fecha seleccionada es mayor que la fecha actual
            if (fechaSeleccionada > DateTime.Now)
            {
                MessageBox.Show("La fecha debe ser igual o menor al día de hoy.");
                return;
            }
            
            // Obtener los valores seleccionados por el usuario
            string vacunaSeleccionada = comboBox1.SelectedItem?.ToString();  // Obtener el valor seleccionado en el ComboBox

            // Validar si el usuario ha seleccionado una vacuna
            if (string.IsNullOrEmpty(vacunaSeleccionada))
            {
                MessageBox.Show("Por favor seleccione una vacuna.");
                return;
            }

            // Guardar en un archivo de texto
            string filePath = "vacunas.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                // Incluye el ID del perro en el registro
                writer.WriteLine($"ID: {perroID}, Vacuna: {vacunaSeleccionada}, Fecha: {fechaSeleccionada:dd/MM/yyyy}");
            }

            MessageBox.Show("Vacuna suministrada y guardada correctamente.");
        }

        //Boton AgendarVacuna
        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener la fecha seleccionada en el DateTimePicker
            DateTime fechaSeleccionada = dateTimePicker1.Value;

            // Validar si la fecha seleccionada es mayor que la fecha actual
            if (fechaSeleccionada <= DateTime.Now)
            {
                MessageBox.Show("La fecha debe ser posterior al día de hoy.");
                return;
            }

            // Obtener el valor seleccionado en el ComboBox
            string vacunaSeleccionada = comboBox1.SelectedItem?.ToString();

            // Validar si el usuario ha seleccionado una vacuna
            if (string.IsNullOrEmpty(vacunaSeleccionada))
            {
                MessageBox.Show("Por favor seleccione una vacuna.");
                return;
            }

            // Guardar la vacuna y la fecha en un archivo de texto
            string filePath = "vacunas_agendadas.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                // Incluye el ID del perro en el registro
                writer.WriteLine($"ID: {perroID}, Vacuna: {vacunaSeleccionada}, Fecha Agendada: {fechaSeleccionada:dd/MM/yyyy}");
            }

            MessageBox.Show("Vacuna agendada correctamente.");
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

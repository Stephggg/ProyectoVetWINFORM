﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Perros;

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

            // Rellenar el ComboBox con las vacunas disponibles
            comboBox1.Items.AddRange(new string[] { "Especial Cachorros", "Polivalente", "Traqueobronquitis", "Antirrábica" });
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;  // Asignar el evento para cuando se seleccione una vacuna
        }

        // Método para obtener el perro por ID (simulado, ya que no se está usando base de datos)
        private Perro ObtenerPerroPorID(int id)
        {
            List<Perro> perros = new List<Perro>();

            try
            {
                using (StreamReader reader = new StreamReader("perros.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var datos = line.Split(',');
                        var perro = new Perro
                        {
                            ID = int.Parse(datos[0]),
                            Nombre = datos[1],
                            Raza = datos[2],
                            Dueño = datos[3],
                            Telefono = datos[4],
                            Fecha_De_Nacimiento = datos[5],
                            Nota = datos[6]
                        };
                        perros.Add(perro);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return perros.FirstOrDefault(p => p.ID == id);  // Devuelve el perro que coincide con el ID
        }

        // Botón para regresar y cargar pantalla de edición
        private void button2_Click(object sender, EventArgs e)
        {
            // Buscar el perro por ID en el archivo
            Perro perro = ObtenerPerroPorID(perroID);

            // Crear la instancia de PantallaEdicion
            PantallaEdicion pantallaControles = new PantallaEdicion(panel7);

            // Si el perro fue encontrado, pasamos los datos a PantallaEdicion
            if (perro != null)
            {
                pantallaControles.CargarDatos(perro);
            }
            else
            {
                MessageBox.Show("No se encontró el perro con el ID especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Agregar la pantalla de edición si no está ya en el panel
            if (!panel7.Controls.Contains(pantallaControles))
            {
                panel7.Controls.Add(pantallaControles);
                pantallaControles.Dock = DockStyle.Fill;
                pantallaControles.BringToFront();
            }
        }



        // Botón SuministraVacuna
        private void button4_Click(object sender, EventArgs e)
        {
            // Mostrar cuadro de confirmación
            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres confirmar?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario selecciona "No", salir del método
            if (result == DialogResult.No)
            {
                return;
            }

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

            // Obtener el precio ingresado en textBox1 o usar el valor predeterminado según la vacuna seleccionada
            decimal precioVacuna;

            // Asignar precio por defecto según la vacuna seleccionada
            if (vacunaSeleccionada == "Especial Cachorros")
            {
                precioVacuna = 200.00m;
            }
            else if (vacunaSeleccionada == "Polivalente")
            {
                precioVacuna = 150.00m;
            }
            else if (vacunaSeleccionada == "Traqueobronquitis")
            {
                precioVacuna = 100.00m;
            }
            else if (vacunaSeleccionada == "Antirrábica")
            {
                precioVacuna = 180.00m;
            }
            else
            {
                MessageBox.Show("Vacuna no válida.");
                return;
            }

            // Verificar si el usuario ha ingresado un precio personalizado
            if (decimal.TryParse(textBox1.Text, out decimal precioIngresado))
            {
                precioVacuna = precioIngresado; // Usar el precio personalizado
            }

            // Guardar en un archivo de texto
            string filePath = "vacunas.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                // Incluye el ID del perro, la vacuna, la fecha y el precio
                writer.WriteLine($"ID: {perroID}, Vacuna: {vacunaSeleccionada}, Fecha: {fechaSeleccionada:dd/MM/yyyy}, Precio: C$ {precioVacuna:0.00}");
            }

            MessageBox.Show("Vacuna suministrada y guardada correctamente.");
        }



        // Botón AgendarVacuna
        private void button1_Click(object sender, EventArgs e)
        {
            // Mostrar cuadro de confirmación
            DialogResult result = MessageBox.Show("¿Estás seguro de que quieres agendar esta vacuna?", "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario selecciona "No", salir del método
            if (result == DialogResult.No)
            {
                return;
            }

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

            // Obtener el precio ingresado en textBox1 o usar el valor predeterminado según la vacuna seleccionada
            decimal precioVacuna;

            // Asignar precio por defecto según la vacuna seleccionada
            if (vacunaSeleccionada == "Especial Cachorros")
            {
                precioVacuna = 200.00m;
            }
            else if (vacunaSeleccionada == "Polivalente")
            {
                precioVacuna = 150.00m;
            }
            else if (vacunaSeleccionada == "Traqueobronquitis")
            {
                precioVacuna = 100.00m;
            }
            else if (vacunaSeleccionada == "Antirrábica")
            {
                precioVacuna = 180.00m;
            }
            else
            {
                MessageBox.Show("Vacuna no válida.");
                return;
            }

            // Verificar si el usuario ha ingresado un precio personalizado
            if (decimal.TryParse(textBox1.Text, out decimal precioIngresado))
            {
                precioVacuna = precioIngresado; // Usar el precio personalizado
            }

            // Guardar la vacuna y la fecha en un archivo de texto
            string filePath = "vacunas_agendadas.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                // Incluye el ID del perro, la vacuna, la fecha y el precio
                writer.WriteLine($"ID: {perroID}, Vacuna: {vacunaSeleccionada}, Fecha Agendada: {fechaSeleccionada:dd/MM/yyyy}, Precio: C$ {precioVacuna:0.00}");
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el nombre de la vacuna seleccionada
            string vacunaSeleccionada = comboBox1.SelectedItem?.ToString();

            // Asignar el precio correspondiente en el TextBox según la vacuna seleccionada
            if (vacunaSeleccionada == "Especial Cachorros")
            {
                textBox1.Text = "200.00";
            }
            else if (vacunaSeleccionada == "Polivalente")
            {
                textBox1.Text = "150.00";
            }
            else if (vacunaSeleccionada == "Traqueobronquitis")
            {
                textBox1.Text = "100.00";
            }
            else if (vacunaSeleccionada == "Antirrábica")
            {
                textBox1.Text = "180.00";
            }
        }


    }
}

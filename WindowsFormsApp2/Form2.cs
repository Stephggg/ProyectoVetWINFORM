using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            CargarInformacionVacunas(1); // ID de perro ejemplo, puedes cambiarlo
        }

        private void CargarInformacionVacunas(int idPerro)
        {
            // Ruta de los archivos
            string pathVacunas = "vacunas.txt"; // Archivo de vacunas
            string pathPerros = "perros.txt"; // Archivo de perros

            // Verificar si los archivos existen
            if (!File.Exists(pathVacunas) || !File.Exists(pathPerros))
            {
                MessageBox.Show("No se encontraron los archivos necesarios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Leer los archivos
            var vacunasData = File.ReadAllLines(pathVacunas);
            var perrosData = File.ReadAllLines(pathPerros);

            // Filtrar los perros por ID (usaremos el ID proporcionado como ejemplo)
            var perrosFiltrados = perrosData.Where(p => p.StartsWith(idPerro.ToString())).ToList();

            if (perrosFiltrados.Count == 0)
            {
                MessageBox.Show("No se encontró información para el perro con el ID: " + idPerro, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Limpiar los RichTextBox antes de cargar nueva información
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            richTextBox5.Clear();

            decimal total = 0; // Variable para acumular el total

            // Variables para almacenar la información que vamos a mostrar en cada RichTextBox
            string nombres = "";
            string razas = "";
            string dueños = "";
            string vacunasInfo = "";
            string preciosInfo = "";

            // Recorremos todos los perros que coinciden con el ID
            foreach (var perro in perrosFiltrados)
            {
                // Extraemos la información del perro
                var partesPerro = perro.Split(',');
                string nombrePerro = partesPerro[1];
                string razaPerro = partesPerro[2];
                string dueñoPerro = partesPerro[3];

                // Agregar la información a las variables correspondientes
                nombres += nombrePerro + "\n";
                razas += razaPerro + "\n";
                dueños += dueñoPerro + "\n";

                // Filtramos las vacunas del perro
                var vacunasDelPerro = vacunasData.Where(v => v.Contains("ID: " + idPerro)).ToList();

                // Recorremos las vacunas del perro
                foreach (var vacuna in vacunasDelPerro)
                {
                    var partesVacuna = vacuna.Split(',');
                    string nombreVacuna = partesVacuna[1].Split(':')[1].Trim();
                    string fechaVacuna = partesVacuna[2].Split(':')[1].Trim();
                    string precioVacuna = partesVacuna[3].Split(':')[1].Trim();

                    // Agregar la información de las vacunas
                    vacunasInfo += nombreVacuna + "\n" + fechaVacuna + "\n\n";
                    preciosInfo += precioVacuna + "\n";

                    // Sumar el precio de las vacunas para obtener el total
                    if (decimal.TryParse(precioVacuna.Replace("C$", "").Trim(), out decimal precio))
                    {
                        total += precio;
                    }
                }
            }

            // Ahora agregamos la información en los RichTextBox correspondientes
            richTextBox1.AppendText("Nombres:\n" + nombres);  // Nombres de los perros
            richTextBox2.AppendText("Razas:\n" + razas);  // Razas de los perros
            richTextBox3.AppendText("Dueños:\n" + dueños);  // Dueños de los perros
            richTextBox4.AppendText("Vacunas:\n" + vacunasInfo);  // Información de las vacunas
            richTextBox5.AppendText("Precios:\n" + preciosInfo);  // Precios de las vacunas

            // Mostrar el total de las vacunas en el último RichTextBox
            richTextBox5.AppendText($"\nTotal: C$ {total.ToString("0.00")}");
        }
    }
}

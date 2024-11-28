using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VacunaNamespace;

namespace WindowsFormsApp2
{
    public partial class TarjetaVacunas : UserControl
    {
        private Panel panel7;
        private int idPerro; //Campo para almacenar el id del perro

        public TarjetaVacunas(Panel panel, int idPerro)
        {
            InitializeComponent();
            this.panel7 = panel;
            this.idPerro = idPerro; // Asignar el ID del perro al campo.

            // Cargar datos al inicializar el control.
            CargarVacunas();

        }

        public TarjetaVacunas(Panel panel7)
        {
            this.panel7 = panel7;
        }

        private List<Vacuna> CargarVacunasDesdeArchivo()
        {
            List<Vacuna> vacunas = new List<Vacuna>();
            try
            {
                using (StreamReader reader = new StreamReader("vacunas.txt"))
                {
                    string line;
                    int lineNumber = 0; // Para rastrear el número de línea en caso de error.

                    while ((line = reader.ReadLine()) != null)
                    {
                        lineNumber++;

                        // Eliminar espacios extra y verificar que la línea contiene las etiquetas adecuadas.
                        line = line.Trim();
                        if (string.IsNullOrEmpty(line)) continue;

                        // Separar los componentes por comas
                        string[] datos = line.Split(',');

                        if (datos.Length != 3)
                        {
                            throw new FormatException($"Número incorrecto de columnas en la línea {lineNumber}: {line}");
                        }

                        // Extraer los valores después de los dos puntos
                        string idPart = datos[0].Split(':')[1].Trim(); // Extraemos "1" de "ID: 1"
                        string vacunaPart = datos[1].Split(':')[1].Trim(); // Extraemos "Especial Cachorros" de "Vacuna: Especial Cachorros"
                        string fechaPart = datos[2].Split(':')[1].Trim();  // Extraemos "27/11/2024" de "Fecha: 27/11/2024"

                        // Validar y convertir el ID.
                        if (!int.TryParse(idPart, out int id))
                        {
                            throw new FormatException($"El ID no es válido en la línea {lineNumber}: {idPart}");
                        }

                        // Intentar convertir la fecha usando el formato específico
                        DateTime fecha;
                        if (!DateTime.TryParseExact(fechaPart, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out fecha))
                        {
                            throw new FormatException($"La fecha no es válida en la línea {lineNumber}: {fechaPart}");
                        }

                        // Agregar la vacuna a la lista después de validar todos los datos.
                        // Dentro de CargarVacunasDesdeArchivo()
                        vacunas.Add(new Vacuna(id, vacunaPart, fecha));  // Llamamos al constructor de Vacuna correctamente.

                    }
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error con detalles sobre el problema.
                MessageBox.Show($"Error al cargar las vacunas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return vacunas;
        }


        private void CargarVacunas()
        {
            try
            {
                // Cargar vacunas desde un archivo o fuente de datos.
                List<Vacuna> vacunas = CargarVacunasDesdeArchivo();

                // Filtrar las vacunas según el ID del perro.
                var vacunasSuministradas = vacunas
                    .Where(v => v.ID == idPerro && v.Estado == "Suministrada")
                    .ToList();

                var vacunasAgendadas = vacunas
                    .Where(v => v.ID == idPerro && v.Estado == "Agendada")
                    .ToList();

                // Asignar datos a los DataGridView.
                dataGridView1.DataSource = vacunasSuministradas;
                dataGridView2.DataSource = vacunasAgendadas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las vacunas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VacunaNamespace;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class ListaVacunas : UserControl
    {
        public ListaVacunas()
        {
            InitializeComponent();
            ConfigurarEstiloDataGridView();
        }

        private void ConfigurarEstiloDataGridView()
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Configurar las columnas para que se ajusten al contenido
            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Ajusta el ancho según el contenido de todas las celdas
            }

            // Ajustar automáticamente las filas según su contenido
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Opcional: Configurar para que el texto se ajuste dentro de las celdas
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ListaVacunas_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            string pathVacunasAgendadas = "vacunas_agendadas.txt";  // Cambiado a vacunas_agendadas.txt
            string pathPerros = "perros.txt";

            // Verifica si los archivos existen
            if (!File.Exists(pathVacunasAgendadas) || !File.Exists(pathPerros))
            {
                MessageBox.Show("No se encontraron los archivos necesarios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lee las líneas de los archivos
            var vacunasData = File.ReadAllLines(pathVacunasAgendadas);  // Cambiado a vacunas_agendadas.txt
            var perrosData = File.ReadAllLines(pathPerros);

            // Procesa los datos de perros en un diccionario para acceso rápido
            var perrosDict = new Dictionary<int, (string Nombre, string Dueño, string Telefono)>();
            foreach (var linea in perrosData)
            {
                var partes = linea.Split(',');
                if (partes.Length >= 6 && int.TryParse(partes[0], out int id))
                {
                    perrosDict[id] = (partes[1], partes[3], partes[4]);
                }
            }

            // Prepara las filas para el DataGridView
            var filas = new List<object[]>();
            foreach (var linea in vacunasData)
            {
                var partes = linea.Split(',');
                if (partes.Length >= 4 && partes[0].StartsWith("ID: ") && int.TryParse(partes[0].Substring(4), out int id))
                {
                    if (perrosDict.TryGetValue(id, out var infoPerro))
                    {
                        // Extraemos la información: Vacuna, Fecha Agendada y Precio
                        var vacuna = partes[1].Split(':')[1].Trim();
                        var fechaAgendadaStr = partes[2].Split(':')[1].Trim();
                        var precio = partes[3].Split(':')[1].Trim();  // Extraemos el precio

                        // Agregamos la fila
                        filas.Add(new object[] {
                    id,
                    infoPerro.Nombre,
                    infoPerro.Dueño,
                    infoPerro.Telefono,
                    vacuna,
                    fechaAgendadaStr,
                    precio  // Agregar el precio
                });
                    }
                }
            }

            // Configura el DataGridView
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("Dueño", "Dueño");
            dataGridView1.Columns.Add("Telefono", "Teléfono");
            dataGridView1.Columns.Add("Vacuna", "Vacuna");
            dataGridView1.Columns.Add("Fecha Agendada", "Fecha Agendada");
            dataGridView1.Columns.Add("Precio", "Precio");  

            ConfigurarEstiloDataGridView();

            // Agrega las filas
            foreach (var fila in filas)
            {
                dataGridView1.Rows.Add(fila);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar si hay una selección válida
            if (comboBox1.SelectedIndex == -1) return;

            // Obtener la selección del ComboBox
            string seleccion = comboBox1.SelectedItem.ToString();

            // Determinar los días según la selección
            int dias = seleccion.Contains("5") ? 5 :
                       seleccion.Contains("10") ? 10 :
                       seleccion.Contains("20") ? 20 :
                       seleccion.Contains("30") ? 30 : 0;

            // Calcular la fecha límite (para los próximos días, no los pasados)
            DateTime fechaLimite = DateTime.Today.AddDays(dias);

            // Recorremos las filas del DataGridView y las ocultamos según el filtro de fecha
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                if (fila.IsNewRow) continue;  // Ignorar la fila en blanco

                // Obtener el valor de la columna "Fecha Agendada" y convertirlo a DateTime
                string fechaAgendadaString = fila.Cells["Fecha Agendada"].Value.ToString();

                DateTime fechaAgendada;
                bool esFechaValida = DateTime.TryParseExact(fechaAgendadaString, "dd/MM/yyyy",
                                                            System.Globalization.CultureInfo.InvariantCulture,
                                                            System.Globalization.DateTimeStyles.None,
                                                            out fechaAgendada);

                if (esFechaValida)
                {
                    // Comparar la fecha agendada con la fecha límite (próximos días)
                    bool mostrarFila = fechaAgendada <= fechaLimite;  // Mostrar solo las vacunas para los próximos días

                    // Establecer la visibilidad de la fila
                    fila.Visible = mostrarFila;
                }
                else
                {
                    fila.Visible = false;  // Si la fecha no es válida, ocultar la fila
                }
            }
        }

    }
}

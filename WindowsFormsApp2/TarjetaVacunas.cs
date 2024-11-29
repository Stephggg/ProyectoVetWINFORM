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
        private int idPerro; // Agregamos la variable para almacenar el ID

        // Constructor modificado para recibir el ID del perro
        public TarjetaVacunas(Panel panel, int idPerro)
        {
            InitializeComponent();
            this.panel7 = panel;
            this.idPerro = idPerro;  // Guardamos el ID del perro
            CargarDatos();  // Llama a CargarDatos() al inicializar el formulario
        }
        private void ConfigurarEstiloDataGridView()
        {
            // Configura las columnas del DataGridView para usar el modo Fill
            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            // Opcional: Configurar estilos adicionales
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // Permitir que el texto se ajuste
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Ajustar filas automáticamente
        }

        private void CargarDatos()
        {
            string pathVacunasAgendadas = "vacunas_agendadas.txt";  // Archivo de vacunas agendadas
            string pathVacunas = "vacunas.txt"; // Archivo de vacunas suministradas
            string pathPerros = "perros.txt"; // Archivo de perros

            // Verifica si los archivos existen
            if (!File.Exists(pathVacunasAgendadas) || !File.Exists(pathVacunas) || !File.Exists(pathPerros))
            {
                MessageBox.Show("No se encontraron los archivos necesarios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lee las líneas de los archivos
            var vacunasAgendadasData = File.ReadAllLines(pathVacunasAgendadas);
            var vacunasData = File.ReadAllLines(pathVacunas);
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

            // Prepara las filas para los DataGridView
            var filasVacunasAgendadas = new List<object[]>();
            var filasVacunasSuministradas = new List<object[]>();

            // Filtra las vacunas agendadas por el idPerro
            foreach (var linea in vacunasAgendadasData)
            {
                var partes = linea.Split(',');
                if (partes.Length >= 3 && partes[0].StartsWith("ID: ") && int.TryParse(partes[0].Substring(4), out int id))
                {
                    if (id == idPerro && perrosDict.TryGetValue(id, out var infoPerro))
                    {
                        var vacuna = partes[1].Split(':')[1].Trim();
                        var fechaAgendadaStr = partes[2].Split(':')[1].Trim();

                        filasVacunasAgendadas.Add(new object[] {
                    id,
                    infoPerro.Nombre,
                    infoPerro.Dueño,
                    infoPerro.Telefono,
                    vacuna,
                    fechaAgendadaStr
                });
                    }
                }
            }

            // Filtra las vacunas suministradas por el idPerro
            foreach (var linea in vacunasData)
            {
                var partes = linea.Split(',');
                if (partes.Length >= 3 && partes[0].StartsWith("ID: ") && int.TryParse(partes[0].Substring(4), out int id))
                {
                    if (id == idPerro && perrosDict.TryGetValue(id, out var infoPerro))
                    {
                        var vacuna = partes[1].Split(':')[1].Trim();
                        var fechaStr = partes[2].Split(':')[1].Trim();

                        filasVacunasSuministradas.Add(new object[] {
                    id,
                    infoPerro.Nombre,
                    infoPerro.Dueño,
                    infoPerro.Telefono,
                    vacuna,
                    fechaStr
                });
                    }
                }
            }

            // Configura los DataGridView
            ConfigurarDataGridView(dataGridView1, filasVacunasSuministradas);
            ConfigurarDataGridView(dataGridView2, filasVacunasAgendadas);
        }

        private void ConfigurarDataGridView(DataGridView dataGridView, List<object[]> filas)
        {
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("ID", "ID");
            dataGridView.Columns.Add("Nombre", "Nombre del Perro");
            dataGridView.Columns.Add("Dueño", "Dueño");
            dataGridView.Columns.Add("Telefono", "Teléfono");
            dataGridView.Columns.Add("Vacuna", "Vacuna");
            dataGridView.Columns.Add("Fecha", "Fecha");  // Cambiado a "Fecha" para ambas

            // Llama al método para configurar el estilo Fill
            ConfigurarEstiloDataGridView();

            // Agrega las filas correspondientes
            foreach (var fila in filas)
            {
                dataGridView.Rows.Add(fila);
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



        private void button1_Click_1(object sender, EventArgs e)
        {
            // Verifica si se ha seleccionado alguna fila
            if (dataGridView1.SelectedRows.Count == 0 && dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una fila para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string vacuna = string.Empty;
            string fecha = string.Empty;
            string idVacuna = string.Empty;

            // Verifica si se seleccionó una fila en dataGridView1 (vacunas suministradas)
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                vacuna = selectedRow.Cells["Vacuna"].Value.ToString();
                fecha = selectedRow.Cells["Fecha"].Value.ToString(); // La columna de fecha en vacunas.txt se llama "Fecha"
                idVacuna = selectedRow.Cells["ID"].Value.ToString(); // Utiliza el ID de la fila para buscar la vacuna
            }

            // Verifica si se seleccionó una fila en dataGridView2 (vacunas agendadas)
            else if (dataGridView2.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView2.SelectedRows[0];
                vacuna = selectedRow.Cells["Vacuna"].Value.ToString();
                fecha = selectedRow.Cells["Fecha"].Value.ToString(); // La columna de fecha en vacunas_agendadas.txt se llama "Fecha"
                idVacuna = selectedRow.Cells["ID"].Value.ToString(); // Utiliza el ID de la fila para buscar la vacuna
            }

            // Si no se encontró la vacuna o la fecha, mostrar un mensaje
            if (string.IsNullOrEmpty(vacuna) || string.IsNullOrEmpty(fecha))
            {
                MessageBox.Show("No se ha seleccionado una vacuna válida para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Llamamos a la función para eliminar la vacuna del archivo correspondiente
            if (dataGridView1.SelectedRows.Count > 0)
            {
                EliminarVacunaDelArchivo("vacunas.txt", idVacuna, vacuna, fecha);
            }
            else if (dataGridView2.SelectedRows.Count > 0)
            {
                EliminarVacunaDelArchivo("vacunas_agendadas.txt", idVacuna, vacuna, fecha);
            }
        }

        private void EliminarVacunaDelArchivo(string filePath, string idVacuna, string vacuna, string fecha)
        {
            try
            {
                // Leer todas las líneas del archivo
                var lineas = File.ReadAllLines(filePath).ToList();

                // Filtrar las líneas que no coinciden con la vacuna y fecha
                var lineasFiltradas = lineas.Where(linea =>
                {
                    // Extraemos la información de cada línea para compararla
                    var partes = linea.Split(',');
                    if (partes.Length >= 3)
                    {
                        string id = partes[0].Substring(4); // Extrae el ID de la línea
                        string vacunaInfo = partes[1].Split(':')[1].Trim(); // Extrae el nombre de la vacuna
                        string fechaInfo = partes[2].Split(':')[1].Trim(); // Extrae la fecha

                        // Compara ID, vacuna y fecha
                        return !(id == idVacuna && vacunaInfo == vacuna && fechaInfo == fecha);
                    }
                    return true;
                }).ToList();

                // Sobrescribe el archivo con las líneas filtradas
                File.WriteAllLines(filePath, lineasFiltradas);

                // Muestra un mensaje de éxito
                MessageBox.Show("La vacuna se ha eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recarga los datos en los DataGridView después de la eliminación
                CargarDatos();
            }
            catch (Exception ex)
            {
                // Manejo de errores
                MessageBox.Show($"Hubo un error al eliminar la vacuna: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Boton Confirmar Vacuna
        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}

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
using Perros;


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

            dataGridView2.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // Configurar las columnas para que se ajusten al contenido
            foreach (DataGridViewColumn columna in dataGridView2.Columns)
            {
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Ajusta el ancho según el contenido de todas las celdas
            }

            // Ajustar automáticamente las filas según su contenido
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Opcional: Configurar para que el texto se ajuste dentro de las celdas
            dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
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

                if (partes.Length >= 4 && partes[0].StartsWith("ID: ") && int.TryParse(partes[0].Substring(4), out int id))
                {
                    if (id == idPerro && perrosDict.TryGetValue(id, out var infoPerro))
                    {
                        var vacuna = partes[1].Split(':')[1].Trim();  // Extraemos el nombre de la vacuna
                        var fechaAgendadaStr = partes[2].Split(':')[1].Trim();  // Extraemos la fecha
                        var precio = partes[3].Split(':')[1].Trim();  // Extraemos el precio

                        filasVacunasAgendadas.Add(new object[] {
                    id,
                    infoPerro.Nombre,
                    infoPerro.Dueño,
                    infoPerro.Telefono,
                    fechaAgendadaStr,
                    precio,  // Añadimos el precio
                    vacuna
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
                        var precio = "C$ 180.00"; // Aquí puedes ajustar según tu lógica para obtener el precio

                        filasVacunasSuministradas.Add(new object[] {
                    id,
                    infoPerro.Nombre,
                    infoPerro.Dueño,
                    infoPerro.Telefono,
                    fechaStr,
                    precio,  // Añadimos el precio
                    vacuna
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
            dataGridView.Columns.Add("Fecha", "Fecha");  // Asegúrate de que esta columna esté configurada correctamente
            dataGridView.Columns.Add("Precio", "Precio C$");
            dataGridView.Columns.Add("Vacuna", "Vacuna");

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

            // Cargar los datos del perro desde el archivo
            var perros = CargarPerrosDesdeArchivo();
            var perroActual = perros.FirstOrDefault(p => p.ID == idPerro);

            if (perroActual != null)
            {
                pantallaControles.CargarDatos(perroActual);
            }

            if (!panel7.Controls.Contains(pantallaControles))
            {
                panel7.Controls.Add(pantallaControles);
                pantallaControles.Dock = DockStyle.Fill;
                pantallaControles.BringToFront();
            }
        }

        // Método auxiliar para cargar datos de perros (extraído del otro formulario para reutilizar)
        private List<Perro> CargarPerrosDesdeArchivo()
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
                        perros.Add(new Perro
                        {
                            ID = int.Parse(datos[0]),
                            Nombre = datos[1],
                            Raza = datos[2],
                            Dueño = datos[3],
                            Telefono = datos[4],
                            Fecha_De_Nacimiento = datos[5],
                            Nota = datos[6]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return perros;
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            // Verifica si se ha seleccionado alguna fila en el DataGridView de vacunas agendadas (dataGridView2)
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona una fila en el DataGridView de vacunas agendadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtén los datos de la fila seleccionada en dataGridView2 (vacunas agendadas)
            var selectedRow = dataGridView2.SelectedRows[0];
            string vacuna = selectedRow.Cells["Vacuna"].Value.ToString();
            string fechaAgendada = selectedRow.Cells["Fecha"].Value.ToString();
            string idVacuna = selectedRow.Cells["ID"].Value.ToString();  // Asumimos que el ID está en la columna "ID"

            // Mostrar un mensaje de confirmación
            var confirmResult = MessageBox.Show($"¿Deseas suministrar la vacuna {vacuna} para el perro con ID {idVacuna}?",
                                                "Confirmar Vacuna",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                // Obtiene la fecha actual (se actualizará la fecha a la actual en el formato dd/MM/yyyy)
                string fechaSuministrada = DateTime.Now.ToString("dd/MM/yyyy");  // Fecha actual con formato dd/MM/yyyy
                string precio = selectedRow.Cells["Precio"].Value.ToString(); // Asumiendo que tienes el precio en la columna "Precio"
                string nombrePerro = selectedRow.Cells["Nombre"].Value.ToString();
                string dueño = selectedRow.Cells["Dueño"].Value.ToString();
                string telefono = selectedRow.Cells["Telefono"].Value.ToString();

                // Agrega la vacuna al archivo de vacunas suministradas
                AgregarVacunaAlArchivo("vacunas.txt", idVacuna, vacuna, fechaSuministrada, precio);

                // Elimina la vacuna de las vacunas agendadas
                EliminarVacunaDelArchivo("vacunas_agendadas.txt", idVacuna, vacuna, fechaAgendada);

                // Actualiza el DataGridView para reflejar los cambios
                try
                {
                    // Intentamos eliminar la fila de dataGridView2 (vacunas agendadas)
                    dataGridView2.Rows.Remove(selectedRow);
                }
                catch (ArgumentException)
                {
                    // Si ocurre una excepción (por ejemplo, si la fila ya fue eliminada o no se puede eliminar), no hacemos nada
                }

                // Añade la vacuna a dataGridView1 (vacunas suministradas)
                dataGridView1.Rows.Add(idVacuna, nombrePerro, dueño, telefono, fechaSuministrada, precio, vacuna);

                // Muestra un mensaje de éxito
                MessageBox.Show("La vacuna ha sido confirmada y movida a vacunas suministradas.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        // Método para agregar la vacuna al archivo de vacunas suministradas (vacunas.txt)
        private void AgregarVacunaAlArchivo(string filePath, string idVacuna, string vacuna, string fecha, string precio)
        {
            try
            {
                // Formatea la nueva línea a agregar al archivo con el formato correcto
                string nuevaLinea = $"ID: {idVacuna}, Vacuna: {vacuna}, Fecha: {fecha}, Precio: {precio}";

                // Escribe la nueva línea al archivo
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine(nuevaLinea);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hubo un error al agregar la vacuna al archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void TarjetaVacunas_Load_1(object sender, EventArgs e)
        {

        }
    }
}

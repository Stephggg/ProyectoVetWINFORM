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
using WindowsFormsApp2; 

namespace WindowsFormsApp2
{
    public partial class Listar : UserControl


    {
        Form1 form1;
        private Panel panel7;



        private List<Perro> perros = new List<Perro>();

        public class Perro
        {
            public int ID { get; set; }
            public string Nombre { get; set; }
            public string Raza { get; set; }
            public string Dueño { get; set; }
            public string Telefono { get; set; }
            public string Fecha { get; set; }
            public string Nota { get; set; }
        }
        public Listar(Panel panel)
        {
            InitializeComponent();
            CargarDatosPerros(); 
            ConfigurarComboBox(); 
            ActualizarDataGridView(perros);
            this.panel7 = panel;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
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


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Listar.cs
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Obtener el perro seleccionado desde la lista de perros
                var perroSeleccionado = perros[e.RowIndex];

                // Crear una instancia de Perros.Perro y copiar los valores
                Perros.Perro perroParaEditar = new Perros.Perro
                {
                    ID = perroSeleccionado.ID,
                    Nombre = perroSeleccionado.Nombre,
                    Raza = perroSeleccionado.Raza,
                    Dueño = perroSeleccionado.Dueño,
                    Telefono = perroSeleccionado.Telefono,
                    Fecha_De_Nacimiento = perroSeleccionado.Fecha,  // Asumiendo que 'Fecha' es la fecha de nacimiento
                    Nota = perroSeleccionado.Nota
                };

                // Crear la instancia de PantallaEdicion y cargar los datos
                PantallaEdicion pantallaControl = new PantallaEdicion(panel7);

                if (!panel7.Controls.Contains(pantallaControl))
                {
                    panel7.Controls.Add(pantallaControl);
                    pantallaControl.Dock = DockStyle.Fill;
                    pantallaControl.BringToFront();
                }

                // Pasar el objeto Perros.Perro a la pantalla de edición
                pantallaControl.CargarDatos(perroParaEditar);
            }
        }








        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void CargarDatosPerros()
        {
            if (File.Exists("perros.txt")) // Comprueba si el archivo existe.
            {
                try
                {
                    using (StreamReader reader = new StreamReader("perros.txt")) // Abre el archivo en modo lectura.
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null) // Lee línea por línea.
                        {
                            var parts = line.Split(','); // Divide la línea en partes usando ",".
                            if (parts.Length == 7)
                            {
                                perros.Add(new Perro // Agrega un nuevo perro a la lista.
                                {
                                    ID = int.Parse(parts[0]),
                                    Nombre = parts[1],
                                    Raza = parts[2],
                                    Dueño = parts[3],
                                    Telefono = parts[4],
                                    Fecha = parts[5],
                                    Nota = parts[6]
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ConfigurarComboBox()
        {

            comboBox2.SelectedIndex = 1; 
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string criterio = comboBox2.SelectedItem.ToString(); // Obtiene el criterio del ComboBox.
            string textoBusqueda = textBox6.Text.Trim(); // Obtiene el texto ingresado.

            List<Perro> resultados = new List<Perro>(); // Lista temporal para los resultados.

            if (!string.IsNullOrWhiteSpace(textoBusqueda)) 
            {
                foreach (var perro in perros) // Recorre la lista de perros.
                {
                    switch (criterio) // Evalúa el criterio de búsqueda.
                    {
                        case "ID":
                            if (int.TryParse(textoBusqueda, out int idBusqueda) && perro.ID == idBusqueda)
                            {
                                resultados.Add(perro); // Agrega perros que coincidan con el ID.
                            }
                            break;
                        case "Nombre":
                            if (perro.Nombre.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                resultados.Add(perro); // Agrega perros cuyo nombre coincida parcialmente.
                            }
                            break;
                        case "Dueño":
                            if (perro.Dueño.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                resultados.Add(perro); // Agrega perros cuyo dueño coincida parcialmente.
                            }
                            break;
                    }
                }
            }
            else
            {
                resultados = perros; // Si no hay texto, muestra todos los perros.
            }

            ActualizarDataGridView(resultados); // Muestra los resultados en el DataGridView.
        }

        private void ActualizarDataGridView(List<Perro> listaPerros)
        {
            dataGridView1.DataSource = null; // Limpia el DataGridView.
            dataGridView1.DataSource = Convertir(listaPerros); // Asigna los datos convertidos.
        }

        private List<Perro> Convertir(List<Perro> listaPerros)
        {
            var listaVisual = new List<Perro>(); // Crea una lista temporal.
            foreach (var perro in listaPerros) // Copia cada perro en la lista temporal.
            {
                listaVisual.Add(new Perro
                {
                    ID = perro.ID,
                    Nombre = perro.Nombre,
                    Raza = perro.Raza,
                    Dueño = perro.Dueño,
                    Telefono = perro.Telefono,
                    Nota = perro.Nota,
                    Fecha = perro.Fecha
                });
            }
            return listaVisual; // Retorna la lista.
        }

        private void Listar_Load(object sender, EventArgs e)
        {

        }
    }
}

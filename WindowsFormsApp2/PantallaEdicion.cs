using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Perros;
namespace WindowsFormsApp2
{
    public partial class PantallaEdicion : UserControl
    {
        private Panel panel7;
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

        public PantallaEdicion(Panel panel)
        {
            InitializeComponent();
            this.panel7 = panel;
        }

        public void CargarDatos(WindowsFormsApp2.Listar.Perro perroListar)
        {
            // Crea un nuevo objeto Perro para la edición.
            var perroPantallaEdicion = new Perro
            {
                ID = perroListar.ID,
                Nombre = perroListar.Nombre,
                Raza = perroListar.Raza,
                Dueño = perroListar.Dueño,
                Telefono = perroListar.Telefono,
                Fecha_De_Nacimiento = perroListar.Fecha,
                Nota = perroListar.Nota
            };

            // Llena los controles de la interfaz con los datos del perro.
            label4.Text = $"ID:        {perroPantallaEdicion.ID}";
            textBox1.Text = perroPantallaEdicion.Nombre;
            textBox4.Text = perroPantallaEdicion.Raza;
            textBox2.Text = perroPantallaEdicion.Dueño;
            textBox5.Text = perroPantallaEdicion.Telefono;
            richTextBox1.Text = perroPantallaEdicion.Nota;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Obtiene el ID del perro desde la etiqueta.
            int id = int.Parse(label4.Text.Split(':')[1].Trim());

            // Carga todos los perros desde el archivo.
            List<Perro> perros = CargarPerrosDesdeArchivo();

            Perro perro = null; // Variable para almacenar el perro que se va a eliminar.

            // Busca el perro con el ID especificado.
            foreach (var p in perros)
            {
                if (p.ID == id)
                {
                    perro = p;
                    break; // Detiene el ciclo una vez que encuentra el perro.
                }
            }

            if (perro != null)
            {
                perros.Remove(perro); // Elimina el perro de la lista.
                GuardarPerrosEnArchivo(perros); // Guarda la lista actualizada en el archivo.

                MessageBox.Show("Perro eliminado con éxito."); // Muestra mensaje de éxito.
            }
            else
            {
                MessageBox.Show("Perro no encontrado."); // Muestra mensaje si no se encuentra el perro.
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(label4.Text.Split(':')[1].Trim());
            string nuevoNombre = textBox1.Text;
            string nuevaRaza = textBox4.Text;
            string nuevoDueño = textBox2.Text;
            string nuevoTelefono = textBox5.Text;
            string nuevaNota = richTextBox1.Text;

            List<Perro> perros = CargarPerrosDesdeArchivo();

            Perro perro = null;

            foreach (var p in perros)
            {
                if (p.ID == id)
                {
                    perro = p;
                    break;
                }
            }

            if (perro != null)
            {
                perro.Nombre = string.IsNullOrWhiteSpace(nuevoNombre) ? perro.Nombre : nuevoNombre;
                perro.Raza = string.IsNullOrWhiteSpace(nuevaRaza) ? perro.Raza : nuevaRaza;
                perro.Dueño = string.IsNullOrWhiteSpace(nuevoDueño) ? perro.Dueño : nuevoDueño;
                perro.Telefono = string.IsNullOrWhiteSpace(nuevoTelefono) ? perro.Telefono : nuevoTelefono;
                perro.Nota = string.IsNullOrWhiteSpace(nuevaNota) ? perro.Nota : nuevaNota;

                GuardarPerrosEnArchivo(perros); 

                MessageBox.Show("Datos del perro actualizados con éxito.");
            }
            else
            {
                MessageBox.Show("Perro no encontrado.");
            }
        }


        private void GuardarPerrosEnArchivo(List<Perro> perros)
        {
            try
            {
                // Abre el archivo en modo de escritura y sobrescribe su contenido.
                using (StreamWriter writer = new StreamWriter("perros.txt", false))
                {
                    // Escribe cada perro en una línea del archivo.
                    foreach (var perro in perros)
                    {
                        writer.WriteLine($"{perro.ID},{perro.Nombre},{perro.Raza},{perro.Dueño},{perro.Telefono},{perro.Fecha_De_Nacimiento},{perro.Nota}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si ocurre algún problema al guardar el archivo.
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Obtiene el ID del perro desde label4.
            int idPerro = int.Parse(label4.Text.Split(':')[1].Trim());

            // Crea la instancia de Regresar pasando el ID y el panel.
            Regresar pantallaControles = new Regresar(panel7, idPerro);

            if (!panel7.Controls.Contains(pantallaControles))
            {
                panel7.Controls.Add(pantallaControles);
                pantallaControles.Dock = DockStyle.Fill;
                pantallaControles.BringToFront();
            }
        }

        private void PantallaEdicion_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            TarjetaVacunas TarjetaVacunas = new TarjetaVacunas(panel7);

            if (!panel7.Controls.Contains(TarjetaVacunas))
            {
                panel7.Controls.Add(TarjetaVacunas);
                TarjetaVacunas.Dock = DockStyle.Fill;
                TarjetaVacunas.BringToFront();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtpFechaRegistro_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

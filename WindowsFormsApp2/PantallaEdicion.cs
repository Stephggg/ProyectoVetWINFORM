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
        Form1 form1;
        private Panel panel7;
        private int idPerro;

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


        // PantallaEdicion.cs
        public void CargarDatos(Perro perro)
        {
            if (perro != null)
            {
                label4.Text = $"ID: {perro.ID}";
                textBox1.Text = perro.Nombre;
                textBox4.Text = perro.Raza;
                textBox2.Text = perro.Dueño;
                textBox5.Text = perro.Telefono;
                richTextBox1.Text = perro.Nota;

                // Cargar la fecha en el DateTimePicker
                DateTime fechaRegistro;
                if (DateTime.TryParse(perro.Fecha_De_Nacimiento, out fechaRegistro))
                {
                    dtpFechaRegistro.Value = fechaRegistro; // Asignamos la fecha al DateTimePicker
                }
                else
                {
                    dtpFechaRegistro.Value = DateTime.Now; // Si la fecha no es válida, se pone la fecha actual
                }
            }
            else
            {
                MessageBox.Show("No se encontraron datos para este perro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Botón Eliminar
        private void button1_Click(object sender, EventArgs e)
        {
            // Mostrar cuadro de confirmación
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar este perro?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario selecciona "No", salir del método
            if (result == DialogResult.No)
            {
                return;
            }

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
            string nuevaFecha = dtpFechaRegistro.Value.ToString("yyyy-MM-dd"); // Obtener la fecha del DateTimePicker

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
                perro.Fecha_De_Nacimiento = nuevaFecha; // Actualizar la fecha con la del DateTimePicker

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

        //Boton Suministrar
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
            // Obtener el ID del perro desde label4
            int idPerro = int.Parse(label4.Text.Split(':')[1].Trim());

            // Crear la instancia de TarjetaVacunas pasando el ID y el panel
            TarjetaVacunas tarjetaVacunas = new TarjetaVacunas(panel7, idPerro);

            if (!panel7.Controls.Contains(tarjetaVacunas))
            {
                panel7.Controls.Clear();  // Limpiar los controles previos
                panel7.Controls.Add(tarjetaVacunas);
                tarjetaVacunas.Dock = DockStyle.Fill;
                tarjetaVacunas.BringToFront();
            }
            else
            {
                tarjetaVacunas.BringToFront();  // En caso de que ya esté agregado, traerlo al frente
            }
        }




        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                richTextBox1.Enabled = true;
            }
            else
            {
                richTextBox1.Enabled = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números y teclas de control (como backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // Limita a un máximo de 8 caracteres
            if (char.IsDigit(e.KeyChar) && textBox5.Text.Length >= 8)
            {
                e.Handled = true;
            }
        }


    }
}

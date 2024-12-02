using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Perros;

namespace WindowsFormsApp2
{
    public partial class Paciente : UserControl
    {
        private List<Perro> perros = new List<Perro>();
        private int siguienteId = 1;

        public Paciente()
        {
            InitializeComponent();
            CargarDatosPerros();
            ActualizarLabelId();
        }

        private void ActualizarLabelId()
        {
            label4.Text = $"ID: {siguienteId}";
        }
        private void InicializarEtiquetasDeError()
        {
            // Configura todas las etiquetas de error como invisibles al inicio
            lblErrorNombre.Visible = false;
            lblErrorRaza.Visible = false;
            lblErrorDueño.Visible = false;
            lblErrorTelefono.Visible = false;
        }

        private bool ValidarFormulario()
        {
            bool esValido = true;

            // Validar Nombre
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                lblErrorNombre.Text = "Este campo es obligatorio.";
                lblErrorNombre.Visible = true;
                esValido = false;
            }
            else
            {
                lblErrorNombre.Visible = false;
            }

            // Validar Raza
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                lblErrorRaza.Text = "Este campo es obligatorio.";
                lblErrorRaza.Visible = true;
                esValido = false;
            }
            else
            {
                lblErrorRaza.Visible = false;
            }

            // Validar Dueño
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                lblErrorDueño.Text = "Este campo es obligatorio.";
                lblErrorDueño.Visible = true;
                esValido = false;
            }
            else
            {
                lblErrorDueño.Visible = false;
            }

            // Validar Teléfono (exactamente 8 dígitos)
            if (textBox5.Text.Length != 8)
            {
                lblErrorTelefono.Text = "El teléfono debe tener exactamente 8 dígitos.";
                lblErrorTelefono.Visible = true;
                esValido = false;
            }
            else
            {
                lblErrorTelefono.Visible = false;
            }

            return esValido;
        }




        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario())
            {
                return; // Si hay errores, no proceder
            }

            try
            {
                Perro nuevoPerro = new Perro
                {
                    ID = siguienteId++,
                    Nombre = textBox1.Text.Trim(),
                    Raza = textBox4.Text.Trim(),
                    Dueño = textBox2.Text.Trim(),
                    Telefono = textBox5.Text.Trim(),
                    Fecha_De_Nacimiento = dtpFechaRegistro.Value.ToString("dd/MM/yyyy"),
                    Nota = richTextBox1.Text.Trim()
                };

                perros.Add(nuevoPerro);
                GuardarDatosPerros();
                LimpiarFormulario();
                ActualizarLabelId();
                MessageBox.Show("Perro registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el perro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarFormulario()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            richTextBox1.Clear();
            dtpFechaRegistro.Value = DateTime.Now;
            ActualizarLabelId();
        }

        private void GuardarDatosPerros()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("perros.txt", append: true))
                {
                    var nuevosPerros = perros.Where(p => p.ID >= siguienteId - 1).ToList();
                    foreach (var perro in nuevosPerros)
                    {
                        writer.WriteLine($"{perro.ID},{perro.Nombre},{perro.Raza},{perro.Dueño},{perro.Telefono},{perro.Fecha_De_Nacimiento},{perro.Nota}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosPerros()
        {
            if (File.Exists("perros.txt"))
            {
                try
                {
                    using (StreamReader reader = new StreamReader("perros.txt"))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var parts = line.Split(',');
                            if (parts.Length == 7)
                            {
                                perros.Add(new Perro
                                {
                                    ID = int.Parse(parts[0]),
                                    Nombre = parts[1],
                                    Raza = parts[2],
                                    Dueño = parts[3],
                                    Telefono = parts[4],
                                    Fecha_De_Nacimiento = parts[5],
                                    Nota = parts[6]
                                });

                                siguienteId = Math.Max(siguienteId, int.Parse(parts[0]) + 1);
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
    


    private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            richTextBox1.Clear();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // Solo permite números y teclas de control
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // Restringir a un máximo de 8 caracteres
            if (char.IsDigit(e.KeyChar) && textBox5.Text.Length >= 8)
            {
                e.Handled = true;
            }
        }




    }
}

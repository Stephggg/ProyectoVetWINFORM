using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        private void button1_Click(object sender, EventArgs e)
        {
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void Paciente_Load(object sender, EventArgs e)
        {

        }
    }
}

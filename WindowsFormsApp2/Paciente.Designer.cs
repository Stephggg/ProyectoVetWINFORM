namespace WindowsFormsApp2
{
    partial class Paciente
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dtpFechaRegistro = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblErrorNombre = new System.Windows.Forms.Label();
            this.lblErrorRaza = new System.Windows.Forms.Label();
            this.lblErrorDueño = new System.Windows.Forms.Label();
            this.lblErrorTelefono = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.label7.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(72, 90);
            this.label7.MaximumSize = new System.Drawing.Size(850, 700);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 23);
            this.label7.TabIndex = 47;
            this.label7.Text = "Nombre del Perro:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(465, 504);
            this.button1.MaximumSize = new System.Drawing.Size(850, 700);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 30);
            this.button1.TabIndex = 44;
            this.button1.Text = "🏠 Guardar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(300, 504);
            this.button2.MaximumSize = new System.Drawing.Size(850, 700);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 30);
            this.button2.TabIndex = 45;
            this.button2.Text = "🧽 Limpiar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(167, 222);
            this.label1.MaximumSize = new System.Drawing.Size(850, 700);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 23);
            this.label1.TabIndex = 35;
            this.label1.Text = "Dueño:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 428);
            this.label2.MaximumSize = new System.Drawing.Size(850, 700);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 23);
            this.label2.TabIndex = 36;
            this.label2.Text = "Fecha de nacimiento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(177, 156);
            this.label3.MaximumSize = new System.Drawing.Size(850, 700);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 23);
            this.label3.TabIndex = 37;
            this.label3.Text = "Raza:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(141, 288);
            this.label5.MaximumSize = new System.Drawing.Size(850, 700);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 161);
            this.label5.TabIndex = 39;
            this.label5.Text = "Teléfono:\n\n\n\n\n\n\n";
            // 
            // textBox5
            // 
            this.textBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox5.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(243, 288);
            this.textBox5.MaximumSize = new System.Drawing.Size(850, 700);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(319, 32);
            this.textBox5.TabIndex = 33;
            this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress_1);
            // 
            // textBox4
            // 
            this.textBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox4.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(241, 156);
            this.textBox4.MaximumSize = new System.Drawing.Size(850, 700);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(319, 32);
            this.textBox4.TabIndex = 32;
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress_1);
            // 
            // textBox2
            // 
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox2.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(241, 222);
            this.textBox2.MaximumSize = new System.Drawing.Size(850, 700);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(318, 32);
            this.textBox2.TabIndex = 31;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress_1);
            // 
            // textBox1
            // 
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox1.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(242, 90);
            this.textBox1.MaximumSize = new System.Drawing.Size(850, 700);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(318, 32);
            this.textBox1.TabIndex = 30;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress_1);
            // 
            // dtpFechaRegistro
            // 
            this.dtpFechaRegistro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpFechaRegistro.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaRegistro.Location = new System.Drawing.Point(242, 421);
            this.dtpFechaRegistro.MaximumSize = new System.Drawing.Size(850, 700);
            this.dtpFechaRegistro.Name = "dtpFechaRegistro";
            this.dtpFechaRegistro.Size = new System.Drawing.Size(350, 32);
            this.dtpFechaRegistro.TabIndex = 49;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.label6.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(175, 354);
            this.label6.MaximumSize = new System.Drawing.Size(850, 700);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 23);
            this.label6.TabIndex = 40;
            this.label6.Text = "Nota:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.SystemColors.Window;
            this.checkBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.checkBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBox1.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.checkBox1.Location = new System.Drawing.Point(236, 354);
            this.checkBox1.MaximumSize = new System.Drawing.Size(850, 700);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 42;
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(257, 354);
            this.richTextBox1.MaximumSize = new System.Drawing.Size(850, 700);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(297, 56);
            this.richTextBox1.TabIndex = 43;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(198, 24);
            this.label4.MaximumSize = new System.Drawing.Size(850, 700);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 23);
            this.label4.TabIndex = 51;
            this.label4.Text = "ID:";
            // 
            // lblErrorNombre
            // 
            this.lblErrorNombre.AutoSize = true;
            this.lblErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.lblErrorNombre.Location = new System.Drawing.Point(240, 125);
            this.lblErrorNombre.MaximumSize = new System.Drawing.Size(850, 700);
            this.lblErrorNombre.Name = "lblErrorNombre";
            this.lblErrorNombre.Size = new System.Drawing.Size(35, 13);
            this.lblErrorNombre.TabIndex = 52;
            this.lblErrorNombre.Text = "label8";
            this.lblErrorNombre.Visible = false;
            // 
            // lblErrorRaza
            // 
            this.lblErrorRaza.AutoSize = true;
            this.lblErrorRaza.ForeColor = System.Drawing.Color.Red;
            this.lblErrorRaza.Location = new System.Drawing.Point(240, 191);
            this.lblErrorRaza.MaximumSize = new System.Drawing.Size(850, 700);
            this.lblErrorRaza.Name = "lblErrorRaza";
            this.lblErrorRaza.Size = new System.Drawing.Size(35, 13);
            this.lblErrorRaza.TabIndex = 53;
            this.lblErrorRaza.Text = "label8";
            this.lblErrorRaza.Visible = false;
            // 
            // lblErrorDueño
            // 
            this.lblErrorDueño.AutoSize = true;
            this.lblErrorDueño.ForeColor = System.Drawing.Color.Red;
            this.lblErrorDueño.Location = new System.Drawing.Point(240, 257);
            this.lblErrorDueño.MaximumSize = new System.Drawing.Size(850, 700);
            this.lblErrorDueño.Name = "lblErrorDueño";
            this.lblErrorDueño.Size = new System.Drawing.Size(35, 13);
            this.lblErrorDueño.TabIndex = 54;
            this.lblErrorDueño.Text = "label8";
            this.lblErrorDueño.Visible = false;
            // 
            // lblErrorTelefono
            // 
            this.lblErrorTelefono.AutoSize = true;
            this.lblErrorTelefono.ForeColor = System.Drawing.Color.Red;
            this.lblErrorTelefono.Location = new System.Drawing.Point(240, 323);
            this.lblErrorTelefono.MaximumSize = new System.Drawing.Size(850, 700);
            this.lblErrorTelefono.Name = "lblErrorTelefono";
            this.lblErrorTelefono.Size = new System.Drawing.Size(35, 13);
            this.lblErrorTelefono.TabIndex = 55;
            this.lblErrorTelefono.Text = "label8";
            this.lblErrorTelefono.Visible = false;
            // 
            // Paciente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblErrorTelefono);
            this.Controls.Add(this.lblErrorDueño);
            this.Controls.Add(this.lblErrorRaza);
            this.Controls.Add(this.lblErrorNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFechaRegistro);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Paciente";
            this.Size = new System.Drawing.Size(638, 575);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dtpFechaRegistro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblErrorNombre;
        private System.Windows.Forms.Label lblErrorRaza;
        private System.Windows.Forms.Label lblErrorDueño;
        private System.Windows.Forms.Label lblErrorTelefono;
    }
}

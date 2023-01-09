using System.IO;
using System.Security.Principal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Diagnostics;

namespace RegistroTareas
{
    public partial class Form1 : Form
    {
        //Test uso de git en visual studio
        //Variables globales
        static string inputTarea = null;
        static string inputTareaPendiente = null;
        static string rutaCarpeta = "RegistroTareas";
        static string rutaPendientes = rutaCarpeta + "\\tareasPendientes.txt";

        static string date = DateTime.Now.ToString("yyyy-MM-dd"); // Asignamos la fecha actual a la variable date
        static string time = DateTime.Now.ToString("HH:mm:ss"); // Asignamos la hora actual a la variable time
        static string dateTime = date + "_" + time; // Asignamos la fecha y hora actual a la variable dateTime

        public Form1()
            
        {
            InitializeComponent();
            // Creamos la carpeta del registro de tareas si no existe
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            string rutaArchivo = "RegistroTareas\\" + date + ".txt";
            if (File.Exists(rutaArchivo))
            {
                string[] elementos = File.ReadAllLines(rutaArchivo);
                listBox1.Items.AddRange(elementos);
                
            }
        }

        private void label2_Click(object sender, EventArgs e) //Etiqueta del listado de tareas
        {
        }

        private void label1_Click(object sender, EventArgs e) //Etiqueta del input de tarea completada
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) //Campo de texto para ingresar tarea
        {
            inputTarea = textBox1.Text;
        }
        private void button1_Click(object sender, EventArgs e) //Botón que añade la tarea del campo de texto a completadas
        {
            if (inputTarea == null) // Si el campo de texto está vacío, no se añade nada
               {
                MessageBox.Show("No se ha ingresado ninguna tarea");
            }
            else // Si el campo de texto está lleno, se añade la tarea al listado
            {
                time = DateTime.Now.ToString("HH:mm:ss"); // Asignamos la hora actual a la variable time
                listBox1.Items.Add(time); //Añadimos la hora actual al listado de tareas
                listBox1.Items.Add(inputTarea);
                textBox1.Text = ""; // Vacía el campo de texto

                // Sobreescritura del archivo de texto con la nueva tarea añadida al listado de tareas 
                string[] elementosLista = new string[listBox1.Items.Count];
                listBox1.Items.CopyTo(elementosLista, 0);


                string date = DateTime.Now.ToString("yyyy-MM-dd"); // Asignamos la fecha actual a la variable date
                File.WriteAllLines("RegistroTareas\\" + date + ".txt", elementosLista); // Creamos el archivo de texto con la fecha y hora actual
            }
           
        }
        private void button4_Click(object sender, EventArgs e) //Botón que añade la tarea del campo de texto a pendientes
        {
            
            if (inputTarea == null) // Si el campo de texto está vacío, no se añade nada
            {
                MessageBox.Show("No se ha ingresado ninguna tarea");
            }
            else // Si el campo de texto está lleno, se añade la tarea al listado
            {
                time = DateTime.Now.ToString("HH:mm:ss"); // Asignamos la hora actual a la variable time
                listBox2.Items.Add(time); //Añadimos la hora actual al listado de tareas
                listBox2.Items.Add(inputTarea);
                textBox1.Text = ""; // Vacía el campo de texto

                // Sobreescritura del archivo de texto con la nueva tarea añadida al listado de tareas 
                string[] elementosLista = new string[listBox2.Items.Count];
                listBox2.Items.CopyTo(elementosLista, 0);

                // Creamos el archivo de texto tareas pendientes si no existe
                if (!File.Exists(rutaPendientes))
                {
                    File.Create(rutaPendientes);
                }

                string date = DateTime.Now.ToString("yyyy-MM-dd"); // Asignamos la fecha actual a la variable date
                File.WriteAllLines("RegistroTareas\\" + date + ".txt", elementosLista); // Creamos el archivo de texto con la fecha y hora actual
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e) //Botón que elimina el elemento seleccionado de la lista
        {
            // Preguntamos al usuario con una ventana emergente si está seguro que desea eliminar el elemento seleccionado, si pulsa sobre "No" se cancela la acción
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar el elemento seleccionado?", "Eliminar elemento", MessageBoxButtons.YesNo);

            // Si el usuario ha pulsado que si, se elimina el elemento seleccionado
            if (dialogResult == DialogResult.Yes)
            {
                // Eliminamos el elemento anterior al que hemos seleccionado en la lista y tambien el que hemos seleccionado
                listBox1.Items.RemoveAt(listBox1.SelectedIndex - 1);
                listBox1.Items.Remove(listBox1.SelectedItem);
                
                    // Sobreescritura de archivo
                    string[] elementosLista = new string[listBox1.Items.Count];
                    listBox1.Items.CopyTo(elementosLista, 0);

                    // Creamos la carpeta si no existe
                    if (!Directory.Exists(rutaCarpeta))
                    {
                        Directory.CreateDirectory(rutaCarpeta);
                    }
                    string date = DateTime.Now.ToString("yyyy-MM-dd"); // Asignamos la fecha actual a la variable date
                    File.WriteAllLines("RegistroTareas\\" + date + ".txt", elementosLista); // Creamos el archivo de texto con la fecha y hora actual
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            // Abrimos la carpeta del registro de tareas en explorer.exe
            string rutaCarpeta = "RegistroTareas";
            Process.Start("explorer.exe", rutaCarpeta);


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }   
}
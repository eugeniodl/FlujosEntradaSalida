using BibliotecaBanco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeerArchivo
{
    public partial class frmLeerArchivo : frmBancoUI
    {
        private FileStream entrada; // mantiene la conexión a un archivo
        private StreamReader archivoReader; // lee datos de un archivo de texto

        public frmLeerArchivo()
        {
            InitializeComponent();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            // crea un cuadro de diálogo que permite al usuario abrir el archivo
            OpenFileDialog selectorArchivo = new OpenFileDialog();
            DialogResult resultado = selectorArchivo.ShowDialog();
            string nombreArchivo; // nombre del archivo que contiene los datos

            // sale del manejador de eventos si el usuario hace clic en Cancelar
            if (resultado == DialogResult.Cancel)
                return;

            nombreArchivo = selectorArchivo.FileName; // obtiene el nombre de archivo especificado
            LimpiarControlesTextBox();

            // muestra error si el usuario especifica un archivo inválido
            if (nombreArchivo == "" || nombreArchivo == null)
                MessageBox.Show("Nombre de archivo inválido", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    // crea objeto FileStream para obtener acceso de lectura al archivo
                    entrada = new FileStream(nombreArchivo, FileMode.Open,
                        FileAccess.Read);
                    // establece el archivo del que se van a leer los datos
                    archivoReader = new StreamReader(entrada);

                    btnAbrir.Enabled = false; // deshabilita el botón Abrir archivo
                    btnSiguiente.Enabled = true; // habilita el botón Siguiente registro
                }
                catch (IOException)
                {
                    MessageBox.Show("Error al leer el archivo", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                // obtiene el siguiente registro disponible en el archivo
                string registroEntrada = archivoReader.ReadLine();
                string[] camposEntrada; // almacena piezas individuales de datos

                if (registroEntrada != null)
                {
                    camposEntrada = registroEntrada.Split(',');
                    Registro registro = new Registro(Convert.ToInt32(camposEntrada[0]),
                        camposEntrada[1], camposEntrada[2],
                        Convert.ToDecimal(camposEntrada[3]));

                    // copia los valores del arreglo string a los valores de los controles TextBox
                    EstablecerValoresControlesTextBox(camposEntrada);
                }
                else
                {
                    archivoReader.Close(); // cierra StreamReader
                    entrada.Close(); // cierra FileStream si no hay registros en el archivo
                    btnAbrir.Enabled = true; // habilita el botón Abrir archivo
                    btnSiguiente.Enabled = false; // deshabilita el botón Siguiente registro
                    LimpiarControlesTextBox();

                    // notifica al usuario si no hay registros en el archivo
                    MessageBox.Show("No hay más registros en el archivo", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Error al leer del archivo", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

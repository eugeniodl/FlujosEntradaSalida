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

namespace CrearArchivo
{
    public partial class frmCrearArchivo : frmBancoUI
    {
        private StreamWriter archivoWriter; // escribe datos en el archivo de texto
        private FileStream salida; // mantiene la conexión con el archivo

        public frmCrearArchivo()
        {
            InitializeComponent();
        }

        // manejador de eventos para el botón Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // crea un cuadro de diálogo que permite al usuario guardar el archivo
            SaveFileDialog selectorArchivo = new SaveFileDialog();
            DialogResult resultado = selectorArchivo.ShowDialog();
            string nombreArchivo; // nombre del archivo en el que se van a guardar los datos

            selectorArchivo.CheckFileExists = false; // permite al usuario crear el archivo

            // sale del manejador de eventos si el usuario hace clic en "Cancelar"
            if (resultado == DialogResult.Cancel)
                return;

            nombreArchivo = selectorArchivo.FileName; // obtiene el nombre del archivo especificado

            // muestra error si el usuario especificó un archivo inválido
            if (nombreArchivo == "" || nombreArchivo == null)
                MessageBox.Show("Nombre de archivo inválido", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                // guarda el archivo mediante el objeto FileStream, si el usuario especificó un archivo válido

                try
                {
                    // abre el archivo con acceso de escritura
                    salida = new FileStream(nombreArchivo, FileMode.OpenOrCreate,
                        FileAccess.Write);

                    // establece el archivo para escribir los datos
                    archivoWriter = new StreamWriter(salida);

                    // deshabilita el botón Guardar y habilita el botón Entrar
                    btnGuardar.Enabled = false;
                    btnEntrar.Enabled = true;
                }
                // maneja la excepción si hay un problema al abrir el archivo
                catch (IOException)
                {
                    // notifica al usuario si el archivo existe
                    MessageBox.Show("Error al abrir el archivo", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // determina si el archivo existe o no
            if (salida != null)
            {
                try
                {
                    archivoWriter.Close(); // cierra StreamWriter
                    salida.Close(); // cierra el archivo
                }
                catch (IOException)
                {
                    MessageBox.Show("No se puede cerrar el archivo", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            // almacena el arreglo string de valores de los controles TextBox
            string[] valores = ObtenerValoresControlesTexBox();

            // Registro que contiene los valores de los controles TextBox
            Registro registro = new Registro();

            // determina si el campo del control TextBox está vacío
            if (valores[(int)IndicesTextBox.CUENTA] != "")
            {
                // almacena los valores de los controles TextBox en Registro

                try
                {
                    // obtiene el valor del número de cuenta del control TextBox
                    int numeroCuenta = int.Parse(valores[(int)IndicesTextBox.CUENTA]);

                    // determina si numeroCuenta es válido
                    if (numeroCuenta > 0)
                    {
                        // almacena los campos TextBox en Registro
                        registro.Cuenta = numeroCuenta;
                        registro.PrimerNombre = valores[(int)IndicesTextBox.NOMBRE];
                        registro.ApellidoPaterno = valores[(int)IndicesTextBox.APELLIDO];
                        registro.Saldo = decimal.Parse(valores[(int)IndicesTextBox.SALDO]);

                        // escribe el Registro al archivo, los campos separados por comas
                        archivoWriter.WriteLine(registro.Cuenta + "," +
                            registro.PrimerNombre + "," + registro.ApellidoPaterno + "," +
                            registro.Saldo);
                    }
                    else
                    {
                        // notifica al usuario si el número de cuenta es inválido
                        MessageBox.Show("Número de cuenta inválido", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error al escribir en archivo", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // notifica al usuario si ocurre un error en relación con el formato de los parámetros
                catch (FormatException)
                {
                    MessageBox.Show("Formato inválido", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            LimpiarControlesTextBox();
        }
    }
}

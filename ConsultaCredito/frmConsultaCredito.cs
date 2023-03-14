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

namespace ConsultaCredito
{
    public partial class frmConsultaCredito : Form
    {
        private FileStream entrada; // mantiene la conexión con el archivo
        private StreamReader archivoReader; // lee datos del archivo de texto

        // nombre del archivo que almacena los saldos con crédito, débito o en cero
        private string nombreArchivo;

        public frmConsultaCredito()
        {
            InitializeComponent();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectorArchivo = new OpenFileDialog();
            DialogResult resultado = selectorArchivo.ShowDialog();

            if (resultado == DialogResult.Cancel)
                return;

            nombreArchivo = selectorArchivo.FileName;

            if (nombreArchivo == "" || nombreArchivo == null)
                MessageBox.Show("Nombre de archivo inválido", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                entrada = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
                archivoReader = new StreamReader(entrada);

                btnAbrir.Enabled = false;
                btnCredito.Enabled = true;
                btnDebito.Enabled = true;
                btnCero.Enabled = true;
            }
        }

        // se invoca cuando el usuario hace clic en el botón de saldos con crédito,
        // saldos con débito o saldos en cero
        private void obtenerSaldos_Click(object sender, EventArgs e)
        {
            // convierte el emisor explícitamente a un objeto de tipo Button
            Button emisorButton = (Button)sender;

            // obtiene el texto del botón en el que se hizo clic, y que almacena el tipo de la cuenta
            string tipoCuenta = emisorButton.Text;

            // lee y muestra la información del archivo
            try
            {

                // regresa al principio del archivo
                entrada.Seek(0, SeekOrigin.Begin);

                txtMostrar.Text = "Las cuentas son:\r\n";

                // recorre el archivo hasta llegar a su fin
                while (true)
                {
                    string[] camposEntrada; // almacena piezas de datos individuales
                    Registro registro; // almacena cada Registro a medida que se lee el archivo
                    decimal saldo; // almacena el saldo de cada Registro

                    // obtiene el siguiente Registro disponible en el archivo
                    string registroEntrada = archivoReader.ReadLine();

                    // cuando está al final del archivo, sale del método
                    if (registroEntrada == null)
                        return;

                    camposEntrada = registroEntrada.Split(','); // analiza la entrada

                    // crea el Registro a partir de entrada
                    registro = new Registro(Convert.ToInt32(camposEntrada[0]),
                        camposEntrada[1], camposEntrada[2],
                        Convert.ToDecimal(camposEntrada[3]));

                    // almacena el último campo del registro en saldo
                    saldo = registro.Saldo;

                    // determina si va a mostrar el saldo o no
                    if (DebeMostrar(saldo, tipoCuenta))
                    {
                        // muestra el registro
                        string salida = registro.Cuenta + "\t" +
                            registro.PrimerNombre + "\t" + registro.ApellidoPaterno + "\t";

                        // muestra el saldo con el formato monetario correcto
                        salida += String.Format("{0:F}", saldo) + "\r\n";

                        txtMostrar.Text += salida; // copia la salida a la pantalla
                    }

                }
            }
            // maneja la excepción cuando no puede leerse el archivo
            catch (IOException)
            {
                MessageBox.Show("No se puede leer el archivo", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // determina si se va a mostrar el registro dado
        private bool DebeMostrar(decimal saldo, string tipoCuenta)
        {
            if(saldo > 0)
            {
                // muestra los saldos con crédito
                if (tipoCuenta == "Saldos con crédito")
                    return true;
            }
            else if(saldo < 0)
            {
                // mostrar los saldos con débito
                if (tipoCuenta == "Saldos con débito")
                    return true;
            }
            else // saldo == 0
            {
                // muestra los saldos en cero
                if (tipoCuenta == "Saldos en cero")
                    return true;
            }
            return false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (entrada != null)
            {
                try
                {
                    entrada.Close();
                    archivoReader.Close();
                }
                catch (IOException)
                {
                    MessageBox.Show("No se puede cerrar el archivo", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            Application.Exit();
        }
    }
}

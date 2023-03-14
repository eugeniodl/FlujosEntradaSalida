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
        private String nombreArchivo;

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

            nombreArchivo = selectorArchivo.FileName; // obtiene el nombre de archivo del usuario

            if(nombreArchivo == "" || nombreArchivo == null)
                MessageBox.Show("Nombre de archivo inválido", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                entrada = new FileStream(nombreArchivo, FileMode.Open,
                    FileAccess.Read);
                archivoReader = new StreamReader(entrada);

                btnAbrir.Enabled = false;
                btnCredito.Enabled = true;
                btnDebito.Enabled = true;
                btnCero.Enabled = true;
            }
        }

        // se invoca cuando el usuario hace clic en el botón saldos con crédito,
        // saldos con débito o saldos en cero
        private void obtenerSaldos_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(entrada != null)
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

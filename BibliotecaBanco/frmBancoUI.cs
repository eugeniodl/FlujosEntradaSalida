using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliotecaBanco
{
    public partial class frmBancoUI : Form
    {
        protected int CuentaTextBox = 4; // número de controles TextBox en el formulario

        // las constantes de la enumeración especifican los índices de los controles TextBox
        public enum IndicesTextBox
        {
            CUENTA,
            NOMBRE,
            APELLIDO,
            SALDO
        }

        public frmBancoUI()
        {
            InitializeComponent();
        }

        // limpia todos los controles TextBox
        public void LimpiarControlesTextBox()
        {
            // itera a través de cada Control en el formulario
            for (int i = 0; i < Controls.Count; i++)
            {
                Control miControl = Controls[i]; // obtiene el control

                // determina si el Control es TextBox
                if (miControl is TextBox)
                {
                    // limpia la propiedad Text (la establece a una cadena vacía)
                    miControl.Text = "";
                }
            }
        }

        // establece los valores de los controles TextBox con el arreglo string valores
        public void EstablecerValoresControlesTextBox(string[] valores)
        {
            // determina si el arreglo string tiene la longitud correcta
            if(valores.Length != CuentaTextBox)
            {
                // lanza excepción si no tiene la longitud correcta
                throw (new ArgumentException("Debe haber " +
                    (CuentaTextBox + 1) + " objetos string en el arreglo"));
            }
            // establece valores si el arreglo tiene la longitud correcta
            else
            {
                txtCuenta.Text = valores[(int)IndicesTextBox.CUENTA];
                txtPrimerNombre.Text = valores[(int)IndicesTextBox.NOMBRE];
                txtApellidoPaterno.Text = valores[(int)IndicesTextBox.APELLIDO];
                txtSaldo.Text = valores[(int)IndicesTextBox.SALDO];
            }
        }

        // devuelve los valores de los controles TextBox como un arreglo string
        public string[] ObtenerValoresControlesTextBox()
        {
            string[] valores = new string[CuentaTextBox];

            // copia los campos de los controles TextBox al arreglo string
            valores[(int)IndicesTextBox.CUENTA] = txtCuenta.Text;
            valores[(int)IndicesTextBox.NOMBRE] = txtPrimerNombre.Text;
            valores[(int)IndicesTextBox.APELLIDO] = txtApellidoPaterno.Text;
            valores[(int)IndicesTextBox.SALDO] = txtSaldo.Text;

            return valores;
        }
    }
}

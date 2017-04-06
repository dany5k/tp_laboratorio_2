using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_1
{
    public partial class TP_1_Calculadora : Form
    {
        public TP_1_Calculadora()
        {
            InitializeComponent();
        }
        #region Desarrollo
        string valor,operador;
        Numero n1;
        Numero n2;

        private void textBox2_TextChanged(object sender, EventArgs e)
        
        {
            valor = this.txtNumero2.Text; // Se toma el valor del primer número escrito por el usuario y se guarda en una variable
            n2 = new Numero(valor); // Pasamos los datos a un objeto de tipo Numeros con un parametro
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblResultado.Text = "";//Al crearse la forma, se limpia el label de resultados
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            valor = this.txtNumero1.Text; // Se toma el valor del primer número escrito por el usuario y se guarda en una variable
            n1 = new Numero(valor); // Pasamos los datos a un objeto de tipo Numeros con un parametro
            
        }

        private void cmbOperacion_SelectedIndexChanged(object sender, EventArgs e) // Es el combobox donde elegimos al operador
        {
           operador= Calculadora.validarOperador( cmbOperacion.Text).ToString(); // Convertimos el operador elegido y lo guardamos en una variable de tipo String
            /*Se busca el método de validarOperador de la clase Calculadora*/
        }

        private void btnOperar_Click(object sender, EventArgs e) // El boton de Igual
        {
            double result;
            result = Calculadora.operar(n1, n2, operador); // Pasamos los parámetros a un método de la clase Calculadora, se calcula y nos da el resultado
            lblResultado.Text = result.ToString(); // Convertimos el resultado a String y lo mostramos
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e) // Limpia todos los campos de la windows form
        {
            lblResultado.Text = "";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperacion.Text = "";
        }
    }
        #endregion
}

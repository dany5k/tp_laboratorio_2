using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1
{
    class Calculadora
    {
        #region Desarrollo
        public static double operar(Numero numero1, Numero numero2, string operador) // Aqui es donde se hacen las cuentas
        {
            double resultado = 0;
            if(numero1 != null && numero2 != null) // Uso esto para controlar la exepcion null
            {
                if (operador == "+")
                {
                    resultado = numero1.getNumero() + numero2.getNumero(); // Con el getNumero() obtenemos el número del objeto, es decir el valor ingresado
                }
                if (operador == "-")
                {
                    resultado = numero1.getNumero() - numero2.getNumero();
                }
                if (operador == "*")
                {
                    resultado = numero1.getNumero() * numero2.getNumero();
                }
                if (operador == "/" && numero2.getNumero() == 0) // Si no se puede dividir por cero, devolvemos cero
                {
                    resultado = 0;
                }
                else
                {
                    if (operador == "/" && numero2.getNumero() != 0) // Si se puede dividir, devolvemos el resultado
                    {
                        resultado = numero1.getNumero() / numero2.getNumero();
                    }
                }
            }
           
            
            return resultado;
        }
        public static string validarOperador(string operador) // Este método sólo devolverá el operador elegido por el usuario
        {
            return operador; // En realidad no hace falta validar nada, ya que el operador se elige, noi se escribe, por lo que no habrá errores
        } // Retornamos el operador

#endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_1
{
    public class Numero
    {
        private double _numero;

        #region Desarrollo

        public double getNumero() // Obtiene el valor del número de un objeto (del atributo de un objeto)
        {
            return this._numero; // Y lo retorna
        }

        public Numero() //Constructor por defecto
        {
            this._numero = 0; // Inicializamos el atributo número en cero
        }

        public Numero(double numero) // Este constructor es inútil, ya que nunca se utilizó, yo no lo usé, ya que por mi no hace falta, uso el que tiene String
        {
            this._numero = numero;
        }

        public Numero(string numero):this() // Se buscará el constructor por defecto y luego se volverá aqui
        {
            setNumero(numero); // Buscamos el método setNumero() con un parámetro
        }

        private void setNumero(string numero) // Este método llamará al método de validarNumero() y luego cargará el valor al atributo número
        {
            this._numero = validarNumero(numero); // Se busca el metodo validarNumero()         
        }

        private static double validarNumero(string numeroString)
        {
            double valor;
            if(double.TryParse(numeroString,out valor)==true ) // Si se puede convertir el valor a un double, retornamos este valor guardado en una variable de tipo double.
            {
                return valor;
            }
            else // De lo contrario, devolvemos la variable con un valor cero.
            return valor=0;
        }
        #endregion
    }
}

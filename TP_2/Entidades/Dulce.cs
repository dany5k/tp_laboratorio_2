using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public class Dulce : Producto
    {
        public Dulce(EMarca marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque): base(marca, codigoDeBarras, colorPrimarioEmpaque)
        {
        }
        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        public override short CantidadCalorias //Falta override+ public
        {
            get
            {
                return 80;
            }
        }

        public override sealed string Mostrar() //Es public
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar()); //Base
            sb.AppendLine("CALORIAS: "+ this.CantidadCalorias); //No lleva {0} ni ,(coma)
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString(); //ToString();
        }
    }
}//Ok

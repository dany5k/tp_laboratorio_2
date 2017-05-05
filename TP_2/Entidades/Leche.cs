using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2017
{
    public class Leche : Producto //public + Hereda de Producto
    {
        public enum ETipo { Entera, Descremada }
        ETipo _tipo = ETipo.Entera; //Por defecto es Entera

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codigoDeBarras, ConsoleColor colorPrimarioEmpaque,ETipo tipo): base(marca, codigoDeBarras, colorPrimarioEmpaque)
        {
            this._tipo = tipo;
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        public override short CantidadCalorias //public
        {
            get
            {
                return 20; //Ok
            }
        }

        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar()); //Llamada a la base
            sb.AppendLine("CALORIAS: "+ this.CantidadCalorias); //No lleva el {0}
            sb.AppendLine("TIPO: " + this._tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();//ToString()
        }
    }
}//OK

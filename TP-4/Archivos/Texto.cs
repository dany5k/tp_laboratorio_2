using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _path;

        public Texto(string archivo)
        {
             this._path = archivo;
        }
       /// <summary>
        /// Initializing interface
       /// </summary>
       /// <param name="data"></param>
       /// <returns></returns>
        public bool guardar(string data) 
        {
            bool result = false; 

            using (StreamWriter file = new StreamWriter(this._path, true))
            {
                file.WriteLine(data);
                result = true;
            }
            return result;
        }
        /// <summary>
        /// Initializing interface
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool leer(out List<string> list) 
        {
            string data;
            list = new List<string>();
            bool flag = false;

            using (StreamReader sr = new StreamReader(this._path))
            {
                while ((data = sr.ReadLine()) != null )
                {
                    list.Add(sr.ReadLine());
                }
                flag = true;
            }

            return flag;
        }
    }
}

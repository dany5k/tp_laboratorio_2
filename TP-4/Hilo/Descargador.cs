﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;
        

        public Descargador(Uri direccion)
        {
            this.direccion = direccion;
            this.html = direccion.ToString();
        }
        public delegate void FinDescargaCallback(string html);
        public delegate void ProgresoDescargaCallback(int progreso);

        public event FinDescargaCallback finDescarga;
        public event ProgresoDescargaCallback progresoDescarga;

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += this.WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += this.WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e; //attention, must be captured
                
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progresoDescarga(e.ProgressPercentage);
        }
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            finDescarga(e.Result);
        }
    }
}

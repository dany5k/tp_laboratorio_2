using System;
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
        private WebClient cliente;
        private System.Net.DownloadStringCompletedEventHandler onDownloadComplete;
        private System.Net.DownloadProgressChangedEventHandler onProgressChanged;
        
        public Descargador(Uri direccion, System.Net.DownloadProgressChangedEventHandler onProgressChanged, System.Net.DownloadStringCompletedEventHandler onDownloadComplete)
        {
            this.html = direccion.AbsolutePath;
            this.direccion = direccion;
            this.cliente = new WebClient();

            this.cliente.DownloadProgressChanged += this.WebClientDownloadProgressChanged;
            this.cliente.DownloadProgressChanged += onProgressChanged;

            this.cliente.DownloadStringCompleted += this.WebClientDownloadCompleted;
            this.cliente.DownloadStringCompleted += onDownloadComplete;

            this.onProgressChanged = onProgressChanged;
            this.onDownloadComplete = onDownloadComplete;
        }

        public void IniciarDescarga()
        {
            try
            {
                //?Not nessesary code
                //WebClient cliente = new WebClient(); 
                //cliente.DownloadProgressChanged += ;
                //cliente.DownloadStringCompleted += ;

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e; //attention, must be captured
                
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
        }
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
        }
    }
}

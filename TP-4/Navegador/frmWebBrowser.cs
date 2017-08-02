using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Hilo;
///<summary>
///Without this we have an error at lines 124 and 129
///</summary>
using System.Net; 

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        Archivos.Texto archivos;

        public frmWebBrowser()
        {
            InitializeComponent();
        }

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
            
            
            this.archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        delegate void ProgresoDescargaCallback(int progreso);

        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });
            }
            else
            {
                tspbProgreso.Value = progreso;
            }
        }
        delegate void FinDescargaCallback(string html);
        private void FinDescarga(string html)
        {
            if (rtxtHtmlCode.InvokeRequired)
            {
                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });
            }
            else
            {
                rtxtHtmlCode.Text = html;
            }
        }
        /// <summary>
        /// Button Ir_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIr_Click(object sender, EventArgs e)
        {
             Uri geturl;

            try
            {
                if (Uri.TryCreate(this.txtUrl.Text, UriKind.Absolute, out geturl) == false)
                {
                    txtUrl.Text = "http://" + txtUrl.Text;
                    geturl = new Uri(txtUrl.Text);
                }

                Descargador descargador = new Descargador(geturl);

                descargador.progresoDescarga += this.ProgresoDescarga;

                descargador.finDescarga += this.FinDescarga;

                Thread th = new Thread(descargador.IniciarDescarga);

                th.Start();


                archivos.guardar(this.txtUrl.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!","Something was wrong" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void onDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.tspbProgreso.Value = e.ProgressPercentage;
        }

        private void onDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.tspbProgreso.Value = 100;
            try //controlling target exception
            {
                this.rtxtHtmlCode.Text = e.Result;
            }
            catch (Exception)
            {

                MessageBox.Show("Error, the target URL cannot be opened", "URL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            
        }

        private string getUrl(string url)
        {
            return "http://" + url;

        }

        
        private void mostrarTodoElHistorialToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmHistorial historial = new frmHistorial();

            historial.Show();
        }
    }
}

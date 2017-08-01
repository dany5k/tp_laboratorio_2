using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Archivos; //missing library
using System.IO;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        public frmHistorial()
        {
            InitializeComponent();
        }

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            
            List<string> historial = new List<string>();
            Texto archivos = new Texto(ARCHIVO_HISTORIAL);
           
            archivos.leer(out historial);

            
                foreach (string item in historial)
                {
                   
                    this.lstHistorial.Items.Add(item);
                                                           
                }
                                                
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace TwinSee
{
    public partial class Form1 : Form
    {
        static string ConfigValueFolder;
        static string FileDaOmettere;
        static List<string> GiaVerificati;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GiaVerificati = new List<string>();
            ConfigValueFolder = ConfigurationManager.AppSettings["Cartella"];
            FileDaOmettere = ConfigurationManager.AppSettings["Filedaomettere"];
            lbl_testo.Text = "TWINSEE" + Environment.NewLine +
                "ATTENZIONE E' STATO GENERATO" + Environment.NewLine +
                "UN SOLO FILE LOG" + Environment.NewLine +
                Environment.NewLine +
                "CONTROLLARE DI AVER CARICATO" + Environment.NewLine +
                "IL PROGRAMMA CORRETTO!";
            this.WindowState = FormWindowState.Minimized;
            AvvioControllo();
        }
        private void AvvioControllo()
        {
            TimerLettura.Interval = 1000;
            TimerLettura.Start();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            TimerLettura.Start();
        }
        private void GoFullscreen(bool fullscreen) 
        { 
            if (fullscreen) 
            { 
                this.WindowState = FormWindowState.Normal; 
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; 
                this.Bounds = Screen.PrimaryScreen.Bounds; 
            } 
            else 
            { 
                this.WindowState = FormWindowState.Maximized; 
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable; 
            } 
        }

        private void TimerLettura_Tick(object sender, EventArgs e)
        {

            if (ControllaGemelli())
            {
                TimerLettura.Stop();
                this.WindowState = FormWindowState.Normal;
                //GoFullscreen(true);
            }

        }
        private bool ControllaGemelli()
        {
            List<string> _nomifile = new List<string>();
            DirectoryInfo _di = new DirectoryInfo( ConfigValueFolder);
            var ElencoFile = _di.GetFiles();
            foreach (var f in ElencoFile)
            {

                var nomefile1 = Path.GetFileNameWithoutExtension(f.FullName);
                string[] _filedacontrollare = nomefile1.Split('_');
                var esiste =GiaVerificati.Find(x => x.Contains(_filedacontrollare[2] + " _" + _filedacontrollare[3]));
                if (FileDaOmettere.Contains(_filedacontrollare[1]) || 
                    !string.IsNullOrEmpty( esiste)) 
                    
                {
                }
                else
                {
                    _nomifile.Add(_filedacontrollare[2] + " _" +_filedacontrollare[3]);
                }

            }
            if(_nomifile.Count>0)
            {
                _nomifile.Sort();
                for(int i=0; i<_nomifile.Count-1;i++ )
                {
                    if (_nomifile[i] != _nomifile[i + 1])
                    {
                        GiaVerificati.Add(_nomifile[i]);
                        return true;
                    }
                    i++;
                }
            }
            return false;
        }
    }
}

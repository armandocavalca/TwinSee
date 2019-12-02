using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;


namespace TwinSee
{
    public partial class Form1 : Form
    {
        static string ConfigValueFolder;
        static string FileDaOmettere;
        static List<string> GiaVerificati;
        static string ConfigHelpFolder;
        static string _Filesolo;
        static string _costante;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GiaVerificati = new List<string>();
            ConfigValueFolder = ConfigurationManager.AppSettings["Cartella"];
            FileDaOmettere = ConfigurationManager.AppSettings["Filedaomettere"];
            ConfigHelpFolder = ConfigurationManager.AppSettings["PercorsoHelp"];
            _costante = "TWINSEE" + Environment.NewLine +
                "ATTENZIONE E' STATO GENERATO" + Environment.NewLine +
                "UN SOLO FILE LOG" + Environment.NewLine +
                " NEW_FILE " + Environment.NewLine +
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
            lbl_testo.Text = "Controllo in esecuzione .......";
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
                lbl_testo.Text = _costante.Replace("NEW_FILE", _Filesolo);

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
                        _Filesolo = _nomifile[i];
                        return true;
                    }
                    i++;
                }
            }
            return false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("Utilizzare tasto OK 'Continua'");

        }

        private void Btn_help_Click(object sender, EventArgs e)
        {
            if(!File.Exists(ConfigHelpFolder))
            {
                MessageBox.Show(" il file :" +
                    ConfigHelpFolder +
                    Environment.NewLine +
                    " inesistente o non raggiungibile");
                return;
            }
            using (Process _process = new Process())
            {
                _process.StartInfo.FileName = ConfigHelpFolder;
                _process.StartInfo.CreateNoWindow = false;
                _process.Start();
            }
        }
    }
}

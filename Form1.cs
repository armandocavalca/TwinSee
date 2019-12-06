﻿using System;
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
        static bool _autorizzatouscire = false;
        static bool _firsttime = true;

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
                if (nomefile1.Substring(1, 5).ToLower() != "dummy" 
                    && nomefile1.Substring(1, 5) != "00000"
                    && nomefile1.Substring(1, 5) != "NullSN")
                {
                    string[] _filedacontrollare = nomefile1.Split('_');
                    var esiste = GiaVerificati.Find(x => x.Contains(_filedacontrollare[2] + " _" + _filedacontrollare[3]));
                    if (FileDaOmettere.Contains(_filedacontrollare[1]) ||
                        !string.IsNullOrEmpty(esiste))

                    {
                    }
                    else
                    {
                        try
                        { _nomifile.Add(_filedacontrollare[2] + " _" + _filedacontrollare[3]); }
                        catch
                        {
                            MessageBox.Show("errore su file " + _filedacontrollare[0] + _filedacontrollare[1]);
                        }
                    }
                }
            }
            if(_nomifile.Count>0)
            {
                if (_firsttime)
                {
                    _nomifile.Sort();
                    for (int i = 0; i < _nomifile.Count - 1; i++)
                    {
                        GiaVerificati.Add(_nomifile[i]);
                    }
                    _firsttime = false;
                }
                else
                {
                    _nomifile.Sort();
                    for (int i = 0; i < _nomifile.Count - 1; i++)
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
            }
            return false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_autorizzatouscire)
            {
                e.Cancel = true;
                MessageBox.Show("Utilizzare tasto OK 'Continua'");
            }
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

        private void Btn_closingWithPassord_Click(object sender, EventArgs e)
        {
            ValidaUser.Validazione _valida = new ValidaUser.Validazione();
            _valida._valido = false;
            ValidaUser.ValidaStatico._validazione = _valida;
            ValidaUser.Form1 fvu = new ValidaUser.Form1();
            fvu.ShowDialog();
            _valida = ValidaUser.ValidaStatico._validazione;
            if (_valida._valido)
            {
                
                if (MessageBox.Show("Utente autorizzato alla chiusura del programma, procedo?", "Uscita", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _autorizzatouscire = true;
                    this.Close(); }
            }

            return;
        }
    }
}

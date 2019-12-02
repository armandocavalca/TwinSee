namespace TwinSee
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbl_testo = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.TimerLettura = new System.Windows.Forms.Timer(this.components);
            this.Btn_help = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_testo
            // 
            this.lbl_testo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_testo.BackColor = System.Drawing.Color.Red;
            this.lbl_testo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_testo.Location = new System.Drawing.Point(48, 21);
            this.lbl_testo.Name = "lbl_testo";
            this.lbl_testo.Size = new System.Drawing.Size(651, 362);
            this.lbl_testo.TabIndex = 0;
            this.lbl_testo.Text = "TWINSEE ";
            this.lbl_testo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.Location = new System.Drawing.Point(51, 402);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(648, 36);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "OK Continua";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // TimerLettura
            // 
            this.TimerLettura.Tick += new System.EventHandler(this.TimerLettura_Tick);
            // 
            // Btn_help
            // 
            this.Btn_help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_help.Location = new System.Drawing.Point(705, 405);
            this.Btn_help.Name = "Btn_help";
            this.Btn_help.Size = new System.Drawing.Size(83, 35);
            this.Btn_help.TabIndex = 2;
            this.Btn_help.Text = "HELP";
            this.Btn_help.UseVisualStyleBackColor = true;
            this.Btn_help.Click += new System.EventHandler(this.Btn_help_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_help);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.lbl_testo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1 - Rel. 1.0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_testo;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Timer TimerLettura;
        private System.Windows.Forms.Button Btn_help;
    }
}


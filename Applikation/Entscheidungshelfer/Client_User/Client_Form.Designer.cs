namespace Client_User
{
    partial class Client_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pgbFortschritt = new System.Windows.Forms.ProgressBar();
            this.btnBefragungNaechsteFrage = new System.Windows.Forms.Button();
            this.btnBefragungAbbrechen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVisualisieren = new System.Windows.Forms.Button();
            this.btnImportieren = new System.Windows.Forms.Button();
            this.lblErgebnis = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pgbFortschritt
            // 
            this.pgbFortschritt.Location = new System.Drawing.Point(68, 75);
            this.pgbFortschritt.Margin = new System.Windows.Forms.Padding(6);
            this.pgbFortschritt.Name = "pgbFortschritt";
            this.pgbFortschritt.Size = new System.Drawing.Size(602, 48);
            this.pgbFortschritt.TabIndex = 0;
            // 
            // btnBefragungNaechsteFrage
            // 
            this.btnBefragungNaechsteFrage.Enabled = false;
            this.btnBefragungNaechsteFrage.Location = new System.Drawing.Point(68, 280);
            this.btnBefragungNaechsteFrage.Margin = new System.Windows.Forms.Padding(6);
            this.btnBefragungNaechsteFrage.Name = "btnBefragungNaechsteFrage";
            this.btnBefragungNaechsteFrage.Size = new System.Drawing.Size(251, 44);
            this.btnBefragungNaechsteFrage.TabIndex = 1;
            this.btnBefragungNaechsteFrage.Text = "Befragung Starten";
            this.btnBefragungNaechsteFrage.UseVisualStyleBackColor = true;
            this.btnBefragungNaechsteFrage.Click += new System.EventHandler(this.btnBefragungNaechsteFrage_Click);
            // 
            // btnBefragungAbbrechen
            // 
            this.btnBefragungAbbrechen.Enabled = false;
            this.btnBefragungAbbrechen.Location = new System.Drawing.Point(68, 365);
            this.btnBefragungAbbrechen.Margin = new System.Windows.Forms.Padding(6);
            this.btnBefragungAbbrechen.Name = "btnBefragungAbbrechen";
            this.btnBefragungAbbrechen.Size = new System.Drawing.Size(251, 44);
            this.btnBefragungAbbrechen.TabIndex = 3;
            this.btnBefragungAbbrechen.Text = "Befragung abbrechen";
            this.btnBefragungAbbrechen.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Fortschritt der Befragung:";
            // 
            // btnVisualisieren
            // 
            this.btnVisualisieren.Enabled = false;
            this.btnVisualisieren.Location = new System.Drawing.Point(398, 365);
            this.btnVisualisieren.Margin = new System.Windows.Forms.Padding(6);
            this.btnVisualisieren.Name = "btnVisualisieren";
            this.btnVisualisieren.Size = new System.Drawing.Size(272, 44);
            this.btnVisualisieren.TabIndex = 7;
            this.btnVisualisieren.Text = "Fragebogen visualisieren";
            this.btnVisualisieren.UseVisualStyleBackColor = true;
            this.btnVisualisieren.Click += new System.EventHandler(this.btnVisualisieren_Click);
            // 
            // btnImportieren
            // 
            this.btnImportieren.Location = new System.Drawing.Point(398, 280);
            this.btnImportieren.Margin = new System.Windows.Forms.Padding(6);
            this.btnImportieren.Name = "btnImportieren";
            this.btnImportieren.Size = new System.Drawing.Size(272, 44);
            this.btnImportieren.TabIndex = 6;
            this.btnImportieren.Text = "Fragebogen importieren";
            this.btnImportieren.UseVisualStyleBackColor = true;
            this.btnImportieren.Click += new System.EventHandler(this.btnImportieren_Click);
            // 
            // lblErgebnis
            // 
            this.lblErgebnis.AutoSize = true;
            this.lblErgebnis.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErgebnis.Location = new System.Drawing.Point(68, 161);
            this.lblErgebnis.Name = "lblErgebnis";
            this.lblErgebnis.Size = new System.Drawing.Size(199, 46);
            this.lblErgebnis.TabIndex = 8;
            this.lblErgebnis.Text = "Ergebnis: ";
            // 
            // Client_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 486);
            this.Controls.Add(this.lblErgebnis);
            this.Controls.Add(this.btnVisualisieren);
            this.Controls.Add(this.btnImportieren);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBefragungAbbrechen);
            this.Controls.Add(this.btnBefragungNaechsteFrage);
            this.Controls.Add(this.pgbFortschritt);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Client_Form";
            this.Text = "Client User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbFortschritt;
        private System.Windows.Forms.Button btnBefragungNaechsteFrage;
        private System.Windows.Forms.Button btnBefragungAbbrechen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVisualisieren;
        private System.Windows.Forms.Button btnImportieren;
        private System.Windows.Forms.Label lblErgebnis;
    }
}


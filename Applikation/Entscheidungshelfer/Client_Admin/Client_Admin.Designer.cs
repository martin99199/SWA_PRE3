﻿namespace Client_Admin
{
    partial class Client_Admin
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExportieren = new System.Windows.Forms.Button();
            this.btnLaden = new System.Windows.Forms.Button();
            this.btnErstellen = new System.Windows.Forms.Button();
            this.tbxVorschau = new System.Windows.Forms.TextBox();
            this.gbFragebogen = new System.Windows.Forms.GroupBox();
            this.btnSpeichern = new System.Windows.Forms.Button();
            this.gbFragebogen.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExportieren
            // 
            this.btnExportieren.Location = new System.Drawing.Point(39, 517);
            this.btnExportieren.Name = "btnExportieren";
            this.btnExportieren.Size = new System.Drawing.Size(450, 59);
            this.btnExportieren.TabIndex = 0;
            this.btnExportieren.Text = "Fragebogen exportieren";
            this.btnExportieren.UseVisualStyleBackColor = true;
            this.btnExportieren.Click += new System.EventHandler(this.btnExportieren_Click);
            // 
            // btnLaden
            // 
            this.btnLaden.Location = new System.Drawing.Point(6, 25);
            this.btnLaden.Name = "btnLaden";
            this.btnLaden.Size = new System.Drawing.Size(214, 46);
            this.btnLaden.TabIndex = 1;
            this.btnLaden.Text = "Laden";
            this.btnLaden.UseVisualStyleBackColor = true;
            this.btnLaden.Click += new System.EventHandler(this.btnLaden_Click);
            // 
            // btnErstellen
            // 
            this.btnErstellen.Location = new System.Drawing.Point(39, 452);
            this.btnErstellen.Name = "btnErstellen";
            this.btnErstellen.Size = new System.Drawing.Size(450, 59);
            this.btnErstellen.TabIndex = 2;
            this.btnErstellen.Text = "Fragebogen erstellen";
            this.btnErstellen.UseVisualStyleBackColor = true;
            this.btnErstellen.Click += new System.EventHandler(this.btnErstellen_Click);
            // 
            // tbxVorschau
            // 
            this.tbxVorschau.Location = new System.Drawing.Point(39, 105);
            this.tbxVorschau.Multiline = true;
            this.tbxVorschau.Name = "tbxVorschau";
            this.tbxVorschau.ReadOnly = true;
            this.tbxVorschau.Size = new System.Drawing.Size(450, 341);
            this.tbxVorschau.TabIndex = 4;
            // 
            // gbFragebogen
            // 
            this.gbFragebogen.Controls.Add(this.btnSpeichern);
            this.gbFragebogen.Controls.Add(this.btnLaden);
            this.gbFragebogen.Location = new System.Drawing.Point(39, 12);
            this.gbFragebogen.Name = "gbFragebogen";
            this.gbFragebogen.Size = new System.Drawing.Size(450, 87);
            this.gbFragebogen.TabIndex = 5;
            this.gbFragebogen.TabStop = false;
            this.gbFragebogen.Text = "Fragebogen";
            // 
            // btnSpeichern
            // 
            this.btnSpeichern.Location = new System.Drawing.Point(230, 25);
            this.btnSpeichern.Name = "btnSpeichern";
            this.btnSpeichern.Size = new System.Drawing.Size(214, 46);
            this.btnSpeichern.TabIndex = 6;
            this.btnSpeichern.Text = "Speichern";
            this.btnSpeichern.UseVisualStyleBackColor = true;
            this.btnSpeichern.Click += new System.EventHandler(this.btnSpeichern_Click);
            // 
            // Client_Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 588);
            this.Controls.Add(this.btnErstellen);
            this.Controls.Add(this.gbFragebogen);
            this.Controls.Add(this.tbxVorschau);
            this.Controls.Add(this.btnExportieren);
            this.Name = "Client_Admin";
            this.Text = "Client Admin";
            this.gbFragebogen.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExportieren;
        private System.Windows.Forms.Button btnLaden;
        private System.Windows.Forms.Button btnErstellen;
        private System.Windows.Forms.TextBox tbxVorschau;
        private System.Windows.Forms.GroupBox gbFragebogen;
        private System.Windows.Forms.Button btnSpeichern;
    }
}


namespace Client_User
{
    partial class Importer
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
            this.cbxFrageboegen = new System.Windows.Forms.ComboBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAnfragen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxFrageboegen
            // 
            this.cbxFrageboegen.FormattingEnabled = true;
            this.cbxFrageboegen.Location = new System.Drawing.Point(60, 74);
            this.cbxFrageboegen.Margin = new System.Windows.Forms.Padding(6);
            this.cbxFrageboegen.Name = "cbxFrageboegen";
            this.cbxFrageboegen.Size = new System.Drawing.Size(648, 33);
            this.cbxFrageboegen.TabIndex = 0;
            // 
            // btnImport
            // 
            this.btnImport.Enabled = false;
            this.btnImport.Location = new System.Drawing.Point(60, 160);
            this.btnImport.Margin = new System.Windows.Forms.Padding(6);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(150, 104);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Importieren";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(562, 160);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 104);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAnfragen
            // 
            this.btnAnfragen.Location = new System.Drawing.Point(316, 160);
            this.btnAnfragen.Margin = new System.Windows.Forms.Padding(6);
            this.btnAnfragen.Name = "btnAnfragen";
            this.btnAnfragen.Size = new System.Drawing.Size(150, 104);
            this.btnAnfragen.TabIndex = 1;
            this.btnAnfragen.Text = "Verfuegbare Frageboegen anfragen";
            this.btnAnfragen.UseVisualStyleBackColor = true;
            this.btnAnfragen.Click += new System.EventHandler(this.btnAnfragen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Verfuegbare Frageboegen:";
            // 
            // Importer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 342);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAnfragen);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.cbxFrageboegen);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Importer";
            this.Text = "Importer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxFrageboegen;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAnfragen;
        private System.Windows.Forms.Label label1;
    }
}
namespace EntscheidungshelferBibliothek
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
            this.cbxAuswahl = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbxAuswahl
            // 
            this.cbxAuswahl.FormattingEnabled = true;
            this.cbxAuswahl.Location = new System.Drawing.Point(524, 39);
            this.cbxAuswahl.Name = "cbxAuswahl";
            this.cbxAuswahl.Size = new System.Drawing.Size(121, 33);
            this.cbxAuswahl.TabIndex = 0;
            // 
            // Importer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 413);
            this.Controls.Add(this.cbxAuswahl);
            this.Name = "Importer";
            this.Text = "Importer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxAuswahl;
    }
}
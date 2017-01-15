namespace EntscheidungshelferBibliothek
{
    partial class FragenSteller
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
            this.lblFrage = new System.Windows.Forms.Label();
            this.btnAntwort1 = new System.Windows.Forms.Button();
            this.btnAntwort2 = new System.Windows.Forms.Button();
            this.btnAbbruch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFrage
            // 
            this.lblFrage.AutoSize = true;
            this.lblFrage.Location = new System.Drawing.Point(12, 9);
            this.lblFrage.Name = "lblFrage";
            this.lblFrage.Size = new System.Drawing.Size(70, 25);
            this.lblFrage.TabIndex = 0;
            this.lblFrage.Text = "label1";
            // 
            // btnAntwort1
            // 
            this.btnAntwort1.Location = new System.Drawing.Point(17, 175);
            this.btnAntwort1.Name = "btnAntwort1";
            this.btnAntwort1.Size = new System.Drawing.Size(659, 84);
            this.btnAntwort1.TabIndex = 1;
            this.btnAntwort1.Text = "button1";
            this.btnAntwort1.UseVisualStyleBackColor = true;
            this.btnAntwort1.Click += new System.EventHandler(this.btnAntwort1_Click);
            // 
            // btnAntwort2
            // 
            this.btnAntwort2.Location = new System.Drawing.Point(17, 293);
            this.btnAntwort2.Name = "btnAntwort2";
            this.btnAntwort2.Size = new System.Drawing.Size(659, 84);
            this.btnAntwort2.TabIndex = 1;
            this.btnAntwort2.Text = "button1";
            this.btnAntwort2.UseVisualStyleBackColor = true;
            this.btnAntwort2.Click += new System.EventHandler(this.btnAntwort2_Click);
            // 
            // btnAbbruch
            // 
            this.btnAbbruch.Location = new System.Drawing.Point(17, 409);
            this.btnAbbruch.Name = "btnAbbruch";
            this.btnAbbruch.Size = new System.Drawing.Size(659, 84);
            this.btnAbbruch.TabIndex = 1;
            this.btnAbbruch.Text = "btnAbbruch";
            this.btnAbbruch.UseVisualStyleBackColor = true;
            this.btnAbbruch.Click += new System.EventHandler(this.btnAbbruch_Click);
            // 
            // FragenSteller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 521);
            this.ControlBox = false;
            this.Controls.Add(this.btnAbbruch);
            this.Controls.Add(this.btnAntwort2);
            this.Controls.Add(this.btnAntwort1);
            this.Controls.Add(this.lblFrage);
            this.Name = "FragenSteller";
            this.Text = "FragenSteller";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFrage;
        private System.Windows.Forms.Button btnAntwort1;
        private System.Windows.Forms.Button btnAntwort2;
        private System.Windows.Forms.Button btnAbbruch;
    }
}
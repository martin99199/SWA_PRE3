namespace Client_Admin
{
    partial class Input_Fragebogen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Input_Fragebogen));
            this.tbxFragebogen = new System.Windows.Forms.TextBox();
            this.btnAbbrechen = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbxFragebogen
            // 
            this.tbxFragebogen.Location = new System.Drawing.Point(34, 152);
            this.tbxFragebogen.Multiline = true;
            this.tbxFragebogen.Name = "tbxFragebogen";
            this.tbxFragebogen.Size = new System.Drawing.Size(495, 328);
            this.tbxFragebogen.TabIndex = 6;
            this.tbxFragebogen.UseWaitCursor = true;
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.Location = new System.Drawing.Point(34, 486);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(219, 59);
            this.btnAbbrechen.TabIndex = 5;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(310, 486);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(219, 59);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lbText
            // 
            this.lbText.AutoSize = true;
            this.lbText.Location = new System.Drawing.Point(30, 9);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(509, 140);
            this.lbText.TabIndex = 8;
            this.lbText.Text = resources.GetString("lbText.Text");
            // 
            // Input_Fragebogen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 557);
            this.ControlBox = false;
            this.Controls.Add(this.lbText);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbxFragebogen);
            this.Controls.Add(this.btnAbbrechen);
            this.Name = "Input_Fragebogen";
            this.Text = "Fragebogen Erstellen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxFragebogen;
        private System.Windows.Forms.Button btnAbbrechen;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lbText;
    }
}
namespace SnippetManager
{
    partial class Settings
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
            this.checkStartup = new System.Windows.Forms.CheckBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDismiss = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkTheme = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkStartup
            // 
            this.checkStartup.AutoSize = true;
            this.checkStartup.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.checkStartup.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkStartup.Location = new System.Drawing.Point(13, 13);
            this.checkStartup.Name = "checkStartup";
            this.checkStartup.Size = new System.Drawing.Size(98, 17);
            this.checkStartup.TabIndex = 0;
            this.checkStartup.Text = "Run on Startup";
            this.checkStartup.UseVisualStyleBackColor = false;
            this.checkStartup.CheckedChanged += new System.EventHandler(this.checkStartup_CheckedChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonSave.Location = new System.Drawing.Point(16, 326);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDismiss
            // 
            this.buttonDismiss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonDismiss.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonDismiss.Location = new System.Drawing.Point(297, 326);
            this.buttonDismiss.Name = "buttonDismiss";
            this.buttonDismiss.Size = new System.Drawing.Size(75, 23);
            this.buttonDismiss.TabIndex = 2;
            this.buttonDismiss.Text = "Dismiss";
            this.buttonDismiss.UseVisualStyleBackColor = false;
            this.buttonDismiss.Click += new System.EventHandler(this.buttonDismiss_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(38, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Activation Key (CTRL + SPACE)";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.Location = new System.Drawing.Point(12, 59);
            this.textBox1.MaxLength = 1;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(20, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // checkTheme
            // 
            this.checkTheme.AutoSize = true;
            this.checkTheme.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.checkTheme.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkTheme.Location = new System.Drawing.Point(13, 36);
            this.checkTheme.Name = "checkTheme";
            this.checkTheme.Size = new System.Drawing.Size(85, 17);
            this.checkTheme.TabIndex = 5;
            this.checkTheme.Text = "Dark Theme";
            this.checkTheme.UseVisualStyleBackColor = false;
            this.checkTheme.CheckedChanged += new System.EventHandler(this.checkTheme_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.checkTheme);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDismiss);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.checkStartup);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkStartup;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDismiss;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkTheme;
    }
}
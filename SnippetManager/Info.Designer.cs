namespace SnippetManager
{
    partial class Info
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
            this.labelKey = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelKey.Location = new System.Drawing.Point(13, 13);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(54, 13);
            this.labelKey.TabIndex = 0;
            this.labelKey.Text = "Keyword: ";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox1.Location = new System.Drawing.Point(16, 30);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(356, 303);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelCount.Location = new System.Drawing.Point(16, 336);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(69, 13);
            this.labelCount.TabIndex = 2;
            this.labelCount.Text = "Used X times";
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.labelKey);
            this.KeyPreview = true;
            this.Name = "Info";
            this.Text = "Info";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Info_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label labelCount;
    }
}
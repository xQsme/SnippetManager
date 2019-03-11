using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnippetManager
{
    public partial class Settings : Form
    {
        public Settings(Boolean startup, char key)
        {
            InitializeComponent();
            checkStartup.Checked = startup;
            textBox1.Text = key.ToString();
            label1.Text = "Activation Key (CTRL + " + key + ")";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonDismiss_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = "Activation Key (CTRL + " + textBox1.Text.ToUpper() + ")";
        }
    }
}

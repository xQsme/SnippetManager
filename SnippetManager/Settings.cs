using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SnippetManager
{
    public partial class Settings : Form
    {
        DataManager data;
        public Settings(DataManager data)
        {
            InitializeComponent();
            this.data = data;
            checkStartup.Checked = data.startup;
            checkTheme.Checked = data.theme;
            textBox1.Text = data.key.ToString();
            if(data.key == ' ')
            {
                label1.Text = "Activation Key (CTRL + SPACE)";
            }
            else
            {
                label1.Text = "Activation Key (CTRL + " + data.key + ")";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Must have an activation key!", "Error");
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void buttonDismiss_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                if (textBox1.Text == " ")
                {
                    label1.Text = "Activation Key (CTRL + SPACE)";
                }
                else
                {
                    label1.Text = "Activation Key (CTRL + " + textBox1.Text.ToUpper() + ")";
                }
                data.key = textBox1.Text[0];
            }
        }

        private void checkStartup_CheckedChanged(object sender, EventArgs e)
        {
            data.startup = checkStartup.Checked;
            /*RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (checkStartup.Checked)
                rk.SetValue("SnippetManager", Application.ExecutablePath);
            else
                rk.DeleteValue("SnippetManager", false);*/
        }

        private void checkTheme_CheckedChanged(object sender, EventArgs e)
        {
            data.theme = checkTheme.Checked;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}

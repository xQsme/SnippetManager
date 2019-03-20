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
        DataManager data;
        public Settings(DataManager data)
        {
            InitializeComponent();
            this.data = data;
            if(!data.theme)
            {
                checkStartup.BackColor = default(Color);
                checkStartup.ForeColor = default(Color);
                checkTheme.BackColor = default(Color);
                checkTheme.ForeColor = default(Color);
                textBox1.BackColor = default(Color);
                textBox1.ForeColor = default(Color);
                buttonSave.BackColor = default(Color);
                buttonSave.ForeColor = default(Color);
                buttonDismiss.BackColor = default(Color);
                buttonDismiss.ForeColor = default(Color);
                label1.BackColor = default(Color);
                label1.ForeColor = default(Color);
                BackColor = default(Color);
            }
            checkStartup.Checked = data.startup;
            checkTheme.Checked = data.theme;
            textBox1.Text = data.keyWord;
            int index = 0;
            if (data.modifier == 1)
            {
                label1.Text = "Activation Keys (ALT + " + data.keyWord + ")";
                index = 0;
            }
            else if (data.modifier == 2)
            {
                label1.Text = "Activation Keys (CTRL + " + data.keyWord + ")";
                index = 1;
            }
            else if (data.modifier == 4)
            {
                label1.Text = "Activation Keys (SHIFT + " + data.keyWord + ")";
                index = 2;
            }
            comboBox1.SelectedIndex = index;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Must have activation keys!", "Error");
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

        private void checkStartup_CheckedChanged(object sender, EventArgs e)
        {
            data.startup = checkStartup.Checked;
        }

        private void checkTheme_CheckedChanged(object sender, EventArgs e)
        {
            data.theme = checkTheme.Checked;
            if(data.theme)
            {
                checkStartup.BackColor = SystemColors.WindowFrame;
                checkStartup.ForeColor = Color.White;
                checkTheme.BackColor = SystemColors.WindowFrame;
                checkTheme.ForeColor = Color.White;
                textBox1.BackColor = Color.FromArgb(64, 64, 64);
                textBox1.ForeColor = Color.White;
                buttonSave.BackColor = Color.FromArgb(64, 64, 64);
                buttonSave.ForeColor = Color.White;
                buttonDismiss.BackColor = Color.FromArgb(64, 64, 64);
                buttonDismiss.ForeColor = Color.White;
                label1.BackColor = SystemColors.WindowFrame;
                label1.ForeColor = Color.White;
                BackColor = SystemColors.WindowFrame;
            }
            else
            {
                checkStartup.BackColor = default(Color);
                checkStartup.ForeColor = default(Color);
                checkTheme.BackColor = default(Color);
                checkTheme.ForeColor = default(Color);
                textBox1.BackColor = default(Color);
                textBox1.ForeColor = default(Color);
                buttonSave.BackColor = default(Color);
                buttonSave.ForeColor = default(Color);
                buttonDismiss.BackColor = default(Color);
                buttonDismiss.ForeColor = default(Color);
                label1.BackColor = default(Color);
                label1.ForeColor = default(Color);
                BackColor = default(Color);
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "ALT")
            {
                data.modifier = 1;
                label1.Text = "Activation Keys (ALT + ";
            }
            else if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "CTRL")
            {
                data.modifier = 2;
                label1.Text = "Activation Keys (CTRL + ";
            } 
            else if(comboBox1.Items[comboBox1.SelectedIndex].ToString() == "SHIFT")
            {
                data.modifier = 4;
                label1.Text = "Activation Keys (SHIFT + ";
            }
            if (textBox1.Text != "")
            {
                if (textBox1.Text == " ")
                {
                    label1.Text += "SPACE)";
                }
                else
                {
                    label1.Text += textBox1.Text.ToUpper() + ")";
                }
            }
        }

        private void Settings_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;

            data.key = e.KeyValue;
            textBox1.Text = e.KeyData.ToString();
            if(textBox1.Text.Contains("D") && textBox1.Text.Length>1)
            {
                textBox1.Text = textBox1.Text[1].ToString();
            }
            if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "ALT")
            {
                data.modifier = 1;
                label1.Text = "Activation Keys (ALT + " + textBox1.Text + ")";
            }
            else if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "CTRL")
            {
                data.modifier = 2;
                label1.Text = "Activation Keys (CTRL + " + textBox1.Text + ")";
            }
            else if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "SHIFT")
            {
                data.modifier = 4;
                label1.Text = "Activation Keys (SHIFT + " + textBox1.Text + ")";
            }
            data.keyWord = textBox1.Text;
        }
    }
}

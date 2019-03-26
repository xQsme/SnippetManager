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
        DataManager newData;
        public Settings(DataManager data)
        {
            InitializeComponent();
            this.data = data;
            newData = (DataManager)data.clone();
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
                comboBox1.BackColor = default(Color);
                comboBox1.ForeColor = default(Color);
                button1.BackColor = default(Color);
                button1.ForeColor = default(Color);
                button2.BackColor = default(Color);
                button2.ForeColor = default(Color);
                label1.BackColor = default(Color);
                label1.ForeColor = default(Color);
                BackColor = default(Color);
            }
            textBox2.BackColor = data.color;
            checkStartup.Checked = data.startup;
            checkTheme.Checked = data.theme;
            textBox1.Text = data.keyWord;
            label3.Text = data.font.Name + " " + data.font.Size;
            label3.Font = data.font;
            label3.ForeColor = data.fontColor;
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
                MessageBox.Show("Must fill every field!", "Error");
            }
            else
            {
                data.startup = newData.startup;
                data.key = newData.key;
                data.keyWord = newData.keyWord;
                data.modifier = newData.modifier;
                data.theme = newData.theme;
                data.color = newData.color;
                data.font = newData.font;
                data.fontColor = newData.fontColor;
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
            newData.startup = checkStartup.Checked;
        }

        private void checkTheme_CheckedChanged(object sender, EventArgs e)
        {
            newData.theme = checkTheme.Checked;
            if(newData.theme)
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
                comboBox1.BackColor = Color.FromArgb(64, 64, 64);
                comboBox1.ForeColor = Color.White;
                button1.BackColor = Color.FromArgb(64, 64, 64);
                button1.ForeColor = Color.White;
                button2.BackColor = Color.FromArgb(64, 64, 64);
                button2.ForeColor = Color.White;
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
                comboBox1.BackColor = default(Color);
                comboBox1.ForeColor = default(Color);
                button1.BackColor = default(Color);
                button1.ForeColor = default(Color);
                button2.BackColor = default(Color);
                button2.ForeColor = default(Color);
                label1.BackColor = default(Color);
                label1.ForeColor = default(Color);
                BackColor = default(Color);
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "ALT")
            {
                newData.modifier = 1;
                label1.Text = "Activation Keys (ALT + ";
            }
            else if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "CTRL")
            {
                newData.modifier = 2;
                label1.Text = "Activation Keys (CTRL + ";
            } 
            else if(comboBox1.Items[comboBox1.SelectedIndex].ToString() == "SHIFT")
            {
                newData.modifier = 4;
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

            newData.key = e.KeyValue;
            textBox1.Text = e.KeyData.ToString();
            if(textBox1.Text.Contains("D") && textBox1.Text.Length>1)
            {
                textBox1.Text = textBox1.Text[1].ToString();
            }
            if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "ALT")
            {
                newData.modifier = 1;
                label1.Text = "Activation Keys (ALT + " + textBox1.Text + ")";
            }
            else if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "CTRL")
            {
                newData.modifier = 2;
                label1.Text = "Activation Keys (CTRL + " + textBox1.Text + ")";
            }
            else if (comboBox1.Items[comboBox1.SelectedIndex].ToString() == "SHIFT")
            {
                newData.modifier = 4;
                label1.Text = "Activation Keys (SHIFT + " + textBox1.Text + ")";
            }
            newData.keyWord = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                textBox2.BackColor = colorDialog1.Color;
                newData.color = colorDialog1.Color;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;

            fontDialog.Font = data.font;
            fontDialog.Color = data.fontColor;

            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                label3.Text = fontDialog.Font.Name + " " + fontDialog.Font.Size;
                label3.Font = fontDialog.Font;
                label3.ForeColor = fontDialog.Color;
                newData.font = fontDialog.Font;
                newData.fontColor = fontDialog.Color;
            }
        }
    }
}

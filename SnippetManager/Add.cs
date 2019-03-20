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
    public partial class Add : Form
    {
        DataManager data;

        public Add(DataManager data)
        {
            InitializeComponent();
            this.data = data;
            if (!data.theme)
            {
                buttonSave.BackColor = default(Color);
                buttonSave.ForeColor = default(Color);
                buttonDismiss.BackColor = default(Color);
                buttonDismiss.ForeColor = default(Color);
                textBox1.BackColor = default(Color);
                textBox1.ForeColor = default(Color);
                richTextBox1.BackColor = default(Color);
                richTextBox1.ForeColor = default(Color);
                label1.BackColor = default(Color);
                label1.ForeColor = default(Color);
                label2.BackColor = default(Color);
                label2.ForeColor = default(Color);
                BackColor = default(Color);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" ||  richTextBox1.Text == "")
            {
                MessageBox.Show("Please fill both inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!data.add(new Snippet(textBox1.Text, richTextBox1.Text)))
            {
                MessageBox.Show("Keyword \"" + textBox1.Text + "\" already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Add_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}

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
                Close();
            }
        }

        private void buttonDismiss_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

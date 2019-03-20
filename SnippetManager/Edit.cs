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
    public partial class Edit : Form
    {
        private Snippet snippet;

        public Edit(Snippet snippet, Boolean theme)
        {
            this.snippet = snippet;
            InitializeComponent();
            textBox1.Text = snippet.keyword;
            richTextBox1.Text = snippet.snippet;
            if (!theme)
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
            snippet.keyword = textBox1.Text;
            snippet.snippet = richTextBox1.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonDismiss_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Edit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}

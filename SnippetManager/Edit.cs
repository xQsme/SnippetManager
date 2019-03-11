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

        public Edit(Snippet snippet)
        {
            this.snippet = snippet;
            InitializeComponent();
            textBox1.Text = snippet.keyword;
            richTextBox1.Text = snippet.snippet;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            snippet.keyword = textBox1.Text;
            snippet.snippet = richTextBox1.Text;
            this.Close();
        }

        private void buttonDismiss_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

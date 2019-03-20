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
    public partial class Info : Form
    {
        public Info(Snippet snippet, Boolean theme)
        {
            InitializeComponent();
            labelKey.Text = "Keyword: " + snippet.keyword;
            labelCount.Text = "Used " + snippet.count + " times";
            richTextBox1.Text = snippet.snippet;
            if (!theme)
            {
                richTextBox1.BackColor = Color.White;
                richTextBox1.ForeColor = default(Color);
                labelKey.BackColor = default(Color);
                labelKey.ForeColor = default(Color);
                labelCount.BackColor = default(Color);
                labelCount.ForeColor = default(Color);
                BackColor = default(Color);
            }
        }

        private void Info_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}

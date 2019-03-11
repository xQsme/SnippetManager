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
    public partial class SnippetSelector : Form
    {
        DataManager data;
        public string ReturnValue { get; set; }
        public SnippetSelector(DataManager data)
        {
            InitializeComponent();
            tableLayoutPanel1.Controls.Add(label1, 1, 1);
            tableLayoutPanel1.Controls.Add(textBox1, 2, 1);
            tableLayoutPanel1.Controls.Add(listBox1, 2, 2);
            this.data = data;
            listBox1.DataSource = data.snippets;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
            if(e.KeyChar == (char)Keys.Enter)
            {
                ReturnValue = data.snippets[listBox1.SelectedIndex].snippet;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void SnippetSelector_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                if(listBox1.SelectedIndex > 0)
                {
                    listBox1.SelectedIndex--;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (listBox1.SelectedIndex < data.snippets.Count-1)
                {
                    listBox1.SelectedIndex++;
                }
            }

        }
    }
}

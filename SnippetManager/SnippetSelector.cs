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
        List<Snippet> currentData;
        public SnippetSelector(DataManager data)
        {
            InitializeComponent();
            tableLayoutPanel1.Controls.Add(label1, 1, 1);
            tableLayoutPanel1.Controls.Add(textBox1, 2, 1);
            tableLayoutPanel1.Controls.Add(listBox1, 2, 2);
            if(!data.theme)
            {
                label1.ForeColor = Color.Black;
                listBox1.ForeColor = Color.Black;
                textBox1.ForeColor = Color.Black;
            }
            this.data = data;
            this.data.snippets.Sort((x, y) => y.count - x.count);
            currentData = new List<Snippet>(this.data.snippets).Take(6).ToList();
            listBox1.DataSource = currentData;
            textBox1.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Snippet> toRemove = new List<Snippet>();
            foreach(Snippet s in data.snippets)
            {
                if(!s.keyword.StartsWith(textBox1.Text))
                {
                    toRemove.Add(s);
                }
            }
            currentData = new List<Snippet>(this.data.snippets);
            foreach (Snippet s in toRemove)
            {
                currentData.Remove(s);
            }
            currentData = currentData.Take(6).ToList();
            listBox1.DataSource = null;
            listBox1.DataSource = currentData;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
            if(e.KeyChar == (char)Keys.Enter)
            {
                if(listBox1.SelectedIndex >= 0 && currentData.Count > 0)
                {
                    ReturnValue = currentData[listBox1.SelectedIndex].snippet;
                    currentData[listBox1.SelectedIndex].count++;
                    DialogResult = DialogResult.OK;
                }
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
                if (listBox1.SelectedIndex < currentData.Count-1)
                {
                    listBox1.SelectedIndex++;
                }
            }

        }
    }
}

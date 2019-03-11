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
    public partial class Form1 : Form
    {
        DataManager data;
        public Form1()
        {
            InitializeComponent();
            data = new DataManager();
            updateList();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = listBox1.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                MessageBox.Show(data.snippets[index].snippet + "\nUsed " + data.snippets[index].count + " times.", data.snippets[index].keyword);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Add add = new Add(data);
            add.ShowDialog();
            updateList();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0 && data.snippets.Count > 0)
            {
                Edit edit = new Edit(data.snippets[listBox1.SelectedIndex]);
                edit.ShowDialog();
                updateList();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex >= 0 && data.snippets.Count > 0)
            {
                data.snippets.Remove(data.snippets[listBox1.SelectedIndex]);
                updateList();
            }
        }

        private void updateList()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = data.snippets;
        }



        /*            SnippetSelector snippetSelector = new SnippetSelector();
            snippetSelector.Show();
            */

    }
}

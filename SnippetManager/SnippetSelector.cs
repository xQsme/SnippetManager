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
        List<Snippet> checkedData;
        List<Snippet> currentData;
        public SnippetSelector(DataManager data)
        {
            InitializeComponent();
            tableLayoutPanel1.Controls.Add(label1, 1, 1);
            tableLayoutPanel1.Controls.Add(textBox1, 2, 1);
            tableLayoutPanel1.Controls.Add(listBox1, 2, 2);
            label1.Font = data.font;
            label1.ForeColor = data.fontColor;
            int height = (int)Math.Ceiling(data.font.Size * 1.3);
            listBox1.ItemHeight = height;
            listBox1.Height = height * 6;
            listBox1.Width = height * 8;
            textBox1.Width = height * 8;
            textBox1.Height = height;
            listBox1.Font = data.font;
            textBox1.Font = data.font;
            listBox1.ForeColor = data.fontColor;
            textBox1.ForeColor = data.fontColor;

            if (!data.theme)
            {
                label1.ForeColor = Color.Black;
                listBox1.ForeColor = Color.Black;
                textBox1.ForeColor = Color.Black;
            }
            this.data = data;
            data.snippets.Sort((x, y) => y.count - x.count);
            checkedData = data.snippets.Where(x => x.check == true).ToList();
            currentData = new List<Snippet>(checkedData).Take(6).ToList();
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
            currentData = new List<Snippet>(checkedData);
            foreach (Snippet s in toRemove)
            {
                currentData.Remove(s);
            }
            currentData = currentData.Take(6).ToList();
            listBox1.DataSource = null;
            listBox1.DataSource = currentData;
        }

        private void SnippetSelector_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.Focus();
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (listBox1.SelectedIndex >= 0 && currentData.Count > 0)
                {
                    ReturnValue = currentData[listBox1.SelectedIndex].snippet;
                    currentData[listBox1.SelectedIndex].increment();
                    DialogResult = DialogResult.OK;
                }
                Close();
            }
            if (e.KeyCode == Keys.Up)
            {
                if (listBox1.SelectedIndex > 0)
                {
                    listBox1.SelectedIndex--;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (listBox1.SelectedIndex < currentData.Count - 1)
                {
                    listBox1.SelectedIndex++;
                }
            }
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            //if the item state is selected them change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics,
                                          e.Font,
                                          e.Bounds,
                                          e.Index,
                                          e.State ^ DrawItemState.Selected,
                                          e.ForeColor,
                                          data.color);//Choose the color

            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Draw the current item text
            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, new SolidBrush(data.fontColor), e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }
    }
}

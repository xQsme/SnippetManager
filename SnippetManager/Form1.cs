using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SnippetManager
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        const int MYACTION_HOTKEY_ID = 1;
        DataManager data;
        public Form1()
        {
            InitializeComponent();
            data = new DataManager();
            updateList();
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 2, (int)data.key);
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
            var result = add.ShowDialog();
            if(result == DialogResult.OK)
            {
                data.saveData();
            }
            updateList();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0 && data.snippets.Count > 0)
            {
                Edit edit = new Edit(data.snippets[listBox1.SelectedIndex]);
                var result = edit.ShowDialog();
                if (result == DialogResult.OK)
                {
                    data.saveData();
                }
                updateList();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex >= 0 && data.snippets.Count > 0)
            {
                data.snippets.Remove(data.snippets[listBox1.SelectedIndex]);
                data.saveData();
                updateList();
            }
        }

        private void updateList()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = data.snippets;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(data);
            var result = settings.ShowDialog();
            if (result == DialogResult.OK)
            {
                UnregisterHotKey(this.Handle, MYACTION_HOTKEY_ID);
                RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 2, (int)data.key);
                data.saveData();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            this.Hide();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID)
            {
                SnippetSelector snippetSelector = new SnippetSelector(data);
                snippetSelector.Shown += delegate (Object sender, EventArgs e) {
                    ((Form)sender).WindowState = FormWindowState.Maximized;
                };
                var result = snippetSelector.ShowDialog();
                if (result == DialogResult.OK)
                {
                    SendKeys.Send(snippetSelector.ReturnValue);
                    data.saveData();
                }
            }
            base.WndProc(ref m);
        }
    }
}

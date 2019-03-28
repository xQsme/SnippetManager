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
using Microsoft.Win32;
using System.Diagnostics;

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
        bool AuthorizeCheck { get; set; }
        public Form1()
        {
            InitializeComponent();
            data = new DataManager();
            if(!data.theme)
            {
                buttonAdd.BackColor = default(Color);
                buttonAdd.ForeColor = default(Color);
                buttonEdit.BackColor = default(Color);
                buttonEdit.ForeColor = default(Color);
                buttonDelete.BackColor = default(Color);
                buttonDelete.ForeColor = default(Color);
                buttonSettings.BackColor = default(Color);
                buttonSettings.ForeColor = default(Color);
                checkedListBox1.BackColor = default(Color);
                checkedListBox1.ForeColor = default(Color);
                BackColor = default(Color);
            }
            updateList();
            RegisterHotKey(Handle, MYACTION_HOTKEY_ID, data.modifier, data.key);
            ContextMenu menu = new ContextMenu();
            menu.MenuItems.Add("Open", (s, e) => restore());
            menu.MenuItems.Add("Exit", (s, e) => Application.Exit());
            notifyIcon1.ContextMenu = menu;
        }

        private void restore()
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void checkedListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point loc = checkedListBox1.PointToClient(Cursor.Position);
            int index = checkedListBox1.IndexFromPoint(e.Location);
            Rectangle rec = checkedListBox1.GetItemRectangle(index);
            rec.Width = 16; //checkbox itself has a default width of about 16 pixels
            if (!rec.Contains(loc))
            {  
                if (index != ListBox.NoMatches)
                {
                    Info info = new Info(data.snippets[index], data.theme);
                    info.Show();
                }
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
            if (checkedListBox1.SelectedIndex >= 0 && data.snippets.Count > 0)
            {
                Edit edit = new Edit(data.snippets[checkedListBox1.SelectedIndex], data.theme);
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
            if(checkedListBox1.SelectedIndex >= 0 && data.snippets.Count > 0)
            {
                data.snippets.Remove(data.snippets[checkedListBox1.SelectedIndex]);
                data.saveData();
                updateList();
            }
        }

        private void updateList()
        {
            checkedListBox1.DataSource = null;
            checkedListBox1.DataSource = data.snippets;
            AuthorizeCheck = true;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (data.snippets[i].check)
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Checked);
                }
                else
                {
                    checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
            AuthorizeCheck = false;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(data);
            var result = settings.ShowDialog();
            if (result == DialogResult.OK)
            {
                UnregisterHotKey(Handle, MYACTION_HOTKEY_ID);
                RegisterHotKey(Handle, MYACTION_HOTKEY_ID, data.modifier, data.key);
                if (data.theme)
                {
                    buttonAdd.BackColor = Color.FromArgb(64, 64, 64);
                    buttonAdd.ForeColor = Color.White;
                    buttonEdit.BackColor = Color.FromArgb(64, 64, 64);
                    buttonEdit.ForeColor = Color.White;
                    buttonDelete.BackColor = Color.FromArgb(64, 64, 64);
                    buttonDelete.ForeColor = Color.White;
                    buttonSettings.BackColor = Color.FromArgb(64, 64, 64);
                    buttonSettings.ForeColor = Color.White;
                    checkedListBox1.BackColor = Color.FromArgb(64, 64, 64);
                    checkedListBox1.ForeColor = Color.White;
                    BackColor = SystemColors.WindowFrame;
                }
                else
                {
                    buttonAdd.BackColor = default(Color);
                    buttonAdd.ForeColor = default(Color);
                    buttonEdit.BackColor = default(Color);
                    buttonEdit.ForeColor = default(Color);
                    buttonDelete.BackColor = default(Color);
                    buttonDelete.ForeColor = default(Color);
                    buttonSettings.BackColor = default(Color);
                    buttonSettings.ForeColor = default(Color);
                    checkedListBox1.BackColor = default(Color);
                    checkedListBox1.ForeColor = default(Color);
                    BackColor = default(Color);
                }
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (data.startup)
                {
                    rk.SetValue("SnippetManager", Application.ExecutablePath);
                }
                else
                {
                    rk.DeleteValue("SnippetManager", false);
                }
                data.saveData();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                restore();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            Hide();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID)
            {
                SnippetSelector snippetSelector = new SnippetSelector(data);
                snippetSelector.Shown += delegate (Object sender, EventArgs e) {
                    ((Form)sender).WindowState = FormWindowState.Maximized;
                };
                var screen = Screen.FromPoint(Cursor.Position);
                snippetSelector.StartPosition = FormStartPosition.Manual;
                snippetSelector.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - snippetSelector.Width / 2;
                snippetSelector.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - snippetSelector.Height / 2;
                var result = snippetSelector.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Clipboard.SetText(snippetSelector.ReturnValue);
                    SendKeys.Send("^{v}");
                    data.saveData();
                }
            }
            base.WndProc(ref m);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void checkedListBox1_DrawItem(object sender, DrawItemEventArgs e)
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
            Brush toApply = data.theme ? Brushes.White : Brushes.Black;
            e.Graphics.DrawString(checkedListBox1.Items[e.Index].ToString(), e.Font, toApply, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        private void checkedListBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && checkedListBox1.SelectedIndex >= 0)
            {
                Info info = new Info(data.snippets[checkedListBox1.SelectedIndex], data.theme);
                info.Show();
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!AuthorizeCheck)
            {
                e.NewValue = e.CurrentValue;
            }

        }

        private void checkedListBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Point loc = checkedListBox1.PointToClient(Cursor.Position);
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                Rectangle rec = checkedListBox1.GetItemRectangle(i);
                rec.Width = 16; //checkbox itself has a default width of about 16 pixels

                if (rec.Contains(loc))
                {
                    AuthorizeCheck = true;
                    bool newValue = !checkedListBox1.GetItemChecked(i);
                    checkedListBox1.SetItemChecked(i, newValue);//check 
                    AuthorizeCheck = false;
                    data.snippets[i].check = newValue;
                    data.saveData();
                return;
                }
            }
        }
    }
}

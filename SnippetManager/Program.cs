using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnippetManager
{
    static class Program
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool ShowWindow(int hWnd, int flags);

        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(int hwnd);

        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool createdNew = true;
            using (Mutex mutex = new Mutex(true, "SnippetManager", out createdNew))
            {
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
                else
                {
                    int iHandle = FindWindow("WindowsForms10.Window.8.app.0.141b42a_r9_ad1", "Snippet Manager");
                    ShowWindow(iHandle, 1);
                    SetForegroundWindow(iHandle);
                }
            }
        }
    }
}

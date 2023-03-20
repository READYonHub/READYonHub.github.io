using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace shutdown
{
    public partial class Form1 : Form
    {

        [DllImport("user32")]
        public static extern void LockWorkStation();

        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        public Form1()
        {
            InitializeComponent();
        }

        private void Shutdown_btn_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Windows\system32\shutdown.exe", "-s -t 0");                      // 0 az idő másodpercben
                                                                                                //-t az időt jelenti
                                                                                                //-s a kikapcsolást
        }

            private void Restart_btn_Click(object sender, EventArgs e)
        {
                Process.Start(@"C:\Windows\system32\shutdown.exe", "/r /t 0"); // /r argumentum az újrainditás
                                                                               // 0 az idő másodpercben
                                                                               //-t az időt jelenti 
        }

        private void Lock_btn_Click(object sender, EventArgs e)
        {
            LockWorkStation(); // Windows + L
        }

        private void LogOFF_btn_Click(object sender, EventArgs e)
        {
            ExitWindowsEx(0, 0);// kijelentkezik az aktuális fiókból
        }
    }
}

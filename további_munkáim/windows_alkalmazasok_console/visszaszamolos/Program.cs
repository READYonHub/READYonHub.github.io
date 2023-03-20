using System;
using System.Runtime.InteropServices;

namespace visszaszamolos
{
    internal class Program
    {
        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);
        static void Main(string[] args)
        {
            //vissza számol a masodpercet és kijelentkezik az aktuális profilból
            for (int a = 3; a >= 0; a--)
            {
                Console.Write("Generating Preview in {0}", a);
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                if (a == 0) {
                    ExitWindowsEx(0, 0);// ez müködik
                }
            }
        }
    }
}

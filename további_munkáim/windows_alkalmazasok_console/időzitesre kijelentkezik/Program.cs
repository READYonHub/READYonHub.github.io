using System;
using System.Threading;

namespace visszaszamoles_kijelentkezik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Add meg, hogy mikor jelentkezzn ki a számitógép: (ora:perc)\n");
            string timeString = Console.ReadLine();

            string[] timeParts = timeString.Split(':');
            int ora = int.Parse(timeParts[0]);
            int perc = int.Parse(timeParts[1]);


            // A kijelentkezési időpont beállítása (beállitott)
            DateTime kijelentkezik = DateTime.Today.AddHours(ora).AddMinutes(perc);

            // Az időzítő beállítása és elindítása
            Timer timer = new Timer((state) =>
            {
                if (DateTime.Now >= kijelentkezik)
                {
                    System.Diagnostics.Process.Start("shutdown", "/l /f");
                }
            }, null, 0, 1000);

            Console.WriteLine("A program fut, és kijelentkezik {0}-kor.", kijelentkezik);

            // Várakozás a program leállításáig
            Console.ReadLine();

            // Az időzítő leállítása
            timer.Dispose();
        }
    }
}
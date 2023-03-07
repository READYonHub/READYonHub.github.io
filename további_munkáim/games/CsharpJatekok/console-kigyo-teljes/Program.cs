using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Threading;
using System.Runtime.InteropServices;

namespace console_kigyo
{
    public interface EzAKigyo
    {
        void Mozogj();
        void Eszik();
    }

    public class Koordinata
    {
        public Koordinata()
        {
            //randomoz egy kezdő koordinátát a kigyónak
            Random RandomKezdoHelyX = new Random();
            int xHely = RandomKezdoHelyX.Next(0, LargestWindowWidth);
            Random RandomKezdoHelyY = new Random();
            int yHely = RandomKezdoHelyY.Next(0, (int)LargestWindowHeight);
            X = xHely;
            Y = yHely;
        }
        public Koordinata(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }

    public enum Direction { BalNyil, JobbNyil, FelNyil, leNyil }

    public class Kigyo : EzAKigyo
    {
        public int hossz { get; set; } = 3;
        public Direction Direction { get; set; } = Direction.JobbNyil;
        public Koordinata fejKoordinata { get; set; } = new Koordinata();
        List<Koordinata> magassag { get; set; } = new List<Koordinata>();
        private bool palyanKivul = false;

        public bool GameOver
        {
            get
            {
                return (magassag.Where(c => c.X == fejKoordinata.X
                  && c.Y == fejKoordinata.Y).ToList().Count > 1) || palyanKivul;
            }
        }
        public void Eszik()
        {
            hossz++;
        }

        public void Mozogj()
        {
            switch (Direction)
            {
                case Direction.BalNyil:
                    fejKoordinata.X--;
                    break;
                case Direction.JobbNyil:
                    fejKoordinata.X++;
                    break;
                case Direction.FelNyil:
                    fejKoordinata.Y--;
                    break;
                case Direction.leNyil:
                    fejKoordinata.Y++;
                    break;
            }
            try
            {
                SetCursorPosition(fejKoordinata.X, fejKoordinata.Y);
                ForegroundColor = ConsoleColor.DarkYellow;
                Write("@");
                magassag.Add(new Koordinata(fejKoordinata.X, fejKoordinata.Y));
                if (magassag.Count > this.hossz)
                {
                    var magassagVege = magassag.First();
                    SetCursorPosition(magassagVege.X, magassagVege.Y);
                    Write(" ");
                    magassag.Remove(magassagVege);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                palyanKivul = true;
            }
        }
    }

    public class Kaja
    {
        public Kaja()
        {
            //kaja spawn koordinata
            Random r = new Random();
            var x = r.Next(1, LargestWindowWidth);
            var y = r.Next(1, LargestWindowHeight);
            celpont = new Koordinata(x, y);
            Rajzol();
        }

        public Koordinata celpont { get; set; }

        void Rajzol()
        {
            SetCursorPosition(celpont.X, celpont.Y);
            ForegroundColor = ConsoleColor.Green;
            Write("$");
        }
    }   

    class Program
    {
        /* megoldás 1 a teljesképernyőre
        
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        megoldás 1 a teljesképernyőre*/

        /* megoldás 2 a teljesképernyőre (JOBB) */
        
        internal static class DllImports
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct COORD
            {

                public short X;
                public short Y;
                public COORD(short x, short y)
                {
                    this.X = x;
                    this.Y = y;
                }

            }
            [DllImport("kernel32.dll")]
            public static extern IntPtr GetStdHandle(int handle);
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool SetConsoleDisplayMode(IntPtr ConsoleOutput, uint Flags, out COORD NewScreenBufferDimensions);
        }

        /*megoldás 2 a teljesképernyőre (JOBB)*/

        static void Formazas()
        {
            //console ablak cime
            Title = "Konzolos Kigyós Játék"; 

        }
        static void Main(string[] args)
        {
            Formazas();

            /* megoldás 1 a teljesképernyőre
              
            SetWindowSize(LargestWindowWidth, LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);        

            megoldás 1 a teljesképernyőre*/

            /* megoldás 2 a teljesképernyőre (JOBB)*/

            IntPtr hConsole = DllImports.GetStdHandle(-11);   // megkapjuk a konzolt
            DllImports.COORD xy = new DllImports.COORD(100, 100);
            DllImports.SetConsoleDisplayMode(hConsole, 1, out xy); // beállitja a cmd ablakot teljesképernyőre

            SetWindowSize(LargestWindowWidth, LargestWindowHeight); // teljes képernyő
            SetBufferSize(WindowWidth, WindowHeight); // buffer méret beállítása

            SetCursorPosition(0, 0);
            
            /* megoldás 2 a teljesképernyőre (JOBB)*/

            CursorVisible = false;
            bool kilep = false;
            double gyorsassag = 1000 / 5.0;
            DateTime utolsoIdo = DateTime.Now;
            Kaja kaja = new Kaja();
            Kigyo kigyo = new Kigyo();

            //game loop
            while (!kilep)
            {
                //irányitás
                if (KeyAvailable)
                {
                    ConsoleKeyInfo be = ReadKey();

                    switch (be.Key)
                    {
                        case ConsoleKey.Escape:
                            kilep = true;
                            break;
                        case ConsoleKey.LeftArrow:
                            kigyo.Direction = Direction.BalNyil;
                            break;
                        case ConsoleKey.RightArrow:
                            kigyo.Direction = Direction.JobbNyil;
                            break;
                        case ConsoleKey.UpArrow:
                            kigyo.Direction = Direction.FelNyil;
                            break;
                        case ConsoleKey.DownArrow:
                            kigyo.Direction = Direction.leNyil;
                            break;
                    }
                }

                if ((DateTime.Now - utolsoIdo).TotalMilliseconds >= gyorsassag)
                {
                    //game action
                    kigyo.Mozogj();

                    //ha a fejPozoció érintkezik a kaja függvénnyel akkor ...
                    if (kaja.celpont.X == kigyo.fejKoordinata.X
                        && kaja.celpont.Y == kigyo.fejKoordinata.Y)
                    {
                        kigyo.Eszik();
                        kaja = new Kaja();
                        gyorsassag /= 1.1;
                    }

                    //ha kilép az ablakméretbőll akkor vége a játéknak
                    if (kigyo.GameOver)
                    {
                        Clear();
                        WriteLine($"Vége a játéknak. A pontszámod: {kigyo.hossz}");
                        kilep = true;
                        //ReadLine();
                        Thread.Sleep(500);

                        //új játék
                        SetCursorPosition(WindowWidth / 2 - 5, WindowHeight / 2);
                        WriteLine("Új játék\t(Enter)\n");
                        SetCursorPosition(WindowWidth / 2 - 5, WindowHeight / 2 + 1);
                        WriteLine("Kilépés \t(Esc)");

                        //figyeli a billentyűleütést
                        ConsoleKeyInfo keyInfo;

                        //addig vár ameddig Enter vagy Escape-et le nem nyomják
                        do
                        {
                            keyInfo = ReadKey(true);
                        }
                        while (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Escape);

                        //ha Escape akkor kilép
                        if (keyInfo.Key == ConsoleKey.Escape)
                        {
                            kilep = true;
                        }

                        //ha Enter akkor folytatja
                        // új játék indítása
                        else
                        {
                            // ha Entert nyomott akkor újra meghivja a Main függvényt
                            while (keyInfo.Key != ConsoleKey.Enter) { }

                            // új játék indítása
                            Clear();
                            Indit();
                        }

                        Clear();
                    }
                    //új játék vége

                    utolsoIdo = DateTime.Now;
                }
            }
        }
        //ez a függvény újrahivja a főprogramot
        static void Indit()
        {
            string[] args = new string[] { };
            Main(args);
        }
    }
}
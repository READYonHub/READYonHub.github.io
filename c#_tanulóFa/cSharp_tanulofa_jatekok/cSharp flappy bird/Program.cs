using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace cSharp_flappy_bird
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Console Flappy Bird";
            Console.CursorVisible = false;
            Flappy flappy = new Flappy(80, 20);
            flappy.Run();
            Console.ReadKey();
        }
    }
}

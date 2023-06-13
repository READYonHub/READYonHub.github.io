using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharp_flappy_bird
{
    internal class Flappy
    {
        int Width { get; set; }
        int Height { get; set; }
        Board board;
        Bird bird;
         
        public Flappy(int width, int height)
        {
            Width = width;
            Height = height;
        }
        void Setup()
        {
            board = new Board(Width,Height);
        }
        public void Run ()
        {
            Console.Clear();
            Setup();
            board.Write();  
        }
    }
    class Bird
    {
        public int X { set; get; }
        public int Y { set; get; }
        ConsoleKeyInfo keyInfo;
        ConsoleKey consoleKey;

        public Bird(int x, int y)
        {
            X = x;
            Y = y;
            keyInfo = new ConsoleKeyInfo();
            consoleKey = new ConsoleKey();
        }
        void Inout()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
            }
        }
        public void Logic()
        {
            Input();
            if(consoleKey == ConsoleKey.Spacebar)
            {
                Up(); 
            }
            else
            {
                Down();
            }
            consoleKey = ConsoleKey.A;
        }
        void Up()
        {
            Console.Write("\0");
            Y--;
            Write();
        }
        void Down()
        {
            Console.Write("\0");
            Y++;
            Write();
        }
        public void Write()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(X, Y - 1);
            Console.Write("▄");
            Console.SetCursorPosition(X - 1, Y - 1);
            Console.Write("▄");
            Console.SetCursorPosition(X - 1, Y);
            Console.Write("▀");
            Console.SetCursorPosition(X,Y);
            Console.Write("▀");
            Console.ForegroundColor = ConsoleColor.White;

        }
        public void Input(string str)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(X, Y - 1);
            Console.Write(str);
            Console.SetCursorPosition(X - 1, Y - 1);
            Console.Write(str);
            Console.SetCursorPosition(X - 1, Y);
            Console.Write(str);
            Console.SetCursorPosition(X, Y);
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.White;

        }
    }

    public class Board
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public Board()
        {
            Height = 20;
            Width = 80;
        }
        public Board(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public void Write()
        {
            for (int i = 1; i <= Width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("─");
            }
            for (int i = 1; i <= Width; i++)
            {
                Console.SetCursorPosition(i, Height + 1);
                Console.Write("─");
            }
            for (int i = 1; i <= Height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("│");
            }
            for (int i = 1; i <= Height; i++)
            {
                Console.SetCursorPosition(Width + 1, i);
                Console.Write("│");
            }
            Console.SetCursorPosition(0, 0);
            Console.Write("┌");
            Console.SetCursorPosition(Width + 1, 0);
            Console.Write("┐");
            Console.SetCursorPosition(0,Height + 1);
            Console.Write("└");
            Console.SetCursorPosition(Width + 1, Height + 1);
            Console.Write("┘");
        }
    }
}

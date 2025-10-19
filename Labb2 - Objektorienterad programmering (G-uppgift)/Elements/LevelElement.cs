

using System.Reflection.Emit;
using System.Xml.Linq;
using Labb2___Objektorienterad_programmering__G_uppgift_.Modeller;

namespace Labb2___Objektorienterad_programmering__G_uppgift_.Modeller
{
    abstract class LevelElement
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }
        public bool Alive { get; set; } = true;

        public LevelElement(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual void Draw()
        {
            if (!Alive) return;

            int offsetX = 0;
            int offsetY = 4;

            Console.SetCursorPosition(X + offsetX, Y + offsetY);
            Console.ForegroundColor = Color;
            Console.Write(Symbol);
            Console.ResetColor();
        }
    }
}





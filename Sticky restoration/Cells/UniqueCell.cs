using System.Drawing;

namespace Sticky_restoration
{
    public enum CellType { emptyCell, borderCell, sawCell }
    public struct UniqueCell
    {
        public char Texture { get; set; }
        public ConsoleColor Color { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        bool isFigurePart;

        public void CellDraw()
        {
            Console.ForegroundColor = Color;
            Console.Write(Texture);
            Console.ResetColor();
        }

        public void Move(ConsoleKey move)
        {
            switch (move)
            {
                case ConsoleKey.A:
                    X--;
                    break;
                case ConsoleKey.W:
                    Y--;
                    break;
                case ConsoleKey.D:
                    X++;
                    break;
                case ConsoleKey.S:
                    Y++;
                    break;
                default:
                    break;
            }
        }

        public UniqueCell(char texture = '█', ConsoleColor color = ConsoleColor.Red, int x = 1, int y = 1, bool isFigurePart = false)
        {
            Texture = texture;
            Color = color;
            X = x;
            Y = y;
            this.isFigurePart = isFigurePart;
        }

        public UniqueCell()
        {
            Texture = '█';
            Color = ConsoleColor.Red;
            X = 1; Y = 1;
            isFigurePart = false;
        }
    }
}

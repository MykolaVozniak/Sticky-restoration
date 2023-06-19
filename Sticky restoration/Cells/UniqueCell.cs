using Sticky_restoration;

namespace Sticky_restoration
{
    public struct UniqueCell : ICell
    {
        public char Texture { get; set; }
        public ConsoleColor Color { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public bool isFigurePart { get; set; }

        public void CellDraw()
        {
            Console.ForegroundColor = Color;
            Console.Write(Texture);
            Console.ResetColor();
        }

        public void Move(ConsoleKey move)
        {
            if (isFigurePart)
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

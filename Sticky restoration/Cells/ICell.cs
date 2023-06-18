namespace Sticky_restoration
{
    public interface ICell
    {
        public char Texture { get; set; }
        public ConsoleColor Color { get; set; }

        public void CellDraw()
        {
            Console.ForegroundColor = Color;
            Console.Write(Texture);
            Console.ResetColor();
        }
    }
}

namespace Sticky_restoration.Cells
{
    internal class Cell
    {
        public char Texture { get; set; }
        public ConsoleColor Color { get; set; }

        public void CellDraw()
        {
            Console.Write(Texture);
        }

    }
}

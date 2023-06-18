namespace Sticky_restoration;

internal class CommonCell : ICell
{
    public char Texture { get; set; }
    public ConsoleColor Color { get; set; }

    public void CellDraw()
    {
        Console.ForegroundColor = Color;
        Console.Write(Texture);
        Console.ResetColor();
    }

    public CommonCell(char texture, ConsoleColor color)
    {
        Texture = texture;
        Color = color;
    }

    public CommonCell()
    {
        Texture = '█';
        Color = ConsoleColor.Blue;
    }

}

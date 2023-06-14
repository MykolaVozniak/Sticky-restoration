namespace Sticky_restoration
{
    internal class Program
    {
        public static byte windowY = 35, windowX = 79;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            MainMenu mainMenu = new MainMenu();
            while (true)
            {
                mainMenu.Load();
            }
            
        }
    }
}
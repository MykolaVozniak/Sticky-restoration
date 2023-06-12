namespace Sticky_restoration
{
    internal class Program
    {
        public static byte windowY = 35, windowX = 79;

        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Load();
        }
    }
}
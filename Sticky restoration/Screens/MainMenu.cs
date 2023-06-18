using System.Drawing;

namespace Sticky_restoration
{
    public class MainMenu : Screen
    {
        GGame game;
        Manual manual = new Manual();

        public void Load()
        {
            base.Load();
            
            ConsoleKey moveTo = Console.ReadKey(true).Key;
            switch (moveTo)
            {
                case ConsoleKey.P:
                    game = new GGame(windowColor : this.windowColor);
                    game.Load();
                    break;
                case ConsoleKey.H:
                    game = new GGame();
                    game.Load();
                    break;
                case ConsoleKey.C:
                    game = new GGame();
                    game.Load();
                    break;
                case ConsoleKey.S:
                    game = new GGame();
                    game.Load();
                    break;
                case ConsoleKey.M:
                    manual.Load();
                    break;
                case ConsoleKey.W:
                    game = new GGame();
                    game.Load();
                    break;
                default:
                    break;
            }
        }

        public MainMenu
            (
            int windowX = 79, 
            int windowY = 35, 
            ConsoleColor windowColor = ConsoleColor.Black, 
            byte frameMargin = 1, 
            byte frameThickness = 1, 
            char frameTexture = '▓', 
            ConsoleColor frameColor = ConsoleColor.White, 
            bool isSoundOn = false, 
            int soundFrequency = 200, 
            int soundDuration = 130, 
            string programName = "programName", 
            string screenName = "screenName", 
            string[] screenText = null
            )
        : base(windowX, windowY, windowColor, frameMargin, frameThickness, frameTexture, frameColor, isSoundOn, soundFrequency, soundDuration, programName, screenName, screenText)
        {
        }
    }
}

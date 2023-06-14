namespace Sticky_restoration
{
    public class MainMenu : Screen
    {
        Game game;
        Manual manual = new Manual();

        public void Load()
        {
            base.Load();
            
            ConsoleKey moveTo = Console.ReadKey(true).Key;
            switch (moveTo)
            {
                case ConsoleKey.P:
                    game = new Game(GameMode.Classic);
                    game.Load();
                    break;
                case ConsoleKey.H:
                    game = new Game(GameMode.Hollow);
                    game.Load();
                    break;
                case ConsoleKey.C:
                    game = new Game(GameMode.Colorful);
                    game.Load();
                    break;
                case ConsoleKey.S:
                    game = new Game(GameMode.Shard);
                    game.Load();
                    break;
                case ConsoleKey.M:
                    manual.Load();
                    break;
                case ConsoleKey.W:
                    game = new Game(GameMode.Word);
                    game.Load();
                    break;
                default:
                    break;
            }
        }

        public MainMenu()
        {
            screenName = "Main Menu";
            screenText = new string[] 
            { 
                "Play Classic Mode \t[P]",
                "Play Hollow Mode \t[H]",
                "Play Colorful Mode \t[C]",
                "Play Shard Mode \t[S]",
                "Play Word Mode \t[W]",
                "Go to Manual \t[M]"
            };
        }
    }
}

namespace Sticky_restoration
{
    enum GameMode { Classic, Hollow, Colorful, Shard }

    class Game : Screen
    {
        GameModule game = new GameModule();
        PictureModule picture = new PictureModule();
        GameMode gameMode;

        public void Load()
        {
            screenName = $"{gameMode} Mode";
            base.Load();
            Console.ReadKey();
        }

        public Game(GameMode gameMode)
        {
            this.gameMode = gameMode;
        }

        public Game()
        {
            gameMode = GameMode.Classic;
            info = new string[] {};
        }
    }
}

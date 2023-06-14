namespace Sticky_restoration
{
    public enum GameMode { Classic, Hollow, Colorful, Shard, Word }

    public class Game : Screen
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
            screenText = new string[] {};
        }
    }
}

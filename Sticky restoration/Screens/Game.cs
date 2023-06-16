using System.Runtime.InteropServices;

namespace Sticky_restoration
{
    public enum GameMode { Classic, Hollow, Colorful, Shard, Word }

    public class Game : Screen
    {
        GameMode gameMode;

        private const sbyte emptyCell = 0;
        private static readonly sbyte[] pieceCells = { 1, 3, 5, 7, 9 };
        private static readonly sbyte[] figureCells = { 2, 4, 6, 8, 10 };
        private const sbyte borderCell = -1;
        private const sbyte sawCell = -2;

        private sbyte[,] rawMatrix;

        private sbyte[,] GameMatrixGenerate()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    rawMatrix[i, j] = emptyCell;
                }

            }

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (i == 1 || i == 20 || j == 1 || j == 20)
                    {
                        rawMatrix[i, j] = borderCell;
                    }
                }
            }

            return rawMatrix;

        }

        public void Load()
        {
            screenName = $"{gameMode} Mode";
            base.Load();

            //GameMatrixGenerate();




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

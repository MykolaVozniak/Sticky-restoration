using System.Runtime.InteropServices;

namespace Sticky_restoration
{
    //public enum GameMode { Classic, Hollow, Colorful, Shard, Word }

    public class Game : Screen
    {
        GameMode gameMode;

        private const sbyte emptyCell = 0;
        private const sbyte pieceCell = 1;
        private const sbyte figureCell = 2;
        private const sbyte borderCell = -1;
        private const sbyte sawCell = -2;

        private sbyte[,] backMatrix;
        private int matrixX;
        private int matrixY;

        ConsoleKey move = ConsoleKey.D;


        private void GenerateMatrix()
        {
            backMatrix = new sbyte[matrixY,matrixX];
            for (int i = 0; i < matrixY; i++)
            {
                for (int j = 0; j < matrixX; j++)
                {
                    if (i == 0 || i == matrixY - 1 || j == 0 || j == matrixX - 1)
                    {
                        backMatrix[i, j] = borderCell;
                    }
                    else
                    {
                        backMatrix[i, j] = emptyCell;
                    }  
                }
            }

        }

        private void CreatePlayer()
        {
            Random random = new Random();
            int figureCellX = random.Next(matrixX / 3, matrixX - matrixX / 3);
            int figureCellY = random.Next(matrixY / 3, matrixY - matrixY / 3);
            backMatrix[figureCellY, figureCellX] = figureCell;
        }

        private void PieceGenerate()
        {
            Random random = new Random();
            int pieceCellX = random.Next(matrixX / 5, matrixX - matrixX / 5);
            int pieceCellY = random.Next(matrixY / 5, matrixY - matrixY / 5);
            backMatrix[pieceCellY, pieceCellX] = pieceCell;
        }

        private void MatrixVisualize()
        {
            for (int i = 0; i < matrixY; i++)
            {
                Console.SetCursorPosition(frameMargin + 3, i + frameMargin + 4);
                
                for (int j = 0; j < matrixX; j++)
                {
                    switch (backMatrix[i, j])
                    {
                        case borderCell:
                            Console.Write("O");
                            break;
                        case emptyCell:
                            Console.Write(".");
                            break;
                        case figureCell:
                            Console.Write("X");
                            break;
                        default:
                            break;
                    }   
                }
                Console.WriteLine();   
            }
        }

        private void FigureMove(ConsoleKey move)
        {
            for (int i = 1; i < matrixY-1; i++)
            {
                for (int j = 1; j < matrixX-1; j++)
                {
                    switch (move)
                    {
                        case ConsoleKey.A:

                            backMatrix[i, j - 1] = backMatrix[i, j];
                            break;
                        case ConsoleKey.W:
                            backMatrix[i - 1, j] = backMatrix[i, j];
                            break;
                        case ConsoleKey.D:
                            backMatrix[i, j + 1] = backMatrix[i, j];
                            break;
                        case ConsoleKey.S:
                            backMatrix[i + 1, j] = backMatrix[i, j];
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void PlayGame()
        {
            while (true)
            {
                Thread.Sleep(1000);
                MatrixVisualize();
                FigureMove(move);
                
                if (Console.KeyAvailable)
                {
                    ConsoleKey move = Console.ReadKey(true).Key;
                }
            }
        }

        public void Load()
        {
            screenName = $"{gameMode} Mode";
            base.Load();

            GenerateMatrix();
            CreatePlayer();
            PlayGame();

            Console.ReadKey();
        }



        public Game(GameMode gameMode = GameMode.Classic) : base()
        {
            this.gameMode = gameMode;
            screenText = new string[] { };
            matrixX = 35;
            matrixY = 25;
        }

    }
}

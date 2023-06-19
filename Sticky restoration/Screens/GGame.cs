using System.Security.Cryptography;

namespace Sticky_restoration
{
    public enum GameMode { Classic, Hollow, Colorful, Shard, Word }
    public class GGame : Screen
    {
        int matrixX;
        int matrixY;
        int matrixXSpacing;

        char[,] picture;
        int pictureX;
        int pictureY;

        ICell[,] pictureMatrix;
        ICell[,] gameMatrix;

        CommonCell borderCell;
        CommonCell emptinessCell;
        //???Cell saw;
        List<UniqueCell> spawnCellList = new List<UniqueCell>();

        private void DrawMatrix(ICell[,] matrix, int startDrawPoint)
        {
            for (int i = 0; i < matrixY; i++)
            {
                Console.SetCursorPosition(startDrawPoint, i + 5);
                for (int j = 0; j < matrixX; j++)
                {
                    matrix[i, j].CellDraw();
                }
                Console.WriteLine();
            }
        }

        private ICell[,] GenerateMatrix(ICell[,] matrix)
        {
            matrix = new ICell[matrixY, matrixX];
            for (int i = 0; i < matrixY; i++)
            {
                for (int j = 0; j < matrixX; j++)
                {
                    if (i == 0 || i == matrixY - 1 || j == 0 || j == matrixX - 1)
                    {
                        matrix[i, j] = borderCell;
                    }
                    else
                    {
                        matrix[i, j] = emptinessCell;
                    }
                }
            }
            return matrix;
        }

        private ICell[,] GeneratePictureMatrix(ICell[,] matrix)
        {
            matrix = GenerateMatrix(matrix);
            int startPointX = (matrixX - pictureX) / 2;
            int startPointY = (matrixY - pictureY) / 2;
            if (startPointX > 0 && startPointY > 0)
            {
                for (int i = 0; i < pictureY; i++)
                {
                    for (int j = 0; j < pictureX; j++)
                    {
                     matrix[i + startPointY, j + startPointX] = new UniqueCell(texture: picture[i, j], x: i + startPointY, y: i + startPointY, isFigurePart: true);
                    }
                }
            }
            return matrix;
        }

        private ICell[,] GenerateGameMatrix(ICell[,] matrix)
        {
            matrix = GenerateMatrix(matrix);
            Random random = new Random();
            int figureCellX = random.Next(matrixX / 3, matrixX - matrixX / 3);
            int figureCellY = random.Next(matrixY / 3, matrixY - matrixY / 3);
            matrix[figureCellY, figureCellX] = new UniqueCell(texture: spawnCellList[0].Texture, color:ConsoleColor.Yellow, x: figureCellX, y: figureCellY, isFigurePart: true);
            return matrix;
        }

        private void UpdateGameMatrix()
        {
            for (int i = 0; i < matrixY; i++)
            {
                for (int j = 0; j < matrixX; j++)
                {
                    if (gameMatrix[i, j] == null)
                    {
                        gameMatrix[i, j] = emptinessCell;
                    }
                    if (gameMatrix[i, j] is UniqueCell && ((UniqueCell)gameMatrix[i, j]).isFigurePart)
                    {
                        gameMatrix[((UniqueCell)gameMatrix[i, j]).Y, ((UniqueCell)gameMatrix[i, j]).X] = gameMatrix[i, j];
                    }
                }
            }
            Random random = new Random();
            int figureCellX = random.Next(matrixX / 5, matrixX - matrixX / 5);
            int figureCellY = random.Next(matrixY / 5, matrixY - matrixY / 5);
            gameMatrix[figureCellY, figureCellX] = new UniqueCell(texture: spawnCellList[0].Texture, x: figureCellX, y: figureCellY, isFigurePart: false);
        }

        private void ExtractCells()
        {
            pictureY = picture.GetLength(0);
            pictureX = picture.GetLength(1);
            char emptinessCellIdentifier = emptinessCell.Texture;
            char borderCellIdentifire = borderCell.Texture;

            for (int i = 0; i < pictureY; i++)
            {
                for (int j = 0; j < pictureX; j++)
                {
                    if (!spawnCellList.Contains(new UniqueCell(texture: picture[i, j])) && picture[i,j] != emptinessCellIdentifier && picture[i, j] != borderCellIdentifire)
                    {
                        spawnCellList.Add(new UniqueCell(texture: picture[i, j]));
                    }
                }
            }
        }

        private void PlayGame()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey move = Console.ReadKey(true).Key;
                    foreach (var cell in gameMatrix)
                    {
                        if (cell is UniqueCell)
                        {
                            ((UniqueCell)cell).Move(move);
                        }
                    }
                }
                UpdateGameMatrix();
                int startDrawPoint = matrixXSpacing;
                DrawMatrix(gameMatrix, startDrawPoint);
                Thread.Sleep(0);
            }
        }

        private void LiteOutput()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < spawnCellList.Count; i++)
            {
                spawnCellList[i].CellDraw();
            }
            Console.SetCursorPosition(0, 1);
            Console.WriteLine(spawnCellList.Count);
        }

        public void Load()
        {
            base.Load();
            ExtractCells();

            pictureMatrix = GeneratePictureMatrix(pictureMatrix);
            gameMatrix = GenerateGameMatrix(gameMatrix);

            int startDrawPoint = matrixXSpacing;
            DrawMatrix(gameMatrix, startDrawPoint);

            startDrawPoint = matrixXSpacing * 2 + matrixX;
            DrawMatrix(pictureMatrix, startDrawPoint);

            LiteOutput();

            PlayGame();

            Console.ReadKey();
        }

        public GGame() : base()
        {
            picture = new char[,]
            {
                { ' ','█','█',' ','█','█',' '},
                { '█','█','█','█','█','█','█'},
                { '█','█','█','█','█','█','█'},
                { ' ','█','█','█','█','█',' '},
                { ' ',' ','█','█','█',' ',' '},
                { ' ',' ',' ','█',' ',' ',' '},
            };

            borderCell = new CommonCell('X'); //█ problem
            emptinessCell = new CommonCell(' ');

            matrixX = 35;
            matrixY = 25;
            matrixXSpacing = (windowX - matrixX * 2) / 3;
        }
    }
}

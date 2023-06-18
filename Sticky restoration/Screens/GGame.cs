namespace Sticky_restoration
{
    public enum GameMode { Classic, Hollow, Colorful, Shard, Word }
    public class GGame : Screen
    {
        //--------------------------------------auto
        int pictureX;
        int pictureY;

        List<UniqueCell> uniqueCellArray = new List<UniqueCell>();

        ICell[,] pictureMatrix;
        ICell[,] gameMatrix;

        int matrixSpacing;

        //--------------------------------------constructor
        char[,] picture;

        CommonCell borderCell;
        CommonCell emptinessCell;
        // ??Cell saw;

        int matrixX;
        int matrixY;

        //Але в один масив вмонтовуємо пікчер, а другий пускаємо в гру.


        public void DrawMatrix(ICell[,] matrix, int startDrawPoint)
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

        public ICell[,] GenerateMatrix(ICell[,] matrix)
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
        public void ExtractCells()
        {
            pictureY = picture.GetLength(0);
            pictureX = picture.GetLength(1);
            char emptinessCellIdentifier = emptinessCell.Texture;
            char borderCellIdentifire = borderCell.Texture;

            for (int i = 0; i < pictureY; i++)
            {
                for (int j = 0; j < pictureX; j++)
                {
                    if (picture[i,j] != emptinessCellIdentifier && picture[i, j] != borderCellIdentifire)
                    {
                        uniqueCellArray.Add(new UniqueCell(texture: picture[i, j]));
                    }
                }
            }
            
        }

        public void LiteOutput()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < uniqueCellArray.Count; i++)
            {
                uniqueCellArray[i].CellDraw();
            }

            int startDrawPoint = matrixSpacing;
            DrawMatrix(gameMatrix, startDrawPoint);

            startDrawPoint = matrixSpacing*2 + matrixX;
            DrawMatrix(pictureMatrix, startDrawPoint);
        }

        public void Load()
        {
            base.Load();
            ExtractCells();

            pictureMatrix = GenerateMatrix(pictureMatrix);
            gameMatrix = GenerateMatrix(gameMatrix);

            LiteOutput();

            Console.ReadKey();
        }

        public GGame() : base()
        {
            picture = new char[,]
            {
                { ' ',' ','D',' ',' '},
                { ' ',' ','D',' ',' '},
                { ' ','D','D','D',' '},
                { ' ','D','D','D',' '},
                { ' ','R','R','R',' '},
                { ' ','E','E','E',' '},
                { ' ','D','D','D',' '},
                { 'D','D','D','D','D'},
            };

            borderCell = new CommonCell('O', ConsoleColor.Blue);
            emptinessCell = new CommonCell(' ', ConsoleColor.Blue);

            matrixX = 35;
            matrixY = 25;
            matrixSpacing = (windowX - matrixX * 2) / 3;
        }

        public GGame
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

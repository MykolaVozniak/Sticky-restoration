namespace Sticky_restoration
{
    public enum GameMode { Classic, Hollow, Colorful, Shard, Word }
    public class GGame : Screen
    {
        int pictureX;
        int pictureY;
        char[,] picture =
        {
            {' ',' ','D',' ',' '},
            {' ',' ','D',' ',' '},
            {' ','D','D','D',' '},
            {' ','D','D','D',' '},
            {' ','R','R','R',' '},
            {' ','E','E','E',' '},
            {' ','D','D','D',' '},
            {'D','D','D','D','D'},
        };
        char emptyCellIdentifier = ' ';
        char borderCellIdentifire = '0';

        List<UniqueCell> uniqueCellArray = new List<UniqueCell>();

        public void ExtractCells()
        {
            pictureY = picture.GetLength(0);
            pictureX = picture.GetLength(1);
            int k = 0;

            for (int i = 0; i < pictureY; i++)
            {
                for (int j = 0; j < pictureX; j++)
                {
                    if (picture[i,j] != emptyCellIdentifier && picture[i, j] != borderCellIdentifire)
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
        }

        public void Load()
        {
            base.Load();
            ExtractCells();
            LiteOutput();

            Console.ReadKey();
        }

        public GGame() : base()
        {

        }

    }
}

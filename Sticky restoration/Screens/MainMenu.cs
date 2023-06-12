namespace Sticky_restoration
{
    internal class MainMenu : Screen
    {
        public void Load()
        {
            base.Load();

            byte startY = 5;
            byte startX = 3;
            byte y = 25, x = 35;
            byte[,] PlanMatrix = new byte[y, x];
            Random random = new Random();
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    PlanMatrix[i, j] = Convert.ToByte(random.Next(0, 9));
                }
            }
            /*
            for (int i = 0; i < y; i++)
            {
                Console.SetCursorPosition(startX, i + startY);
                for (int j = 0; j < x; j++)
                {
                    Console.Write(PlanMatrix[i, j]);
                }
            }

            for (int i = 0; i < y; i++)
            {
                Console.SetCursorPosition(x + startX * 2, i + startY);
                for (int j = 0; j < x; j++)
                {
                    Console.Write(PlanMatrix[i, j]);
                }
            }*/

            Console.ReadKey();
        }

        public MainMenu()
        {
            screenName = "Main Menu";
            info = new string[] { "e999999999999999999999999999999999", "y", "233232332" };
        }
    }
}

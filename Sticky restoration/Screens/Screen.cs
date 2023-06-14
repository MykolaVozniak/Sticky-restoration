namespace Sticky_restoration
{
    public abstract class Screen
    {
        protected byte windowX;
        protected byte windowY;

        protected char frameTexture;
        private string gameName;
        protected string screenName;
        protected string[] screenText;

        private byte XCenter(string str)
        {
            byte center = (byte)((windowX - str.Length) / 2);
            return center;
        }
        private byte YCenter(string[] str)
        {
            byte center = (byte)((windowY - (str.Length * 2)) / 2);
            return center;
        }

        private void DrawFrame()
        {
            string frame = $"\n {new string(frameTexture, windowX - 2)} ";
            for (byte i = 0; i < windowY - 4; i++)
            {
                frame += $"\n {frameTexture}{new string(' ', windowX - 4)}{frameTexture} ";
            }
            frame += $"\n {new string(frameTexture, windowX - 2)}";

            Console.WriteLine(frame);
        }

        public void Load()
        {
            Console.Clear();
            Console.SetWindowSize(windowX, windowY);
            Console.SetCursorPosition(0, 0);

            DrawFrame();   

            Console.SetCursorPosition(XCenter(gameName)-1, 1);
            Console.WriteLine($" {gameName} ");

            Console.SetCursorPosition(XCenter(screenName), 3);
            Console.WriteLine($"{screenName}");

            byte j = 0;
            foreach (string i in screenText)
            {
                Console.SetCursorPosition(XCenter(i), YCenter(screenText) + j);
                Console.WriteLine($"{i}");
                j = (byte)(j + 2);
            }
        }

        public Screen()
        {
            windowX = Program.windowX;
            windowY = Program.windowY;

            frameTexture = '▓';
            gameName = "Sticky Restoration";
            screenName = "screenName";
            screenText = new string[] { "1", "2", "3" };
        }
    }
}

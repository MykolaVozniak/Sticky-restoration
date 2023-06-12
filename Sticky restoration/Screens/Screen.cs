using System.Xml.Linq;

namespace Sticky_restoration
{
    abstract class Screen
    {
        protected string gameName, screenName;
        protected string[] info;
        protected bool isCentered;

        protected byte windowX;
        protected byte windowY;

        public byte XCenter(string str)
        {
            byte center = (byte)((windowX - str.Length) / 2);
            return center;
        }
        public byte YCenter(string[] str)
        {
            byte center = (byte)((windowY - (str.Length*2)) / 2);
            return center;
        }

        public void Load()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            Console.SetWindowSize(windowX, windowY);
            Console.WriteLine($"\n{new string('-', windowX)}{new string('\n', windowY - 3)}{new string('-', windowX)}");

            Console.SetCursorPosition(XCenter(gameName), 1);
            Console.WriteLine($" {gameName} ");

            Console.SetCursorPosition(XCenter(screenName), 3);
            Console.WriteLine($"{screenName}");

            if (isCentered)
            {
                byte j = 0;
                foreach (string i in info)
                {
                    Console.SetCursorPosition(XCenter(i), YCenter(info) + j);
                    Console.WriteLine($"{i}");
                    j = (byte)(j + 2);
                }
            }
            else
            {
                Console.SetCursorPosition(0, YCenter(info));
                foreach (string i in info)
                {
                    Console.WriteLine($"{i}\n");
                }
            }
            
                
        }

        public Screen()
        {
            gameName = "Sticky Restoration";
            screenName = "screenName";

            windowX = Program.windowX;
            windowY = Program.windowY;

            info = new string[] { "1", "2", "3"};
            isCentered = true;
        }
    }
}

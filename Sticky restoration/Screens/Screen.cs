using System.Drawing;

namespace Sticky_restoration
{
    public abstract class Screen
    {
        //Window
        protected int windowX;
        protected int windowY;
        protected ConsoleColor windowColor;

        //Frame
        protected byte frameMargin;
        protected byte frameThickness;
        protected char frameTexture;
        protected ConsoleColor frameColor;

        //Sound
        protected bool isSoundOn;
        protected int soundFrequency;
        protected int soundDuration;

        //Text
        protected string programName;
        protected string screenName;
        protected string[] screenText;

        //Text Customization
        //colors and align, position

        private int XCenter(string str)
        {
            int center = (windowX - str.Length) / 2;
            return center;
        }
        private int YCenter(string[] str)
        {
            int center = (windowY - (str.Length * 2)) / 2;
            return center;
        }

        private void DrawFrame()
        {
            Console.ForegroundColor = frameColor;
            Console.BackgroundColor = windowColor;

            for (int i = 0; i < windowY; i++)
            {
                Console.WriteLine($"{new string(' ', windowX)}");
            }

            for (int i = frameMargin; i < windowY - frameMargin; i++)
            {
                Console.SetCursorPosition(frameMargin, i);
                Console.WriteLine($"{new string(frameTexture, windowX - frameMargin*2)}");
            }

            for (int i = (frameMargin + frameThickness); i < windowY - (frameMargin + frameThickness); i++)
            {
                Console.SetCursorPosition((frameMargin + frameThickness), i);
                Console.WriteLine($"{new string(' ', windowX - (frameMargin + frameThickness) * 2)}");
            }

            Console.SetCursorPosition(0, 0);
            Console.ResetColor();
        }

        private void DrawText()
        {
            Console.BackgroundColor = windowColor;
            Console.SetCursorPosition(XCenter(programName) - 1, 1);
            Console.WriteLine($" {programName} ");

            Console.SetCursorPosition(XCenter(screenName) - 1, 3);
            Console.WriteLine($" {screenName} ");

            byte j = 0;
            foreach (string i in screenText)
            {
                Console.SetCursorPosition(XCenter(i), YCenter(screenText) + j);
                Console.WriteLine($"{i}");
                j = (byte)(j + 2);
            }
        }

        public void Load()
        {
            if (isSoundOn)
            {
                Console.Beep(soundFrequency, soundDuration);
            }

            Console.ResetColor();
            Console.Clear();
            Console.SetWindowSize(windowX, windowY);
            Console.SetCursorPosition(0, 0);

            DrawFrame();
            DrawText();
        }

        public Screen()
        {
            //Window
            windowX = 79;
            windowY = 35;
            windowColor = ConsoleColor.Black;

            //Frame
            frameMargin = 1;
            frameThickness = 1;
            frameTexture = '▓'; //░▒▓█
            frameColor = ConsoleColor.White;

            //Sound
            isSoundOn = false;
            soundFrequency = 200;
            soundDuration = 130;

            //Text
            programName = "programName";
            screenName = "screenName";
            screenText = new string[] { "1 screenText", "2 screenText", "3 screenText" };
        }

        public Screen
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
        {
            //Window
            this.windowX = (windowX > Console.WindowWidth && windowX < Console.LargestWindowWidth) ? windowX : 79;
            this.windowY = (windowY > Console.WindowHeight && windowY < Console.LargestWindowHeight) ? windowY : 35;
            this.windowColor = windowColor;

            //Frame
            this.frameMargin = frameMargin;
            this.frameThickness = frameThickness;
            this.frameTexture = frameTexture;
            this.frameColor = frameColor;

            //Sound
            this.isSoundOn = isSoundOn;
            this.soundFrequency = (soundFrequency >= 37 && soundFrequency <= 32767) ? soundFrequency : 200; 
            this.soundDuration = (soundDuration >= 10 && soundDuration <= 5000) ?  soundDuration : 130;

            //Text
            this.programName = (programName == null || programName.Length >= windowX) ? "programName" : programName;
            this.screenName = (screenName == null || screenName.Length >= windowX) ? "screenName" : screenName;
            this.screenText = screenText ?? new string[] { "1 screenText", "2 screenText", "3 screenText" };

            for(int i = 0; i < screenText.Length; i++)
            {
                if (screenText[i] == null || screenText[i].Length >= windowX)
                {
                    screenText[i] = $"{i + 1} screenText";
                }
            }
        }
    }
}

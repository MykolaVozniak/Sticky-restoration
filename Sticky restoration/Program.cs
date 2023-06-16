using System.Drawing;

namespace Sticky_restoration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            //int windowY = 35, windowX = 79;
            //35x79 //55x133
            MainMenu mainMenu = new(
            windowX : 79,
            windowY: 35,
            windowColor: ConsoleColor.Green,

            frameMargin: 5,
            FrameThickness: 1,
            frameTexture: '▓', //░▒▓█
            frameColor: ConsoleColor.Black,

            isSoundOn: false,
            soundFrequency: 200,
            soundDuration: 130,

            programName: "programName",
            screenName: "screenName",
            screenText: new string[] { "1 screenText", "2 screenText", "3 screenText" }
            );
            while (true)
            {
                mainMenu.Load();
            }       
        }
    }
}
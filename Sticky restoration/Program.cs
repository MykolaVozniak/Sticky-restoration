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

            frameMargin: 1,
            FrameThickness: 1,
            frameTexture: '▓', //░▒▓█
            frameColor: ConsoleColor.Red,

            isSoundOn: false,
            soundFrequency: 200,
            soundDuration: 130,

            programName: "Sticky restoration",
            screenName: "Main Menu",
            screenText: new string[]
            {
                "Play Classic Mode \t[P]",
                "Play Hollow Mode \t[H]",
                "Play Colorful Mode \t[C]",
                "Play Shard Mode \t[S]",
                "Play Word Mode \t[W]",
                "Go to Manual \t[M]"
            }
            );
            while (true)
            {
                mainMenu.Load();
            }       
        }
    }
}
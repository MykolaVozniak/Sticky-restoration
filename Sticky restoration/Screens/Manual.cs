namespace Sticky_restoration
{
    public class Manual : Screen
    {
        public void Load()
        {
            base.Load();
            Console.ReadKey();
        }

        public Manual()
        {
            screenText = new string[]
            { 
                "1M", 
                "2M", 
                "3M", 
            };
        }
    }
}

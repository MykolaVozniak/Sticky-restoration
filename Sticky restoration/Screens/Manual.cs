namespace Sticky_restoration
{
    class Manual : Screen
    {
        public void Load()
        {
            base.Load();
            Console.ReadKey();
        }

        public Manual()
        {
            info = new string[]
            { 
                "1M", 
                "2M", 
                "3M", 
            };
        }
    }
}

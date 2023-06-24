namespace RPG {
    public class ExitGame {
        public ExitGame() {
            
        }

        public void Exit() {
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
namespace RPG;

public class WarningScreen
{
    public WarningScreen()
    {
        string warning = ("WARNING: THIS GAME MAY CONTAIN LOUD NOISES AND FLICKERING AND THE NEED OF A GREAT IMAGINATION...");
        string continueOn = ("Press any key to continue...");

        Console.WriteLine(warning);
        Console.WriteLine(continueOn);
        Console.ReadKey();
    }
}
namespace RPG;

public class CreditsScreen
{
    public void RunCredits()
    {
        string a = "CREDITS";
        string b = "Thank you so much for playing the DEMO of INSERT NAME HERE!";
        string c = "Programming: Niek Melet";
        string d = "Story: Bastiaan Melet";

        string finalMessage = "Press any key to continue";
        
        Console.Clear();
        
        Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
        Console.WriteLine(a);
        
        Console.SetCursorPosition((Console.WindowWidth - b.Length) / 2, Console.CursorTop);
        Console.WriteLine(b);
        
        Console.SetCursorPosition((Console.WindowWidth - c.Length) / 2, Console.CursorTop);
        Console.WriteLine(c);
        
        Console.SetCursorPosition((Console.WindowWidth - d.Length) / 2, Console.CursorTop);
        Console.WriteLine(d);
        
        Console.SetCursorPosition((Console.WindowWidth - finalMessage.Length) / 2, Console.CursorTop);
        Console.WriteLine(finalMessage);
        
        Console.ReadKey(true);
        TitleScreen _titleScreen = new TitleScreen();
        _titleScreen.RunTitleScreen();
    }
}
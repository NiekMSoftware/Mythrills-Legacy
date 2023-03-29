﻿namespace RPG;

public class OptionsScreen
{
    public void runOptions()
    {
        string optionText = "OPTIONS";
        
        Console.Clear();
        Console.SetCursorPosition((Console.WindowWidth - optionText.Length) / 2, Console.CursorTop);
        Console.WriteLine(optionText);
        Console.ReadKey(true);

        //Return to the title screen
        TitleScreen _titleScreen = new TitleScreen();
        _titleScreen.RunTitleScreen();
    }
}
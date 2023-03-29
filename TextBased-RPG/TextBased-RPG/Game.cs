using System;
using System.Collections.Generic;
using System.Text;

namespace RPG;

public class Game
{
    public void Start()
    {
       Console.Title = "PLACEHOLDER";
       //Run the warning
       Warning();
       
       //Run the title Screen
       RunTitleScreen_();
    }

    private void Warning()
    {
        WarningScreen _warning = new WarningScreen();
        _warning.Warning();
    }
    public void RunTitleScreen_()
    {
        TitleScreen _titleScreen = new TitleScreen();
        _titleScreen.RunTitleScreen();
    }

    //Shut down the program
    public void ExitGame()
    {
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey(true);
        Environment.Exit(0);
    }

    //Show off the settings the player can adjust
    private void DisplayOptionsInfo()
    {
        OptionsScreen _optionsScreen = new OptionsScreen();
        _optionsScreen.runOptions();
    }

    private void DisplayCredits()
    {
        CreditsScreen _creditsScreen = new CreditsScreen();
        _creditsScreen.RunCredits();
    }

    public void RunFirstOption()
    {
        RunGame _game = new RunGame();
        _game.StartGame();
    }
}
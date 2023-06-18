using System;
using System.Collections.Generic;
using System.Text;
using RPG.Room_Generation;

namespace RPG;

public class Game
{
    private WarningScreen _warning;
    private TitleScreen _titleScreen;
    public Player _player;
    public PlayerInit _playerInit;
    public MenuNavigation menuNavigation;
    public Room _room;
    private bool mainLoop = true;
    
    public Game()
    {
        this._player = new Player();
        this._room = new Room(this._player);
        this.Start();
        
        //Run the warning
        Warning();
    }
    
    public void Start()
    {
       //Run the title Screen
       RunTitleScreen();
       
       // Player init
       PlayerInit();
       
       //Let' s GO!
       RunGame();
    }

    private void Warning()
    {
        _warning = new WarningScreen();
    }
    public void RunTitleScreen()
    {
        _titleScreen = new TitleScreen();
    }

    public void PlayerInit()
    {
        _playerInit = new PlayerInit(_player);
    }

    public void RunGame()
    {
        while (mainLoop)
            // TODO: Fix room reference
            this._room.Run();
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
        PlayerInit _game = new PlayerInit(this._player);
        //_game.StartGame();
    }
}
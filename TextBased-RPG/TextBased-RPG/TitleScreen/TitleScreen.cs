﻿namespace RPG;

public class TitleScreen
{
    
    public string title = @"
(   (                         )    )  (   (         (      
)\ ))\ )   (       (       ( /( ( /(  )\ ))\ )      )\ )
(()/(()/(   )\      )\  (   )\()))\())(()/(()/(  (  (()/(
 /(_))(_)|(((_)(  (((_) )\ ((_)\((_)\  /(_))(_)) )\  /(_))
(_))(_))  )\ _ )\ )\___((_) _((_) ((_)(_))(_))_ ((_)(_))
| _ \ |   (_)_\(_|(/ __| __| || |/ _ \| |  |   \| __| _ \
|  _/ |__  / _ \  | (__| _|| __ | (_) | |__| |) | _||   / 
|_| |____|/_/ \_\  \___|___|_||_|\___/|____|___/|___|_|_\ 
Welcome to the game! Press any key...

";
        
        /*
        * Display title screen and its further navigational settings
        */
    public string[] options =
        {
            "Play", "Options", "Credits", "Exit"
        };
    // public TitleScreen()
    // {
    //     MenuNavigation menuNavigation = new MenuNavigation(title, options);
    //     int selectedIndex = menuNavigation.Run();
    //
    //     switch (selectedIndex)
    //     {
    //         case 0:
    //             RunGame _runGame = new RunGame();
    //             _runGame.StartGame();
    //             break;
    //         case 1:
    //             OptionsScreen _options = new OptionsScreen();
    //             _options.runOptions();
    //             break;
    //         case 2:
    //             CreditsScreen _credits = new CreditsScreen();
    //             _credits.RunCredits();
    //             break;
    //         case 3:
    //             Game quit = new Game();
    //             quit.ExitGame();
    //             break;
    //     }
    // }

    public string GetTitle()
    {
        return title;
    }
}
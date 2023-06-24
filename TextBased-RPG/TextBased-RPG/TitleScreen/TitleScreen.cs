namespace RPG;

public class TitleScreen {
    
    MenuNavigation menuNavigation;
    
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
    public TitleScreen() {
        int numStatus = 1;
        
        while (numStatus > 0) {
            numStatus = this.ShowTitle();
        }
    }

    public int ShowTitle() {
        this.menuNavigation = new MenuNavigation(title, options);
        int selectedIndex = menuNavigation.Run();
    
        switch (selectedIndex)
        {
            case 0:
                break;
            case 1:
                OptionsScreen _options = new OptionsScreen();
                _options.runOptions();
                break;
            case 2:
                CreditsScreen _credits = new CreditsScreen();
                _credits.RunCredits();
                break;
            case 3:
                ExitGame quit = new ExitGame();
                quit.Exit();
                break;
        }

        return selectedIndex;
    }

    public string GetTitle()
    {
        return title;
    }
}
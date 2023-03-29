namespace RPG;

public class MainMenu
{
    /*
     * Make a skeleton for the Menu
     */
    private int selectedIndex;

    private string[] options;
    private string prompt;
    
    public MainMenu(string _prompt, string[] _options)
    {
        prompt = _prompt;
        options = _options;
        selectedIndex = 0;
    }
    
    /*
     * Make a method responsible for rendering
     */
    private void DisplayOptions()
    {
        Console.WriteLine(prompt);
        for (int i = 0; i < options.Length; i++)
        {
            string currentOption = options[i];

            if (i == selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            Console.WriteLine($"<< {currentOption} >>");
        }

        Console.ResetColor();
    }

    /*
     * Make a public int method to let the outside call it out
     */
    public int Run()
    {
        ConsoleKey keyPressed;
        do
        {
            Console.Clear();
            DisplayOptions();
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;
            
            //Update selectedIndex based on arrow keys
            if (keyPressed == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                
                //Cycle it through back to the top when pressed down
                if (selectedIndex == -1)
                {
                    selectedIndex = options.Length - 1;
                }
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                
                //Cycle it back up to the bottom when pressed up
                if (selectedIndex == options.Length)
                {
                    selectedIndex = 0;
                }
            }
        } while (keyPressed != ConsoleKey.Enter);
        
        return selectedIndex;
    }
    
}
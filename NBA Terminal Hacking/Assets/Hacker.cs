using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    string[] RookiePasswords = { "kobe", "lebron", "steph", "mike", "kevin" };
    string[] AllStarPasswords = { "kyrie", "ben", "russell", "lonzo", "james" };
    string[] HallofFamePasswords = { "donovan", "carmelo", "ben", "paul", "chris" };

    //game state
    enum Screen { MainMenu, Password, Win };
    Screen CurrentScreen;
    string password;
    int level;
    int attempts;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu("Welcome NBA fan! Select your difficulty.");
    }

    void ShowMainMenu(string hello)
    {
        Terminal.ClearScreen();
        Terminal.WriteLine(hello);
        CurrentScreen = Screen.MainMenu;
        Terminal.WriteLine("Type in \"menu\" to go back anytime.");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for Rookie");
        Terminal.WriteLine("Press 2 for All-Star");
        Terminal.WriteLine("Press 3 for Hall of Fame");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        print(input);
        if (input == "menu")
        {
            ShowMainMenu("Select your difficulty.");
        }

        else if (CurrentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }

        else if (CurrentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            attempts = 0;
            DisplayWinScreen();
        }

        else
        {
            attempts++;
            AskforPassword();
            if (attempts >= 5)
            {
                Terminal.WriteLine("Too hard? Enter \"menu\" to go back.");
            }
        }
    }

    void DisplayWinScreen()
    {
        CurrentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine("Enter \"menu\" to play again.");
    }

    void ShowLevelReward()
    {
        if (level == 1)
        {
            Terminal.WriteLine("Great job rook. Keep practicing.");
            Terminal.WriteLine(@"
|__  o\
| W    \O
|       |\_
|      /-\
|    /     \
|
|
"
            );
        }
        else if (level == 2)
        {
            Terminal.WriteLine("Nice shot. You are a phenomenal player.");
            Terminal.WriteLine(@"
o- - -  \o          __|
   o/   /|          vv`\
  /|     |              |
   |    / \_            |
  / \   |               |
 /  |                   |
"
            );
        }
        else if (level == 3)
        {
            Terminal.WriteLine("Amazing job. You truly are the GOAT.");
            Terminal.WriteLine(@"
            ________
    o      |   __   |
      \_ O |  |__|  |
   ____/ \ |___WW___|
   __/   /     ||
               ||
_______________||________________
"
            );
        }
        else
        {
            Debug.LogError("Invalid level number");
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskforPassword();
        }

        else if ((input == "GOAT") || (input == "Greatest of All Time"))
        {
            Terminal.WriteLine("Whoa there. Let's not get ahead of ourselves rookie.");
        }

        else
        {
            Terminal.WriteLine("Please enter a valid input.");
        }
    }

    void AskforPassword()
    {
        CurrentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetPassword();
        Terminal.WriteLine("Please enter your password: " + password.Anagram());
    }

    void SetPassword()
    {
        if (level == 1)
        {
            password = RookiePasswords[Random.Range(0, RookiePasswords.Length)];
        }

        else if (level == 2)
        {
            password = AllStarPasswords[Random.Range(0, AllStarPasswords.Length)];
        }

        else if (level == 3)
        {
            password = HallofFamePasswords[Random.Range(0, HallofFamePasswords.Length)];
        }

        else
        {
            Debug.LogError("Invalid level number");
        }
    }
}

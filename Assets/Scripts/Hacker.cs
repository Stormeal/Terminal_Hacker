using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game State
    int level;
    string password;
    string hint;
    int guessCounter;
    System.Random rnd = new System.Random();

    enum Screen { Start, MainMenu, Password, Password2, Win };
    Screen currentScreen = Screen.MainMenu;
    const string menu = "You may write menu anytime";


    // Start is called before the first frame update
    void Start()
    {
        currentScreen = Screen.Start;
        Terminal.WriteLine("Welcome to your person WM2000 Terminal, write 'Menu' to access main menu");
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for local library - easy");
        Terminal.WriteLine("Press 2 for police station - medium");
        Terminal.WriteLine("Press 3 for NASA - hard");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:");
    }


    void OnUserInput(string input)
    {
        if (input.ToLower() == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "exit" || input == "close")
        {
            Terminal.WriteLine("If on the browser, close the tab");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input.ToLower());
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input.ToLower());
        }
        else if (currentScreen == Screen.Password2)
        {
            Console.WriteLine(input);
            CheckPassword(input.ToLower());
        }
    }

    private void RunMainMenu(string input)
    {
        if (currentScreen == Screen.MainMenu)
        {
            switch (input)
            {
                case "1":
                    level = 1;

                    Terminal.ClearScreen();
                    Terminal.WriteLine("Local library has been selected.");
                    StartGame();
                    break;
                case "2":
                    level = 2;

                    Terminal.ClearScreen();
                    Terminal.WriteLine("Police station has been selected.");
                    StartGame();
                    break;
                case "3":
                    level = 3;

                    Terminal.ClearScreen();
                    Terminal.WriteLine(@"
     _ __   __ _ ___  __ _ 
    | '_ \ / _` / __|/ _` |
    | | | | (_| \__ \ (_| |
    |_| |_|\__,_|___/\__,_|
                    ");
                    Terminal.WriteLine("NASA has been selected.");
                    StartGame();
                    break;
                case "007":
                    currentScreen = Screen.MainMenu;
                    level = 7;

                    Terminal.ClearScreen();
                    Terminal.WriteLine("Good day Mr. Bond.");
                    Terminal.WriteLine("Which assets do you need access to?");
                    Terminal.WriteLine("Press 1 for local library");
                    Terminal.WriteLine("Press 2 for police station");
                    Terminal.WriteLine("Enter your selection:");
                    StartGame();
                    break;
                default:
                    Terminal.WriteLine("Your selection could not be found");
                    break;
            }

        }
        else
        {
            Terminal.WriteLine("You have to select a screen before you can play.");
        }
    }

    private void StartGame()
    {
        SetPasswordScreen();
        Terminal.WriteLine("You have initialized level " + level);
        Terminal.WriteLine(menu);

        if (currentScreen == Screen.Password)
        {
            switch (level)
            {
                case 1:
                    Terminal.ClearScreen();
                    setPassword();

                    Terminal.WriteLine("Enter a password, hint: " + password.Anagram());
                    break;
                case 2:
                    Terminal.ClearScreen();
                    setPassword();

                    Terminal.WriteLine("Enter a password, hint: " + password.Anagram());
                    break;
                case 3:
                    setPassword();

                    Terminal.WriteLine("Enter a password, hint: " + password.Anagram());
                    break;
                default:
                    break;
            }

        }
        else if (currentScreen == Screen.Password2)
        {
            level = 33033;
            setPassword();
            Terminal.WriteLine("You are now inside their security");
            Terminal.WriteLine("Break next wall to gain access.");
            Thread.Sleep(1000);
            Terminal.WriteLine(@"
     _ __   __ _ ___  __ _ 
    | '_ \ / _` / __|/ _` |
    | | | | (_| \__ \ (_| |
    |_| |_|\__,_|___/\__,_|
            ");
            Terminal.WriteLine("Enter password, hint: " + password.Anagram());

        }
        else
        {
            Terminal.WriteLine("You must select an asset.");
        }
    }

    private void SetPasswordScreen()
    {
        if (level == 3303)
        {
            currentScreen = Screen.Password2;

        }
        else
        {
            currentScreen = Screen.Password;

        }
    }

    private void CheckPassword(string input)
    {
        switch (currentScreen)
        {
            case Screen.Start:
                break;
            case Screen.MainMenu:
                break;
            case Screen.Password:
                if (input == password)
                {
                    if (level == 3)
                    {
                        level = 3303;
                        StartGame();
                    }
                    else
                    {
                        WinScreen();
                    }
                }
                else
                {
                    guessCounter++;
                    Terminal.WriteLine("Incorrect answer, please try again");
                }
                break;
            case Screen.Password2:
                if (input == password)
                {
                    WinScreen();
                }
                else
                {
                    guessCounter++;
                    Terminal.WriteLine("Incorrect answer, please try again sucker");
                }
                break;
            case Screen.Win:
                break;
            default:
                break;
        }
    }



    public static int GetRandomNumber(System.Random rndObject)
    {
        int nr = rndObject.Next(1, 3);

        return nr;
    }

    private void setPassword()
    {
        switch (level)
        {
            case 1:
                switch (GetRandomNumber(rnd))
                {
                    case 1:
                        password = "book";
                        hint = "Pages might be included";
                        break;
                    case 2:
                        password = "borrow";
                        hint = "You get something teporarily";
                        break;
                    case 3:
                        password = "return";
                        hint = "When done reading.";
                        break;
                    default:
                        break;
                }
                break;
            case 2:
                switch (GetRandomNumber(rnd))
                {
                    case 1:
                        password = "warrant";
                        hint = "Before they can enter your home";
                        break;
                    case 2:
                        password = "culprit";
                        hint = "A person responsible for a crime";
                        break;
                    case 3:
                        password = "detective";
                        hint = "Officer responsible for solving a crime";
                        break;
                    default:
                        break;
                }
                break;
            case 3:
                switch (GetRandomNumber(rnd))
                {
                    case 1:
                        password = "spaceship";
                        hint = "Needs someone to pilot";
                        break;
                    case 2:
                        password = "astronaut";
                        hint = "Requires a long education";
                        break;
                    case 3:
                        password = "cosmonaut";
                        hint = "A lot of knowledge about space";
                        break;
                    default:
                        break;
                }
                break;
            case 33033:
                switch (GetRandomNumber(rnd))
                {
                    case 1:
                        password = "atmosphere";
                        hint = "";
                        break;
                    case 2:
                        password = "circuit";
                        hint = "";
                        break;
                    case 3:
                        password = "hydrosphere";
                        hint = "";
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (level == 1)
        {
            if (guessCounter >= 2)
            {
                Terminal.WriteLine(hint);
                guessCounter = 0;
            }

        }
        else
        {
            if (guessCounter >= 3)
            {
                Terminal.WriteLine(hint);
                guessCounter = 0;
            }
        }
    }

    private void WinScreen()
    {
        Terminal.ClearScreen();
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Well done.");
                Terminal.WriteLine("Here, have a book");
                Terminal.WriteLine(@"
                    _______
                   /      /,
                  /      //
                 /______//
                (______(/
                ");
                break;
            case 2:
                Terminal.WriteLine("Well done. ");
                Terminal.WriteLine("You gotten yourself a teddy bear!");
                Terminal.WriteLine(@"
                  ___
                {~._.~}
                 ( Y )
                ()~*~()
                (_)-(_)
                ");
                break;
            case 3:
                Terminal.WriteLine("Hang on, you're almost there");
                level = 3303;
                currentScreen = Screen.Password2;

                StartGame();

                break;
            case 33033:
                Terminal.WriteLine(@"
     _ __   __ _ ___  __ _ 
    | '_ \ / _` / __|/ _` |
    | | | | (_| \__ \ (_| |
    |_| |_|\__,_|___/\__,_|
                ");
                Terminal.WriteLine("Congratulations");
                Terminal.WriteLine("You are now inside NASA systems.");

                break;

            default:
                break;
        }
    }
}

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
    enum Screen { Start, MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;


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
        Terminal.WriteLine("Press 1 for local library");
        Terminal.WriteLine("Press 2 for police station");
        Terminal.WriteLine("Enter your selection:");
    }


    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
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
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("You have initialized level " + level);
        Terminal.WriteLine("Please stand by while your level is loading..");
        Thread.Sleep(3500);

        if (currentScreen == Screen.Password)
        {
            switch (level)
            {
                case 1:
                    Terminal.ClearScreen();
                    setPassword();

                    Terminal.WriteLine("Dungeons & Dragon question..");
                    Terminal.WriteLine("Please enter city name..");

                    break;
                case 2:
                    Terminal.ClearScreen();
                    setPassword();

                    Terminal.WriteLine("Dungeon & Dragon question");
                    Terminal.WriteLine("Please enter a city name");
                    break;
                default:
                    break;
            }

        }
        else
        {
            Terminal.WriteLine("You must select an asset.");
        }
    }

    private void CheckPassword(string input)
    {
        if (currentScreen == Screen.Password)
        {
            if (input == password)
            {
                WinScreen();
            }
            else
            {
                guessCounter++;
                Terminal.WriteLine("Incorrect answer, please try again");
            }
        }
    }

    private void WinScreen()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Congratulations");
        Terminal.WriteLine("You have completed level " + level);
        Terminal.WriteLine("Write menu to get back.");
    }

    private void setPassword()
    {
        switch (level)
        {
            case 1:
                password = "Waterdeep";
                hint = "The largest city on the Sword Coast";
                break;
            case 2:
                password = "Icewind Dale";
                hint = "The coldest city on the Sword Coast";
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
            if (guessCounter >= 3)
            {
                Terminal.WriteLine(hint);
                guessCounter = 0;
            }

        } else
        {
            if (guessCounter >= 5)
            {
                Terminal.WriteLine(hint);
                guessCounter = 0;
            }
        }
    }
}

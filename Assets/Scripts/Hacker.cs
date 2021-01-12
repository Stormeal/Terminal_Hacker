using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game State
    int level;
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

        Terminal.WriteLine("You have initialized level " + level);
    }

    // Update is called once per frame
    void Update()
    {
    }
}

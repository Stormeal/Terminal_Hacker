using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game State
    int level;


    // Start is called before the first frame update
    void Start()
    {
        Terminal.WriteLine("Welcome to your person WM2000 Terminal, write 'Menu' to access main menu");
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for local library");
        Terminal.WriteLine("Press 2 for police station");
        Terminal.WriteLine("Enter your selection:");
    }


    void OnUserInput(string input)
    {
        switch (input.ToLower())
        {
            case "menu":
                Terminal.ClearScreen();
                ShowMainMenu();
                break;
            case "1":
                level = 1;

                Terminal.ClearScreen();
                Terminal.WriteLine("Local library has been selected, stand by");
                StartGame();
                break;
            case "2":
                level = 2;

                Terminal.ClearScreen();
                Terminal.WriteLine("Police station has been selected, stand by");
                StartGame();
                break;
            case "007":
                level = 7;

                Terminal.ClearScreen();
                Terminal.WriteLine("Good day Mr. Bond, which assets do you need access to?");
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

    private void StartGame()
    {
        Terminal.WriteLine("You have initialized level " + level);
    }

    // Update is called once per frame
    void Update()
    {
    }
}

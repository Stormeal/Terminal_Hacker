using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
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
        switch (input)
        {
            case "Menu":
                Terminal.ClearScreen();
                ShowMainMenu();
                break;
            case "1":
                Terminal.ClearScreen();
                Terminal.WriteLine("Local library has been selected, stand by");
                break;
            case "2":
                Terminal.ClearScreen();
                Terminal.WriteLine("Police station has been selected, stand by");
                break;
            case "007":
                Terminal.ClearScreen();
                Terminal.WriteLine("Good day Mr. Bond, which assets do you need access to?");
                Terminal.WriteLine("Press 1 for local library");
                Terminal.WriteLine("Press 2 for police station");
                Terminal.WriteLine("Enter your selection:");
                break;

            default:
                Terminal.WriteLine("Your selection could not be found");
                break;
        }
    }

    // Update is called once per frame
    void Update()
{
}
}

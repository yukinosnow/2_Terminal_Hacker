using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    //Gmae State
    int level;
    enum Screen { MainMenu, Password, Win};
    Screen CurrentScreen=Screen.MainMenu;
    string password;

	// Use this for initialization
	void Start () {
        ShowMainMenu();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void ShowMainMenu()
    {
        CurrentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Waht would you like to hack into?");
        Terminal.WriteLine("Press 1 for the Level 1");
        Terminal.WriteLine("Press 2 for the Level 2");
        Terminal.WriteLine("Enter your selection:");
    }
    void OnUserInput(string input)
    {
        if(input=="menu")
        {
            ShowMainMenu();
        }
        if(CurrentScreen==Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(CurrentScreen==Screen.Password)
        {
            CheckPassword(input);
        }

    }

    private void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            password = "donkey";
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = "combobulate";
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please enter a vaild input");
        }
    }

    void StartGame()
    {
        CurrentScreen = Screen.Password;
        Terminal.WriteLine("You have choosen level "+level);
        Terminal.WriteLine("Please enter you password:");
    }
    void CheckPassword(string input)
    {
        if(input==password)
        {
            Terminal.WriteLine("WELL DONE!");
            ShowMainMenu();
        }
        else
        {
            Terminal.WriteLine("Sorry, wrong password!");
            Terminal.WriteLine("Please enter you password:");
        }
    }
}

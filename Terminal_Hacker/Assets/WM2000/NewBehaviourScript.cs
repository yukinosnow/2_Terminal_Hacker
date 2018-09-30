using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewBehaviourScript : MonoBehaviour {

    //Game configuration data
    string[] level1Passwords = {"books","aisle","self","password","font","borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest", "borrow" };
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
        bool isValidLevelNumber = ( input == "1" || input == "2" );
        if(isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        /*if (input == "1")
        {
            System.Random rnd = new System.Random();
            int number = rnd.Next(6);
            password = level1Passwords[number];
            StartGame();
        }
        else if (input == "2")
        {
            System.Random rnd = new System.Random();
            int number = rnd.Next(6);
            password = level2Passwords[number];
            StartGame();
        }*/
        else
        {
            Terminal.WriteLine("Please enter a vaild input");
        }
    }

    void StartGame()
    {
        CurrentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch(level)
        {
            case 1:
                {
                    System.Random rnd = new System.Random();
                    int number = rnd.Next(level1Passwords.Length);
                    password = level1Passwords[number];
                    break;
                }
            case 2:
                {
                    System.Random rnd = new System.Random();
                    int number = rnd.Next(level2Passwords.Length);
                    password = level2Passwords[number];
                    break;
                }
            default:
                {
                    Debug.LogError("Invalid level number");
                    break;
                }
                
                
        }
        Terminal.WriteLine("Enter you password, hint:" + password.Anagram());
    }
    void CheckPassword(string input)
    {
        if(input==password)
        {
            DisplayWinScreen();

        }
        else
        {
            Terminal.WriteLine("Sorry, wrong password!");
            Terminal.WriteLine("Enter you password, hint:"+password.Anagram());
        }
    }

    void DisplayWinScreen()
    {
        CurrentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                {
                    Terminal.WriteLine("WELL DONE on level1!");
                    break;
                }
            case 2:
                {
                    Terminal.WriteLine("WELL DONE on level2!");
                    break;
                }
            default:
                {
                    Debug.LogError("Invalid level number");
                    break;
                }
        }
    }
}

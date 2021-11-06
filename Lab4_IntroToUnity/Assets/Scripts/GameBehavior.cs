using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public string labelText = "Collect all 3 goals and pass!";
    public int maxGoals = 3;

    public bool showWinScreen = false;
    public bool showLoseScreen = false;

    private int _goalsCollected = 0;

    public int Goals
    {
        get { return _goalsCollected; }
        set {
            _goalsCollected = value;
            Debug.LogFormat("Goals: {0}", _goalsCollected);

            if (_goalsCollected >= maxGoals)
            {
                labelText = "You've found all the goals!";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Goal found, only " + (maxGoals - _goalsCollected)
                + " more to go!";
            }
        }
    }

    private int _playerHP = 10;

    public int HP 
    {
        get { return _playerHP; }
        set {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);

            if (_playerHP <= 0)
            {
                labelText = "You've died :(";
                showLoseScreen = true;
                Time.timeScale = 0f;
            }
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + _goalsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50),
            labelText);
        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width/2 - 100,
            Screen.height/2 - 50, 200, 100), "YOU WON!" ))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;
            }
        }
        if (showLoseScreen)
        {
            if (GUI.Button(new Rect(Screen.width/2 - 100,
            Screen.height/2 - 50, 200, 100), "You LOST!"))
            {
                SceneManager.LoadScene(0);
                Time.timeScale =1.0f;
            }
        }
    }
}
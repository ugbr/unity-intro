using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public string labelText = "Collect all 3 goals and pass!";
    public int maxGoals = 3;

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
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + _goalsCollected);
        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50),
            labelText);
    }
}

    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

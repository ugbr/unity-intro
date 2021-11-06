using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    private int _playerHP = 100;
    private int _goalsCollected = 0;

    public int Goals
    {
      get { return _goalsCollected; }
      set {
        _goalsCollected = value;
        Debug.LogFormat("Goals: {0}", _goalsCollected);
      }
    }

    public int HP
    {
      get { return _playerHP; }
      set {
        _playerHP = value;
        Debug.LogFormat("Lives: {0}", _playerHP);
      }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

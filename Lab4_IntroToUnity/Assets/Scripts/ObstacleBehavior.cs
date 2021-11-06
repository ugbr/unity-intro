using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public GameBehavior gameManager;

    private int _obstacleHP = 10;

    public int HP
    {
      get { return _obstacleHP; }
      set {
        _obstacleHP = value;
        Debug.LogFormat("Obstacle HP: {0}", _obstacleHP);
      }
    }

    void Start()
    {
      // 2
      gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
      //Put collision code here
      if (collision.gameObject.tag == "Player")
      {
        Debug.Log("Hit a Player!");
        // 3
        _obstacleHP -= 10;

        if (_obstacleHP <= 0)
        {
          StartCoroutine (destroyObstacle ());
        }
        
      }
    }

    IEnumerator destroyObstacle()
    {
      yield return new WaitForSeconds (0.5f);
      Destroy(this.transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

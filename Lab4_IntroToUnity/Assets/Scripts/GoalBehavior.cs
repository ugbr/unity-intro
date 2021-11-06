using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    public GameBehavior gameManager;

    void Start()
    {
      gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.tag == "Player")
      {
        Debug.Log("Goal collected!");
        // 3
        gameManager.Goals += 1;
        StartCoroutine (destroyGoal ());
      }
    }

    IEnumerator destroyGoal()
    {
      yield return new WaitForSeconds (0.5f);
      Destroy(this.transform.gameObject);
    }
}

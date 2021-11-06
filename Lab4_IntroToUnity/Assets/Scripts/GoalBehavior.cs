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
      //Put collision code here
      StartCoroutine (destroyGoal ());
    }

    IEnumerator destroyGoal()
    {
      yield return new WaitForSeconds (0.5f);
      Destroy(this.transform.gameObject);
      Debug.Log("Goal collected!");

      gameManager.Goals += 1;
    }
}

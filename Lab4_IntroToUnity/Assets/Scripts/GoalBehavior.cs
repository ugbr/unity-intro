using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
      //Put collision code here
      StartCoroutine (destroyGoal ());
    }

    IEnumerator destroyGoal()
    {
      yield return new WaitForSeconds (0.5f);
      Destroy(this.transform.gameObject);
    }
}

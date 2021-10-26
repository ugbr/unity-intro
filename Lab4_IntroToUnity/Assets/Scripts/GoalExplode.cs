using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalExplode : MonoBehaviour
{
    public Transform shrapnel;
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem ps = shrapnel.GetComponent<ParticleSystem> ();
        var em = ps.emission;
        em.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
      ParticleSystem ps = shrapnel.GetComponent<ParticleSystem> ();
        var em = ps.emission;
        em.enabled = true;
        StartCoroutine (stopShrapnel ());
    }

    IEnumerator stopShrapnel()
    {
      yield return new WaitForSeconds (0.5f);
      ParticleSystem ps = shrapnel.GetComponent<ParticleSystem> ();
        var em = ps.emission;
        em.enabled = false;
    }
}

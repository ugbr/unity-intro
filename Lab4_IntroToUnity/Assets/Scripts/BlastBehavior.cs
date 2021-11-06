using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastBehavior : MonoBehaviour
{
    private Rigidbody _rb;
    private CapsuleCollider _col;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.MovePosition(this.transform.position +
        this.transform.forward * 2 * Time.fixedDeltaTime);

        StartCoroutine(passiveMe(3));
 
        IEnumerator passiveMe(int secs)
        {
            yield return new WaitForSeconds(secs);
            Destroy(gameObject);
        }
    }


}

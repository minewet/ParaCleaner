using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    public int force = 200;
    private int phase = 0;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("TrashLifeCycle", 4);
    }

    IEnumerator TrashLifeCycle(float delayTime)
    {
        rb.AddForce(Random.onUnitSphere* force, ForceMode.Force);
        phase++;
        if (phase == 5)
        {
            yield return null;
            Destroy(gameObject);
        }
        else
        {
            yield return new WaitForSeconds(delayTime);
            StartCoroutine("TrashLifeCycle", 4);
        }
    }
}

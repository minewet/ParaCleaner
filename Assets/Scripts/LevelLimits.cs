using UnityEngine;
using System.Collections;

public class LevelLimits : MonoBehaviour
{
    //Use for checking if player out of map. 
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.SetColor("_TintColor", new Color(1, 1, 1, 0.8f));
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.collider.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.SetColor("_TintColor", new Color(1, 1, 1, 0));
        }
    }
}

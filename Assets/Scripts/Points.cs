using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Points : MonoBehaviour {

    public AudioClip getpoint;
    public AudioClip busruk;

    public Text Point;
    public Animator animator;   
    public GameObject MainCamera;

    public int score_1;
    public int score_2;
    public int score_3;

    private int pt = 0;


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Trash_1"))
        {
            animator.SetTrigger("Idle");
            animator.SetTrigger("Take");

            MainCamera.GetComponent<AudioSource>().PlayOneShot(getpoint, 1f);
            MainCamera.GetComponent<AudioSource>().PlayOneShot(busruk, 1f);
            Destroy(other.gameObject);

            pt += score_1;
            Point.text = "Total |    " + pt + " oz";
        }

        else if (other.CompareTag("Trash_2"))
        {
            animator.SetTrigger("Idle");
            animator.SetTrigger("Take");

            MainCamera.GetComponent<AudioSource>().PlayOneShot(getpoint, 1f);
            MainCamera.GetComponent<AudioSource>().PlayOneShot(busruk, 1f);
            Destroy(other.gameObject);

            pt += score_2;
            Point.text = "Total |    "+ pt + " oz";
        }

        else if (other.CompareTag("Trash_3"))
        {
            animator.SetTrigger("Idle");
            animator.SetTrigger("Take");

            MainCamera.GetComponent<AudioSource>().PlayOneShot(getpoint, 1f);
            MainCamera.GetComponent<AudioSource>().PlayOneShot(busruk, 1f);
            Destroy(other.gameObject);

            pt += score_3;
            Point.text = "Total |    " + pt + " oz";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashGenerator : MonoBehaviour
{
    public int level;
    public Transform player;
    public int radius = 100;
    GameObject trash_1;
    GameObject trash_2;
    GameObject trash_3;

    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        trash_1 = Resources.Load("Trashes/" + level + "/Trash_1") as GameObject;
        trash_2 = Resources.Load("Trashes/" + level + "/Trash_2") as GameObject;
        trash_3 = Resources.Load("Trashes/" + level + "/Trash_3") as GameObject;
        StartCoroutine("Trash", .5);
    }

    // Update is called once per frame
    IEnumerator Trash(float delayTime) 
    {
        int num = Random.Range(1, 4);
        switch (num)
		{
            case 1:
                obj = MonoBehaviour.Instantiate(trash_1) as GameObject;
                break;
            case 2:
                obj = MonoBehaviour.Instantiate(trash_2) as GameObject;
                break;
            case 3:
                obj = MonoBehaviour.Instantiate(trash_3) as GameObject;
                break;
        }
        Vector3 pos = Random.insideUnitSphere * radius;
        if (pos.y>0) pos.y = -pos.y;
        pos += player.position;
        obj.transform.position = pos;


        yield return new WaitForSeconds(delayTime); 
        StartCoroutine("Trash", .5); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPage : MonoBehaviour
{
    public int trash;
    public int second;
    public int total;

    public Text trashT;
    public Text secT;
    public Text pay;

    public GameObject gold;
    public GameObject silver;
    public GameObject bronze;

    public int goldlimit;
    public int silverlimit;
    public int bronzelimit;


    void Start()
    {
        trashT.text = trash +" oz";
        secT.text = second +" s";

        total = trash * 50 + second * 10;
        pay.text = total + " °ñµå";

        if (total >= goldlimit) gold.SetActive(true);
        else if (total >= silverlimit) silver.SetActive(true);
        else if (total >= bronzelimit) bronze.SetActive(true);
    }
}

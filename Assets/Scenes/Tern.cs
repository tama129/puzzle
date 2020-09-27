using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tern : MonoBehaviour
{
    public float countup = 0.0f;
    public float timeLimit = 3.0f;
    private GameObject damageText;
    private GameObject damegeText2;
    public bool turn = true;
    // Start is called before the first frame update
    ballScript Mikatatern;
    Enemy Tekiturn;
    void Start()
    {
        this.damageText = GameObject.Find("damageText");
        this.damegeText2 = GameObject.Find("damegeText2");
        Mikatatern = GameObject.Find("controller").GetComponent<ballScript>();
        Tekiturn = GameObject.Find("enemy").GetComponent<Enemy>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (turn == true)
        {
            Mikatatern.kaihukuText.GetComponent<Text>().text = "";
            damageText.GetComponent<Text>().text = "";
            damageText.GetComponent<Text>().text = "";
            Mikatatern.Mikata();
        }
            if (turn == false && countup >= timeLimit)
        {
            Mikatatern.kaihukuText.GetComponent<Text>().text = "";
            countup = 0.0f;
            damageText.GetComponent<Text>().text = "";
            damageText.GetComponent<Text>().text = "";
            Tekiturn.teki();

        }
    }
}

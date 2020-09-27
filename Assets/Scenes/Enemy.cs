using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private GameObject damageText;
    private GameObject damegeText2;
    Tern Tern;
    // Start is called before the first frame update
    void Start()
    {
        this.damageText = GameObject.Find("damageText");
        this.damegeText2 = GameObject.Find("damegeText2");
        Tern = GameObject.Find("controller").GetComponent<Tern>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void teki()
    { 
            Tern.turn = true;
        
    }

}

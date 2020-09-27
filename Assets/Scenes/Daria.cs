using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daria : MonoBehaviour
{
    public int HP = 9009;
    public int power = 604;
    public int kaihuku = 50;
    ballScript damege;
    // Start is called before the first frame update
    void Start()
    {
        damege = GameObject.Find("controller").GetComponent<ballScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Dariaturn()
    {
    }
}

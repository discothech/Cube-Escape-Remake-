using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowButton : MonoBehaviour
{

    public GameObject[] firstGroup;
    public GameObject[] secondGroup;
    public YellowButton button;

    public Material normal;
    public Material transpert;
    public bool canPush;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        //if (canPush)
        //{

        if(other.CompareTag("Cube") || other.CompareTag("Player"))
        
        {
            foreach(GameObject first in firstGroup)
            {
                first.GetComponent<Renderer>().material = normal;
                first.GetComponent<Collider>().isTrigger = false;
            }

             foreach(GameObject second in secondGroup)
            {
                second.GetComponent<Renderer>().material = transpert;
                second.GetComponent<Collider>().isTrigger = true;
            }

            GetComponent<Renderer>().material = transpert;
            button.GetComponent<Renderer>().material = normal;
            button.canPush = true;       
         }

        //}
    }
}

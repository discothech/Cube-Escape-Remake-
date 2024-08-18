using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public KeyCode KeyOne;
    public KeyCode KeyOne1;
    public KeyCode KeyTwo;
    public KeyCode KeyTwo1;
    public Vector3 moveDirection;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyOne) || Input.GetKey(KeyOne1))
        {
            GetComponent<Rigidbody>().velocity -= moveDirection;
        }

        if(Input.GetKey(KeyTwo) || Input.GetKey(KeyTwo1))
        {
            GetComponent<Rigidbody>().velocity += moveDirection;
        }
    }


    /*private void OnTriggerEnter(Collider other)    
    {        
        
        if(this.CompareTag("Cube") && other.CompareTag("Cube"))
        {
            foreach(YellowButton button in FindObjectsOfType<YellowButton>())
            {
                button.canPush = false;
            }
        }     
    
    }

    private void OnTriggerExit(Collider other)
    {  

          if(this.CompareTag("Cube") && other.CompareTag("Cube"))
            {
            foreach (YellowButton button in FindObjectsOfType<YellowButton>())
            {
                button.canPush = true;
            }

            }
    }

    */
}

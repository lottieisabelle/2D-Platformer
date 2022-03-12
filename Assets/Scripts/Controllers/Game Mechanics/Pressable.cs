using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Pressable : MonoBehaviour
{    
    public bool blockPressed;

    public List<int> itemsOnbutton = new List<int>();

    public int pressedCount;

    // Start is called before the first frame update
    void Start()
    {
        pressedCount = 0;

        blockPressed = this.transform.parent.GetComponent<ButtonController>().blockPressed;

        if(blockPressed)
        {
            // deactivate boxcollider
            this.GetComponent<BoxCollider2D>().enabled = false;
            pressedCount = this.transform.parent.GetComponent<ButtonController>().lights;
        } else {
            this.GetComponent<BoxCollider2D>().enabled = true;
            this.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    private void Reset()
    {
        this.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // identify box, not box trigger, or box when held
        if(collision.CompareTag("Box") && collision.gameObject.layer == 9){
            // if box id not in list then 
            if(!itemsOnbutton.Contains(collision.gameObject.GetComponent<BoxController>().boxID)){
                // add to list
                itemsOnbutton.Add(collision.gameObject.GetComponent<BoxController>().boxID);
            }
        }
        
        /*
        // need to keep track of what boxes are new, add to list of boxes on button - using boxids
        if(collision.CompareTag("Box") && !collision.gameObject.GetComponent<BoxController>().isHeld && collision.gameObject.layer == 9){
            // if box id not in list then 
            if(!itemsOnbutton.Contains(collision.gameObject.GetComponent<BoxController>().boxID)){
                // add to list
                itemsOnbutton.Add(collision.gameObject.GetComponent<BoxController>().boxID);
            }
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.CompareTag("Player")){
            itemsOnbutton.Add(0);
        }

        // identify box, not box trigger, or box when held
        if(collision.CompareTag("Box") && collision.gameObject.layer == 9){
            // if box id not in list then 
            if(!itemsOnbutton.Contains(collision.gameObject.GetComponent<BoxController>().boxID)){
                // add to list
                itemsOnbutton.Add(collision.gameObject.GetComponent<BoxController>().boxID);
            }
        }

        /*
        // TODO : detecting both child and parent box objects as tagged - need to differentiate between the two / only detect one of them
        if(collision.CompareTag("Box") && !collision.gameObject.GetComponent<BoxController>().isHeld && collision.gameObject.layer == 9){
            // if box id not in list then 
            if(!itemsOnbutton.Contains(collision.gameObject.GetComponent<BoxController>().boxID)){
                // add to list
                itemsOnbutton.Add(collision.gameObject.GetComponent<BoxController>().boxID);
            }
        }
        */
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            itemsOnbutton.Remove(0);
        }

        if(collision.CompareTag("Box") && collision.gameObject.layer == 9){
            itemsOnbutton.Remove(collision.gameObject.GetComponent<BoxController>().boxID);
        }

    }

}


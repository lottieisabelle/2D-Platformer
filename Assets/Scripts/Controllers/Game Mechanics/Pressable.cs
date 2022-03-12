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

    void Update()
    {
        // using list of items on button, count stacked items
        // search objects for boxes and match box ids

    }

    private void Reset()
    {
        this.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // identify box, not box trigger, and not box when held
        if(collision.CompareTag("Box") && collision.gameObject.layer == 9){

            Debug.Log("button trigger stay");
            // set isonbutton to true
            collision.gameObject.GetComponent<BoxController>().isOnButton = true;

            // if box id not in list then 
            if(!itemsOnbutton.Contains(collision.gameObject.GetComponent<BoxController>().boxID)){
                // add to list
                itemsOnbutton.Add(collision.gameObject.GetComponent<BoxController>().boxID);
            }
        }

        // if detecting box trigger, and box is not held, check if in list
        if(collision.CompareTag("BoxTrigger") && !collision.gameObject.transform.parent.GetComponent<BoxController>().isHeld){

            collision.gameObject.transform.parent.GetComponent<BoxController>().isOnButton = true;

            // if box id not in list then 
            if(!itemsOnbutton.Contains(collision.gameObject.transform.parent.GetComponent<BoxController>().boxID)){
                // add to list
                itemsOnbutton.Add(collision.gameObject.transform.parent.GetComponent<BoxController>().boxID);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.CompareTag("Player")){
            itemsOnbutton.Add(0);
        }

        // identify box, not box trigger, or box when held
        if(collision.CompareTag("Box") && collision.gameObject.layer == 9){
            // set isonbutton to true
            collision.gameObject.GetComponent<BoxController>().isOnButton = true;

            // if box id not in list then 
            if(!itemsOnbutton.Contains(collision.gameObject.GetComponent<BoxController>().boxID)){
                // add to list
                itemsOnbutton.Add(collision.gameObject.GetComponent<BoxController>().boxID);
            }
        }

        // if detecting box trigger, do the same
        if(collision.CompareTag("BoxTrigger") && !collision.gameObject.transform.parent.GetComponent<BoxController>().isHeld){

            collision.gameObject.transform.parent.GetComponent<BoxController>().isOnButton = true;

            // if box id not in list then 
            if(!itemsOnbutton.Contains(collision.gameObject.transform.parent.GetComponent<BoxController>().boxID)){
                // add to list
                itemsOnbutton.Add(collision.gameObject.transform.parent.GetComponent<BoxController>().boxID);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            itemsOnbutton.Remove(0);
        }

        if(collision.CompareTag("Box") && collision.gameObject.layer == 9){
            collision.gameObject.GetComponent<BoxController>().isOnButton = false;

            itemsOnbutton.Remove(collision.gameObject.GetComponent<BoxController>().boxID);
        }

        if(collision.CompareTag("BoxTrigger") && !collision.gameObject.transform.parent.GetComponent<BoxController>().isHeld){
            collision.gameObject.transform.parent.GetComponent<BoxController>().isOnButton = false;

            itemsOnbutton.Remove(collision.gameObject.transform.parent.GetComponent<BoxController>().boxID);

        }

    }

}


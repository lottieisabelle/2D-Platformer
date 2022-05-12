using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Pressable : MonoBehaviour
{    
    public bool blockPressed;

    public List<int> itemsOnbutton = new List<int>();
    private List<int> boxChain = new List<int>();

    public int pressedCount;
    private int playerOnButton;

    void Start()
    {
        playerOnButton = 0;
        pressedCount = 0;

        blockPressed = this.transform.parent.GetComponent<ButtonController>().blockPressed;

        if(blockPressed)
        {
            // deactivate boxcollider - as button is not pressable
            this.GetComponent<BoxCollider2D>().enabled = false;
            pressedCount = this.transform.parent.GetComponent<ButtonController>().lights;
        } else {
            this.GetComponent<BoxCollider2D>().enabled = true;
            this.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    void Update()
    {
        blockPressed = this.transform.parent.GetComponent<ButtonController>().blockPressed;

        if(blockPressed)
        {
            // deactivate boxcollider - as button is not pressable
            this.GetComponent<BoxCollider2D>().enabled = false;
            pressedCount = this.transform.parent.GetComponent<ButtonController>().lights;
        } else {
            this.GetComponent<BoxCollider2D>().enabled = true;
            this.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    // calculate the number of objects on the button
    public void getPressedCount()
    {
        // gets the box IDs in order of which they are stored in hierarchy - as it changes when boxes are picked up and moved
        List<int> boxOrder = new List<int>();
        this.transform.parent.parent.parent.GetComponent<LevelController>().getBoxIDs();
        boxOrder = this.transform.parent.parent.parent.GetComponent<LevelController>().boxOrder;

        boxChain.Clear();

        // check if player is on top of any boxes directly on the button
        int boxPlayerOn = this.transform.parent.parent.parent.GetChild(5).GetComponent<PlayerController>().onBoxID;
        if(boxPlayerOn != 0 && itemsOnbutton.Contains(boxPlayerOn)){
            playerOnButton = 1;
        } else {
            playerOnButton = 0;
        }

        // for each box directly on the button
        for(int x = 0; x < itemsOnbutton.Count; x++){

            if(itemsOnbutton[x] != 0){ // 0 is the player - don't need to look for boxes above 

                int boxAbove = 0;
                // gets child index of box
                int index = boxOrder.IndexOf(itemsOnbutton[x]);
                
                while(boxAbove != -1){ 
                    
                    // gets ID of box above
                    boxAbove = this.transform.parent.parent.parent.GetChild(4).GetChild(index).GetComponent<BoxController>().getAbove();

                    // -1 means no boxes were detected above
                    if(boxAbove != -1){
                        // if box not already accounted for, add to list
                        if(!boxChain.Contains(boxAbove)){
                            boxChain.Add(boxAbove);
                        }

                        // check if player is on box above
                        if(boxAbove == boxPlayerOn){
                            playerOnButton = 1;
                        }

                        // gets child index of box above
                        index = boxOrder.IndexOf(boxAbove);
                    }
                }
            }
        }

        if(boxPlayerOn != 0 && (itemsOnbutton.Contains(boxPlayerOn) || boxChain.Contains(boxPlayerOn))){
            playerOnButton = 1;
        } else {
            playerOnButton = 0;
        }
        // total number of objects on the button
        pressedCount = itemsOnbutton.Count + boxChain.Count + playerOnButton;
    }

    private void Reset()
    {
        this.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // identify box, not box trigger, and not box when held
        if(collision.CompareTag("Box") && collision.gameObject.layer == 9){

            // if box id not in list then add to list
            if(!itemsOnbutton.Contains(collision.gameObject.GetComponent<BoxController>().boxID)){
                itemsOnbutton.Add(collision.gameObject.GetComponent<BoxController>().boxID);
            }
        }

        // if detecting box trigger, and box is not held, check if in list
        if(collision.CompareTag("BoxTrigger") && !collision.gameObject.transform.parent.GetComponent<BoxController>().isHeld){

            // if box id not in list then add to list
            if(!itemsOnbutton.Contains(collision.gameObject.transform.parent.GetComponent<BoxController>().boxID)){
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
            // if box id not in list then add to list
            if(!itemsOnbutton.Contains(collision.gameObject.GetComponent<BoxController>().boxID)){
                itemsOnbutton.Add(collision.gameObject.GetComponent<BoxController>().boxID);
            }
        }

        // if detecting box trigger, do the same
        if(collision.CompareTag("BoxTrigger") && !collision.gameObject.transform.parent.GetComponent<BoxController>().isHeld){
            // if box id not in list then add to list
            if(!itemsOnbutton.Contains(collision.gameObject.transform.parent.GetComponent<BoxController>().boxID)){
                itemsOnbutton.Add(collision.gameObject.transform.parent.GetComponent<BoxController>().boxID);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // remove items from on box list when exit button trigger
        if(collision.CompareTag("Player")){
            itemsOnbutton.Remove(0);
        }

        if(collision.CompareTag("Box") && collision.gameObject.layer == 9){
            itemsOnbutton.Remove(collision.gameObject.GetComponent<BoxController>().boxID);
        }

        if(collision.CompareTag("BoxTrigger") && !collision.gameObject.transform.parent.GetComponent<BoxController>().isHeld){
            itemsOnbutton.Remove(collision.gameObject.transform.parent.GetComponent<BoxController>().boxID);

        }
    }
}


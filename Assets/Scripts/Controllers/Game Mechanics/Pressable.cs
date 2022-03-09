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
        // need to keep track of what boxes are new, add to list of boxes on button - using boxids
        if(collision.CompareTag("Box") && !collision.gameObject.GetComponent<PickUpable>().isHeld){
            if(itemsOnbutton.Count == 0){
                itemsOnbutton.Add(collision.gameObject.GetComponent<PickUpable>().boxID);
            } else {
                for(int i = 0; i < itemsOnbutton.Count; i++){
                    if(itemsOnbutton[i] == collision.gameObject.GetComponent<PickUpable>().boxID){
                        // break - do not add to list
                        break;
                    }
                    if((itemsOnbutton[i] != collision.gameObject.GetComponent<PickUpable>().boxID) && (i == itemsOnbutton.Count - 1)){
                        // add to list
                        itemsOnbutton.Add(collision.gameObject.GetComponent<PickUpable>().boxID);
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.CompareTag("Player")){
            itemsOnbutton.Add(0);
        }

        if(collision.CompareTag("Box") && !collision.gameObject.GetComponent<PickUpable>().isHeld){
            if(itemsOnbutton.Count == 0){
                itemsOnbutton.Add(collision.gameObject.GetComponent<PickUpable>().boxID);
            } else {
                for(int i = 0; i < itemsOnbutton.Count; i++){
                    if(itemsOnbutton[i] == collision.gameObject.GetComponent<PickUpable>().boxID){
                        // break - do not add to list
                        break;
                    }
                    if((itemsOnbutton[i] != collision.gameObject.GetComponent<PickUpable>().boxID) && (i == itemsOnbutton.Count - 1)){
                        // add to list
                        itemsOnbutton.Add(collision.gameObject.GetComponent<PickUpable>().boxID);
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            itemsOnbutton.Remove(0);
        }

        if(collision.CompareTag("Box") && !collision.gameObject.GetComponent<PickUpable>().isHeld){
            itemsOnbutton.Remove(collision.gameObject.GetComponent<PickUpable>().boxID);
        }

    }

}


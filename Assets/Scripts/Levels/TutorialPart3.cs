using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// determines when to open the door of the tutorial level - when the player has interacted in all possible ways
public class TutorialPart3 : MonoBehaviour
{   
    private bool buttonLabels;

    // level objects
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject button;
    // child 0 = labels
    // child 1 = trigger
    
    // level variables
    private bool pressed;
    

    // Start is called before the first frame update
    void Start()
    {   
        buttonLabels = GameManager.buttonLabels;
        if(buttonLabels){
            button.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        } else {
            button.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }

        // hide interact icons P and E
        this.transform.GetChild(1).GetComponent<IconController>().hide();
        this.transform.GetChild(2).GetComponent<IconController>().hide();

    }

    // Update is called once per frame
    void Update()
    {
        
        // if the player has pressed the button
        if(button.transform.GetChild(1).GetComponent<Pressable>().isPressed)
        {
            pressed = true;
        }

        if(pressed)
        {
            // open door
            door.GetComponent<DoorController>().openDoor();
        }

    }

}

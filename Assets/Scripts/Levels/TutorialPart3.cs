using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// determines when to open the door of the tutorial level - when the player has interacted in all possible ways
public class TutorialPart3 : MonoBehaviour
{   
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
        // hide interact icons F and W
        this.transform.GetChild(1).GetComponent<IconController>().hide();
        this.transform.GetChild(2).GetComponent<IconController>().hide();
    }

    // Update is called once per frame
    void Update()
    {
        
        // if the player has pressed the button
        if(button.GetComponent<ButtonController>().isPressed)
        {
            pressed = true;
        }

        if(pressed && !door.GetComponent<DoorController>().isOpen)
        {
            // open door
            door.GetComponent<DoorController>().openDoor();
        }

    }

}

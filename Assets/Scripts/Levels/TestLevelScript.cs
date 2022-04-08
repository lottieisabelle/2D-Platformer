using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// determines when to open the door of the tutorial level - when the player has interacted in all possible ways
public class TestLevelScript : MonoBehaviour
{   
    // level objects
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject button;
    // child 0 = label
    // child 1 = trigger

    // level variables
    private bool isPressed;
    private bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        // hide interact icons P and E
        this.transform.GetChild(1).GetComponent<IconController>().hide();
        this.transform.GetChild(2).GetComponent<IconController>().hide();

        isPressed = button.GetComponent<ButtonController>().isPressed;
        isOpen = door.GetComponent<DoorController>().isOpen;

    }

    // Update is called once per frame
    void Update()
    {

        isPressed = button.GetComponent<ButtonController>().isPressed;
        isOpen = door.GetComponent<DoorController>().isOpen;

        if(isPressed){
            if(!isOpen){
                door.GetComponent<DoorController>().openDoor();
            }
        } else {
            if(isOpen){
                door.GetComponent<DoorController>().closeDoor();
            }
        }
        
    }
}

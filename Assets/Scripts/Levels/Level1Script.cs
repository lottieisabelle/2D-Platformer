using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Script : MonoBehaviour
{
    // access settings
    private bool buttonLabels;

    // level objects
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject door;

    // level variables
    private bool isPressed;
    private bool isOpen;

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
        isOpen = door.GetComponent<DoorController>().isOpen;
        isPressed = button.transform.GetChild(1).GetComponent<Pressable>().isPressed;

        if(isPressed)
        {
            if(!isOpen)
            {
                // open door
                door.GetComponent<DoorController>().openDoor();
            }
        } else {
            if(isOpen)
            {
                // close door
                door.GetComponent<DoorController>().closeDoor();
            }
        }
    }
}

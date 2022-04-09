using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4aScript : MonoBehaviour
{
    // level objects
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button3;
    [SerializeField] private GameObject door;

    // level variables
    private bool isPressed1;
    private bool isPressed3;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        // hide interact icons F and W
        this.transform.GetChild(1).GetComponent<IconController>().hide();
        this.transform.GetChild(2).GetComponent<IconController>().hide();

        isOpen = false;
        isOpen = door.GetComponent<DoorController>().isOpen = false;   
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = door.GetComponent<DoorController>().isOpen;
        isPressed1 = button1.GetComponent<ButtonController>().isPressed;
        isPressed3 = button3.GetComponent<ButtonController>().isPressed;

        if(isPressed1 && isPressed3)
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

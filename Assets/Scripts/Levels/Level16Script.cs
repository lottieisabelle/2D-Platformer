using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level16Script : MonoBehaviour
{
    // level objects
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject door;

    // level variables
    private bool isPressed1;
    private bool isPressed2;
    private bool isVisible;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        isVisible = true;
        platform.GetComponent<ShowHideController>().isVisible = isVisible;

        // hide interact icons F and W
        this.transform.GetChild(1).GetComponent<IconController>().hide();
        this.transform.GetChild(2).GetComponent<IconController>().hide();
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = door.GetComponent<DoorController>().isOpen;

        isPressed1 = button1.GetComponent<ButtonController>().isPressed;
        isPressed2 = button2.GetComponent<ButtonController>().isPressed;

        isVisible = platform.GetComponent<ShowHideController>().isVisible;

        if(isPressed1)
        {
            if(!isOpen)
            {
                door.GetComponent<DoorController>().openDoor();
            }
        } else {
            if(isOpen)
            {
                door.GetComponent<DoorController>().closeDoor();
            }
        }

        if(isPressed2)
        {
            if(isVisible)
            {
                platform.GetComponent<ShowHideController>().hide();
                button1.GetComponent<ButtonController>().blockPressed = true;
            }
        } else {
            if(!isVisible)
            {
                platform.GetComponent<ShowHideController>().show();
            }
        }

    }
}

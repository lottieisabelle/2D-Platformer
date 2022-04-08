using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level15Script : MonoBehaviour
{    
    // level objects
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject obstacle;
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
        obstacle.GetComponent<ShowHideController>().isVisible = isVisible;

        // hide interact icons F and W
        this.transform.GetChild(1).GetComponent<IconController>().hide();
        this.transform.GetChild(2).GetComponent<IconController>().hide();

        isOpen = false;
        door.GetComponent<DoorController>().isOpen = isOpen;
    }

    // Update is called once per frame
    void Update()
    {
        isPressed1 = button1.GetComponent<ButtonController>().isPressed;
        isPressed2 = button2.GetComponent<ButtonController>().isPressed;
        isVisible = obstacle.GetComponent<ShowHideController>().isVisible;

        if(!isPressed1)
        {
            if(isVisible)
            {
                // hide obstacle
                obstacle.GetComponent<ShowHideController>().hide();
            }
        } else {
            if(!isVisible)
            {
                // show obstacle
                obstacle.GetComponent<ShowHideController>().show();
            }
        }

        if(isPressed2)
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
    }
}

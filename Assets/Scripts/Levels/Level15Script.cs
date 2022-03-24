using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level15Script : MonoBehaviour
{    
    // level objects
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject door;

    // level variables
    private bool isPressed;
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

        // open door
        //isOpen = 
        //door.GetComponent<DoorController>().openDoor();
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = door.GetComponent<DoorController>().isOpen;
        if(!isOpen){
            door.GetComponent<DoorController>().openDoor();
        }

        isPressed = button.GetComponent<ButtonController>().isPressed;
        isVisible = obstacle.GetComponent<ShowHideController>().isVisible;

        if(!isPressed)
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
    }
}

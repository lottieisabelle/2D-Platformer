using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level28 : MonoBehaviour
{
    // level objects
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject door;

    // level variables
    private bool isPressed2;
    private bool isPressed3;
    private bool platformVisible;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        // hide interact icons F and W
        this.transform.GetChild(1).GetComponent<IconController>().hide();
        this.transform.GetChild(2).GetComponent<IconController>().hide();

        platformVisible = true;
        platform.GetComponent<ShowHideController>().isVisible = platformVisible;

    }

    // Update is called once per frame
    void Update()
    {
        isOpen = door.GetComponent<DoorController>().isOpen;

        isPressed2 = button2.GetComponent<ButtonController>().isPressed;
        isPressed3 = button3.GetComponent<ButtonController>().isPressed;

        if(isPressed3){
            if(platformVisible){
                platform.GetComponent<ShowHideController>().hide();
            }
        } else {
            if(!platformVisible){
                platform.GetComponent<ShowHideController>().show();
            }
        }

        if(isPressed2 && isPressed3)
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level25Script : MonoBehaviour
{
    // level objects
    //[SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject door;

    // level variables
    //private bool isPressed1;
    private bool isPressed2;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        // hide interact icons F and W
        this.transform.GetChild(1).GetComponent<IconController>().hide();
        this.transform.GetChild(2).GetComponent<IconController>().hide();

        isOpen = false;
        door.GetComponent<DoorController>().isOpen = isOpen;
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = door.GetComponent<DoorController>().isOpen;
        //isPressed1 = button1.GetComponent<ButtonController>().isPressed;
        isPressed2 = button2.GetComponent<ButtonController>().isPressed;

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

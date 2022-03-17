using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level11Script : MonoBehaviour
{
    // used for level 5 and level 10
    
    // level objects
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject door;

    // level variables
    private bool isPressed1;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        // hide interact icons P and E
        this.transform.GetChild(1).GetComponent<IconController>().hide();
        this.transform.GetChild(2).GetComponent<IconController>().hide();

    }

    // Update is called once per frame
    void Update()
    {
        isOpen = door.GetComponent<DoorController>().isOpen;
        isPressed1 = button1.GetComponent<ButtonController>().isPressed;

        if(!isPressed1)
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

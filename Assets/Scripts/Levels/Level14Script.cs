using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level14Script : MonoBehaviour
{
    // level objects
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;
    [SerializeField] private GameObject door;

    // level variables
    private bool isPressed2;
    private bool isPressed3;
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

        isPressed2 = button2.GetComponent<ButtonController>().isPressed;
        isPressed3 = button3.GetComponent<ButtonController>().isPressed;

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
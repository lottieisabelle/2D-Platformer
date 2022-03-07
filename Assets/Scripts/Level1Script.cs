using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Script : MonoBehaviour
{
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject door;

    // interact icons
    [SerializeField] GameObject interactIconP;
    [SerializeField] GameObject interactIconE;

    private bool isPressed;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        isPressed = button.GetComponent<Pressable>().isPressed;
        isOpen = door.GetComponent<DoorController>().isOpen;
        interactIconP.GetComponent<IconController>().hide();
        interactIconE.GetComponent<IconController>().hide();
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = door.GetComponent<DoorController>().isOpen;
        isPressed = button.GetComponent<Pressable>().isPressed;

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

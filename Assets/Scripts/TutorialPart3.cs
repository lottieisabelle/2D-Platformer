using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// determines when to open the door of the tutorial level - when the player has interacted in all possible ways
public class TutorialPart3 : MonoBehaviour
{   
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject button;
    
    // interact icon E
    [SerializeField] GameObject interactIconE;

    private bool pressed;

    // Start is called before the first frame update
    void Start()
    {   
        interactIconE.GetComponent<IconController>().hide();
    }

    // Update is called once per frame
    void Update()
    {
        
        // if the player has pressed the button
        if(button.GetComponent<Pressable>().isPressed)
        {
            pressed = true;
        }

        if(pressed)
        {
            // open door
            door.GetComponent<DoorController>().openDoor();
        }

    }

}

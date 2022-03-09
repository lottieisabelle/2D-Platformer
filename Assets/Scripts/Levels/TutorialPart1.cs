using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// determines when to open the door of the tutorial level - when the player has interacted in all possible ways
public class TutorialPart1 : MonoBehaviour
{  
    // level objects
    [SerializeField] private GameObject door;
    
    // interact icon E
    [SerializeField] GameObject interactIconE;

    // level variables
    private bool jumped;
    private bool left;
    private bool right;

    // Start is called before the first frame update
    void Start()
    {   
        interactIconE.GetComponent<IconController>().show();

        jumped = false;
        left = false;
        right = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            jumped = true;
        }

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            left = true;
        }

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            right = true;
        }

        if(jumped && left && right)
        {
            // open door
            door.GetComponent<DoorController>().openDoor();
        }

    }

}

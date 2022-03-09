using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// determines when to open the door of the tutorial level - when the player has interacted in all possible ways
public class TestLevelScript : MonoBehaviour
{   
    private bool buttonLabels;

    // level objects
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject button;
    // child 0 = label
    // child 1 = trigger

    // level variables
    private bool jumped;
    private bool box;
    private bool left;
    private bool right;
    private bool pressed;

    // Start is called before the first frame update
    void Start()
    {
        buttonLabels = GameManager.buttonLabels;
        if(buttonLabels){
            button.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        } else {
            button.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }

        jumped = false;
        box = false;
        left = false;
        right = false;
        pressed = false;
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

        // if the player's hands are not empty - they have picked up the box
        if(!player.GetComponent<PlayerController>().handsEmpty)
        {
            box = true;
        }
        
        // if the player has pressed the button
        if(button.transform.GetChild(1).GetComponent<Pressable>().isPressed)
        {
            pressed = true;
        }

        if(jumped && left && right && box && pressed)
        {
            // open door
            door.GetComponent<DoorController>().openDoor();
        }



    }
}

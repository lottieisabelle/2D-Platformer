using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// determines when to open the door of the tutorial level - when the player has interacted in all possible ways
public class TutorialPart2 : MonoBehaviour
{  
    // level objects
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject door;

    // level variables
    private bool box;

    // Start is called before the first frame update
    void Start()
    {   
        // show interact icon P
        this.transform.GetChild(1).GetComponent<IconController>().show();
        // hide interact icon E
        this.transform.GetChild(2).GetComponent<IconController>().hide();

        box = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if the player's hands are not empty - they have picked up the box
        if(!player.GetComponent<PlayerController>().handsEmpty)
        {
            box = true;
        }

        if(box)
        {
            // open door
            door.GetComponent<DoorController>().openDoor();
        }

    }

}

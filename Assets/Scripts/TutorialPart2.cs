using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// determines when to open the door of the tutorial level - when the player has interacted in all possible ways
public class TutorialPart2 : MonoBehaviour
{   
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject door;
    
    // interact icons
    [SerializeField] GameObject interactIconP;
    [SerializeField] GameObject interactIconE;

    private bool box;

    // Start is called before the first frame update
    void Start()
    {   
        interactIconP.GetComponent<IconController>().show();
        interactIconE.GetComponent<IconController>().hide();

        box = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if the player's hands are not empty - they have picked up the box
        if(!player.GetComponent<PlayerMovement>().handsEmpty)
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

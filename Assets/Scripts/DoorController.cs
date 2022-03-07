using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform door;
    public SpriteRenderer doorSR;
    public BoxCollider2D doorHole;

    public bool isOpen;
    
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        doorHole.enabled = false;
        doorHole.isTrigger = false;

    }

    public void openDoor()
    {
        // open door
        door.localPosition = new Vector3(-2.51f , door.localPosition.y, door.localPosition.z);
        doorSR.flipX = true;
        doorHole.enabled = true;
        doorHole.isTrigger = true;
        isOpen = !isOpen;
    }

    public void closeDoor()
    {
        // close door
        door.localPosition = new Vector3(-1.341f , door.localPosition.y, door.localPosition.z);
        doorSR.flipX = false;
        doorHole.enabled = false;
        doorHole.isTrigger = false;
        isOpen = !isOpen;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool isOpen;

    private Vector3 openPosition;
    private Vector3 closedPosition;
    
    void Start()
    {
        openPosition = new Vector3(-1.61f , this.transform.GetChild(0).GetComponent<Transform>().localPosition.y , this.transform.GetChild(0).GetComponent<Transform>().localPosition.z);
        closedPosition = new Vector3(0f , this.transform.GetChild(0).GetComponent<Transform>().localPosition.y , this.transform.GetChild(0).GetComponent<Transform>().localPosition.z);

        // disable exit
        this.transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;
        this.transform.GetChild(1).GetComponent<BoxCollider2D>().isTrigger = false;
        
        isOpen = false;
    }

    public void openDoor()
    {
        // open door
        this.transform.GetChild(0).GetComponent<Transform>().localPosition = openPosition;
        this.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;

        // enable exit
        this.transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = true;
        this.transform.GetChild(1).GetComponent<BoxCollider2D>().isTrigger = true;

        isOpen = !isOpen;
    }

    public void closeDoor()
    {
        // close door
        this.transform.GetChild(0).GetComponent<Transform>().localPosition = closedPosition;
        this.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;

        // disable exit
        this.transform.GetChild(1).GetComponent<BoxCollider2D>().enabled = false;
        this.transform.GetChild(1).GetComponent<BoxCollider2D>().isTrigger = false;

        isOpen = !isOpen;
    }

}

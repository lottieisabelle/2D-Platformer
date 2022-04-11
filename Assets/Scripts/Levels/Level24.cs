using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level24 : MonoBehaviour
{
    // level objects
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject door;

    // level variables
    private bool isPressed1;
    private bool isPressed2;
    private bool obstacleVisible;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        // hide interact icons F and W
        this.transform.GetChild(1).GetComponent<IconController>().hide();
        this.transform.GetChild(2).GetComponent<IconController>().hide();

        isOpen = false;
        isOpen = door.GetComponent<DoorController>().isOpen = false;

        obstacleVisible = true;
        obstacle.GetComponent<ObstacleController>().isVisible = obstacleVisible;
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = door.GetComponent<DoorController>().isOpen;
        isPressed1 = button1.GetComponent<ButtonController>().isPressed;
        isPressed2 = button2.GetComponent<ButtonController>().isPressed;
        obstacleVisible = obstacle.GetComponent<ObstacleController>().isVisible;

        if(isPressed1){
            if(obstacleVisible){
                // hide
                obstacle.GetComponent<ObstacleController>().hide();
            }
        } else {
            if(!obstacleVisible){
                // show
                obstacle.GetComponent<ObstacleController>().show();
            }
        }   

        if(!isPressed2)
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

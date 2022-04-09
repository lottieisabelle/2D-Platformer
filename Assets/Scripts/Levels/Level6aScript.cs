using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6aScript : MonoBehaviour
{
    // level objects
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject door;

    // level variables
    private bool isPressed1;
    private bool isPressed2;
    private bool isPressed3;
    private bool obstacleVisible;
    private bool isOpen;

    void Start()
    {
        obstacleVisible = true;
        obstacle.GetComponent<ShowHideController>().isVisible = obstacleVisible;

        // hide interact icons F and W
        this.transform.GetChild(1).GetComponent<IconController>().hide();
        this.transform.GetChild(2).GetComponent<IconController>().hide();

        isOpen = false;
        isOpen = door.GetComponent<DoorController>().isOpen = false;
    }

    void Update()
    {
        isOpen = door.GetComponent<DoorController>().isOpen;

        isPressed1 = button1.GetComponent<ButtonController>().isPressed;
        isPressed2 = button2.GetComponent<ButtonController>().isPressed;
        isPressed3 = button3.GetComponent<ButtonController>().isPressed;

        obstacleVisible = obstacle.GetComponent<ShowHideController>().isVisible;

        if(isPressed1 || isPressed3){
            if(obstacleVisible){
                obstacle.GetComponent<ShowHideController>().hide();
            }
        } else {
            if(!obstacleVisible){
                obstacle.GetComponent<ShowHideController>().show();
            }
        }

        if(!isPressed1 && isPressed2 && isPressed3){
            if(!isOpen){
                door.GetComponent<DoorController>().openDoor();
            }
        } else {
            if(isOpen){
                door.GetComponent<DoorController>().closeDoor();
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level28Script : MonoBehaviour
{
    // level objects
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;
    [SerializeField] private GameObject button4;
    [SerializeField] private GameObject platform;
    [SerializeField] private GameObject obstacle;
    [SerializeField] private GameObject door;

    // level variables
    private bool isPressed1;
    private bool isPressed2;
    private bool isPressed3;
    private bool isPressed4;
    private bool platformVisible;
    private bool obstacleVisible;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        platformVisible = true;
        platform.GetComponent<ShowHideController>().isVisible = platformVisible;

        obstacleVisible = true;
        obstacle.GetComponent<ShowHideController>().isVisible = obstacleVisible;

        // hide interact icons F and W
        this.transform.GetChild(1).GetComponent<IconController>().hide();
        this.transform.GetChild(2).GetComponent<IconController>().hide();

        isOpen = false;
        isOpen = door.GetComponent<DoorController>().isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        isOpen = door.GetComponent<DoorController>().isOpen;

        isPressed1 = button1.GetComponent<ButtonController>().isPressed;
        isPressed2 = button2.GetComponent<ButtonController>().isPressed;
        isPressed3 = button3.GetComponent<ButtonController>().isPressed;
        isPressed4 = button4.GetComponent<ButtonController>().isPressed;

        platformVisible = platform.GetComponent<ShowHideController>().isVisible;
        obstacleVisible = obstacle.GetComponent<ShowHideController>().isVisible;

        if(isPressed2){
            if(platformVisible){
                platform.GetComponent<ShowHideController>().hide();
            }
        } else {
            if(!platformVisible){
                platform.GetComponent<ShowHideController>().show();
            }
        }

        if(isPressed1 || isPressed2){
            if(obstacleVisible){
                obstacle.GetComponent<ShowHideController>().hide();
            }
        } else {
            if(!obstacleVisible){
                obstacle.GetComponent<ShowHideController>().show();
            }
        }

        if(isPressed3 && !isPressed4){
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

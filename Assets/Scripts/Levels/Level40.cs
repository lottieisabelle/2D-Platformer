using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level40 : MonoBehaviour
{
    // level objects
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;
    [SerializeField] private GameObject button4;
    [SerializeField] private GameObject button5;

    [SerializeField] private GameObject platform1;
    [SerializeField] private GameObject platform2;

    [SerializeField] private GameObject obstacle1;
    [SerializeField] private GameObject obstacle2;
    [SerializeField] private GameObject obstacle3;

    [SerializeField] private GameObject door;

    // level variables
    private bool isPressed1;
    private bool isPressed2;
    private bool isPressed3;
    private bool isPressed4;
    private bool isPressed5;

    private bool platformVisible1;
    private bool platformVisible2;

    private bool obstacleVisible1;
    private bool obstacleVisible2;
    private bool obstacleVisible3;

    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        platformVisible1 = true;
        platform1.GetComponent<ShowHideController>().isVisible = platformVisible1;

        platformVisible2 = true;
        platform2.GetComponent<ShowHideController>().isVisible = platformVisible2;


        obstacleVisible1 = true;
        obstacle1.GetComponent<ShowHideController>().isVisible = obstacleVisible1;

        obstacleVisible2 = true;
        obstacle2.GetComponent<ShowHideController>().isVisible = obstacleVisible2;

        obstacleVisible3 = true;
        obstacle3.GetComponent<ShowHideController>().isVisible = obstacleVisible3;

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
        isPressed5 = button5.GetComponent<ButtonController>().isPressed;

        platformVisible1 = platform1.GetComponent<ShowHideController>().isVisible;
        platformVisible2 = platform2.GetComponent<ShowHideController>().isVisible;
        
        obstacleVisible1 = obstacle1.GetComponent<ShowHideController>().isVisible;
        obstacleVisible2 = obstacle2.GetComponent<ShowHideController>().isVisible;
        obstacleVisible3 = obstacle3.GetComponent<ShowHideController>().isVisible;

        // platform1
        if(isPressed4){
            if(platformVisible1){
                platform1.GetComponent<ShowHideController>().hide();
            }
        } else {
            if(!platformVisible1){
                platform1.GetComponent<ShowHideController>().show();
            }
        }

        // platform2
        if(isPressed1 && isPressed3){
            if(platformVisible2){
                platform2.GetComponent<ShowHideController>().hide();
                button5.GetComponent<ButtonController>().blockPressed = true;
            }
        } else {
            if(!platformVisible2){
                platform2.GetComponent<ShowHideController>().show();
            }
        }

        // obstacle 1
        if(!isPressed1){
            if(obstacleVisible1){
                obstacle1.GetComponent<ShowHideController>().hide();
            }
        } else {
            if(!obstacleVisible1){
                obstacle1.GetComponent<ShowHideController>().show();
            }
        }

        // obstacle 2
        if(isPressed2){
            if(obstacleVisible2){
                obstacle2.GetComponent<ShowHideController>().hide();
            }
        } else {
            if(!obstacleVisible2){
                obstacle2.GetComponent<ShowHideController>().show();
            }
        }

        // obstacle 3
        if(isPressed2 && isPressed5){
            if(obstacleVisible3){
                obstacle3.GetComponent<ShowHideController>().hide();
            }
        } else {
            if(!obstacleVisible3){
                obstacle3.GetComponent<ShowHideController>().show();
            }
        }

        // door
        if((!isPressed1 && !isPressed2 && !isPressed4) || (isPressed1 && isPressed2 && isPressed4 && isPressed5 && !isPressed3)){
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

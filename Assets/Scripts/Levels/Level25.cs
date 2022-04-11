using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level25 : MonoBehaviour
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
    private bool isVisible;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        isVisible = true;
        obstacle.GetComponent<ObstacleController>().isVisible = isVisible;

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

        isVisible = obstacle.GetComponent<ObstacleController>().isVisible;

        if(!isPressed1 || !isPressed2){
            if(isVisible){
                obstacle.GetComponent<ObstacleController>().hide();
            }
        } else {
            if(!isVisible){
                obstacle.GetComponent<ObstacleController>().show();
            }
        }

        if(!isPressed1 || !isPressed2 || !isPressed3){
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

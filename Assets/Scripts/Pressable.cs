using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Pressable : MonoBehaviour
{
    [SerializeField] private SpriteRenderer value;
    [SerializeField] private Sprite _true, _false;
    
    private bool playerPressed;
    private bool boxPressed;
    public bool blockPressed;

    public bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        blockPressed = this.transform.parent.GetComponent<ButtonController>().blockPressed;

        playerPressed = false;
        boxPressed = false;
        
        if(blockPressed)
        {
            // deactivate boxcollider
            this.GetComponent<BoxCollider2D>().enabled = false;

            isPressed = true;
            value.sprite = _true;
        } else {
            this.GetComponent<BoxCollider2D>().enabled = true;
            this.GetComponent<BoxCollider2D>().isTrigger = true;

            isPressed = false;
            value.sprite = _false;
        }
    }

    void Update()
    {
        if(playerPressed == true || boxPressed == true || blockPressed == true)
        {
            isPressed = true;
            value.sprite = _true;
        } else {
            isPressed = false;
            value.sprite = _false;
        }
    }

    private void Reset()
    {
        this.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {   
        if(collision.CompareTag("Player")){
            playerPressed = true;
            isPressed = true;
            value.sprite = _true;
        }
        if(collision.CompareTag("Box") && !collision.gameObject.GetComponent<PickUpable>().isHeld){
            boxPressed = true;
            isPressed = true;
            value.sprite = _true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.CompareTag("Player"))
            playerPressed = true;
            isPressed = true;
            value.sprite = _true;

        if(collision.CompareTag("Box") && !collision.gameObject.GetComponent<PickUpable>().isHeld)
            boxPressed = true;
            isPressed = true;
            value.sprite = _true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            playerPressed = false;

        if(collision.CompareTag("Box"))
            boxPressed = false;

    }

}


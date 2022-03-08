using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Pressable : MonoBehaviour
{
    [SerializeField] private SpriteRenderer value;
    [SerializeField] private Sprite _true, _false;
    [SerializeField] public bool blockPressed;

    public BoxCollider2D pressTrigger;
    public bool playerPressed;
    public bool boxPressed;
    

    public bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        playerPressed = false;
        boxPressed = false;
        //blockPressed = false;

        isPressed = false;

        value.sprite = _false;

        pressTrigger.isTrigger = true;
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
        pressTrigger.isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {   
        if(collision.CompareTag("Player")){
            playerPressed = true;
            isPressed = true;
            value.sprite = _true;
        }
        if(collision.CompareTag("Box")){
            boxPressed = true;
            isPressed = true;
            value.sprite = _true;
        }
        if(collision.CompareTag("Block")){
            blockPressed = true;
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

        if(collision.CompareTag("Box"))
            boxPressed = true;
            isPressed = true;
            value.sprite = _true;
            
        if(collision.CompareTag("Block"))
            blockPressed = true;
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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // unpressed button
    [SerializeField] public GameObject unpressed;
    // pressed button 
    [SerializeField] public GameObject pressed;

    // trigger info
    [SerializeField] public GameObject trigger;
    
    public bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        unpressed.GetComponent<SpriteRenderer>().enabled = true;
        unpressed.GetComponent<PolygonCollider2D>().enabled = true;

        pressed.GetComponent<SpriteRenderer>().enabled = false;
        pressed.GetComponent<PolygonCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        isPressed = trigger.GetComponent<Pressable>().isPressed;

        if(isPressed){
            unpressed.GetComponent<SpriteRenderer>().enabled = false;
            unpressed.GetComponent<PolygonCollider2D>().enabled = false;

            pressed.GetComponent<SpriteRenderer>().enabled = true;
            pressed.GetComponent<PolygonCollider2D>().enabled = true;
        } else {
            unpressed.GetComponent<SpriteRenderer>().enabled = true;
            unpressed.GetComponent<PolygonCollider2D>().enabled = true;

            pressed.GetComponent<SpriteRenderer>().enabled = false;
            pressed.GetComponent<PolygonCollider2D>().enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // button children
    // child 0 = colour label
    // child 1 = trigger
    // child 2 = unpressed
    // child 3 = pressed
    // child 4 = value (true/false text)

    [SerializeField] public string colour;
    [SerializeField] public bool blockPressed;
    
    public bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        isPressed = this.transform.GetChild(1).GetComponent<Pressable>().isPressed;

        this.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = true;
        this.transform.GetChild(2).GetComponent<PolygonCollider2D>().enabled = true;

        this.transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = false;
        this.transform.GetChild(3).GetComponent<PolygonCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        isPressed = this.transform.GetChild(1).GetComponent<Pressable>().isPressed;

        if(isPressed){
            this.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
            this.transform.GetChild(2).GetComponent<PolygonCollider2D>().enabled = false;

            this.transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = true;
            this.transform.GetChild(3).GetComponent<PolygonCollider2D>().enabled = true;
        } else {
            this.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = true;
            this.transform.GetChild(2).GetComponent<PolygonCollider2D>().enabled = true;

            this.transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = false;
            this.transform.GetChild(3).GetComponent<PolygonCollider2D>().enabled = false;
        }
    }
}

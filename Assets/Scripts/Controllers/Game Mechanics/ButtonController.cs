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
    // child 4 = lights

    [SerializeField] public string colour;
    [SerializeField] public bool blockPressed;
    [SerializeField] public Sprite lightOn, lightOff;
    
    public int lights;

    public bool isPressed;
    private int pressedCount;

    // Start is called before the first frame update
    void Start()
    {
        // show or hide button labels
        if(GameManager.buttonLabels){
            this.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        } else {
            this.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }

        pressedCount = 0;

        // set button to unpressed
        this.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = true;
        this.transform.GetChild(2).GetComponent<PolygonCollider2D>().enabled = true;

        this.transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = false;
        this.transform.GetChild(3).GetComponent<PolygonCollider2D>().enabled = false;

        // set all lights off
        lights = this.transform.GetChild(4).childCount;
        for(int i = 0; i < lights; i++)
        {
            this.transform.GetChild(4).GetChild(i).GetComponent<SpriteRenderer>().sprite = lightOff;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // get number of items on the button
        //pressedCount = this.transform.GetChild(1).GetComponent<Pressable>().pressedCount;

        if(!(this.transform.GetChild(1).GetComponent<Pressable>().blockPressed)){
            this.transform.GetChild(1).GetComponent<Pressable>().getPressedCount();
            pressedCount = this.transform.GetChild(1).GetComponent<Pressable>().pressedCount;
        } else {
            pressedCount = lights;
        }

        float buttonTimer = 0;

        if(pressedCount == 0){

            while(buttonTimer < 0.2f){
                buttonTimer += Time.deltaTime;
            }
            // wait and check again

            this.transform.GetChild(1).GetComponent<Pressable>().getPressedCount();
            pressedCount = this.transform.GetChild(1).GetComponent<Pressable>().pressedCount;

            buttonTimer = 0;

        }
        // if pressed count is 0 - wait for a bit, check again and then set button sprite ?
        
        Debug.Log(pressedCount);

        // turn on the same number of lights as there is items on the button (up to the number of lights)
        for(int i = 0; i < lights; i++)
        {   
            if(i < pressedCount){
                this.transform.GetChild(4).GetChild(i).GetComponent<SpriteRenderer>().sprite = lightOn;
            } else {
                this.transform.GetChild(4).GetChild(i).GetComponent<SpriteRenderer>().sprite = lightOff;
            }
        }

        // the button is pressed when the number of items on the button is at least the number of lights
        if(pressedCount >= lights)
        {
            isPressed = true;
        } else {
            isPressed = false;
        }

        // show the button in the correct position
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

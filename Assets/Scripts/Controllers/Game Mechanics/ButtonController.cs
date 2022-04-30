using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    [SerializeField] public string colour;
    [SerializeField] public bool blockPressed;
    [SerializeField] public Sprite lightOn, lightOff;
    
    public int lights;

    public bool isPressed;
    private int pressedCount;

    private float changeTimer;

    void Start()
    {
        // show or hide button labels
        if(GameManager.buttonLabels){
            this.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        } else {
            this.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }

        pressedCount = 0;

        lights = this.transform.GetChild(4).childCount;

        if(isPressed){
            // set button to pressed
            On();
            pressedCount = lights;
        } else {
            // set button to unpressed
            Off();
        }

        // turn on the same number of lights as there is items on the button (up to the number of lights)
        for(int i = 0; i < lights; i++)
        {   
            if(i < pressedCount){
                this.transform.GetChild(4).GetChild(i).GetComponent<SpriteRenderer>().sprite = lightOn;
            } else {
                this.transform.GetChild(4).GetChild(i).GetComponent<SpriteRenderer>().sprite = lightOff;
            }
        }
        
        changeTimer = 0;
    }

    void Update()
    {
        // delay visual graphics changing to prevent/delay glitching
        if(changeTimer > 0.15f){

            // get number of items on the button
            if(!(this.transform.GetChild(1).GetComponent<Pressable>().blockPressed)){

                this.transform.GetChild(1).GetComponent<Pressable>().getPressedCount();
                pressedCount = this.transform.GetChild(1).GetComponent<Pressable>().pressedCount;

            } else {
                pressedCount = lights;
            }

            // the button is pressed when the number of items on the button is at least the number of lights
            if(pressedCount >= lights)
            {
                isPressed = true;
            } else {
                isPressed = false;
            }

            // turn on the same number of lights as there is items on the button (up to the number of lights)
            for(int i = 0; i < lights; i++)
            {   
                if(i < pressedCount){
                    this.transform.GetChild(4).GetChild(i).GetComponent<SpriteRenderer>().sprite = lightOn;
                } else {
                    this.transform.GetChild(4).GetChild(i).GetComponent<SpriteRenderer>().sprite = lightOff;
                }
            }

            // show the button in the correct position
            if(isPressed){
                On();

            } else {
                Off();
            }
        }

        changeTimer += Time.deltaTime;
    }

    private void On()
    {
        this.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
        this.transform.GetChild(2).GetComponent<PolygonCollider2D>().enabled = false;

        this.transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = true;
        this.transform.GetChild(3).GetComponent<PolygonCollider2D>().enabled = true;

        changeTimer = 0;
    }

    private void Off()
    {
        this.transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = true;
        this.transform.GetChild(2).GetComponent<PolygonCollider2D>().enabled = true;

        this.transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = false;
        this.transform.GetChild(3).GetComponent<PolygonCollider2D>().enabled = false;

        changeTimer = 0;
    }



}

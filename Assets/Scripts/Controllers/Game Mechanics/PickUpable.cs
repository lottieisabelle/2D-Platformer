using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class PickUpable : MonoBehaviour
{   
    private string level;
    private bool handsEmpty;

    void Start()
    {
        level = this.transform.parent.parent.parent.GetComponent<LevelController>().levelName;
    }

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    void Update()
    {
        // if this box is being held, then player hands are not empty
        if(this.transform.parent.GetComponent<BoxController>().isHeld){
            handsEmpty = false;
        } else {
            // otherwise need to get hands empty bool from player - box is in boxes in hierarchy
            handsEmpty = this.transform.parent.parent.parent.GetChild(5).GetComponent<PlayerController>().handsEmpty;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        // show interact icon p
        if(collision.CompareTag("Player")){
            if(level != "Tutorial2" && !this.transform.parent.GetComponent<BoxController>().isHeld)
            {
                this.transform.parent.parent.parent.GetChild(1).GetComponent<IconController>().show();
            }
        }
     
    }

    private void OnTriggerStay2D(Collider2D collision)
    {   
        // show interact icon p
        if(collision.CompareTag("Player")){
            if(level != "Tutorial2" && !this.transform.parent.GetComponent<BoxController>().isHeld)
            {
                this.transform.parent.parent.parent.GetChild(1).GetComponent<IconController>().show();
            }
        }
     
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // hide interact icon p
        if(collision.CompareTag("Player")){
            // not on tutorial part2 and only when hands are empty


            //if(level != "Tutorial2" && !this.transform.parent.GetComponent<BoxController>().isHeld)
            if(level != "Tutorial2" && handsEmpty)
            {
                this.transform.parent.parent.parent.GetChild(1).GetComponent<IconController>().hide();
            }
        }
            
    }
    
}

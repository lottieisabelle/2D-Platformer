using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class PickUpable : MonoBehaviour
{   
    
    private string level;

    void Start()
    {
        level = this.transform.parent.parent.GetComponent<LevelController>().levelName;
    }

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        // show interact icon p
        if(collision.CompareTag("Player")){
            if(level != "Tutorial2" && !this.transform.parent.GetComponent<BoxController>().isHeld)
            {
                this.transform.parent.parent.GetChild(1).GetComponent<IconController>().show();
            }
        }
     
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // hide interact icon p
        if(collision.CompareTag("Player")){
            if(level != "Tutorial2" && !this.transform.parent.GetComponent<BoxController>().isHeld)
            {
                this.transform.parent.parent.GetChild(1).GetComponent<IconController>().hide();
            }
        }
            
    }
    
}

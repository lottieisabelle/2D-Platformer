using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Enterable : MonoBehaviour
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

    // update players ability to exit level
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.CompareTag("Player"))
            collision.GetComponent<PlayerController>().canEnter = true;
            // visibility of the exit interact icon does not change in tutorial part 1
            if(level != "Tutorial1")
            {
                this.transform.parent.parent.GetChild(2).GetComponent<IconController>().show();
            }
    }

    // update players ability to exit level
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            collision.GetComponent<PlayerController>().canEnter = false;
            // visibility of the exit interact icon does not change in tutorial part 1
            if(level != "Tutorial1")
            {
                this.transform.parent.parent.GetChild(2).GetComponent<IconController>().hide();
            }
    }
    
}
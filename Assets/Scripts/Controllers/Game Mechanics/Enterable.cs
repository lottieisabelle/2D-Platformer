using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Enterable : MonoBehaviour
{
    //[SerializeField] private string level;
    //[SerializeField] GameObject interactIconE;

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
        if(collision.CompareTag("Player"))
            collision.GetComponent<PlayerController>().canEnter = true;

            if(level != "Tutorial1")
            {
                // show the E if it's not the tutorial level
                //interactIconE.GetComponent<IconController>().show();
                this.transform.parent.parent.GetChild(2).GetComponent<IconController>().show();
            }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            collision.GetComponent<PlayerController>().canEnter = false;

            if(level != "Tutorial1")
            {
                // hide the E if it's not the tutorial level
                //interactIconE.GetComponent<IconController>().hide();
                this.transform.parent.parent.GetChild(2).GetComponent<IconController>().hide();
            }
    }
    
}
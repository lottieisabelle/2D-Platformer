using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Enterable : MonoBehaviour
{
    [SerializeField] private string level;
    [SerializeField] GameObject interactIconE;

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.CompareTag("Player"))
            collision.GetComponent<PlayerMovement>().canEnter = true;

            if(level != "Tutorial1")
            {
                // show the E if it's not the tutorial level
                interactIconE.GetComponent<IconController>().show();
            }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            collision.GetComponent<PlayerMovement>().canEnter = false;

            if(level != "Tutorial1")
            {
                // hide the E if it's not the tutorial level
                interactIconE.GetComponent<IconController>().hide();
            }
    }
    
}
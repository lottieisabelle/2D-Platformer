using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class PickUpable : MonoBehaviour
{   
    [SerializeField] private string level;
    [SerializeField] GameObject interactIconP;

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.CompareTag("Player"))
            if(level != "Tutorial2")
            {
                interactIconP.GetComponent<IconController>().show();
            }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            if(level != "Tutorial2")
            {
                interactIconP.GetComponent<IconController>().hide();
            }
            
    }
    
}

using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class PickUpable : MonoBehaviour
{   
    [SerializeField] public int boxID;

    public bool isHeld;
    private string level;

    void Start()
    {
        isHeld = false;
        level = this.transform.parent.GetComponent<LevelController>().levelName;
    }

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    // do not show or hide P icon when level = Tutorial2
    // also
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.CompareTag("Player"))
            if(level != "Tutorial2" && !isHeld)
            {
                this.transform.parent.GetChild(1).GetComponent<IconController>().show();
            }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            if(level != "Tutorial2" && !isHeld)
            {
                this.transform.parent.GetChild(1).GetComponent<IconController>().hide();
            }
            
    }
    
}

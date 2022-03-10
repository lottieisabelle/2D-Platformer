using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class PickUpable : MonoBehaviour
{   
    [SerializeField] public int boxID;

    public bool isHeld;
    private string level;

    public bool isOnButton;

    void Start()
    {
        isHeld = false;
        level = this.transform.parent.GetComponent<LevelController>().levelName;

        isOnButton = false;
    }

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.CompareTag("Player")){
            if(level != "Tutorial2" && !isHeld)
            {
                this.transform.parent.GetChild(1).GetComponent<IconController>().show();
            }
        }

        if(collision.CompareTag("Button")){
            isOnButton = true;
        }
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            if(level != "Tutorial2" && !isHeld)
            {
                this.transform.parent.GetChild(1).GetComponent<IconController>().hide();
            }
        }

        if(collision.CompareTag("Button")){
            isOnButton = false;
        }
            
    }
    
}

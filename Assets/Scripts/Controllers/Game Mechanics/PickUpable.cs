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

    void Update()
    {
        if(!isHeld)
        {
            // determine what object box is sitting on
            RaycastHit2D surfaceHit = Physics2D.BoxCast(this.GetComponent<BoxCollider2D>().bounds.center, this.GetComponent<BoxCollider2D>().bounds.size, 0, Vector2.down, 0.3f);

            if(surfaceHit.collider != null){
                Debug.Log(surfaceHit.collider.tag);
                
                if(surfaceHit.collider.CompareTag("Button"))
                {
                    isOnButton = true;
                } 
                else if(surfaceHit.collider.CompareTag("Box"))
                {
                    if(surfaceHit.collider.gameObject.GetComponent<PickUpable>().isOnButton){
                        isOnButton = true;
                    }
                } else {
                    isOnButton = false;
                }

            }
        }
        
    }

    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        // show interact icon p
        if(collision.CompareTag("Player")){
            if(level != "Tutorial2" && !isHeld)
            {
                this.transform.parent.GetChild(1).GetComponent<IconController>().show();
            }
        }

        // TODO : need to figure out what button objects need to have tag button - if not all?
        //if(collision.CompareTag("Button")){
        //    isOnButton = true;
        //}

        // TODO : need better detection method than this - probably boxcast down
        //if(collision.CompareTag("Box") && isOnButton){
        //    collision.gameObject.GetComponent<PickUpable>().isOnButton = true;
        //}

            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // hide interact icon p
        if(collision.CompareTag("Player")){
            if(level != "Tutorial2" && !isHeld)
            {
                this.transform.parent.GetChild(1).GetComponent<IconController>().hide();
            }
        }

        // TODO : need to figure out what button objects need to have tag button - if not all?
        //if(collision.CompareTag("Button")){
        //    isOnButton = false;
        //}

        // TODO : need better detection method than this - probably boxcast down
        //if(collision.CompareTag("Box") && isOnButton){
        //    collision.gameObject.GetComponent<PickUpable>().isOnButton = false;
        //}
            
    }
    
}

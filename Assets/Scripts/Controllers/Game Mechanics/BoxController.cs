using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField] public int boxID;

    public bool isOnButton;
    public bool isHeld;

    private LayerMask boxTriggerLayer;
    private LayerMask notBoxTriggers;

    // Start is called before the first frame update
    void Start()
    {
        boxTriggerLayer = this.transform.parent.GetComponent<LevelController>().boxTriggerLayer;
        notBoxTriggers = ~boxTriggerLayer;
        isHeld = false;
        isOnButton = false;
    }

    public void getAbove()
    {
        // determine object sitting on top of box - excludes box trigger colliders
        RaycastHit2D topHit = Physics2D.BoxCast(this.GetComponent<BoxCollider2D>().bounds.center, this.GetComponent<BoxCollider2D>().bounds.size, 0, Vector2.up, 0.3f, notBoxTriggers);

        if(topHit.collider != null){

            if(topHit.collider.CompareTag("Box"))
            {
                // if different box ID
                if(topHit.collider.gameObject.GetComponent<BoxController>().boxID != this.GetComponent<BoxController>().boxID){
                    
                    // add 1 to on button item count

                    // call recursively on box hit

                }
            } else if (topHit.collider.CompareTag("Player"))
            {
                // add 1 to button item count 

                Debug.Log("player");
            }
        }
    }

}

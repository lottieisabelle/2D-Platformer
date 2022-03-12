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

    /*
    void Update()
    {
        if(!isHeld)
        {
            // determine object sitting on top of box - excludes box trigger colliders
            RaycastHit2D topHit = Physics2D.BoxCast(this.GetComponent<BoxCollider2D>().bounds.center, this.GetComponent<BoxCollider2D>().bounds.size, 0, Vector2.up, 0.3f, notBoxTriggers);

            if(topHit.collider != null){

                if(topHit.collider.CompareTag("Box"))
                {
                    if(topHit.collider.gameObject.GetComponent<BoxController>().boxID != this.GetComponent<BoxController>().boxID){

                        if(this.GetComponent<BoxController>().isOnButton){
                            topHit.collider.gameObject.GetComponent<BoxController>().isOnButton;
                        }

                        Debug.Log(this.GetComponent<BoxController>().boxID + "diff box");
                    } else {
                        Debug.Log(this.GetComponent<BoxController>().boxID + "same box");
                    }
                } else if (topHit.collider.CompareTag("Player"))
                {
                    Debug.Log("player");
                }
                // if same box discard
                // if diff box - important
                // if player important
            }
        }
    }
    */

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
                // add 1 to button item count ? 

                Debug.Log("player");
            }
        }
    }

    /*
    // Update is called once per frame
    void Update()
    {
        if(!isHeld)
        {
            // determine what object box is sitting on - casts rays on all colliders excluding the box triggers
            RaycastHit2D surfaceHit = Physics2D.BoxCast(this.GetComponent<BoxCollider2D>().bounds.center, this.GetComponent<BoxCollider2D>().bounds.size, 0, Vector2.down, 0.3f, notBoxTriggers);

            if(surfaceHit.collider != null){

                // keeps detecting itself - need to check if box, if it's a different boxID than itself
                if(surfaceHit.collider.CompareTag("Box")){
                    if(surfaceHit.collider.gameObject.GetComponent<BoxController>().boxID != this.GetComponent<BoxController>().boxID){
                        Debug.Log("diff box");
                    } else {
                        Debug.Log("same box");
                    }
                } else if(surfaceHit.collider.CompareTag("Button")){
                    Debug.Log("button");
                } else if(surfaceHit.collider.CompareTag("Ground")){
                    Debug.Log("ground");
                }

                //Debug.Log(surfaceHit.collider.tag);
                
                if(surfaceHit.collider.CompareTag("Button"))
                {
                    isOnButton = true;
                } 
                else if(surfaceHit.collider.CompareTag("Box"))
                {
                    if(surfaceHit.collider.gameObject.GetComponent<BoxController>().isOnButton){
                        isOnButton = true;
                    }
                } else {
                    isOnButton = false;
                }

            }
        }
    }
    */
}

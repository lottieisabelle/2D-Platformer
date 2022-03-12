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
                }

                Debug.Log(surfaceHit.collider.tag);
                
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField] public int boxID;

    public bool isHeld;

    private LayerMask boxLayer;

    // Start is called before the first frame update
    void Start()
    {
        boxLayer = this.transform.parent.parent.GetComponent<LevelController>().boxLayer;

        isHeld = false;
    }

    public int getAbove()
    {
        // shoot rays to exclusively detect boxes
        RaycastHit2D boxHit = Physics2D.BoxCast(this.GetComponent<BoxCollider2D>().bounds.center, this.GetComponent<BoxCollider2D>().bounds.size, 0, Vector2.up, 0.3f, boxLayer);

        if(boxHit.collider != null){

            if(boxHit.collider.gameObject.GetComponent<BoxController>().boxID != this.GetComponent<BoxController>().boxID){
                // hit different box
                return (boxHit.collider.gameObject.GetComponent<BoxController>().boxID);

            } else {
                // box hit itself (shouldn't happen but kept just in case)
                return (-1);
            }

        } else {
            // hit no boxes
            return (-1);
        }


    }

}

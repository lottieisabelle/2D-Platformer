using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField] public int boxID;

    public bool isHeld;

    private LayerMask boxLayer;
    private LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        boxLayer = this.transform.parent.parent.GetComponent<LevelController>().boxLayer;
        playerLayer = this.transform.parent.parent.GetComponent<LevelController>().playerLayer;

        isHeld = false;
    }

    public int getAbove()
    {
        // shoot rays to exclusively detect boxes
        RaycastHit2D boxHit = Physics2D.BoxCast(this.GetComponent<BoxCollider2D>().bounds.center, this.GetComponent<BoxCollider2D>().bounds.size, 0, Vector2.up, 0.3f, boxLayer);

        if(boxHit.collider != null){

            // if different box ID
            if(boxHit.collider.gameObject.GetComponent<BoxController>().boxID != this.GetComponent<BoxController>().boxID){
                
                Debug.Log("hit diff box");
                return (boxHit.collider.gameObject.GetComponent<BoxController>().boxID);

            } else {
                Debug.Log("box hit itself");
                return (-1);
            }

        } else {
            Debug.Log("hit no boxes");
            return (-1);
        }


    }

}

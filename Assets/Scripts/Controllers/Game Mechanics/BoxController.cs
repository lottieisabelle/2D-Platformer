using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField] public int boxID;

    public bool isOnButton;
    public bool isHeld;

    // Start is called before the first frame update
    void Start()
    {
        isHeld = false;
        isOnButton = false;
    }

    // Update is called once per frame
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectBoxes : MonoBehaviour
{
    public List<int> boxesInArea = new List<int>();

    public int numBoxes;

    void Start()
    {
        numBoxes = 0;
    }

    void Update()
    {
        numBoxes = boxesInArea.Count;
        //Debug.Log("DB : num boxes: "+ numBoxes);
    }

    private void Reset()
    {
        this.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {   

        // identify box, not box trigger, and not box when held
        if(collision.CompareTag("Box") && collision.gameObject.layer == 9){
            //Debug.Log("Box stay");
            
            // if box id not in list then 
            if(!boxesInArea.Contains(collision.gameObject.GetComponent<BoxController>().boxID)){
                // add to list
                boxesInArea.Add(collision.gameObject.GetComponent<BoxController>().boxID);
            }
        
        }

        // if detecting box trigger, and box is not held, check if in list
        if(collision.CompareTag("BoxTrigger") && !collision.gameObject.transform.parent.GetComponent<BoxController>().isHeld){
            //Debug.Log("Box stay");

            // if box id not in list then 
            if(!boxesInArea.Contains(collision.gameObject.transform.parent.GetComponent<BoxController>().boxID)){
                // add to list
                boxesInArea.Add(collision.gameObject.transform.parent.GetComponent<BoxController>().boxID);
            }
        }
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        // identify box, not box trigger, and not box when held
        if(collision.CompareTag("Box") && collision.gameObject.layer == 9){
            //Debug.Log("Box enter");
            
            // if box id not in list then 
            if(!boxesInArea.Contains(collision.gameObject.GetComponent<BoxController>().boxID)){
                // add to list
                boxesInArea.Add(collision.gameObject.GetComponent<BoxController>().boxID);
            }
        
        }

        // if detecting box trigger, and box is not held, check if in list
        if(collision.CompareTag("BoxTrigger") && !collision.gameObject.transform.parent.GetComponent<BoxController>().isHeld){
            //Debug.Log("Box enter");

            // if box id not in list then 
            if(!boxesInArea.Contains(collision.gameObject.transform.parent.GetComponent<BoxController>().boxID)){
                // add to list
                boxesInArea.Add(collision.gameObject.transform.parent.GetComponent<BoxController>().boxID);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {        
        if(collision.CompareTag("Box") && collision.gameObject.layer == 9){
            //Debug.Log("Box exit");
            boxesInArea.Remove(collision.gameObject.GetComponent<BoxController>().boxID);
        }

        if(collision.CompareTag("BoxTrigger") && !collision.gameObject.transform.parent.GetComponent<BoxController>().isHeld){
            //Debug.Log("Box exit");
            boxesInArea.Remove(collision.gameObject.transform.parent.GetComponent<BoxController>().boxID);

        }
            
    }


}

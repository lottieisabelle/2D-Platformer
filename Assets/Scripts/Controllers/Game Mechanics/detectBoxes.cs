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
    }

    private void Reset()
    {
        this.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {   
        // identify box, not box trigger, and not box when held
        if(collision.CompareTag("Box") && collision.gameObject.layer == 9){
            // if box ID not in list then add to list
            if(!boxesInArea.Contains(collision.gameObject.GetComponent<BoxController>().boxID)){
                boxesInArea.Add(collision.gameObject.GetComponent<BoxController>().boxID);
            }
        }

        // if detecting box trigger, and box is not held, check if in list
        if(collision.CompareTag("BoxTrigger") && !collision.gameObject.transform.parent.GetComponent<BoxController>().isHeld){
            // if box ID not in list then add to list
            if(!boxesInArea.Contains(collision.gameObject.transform.parent.GetComponent<BoxController>().boxID)){
                boxesInArea.Add(collision.gameObject.transform.parent.GetComponent<BoxController>().boxID);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        // identify box, not box trigger, and not box when held
        if(collision.CompareTag("Box") && collision.gameObject.layer == 9){
            // if box ID not in list then add to list
            if(!boxesInArea.Contains(collision.gameObject.GetComponent<BoxController>().boxID)){
                boxesInArea.Add(collision.gameObject.GetComponent<BoxController>().boxID);
            }
        }

        // if detecting box trigger, and box is not held, check if in list
        if(collision.CompareTag("BoxTrigger") && !collision.gameObject.transform.parent.GetComponent<BoxController>().isHeld){
            // if box ID not in list then add to list
            if(!boxesInArea.Contains(collision.gameObject.transform.parent.GetComponent<BoxController>().boxID)){
                boxesInArea.Add(collision.gameObject.transform.parent.GetComponent<BoxController>().boxID);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // remove box ID from list
        if(collision.CompareTag("Box") && collision.gameObject.layer == 9){
            boxesInArea.Remove(collision.gameObject.GetComponent<BoxController>().boxID);
        }

        if(collision.CompareTag("BoxTrigger") && !collision.gameObject.transform.parent.GetComponent<BoxController>().isHeld){
            boxesInArea.Remove(collision.gameObject.transform.parent.GetComponent<BoxController>().boxID);
        }
    }
}

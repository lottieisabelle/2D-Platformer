using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onBoxController : MonoBehaviour
{
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        // player is on this box
        if(collision.CompareTag("Player")){
            this.transform.parent.parent.parent.GetChild(5).GetComponent<PlayerController>().onBoxID = this.transform.parent.GetComponent<BoxController>().boxID;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // player is on this box
        if(collision.CompareTag("Player")){
            this.transform.parent.parent.parent.GetChild(5).GetComponent<PlayerController>().onBoxID = this.transform.parent.GetComponent<BoxController>().boxID;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // player is not on this box
        // need to account for if player holding box and stuff gets weird ?
        if(collision.CompareTag("Player")){
            this.transform.parent.parent.parent.GetChild(5).GetComponent<PlayerController>().onBoxID = 0;
        }
    }
}

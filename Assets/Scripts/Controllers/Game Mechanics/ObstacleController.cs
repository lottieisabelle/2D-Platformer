using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstacleController : MonoBehaviour
{
    public bool isVisible;

    [SerializeField] public TextMeshProUGUI taskText;

    private int num;

    void Start()
    {
        // count number of children 
        num = this.transform.childCount;
    }

    public void show()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<BoxCollider2D>().enabled = true;
        taskText.enabled = true;
        isVisible = true;

        // if obstacle has box detector - turn it off
        if(num != 0){
            this.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
            this.transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = false;
        }
        
    }

    public void hide()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        taskText.enabled = false;
        isVisible = false;

        // if obstacle has box detector - turn it on
        if(num != 0){
            this.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
            this.transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

}

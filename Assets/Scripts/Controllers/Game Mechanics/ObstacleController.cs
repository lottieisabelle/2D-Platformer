using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstacleController : MonoBehaviour
{
    public bool isVisible;

    [SerializeField] public TextMeshProUGUI taskText;

    private bool hasTrigger;
    private int numBoxes;

    public List<int> disabledBoxes = new List<int>();

    void Start()
    {
        if(this.transform.childCount == 0){
            hasTrigger = false;
        } else {
            hasTrigger = true;

            if(isVisible){
                // disable trigger box collider on start
                this.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
                this.transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = false;
            } else {
                // enable trigger box collider on start
                this.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
                this.transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = true;
            }

        }       
        
    }

    void Update()
    {
        numBoxes = this.transform.GetChild(0).GetComponent<detectBoxes>().numBoxes;
    }

    public void show()
    {
        // if obstacle has box detector - turn it off & print number of boxes in the area
        if(hasTrigger){
            
            if(numBoxes != 0){
                Debug.Log(numBoxes + " box(es) detected");

                // for every box (not held) in level - if in area : disable (add to disabled list)
                int totalBoxes = this.transform.parent.parent.GetChild(4).childCount;
                for(int x = 0; x < totalBoxes; x++){
                    
                    if(this.transform.GetChild(0).GetComponent<detectBoxes>().boxesInArea.Contains(this.transform.parent.parent.GetChild(4).GetChild(x).GetComponent<BoxController>().boxID)){
                        
                        disabledBoxes.Add(this.transform.parent.parent.GetChild(4).GetChild(x).GetComponent<BoxController>().boxID);
                        this.transform.parent.parent.GetChild(4).GetChild(x).gameObject.SetActive(false);
                    }
                }

            } else {
                Debug.Log("no boxes");
            }

            this.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
            this.transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = false;

        }

        this.transform.GetComponent<SpriteRenderer>().enabled = true;
        this.transform.GetComponent<BoxCollider2D>().enabled = true;
        taskText.enabled = true;
        isVisible = true;
        
    }

    public void hide()
    {
        // if obstacle has box detector - turn it on
        if(hasTrigger){

            if(disabledBoxes.Count != 0){
                // for every box (not held) in level - if disabled : enable and remove from list
                int totalBoxes = this.transform.parent.parent.GetChild(4).childCount;
                for(int x = 0; x < totalBoxes; x++){
                    
                    if(disabledBoxes.Contains(this.transform.parent.parent.GetChild(4).GetChild(x).GetComponent<BoxController>().boxID)){
                        
                        disabledBoxes.Remove(this.transform.parent.parent.GetChild(4).GetChild(x).GetComponent<BoxController>().boxID);
                        this.transform.parent.parent.GetChild(4).GetChild(x).gameObject.SetActive(true);
                    }
                }
            }

            this.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
            this.transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = true;
        }

        this.transform.GetComponent<SpriteRenderer>().enabled = false;
        this.transform.GetComponent<BoxCollider2D>().enabled = false;
        taskText.enabled = false;
        isVisible = false;

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstacleController : MonoBehaviour
{
    public bool isVisible;

    [SerializeField] public TextMeshProUGUI taskText;

    private Color solidObs;
    private Color transparentObs;

    private Color solidText;
    private Color transparentText;

    private bool hasTrigger;
    private int numBoxes;

    public List<int> disabledBoxes = new List<int>();

    void Start()
    {
        solidObs = new Color(1f,1f,1f,1f);
        transparentObs = new Color(1f,1f,1f,0.5f);

        solidText = new Color(0f,0.1738f,0.2924f,1f);
        transparentText = new Color(0f,0.1738f,0.2924f,0.5f);

        taskText.gameObject.layer = 5;


        if(this.transform.childCount == 0){
            hasTrigger = false;
        } else {
            hasTrigger = true;

            if(isVisible){
                this.transform.GetComponent<SpriteRenderer>().color = solidObs;
                // disable trigger box collider on start
                this.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
                this.transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = false;
            } else {
                this.transform.GetComponent<SpriteRenderer>().color = transparentObs;
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
                // for every box (not held) in level - if in area : disable (add to disabled list)
                int totalBoxes = this.transform.parent.parent.GetChild(4).childCount;
                for(int x = 0; x < totalBoxes; x++){
                    
                    if(this.transform.GetChild(0).GetComponent<detectBoxes>().boxesInArea.Contains(this.transform.parent.parent.GetChild(4).GetChild(x).GetComponent<BoxController>().boxID)){
                        
                        disabledBoxes.Add(this.transform.parent.parent.GetChild(4).GetChild(x).GetComponent<BoxController>().boxID);
                        this.transform.parent.parent.GetChild(4).GetChild(x).gameObject.SetActive(false);
                    }
                }

            } 

            this.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
            this.transform.GetChild(0).GetComponent<BoxCollider2D>().isTrigger = false;

        }

        this.transform.GetComponent<SpriteRenderer>().color = solidObs;
        this.transform.GetComponent<BoxCollider2D>().enabled = true;
        taskText.color = solidText;
        
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

        this.transform.GetComponent<SpriteRenderer>().color = transparentObs;
        this.transform.GetComponent<BoxCollider2D>().enabled = false;
        taskText.color = transparentText;
        
        isVisible = false;

    }

}

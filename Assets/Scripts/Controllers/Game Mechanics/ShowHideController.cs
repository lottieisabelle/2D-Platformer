using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowHideController : MonoBehaviour
{
    public bool isVisible;

    [SerializeField] public TextMeshProUGUI taskText;

    private int num;

    void Start()
    {
        // count number of children to hide
        num = this.transform.childCount;

    }

    public void show()
    {
        this.GetComponent<BoxCollider2D>().enabled = true;
        taskText.enabled = true;
        isVisible = true;

        if(num == 0){
            this.GetComponent<SpriteRenderer>().enabled = true;
            
        } else {

            for(int i = 0; i < num; i++){
                this.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
            }

        }
        
    }

    public void hide()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        taskText.enabled = false;
        isVisible = false;

        if(num == 0){
            this.GetComponent<SpriteRenderer>().enabled = false;
            
        } else {

            for(int i = 0; i < num; i++){
                this.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
            }

        }
        
    }

}

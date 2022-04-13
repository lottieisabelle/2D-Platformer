using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlatformController : MonoBehaviour
{
    public bool isVisible;
    [SerializeField] public TextMeshProUGUI taskText;

    private int num;

    private Color solidPlat;
    private Color transparentPlat;

    private Color solidText;
    private Color transparentText;

    void Start()
    {
        // count number of children to hide
        num = this.transform.childCount;

        solidPlat = new Color(1f,1f,1f,1f);
        transparentPlat = new Color(1f,1f,1f,0.5f);

        solidText = new Color(0f,0.1738f,0.2924f,1f);
        transparentText = new Color(0f,0.1738f,0.2924f,0.5f);
    }

    public void show()
    {
        this.GetComponent<BoxCollider2D>().enabled = true;
        taskText.color = solidText;
        
        isVisible = true;

        if(num == 0){
            this.GetComponent<SpriteRenderer>().color = solidPlat;
            
        } else {

            for(int i = 0; i < num; i++){
                this.transform.GetChild(i).GetComponent<SpriteRenderer>().color = solidPlat;
            }

        }
        
    }

    public void hide()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        taskText.color = transparentText;

        isVisible = false;

        if(num == 0){
            this.GetComponent<SpriteRenderer>().color = transparentPlat;
            
        } else {

            for(int i = 0; i < num; i++){
                this.transform.GetChild(i).GetComponent<SpriteRenderer>().color = transparentPlat;
            }

        }
        
    }
}

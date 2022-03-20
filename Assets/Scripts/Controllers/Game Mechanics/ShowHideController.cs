using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideController : MonoBehaviour
{
    public bool isVisible;

    private SpriteRenderer obj;
    private SpriteRenderer objTask;
    private BoxCollider2D objColl;
    
    // Start is called before the first frame update
    void Start()
    {
        obj = this.GetComponent<SpriteRenderer>();
        objTask = this.transform.GetChild(0).GetComponent<SpriteRenderer>();

        objColl = this.GetComponent<BoxCollider2D>();

    }

    public void show()
    {
        obj.enabled = true;
        objTask.enabled = true;
        objColl.enabled = true;

        isVisible = true;
    }

    public void hide()
    {
        obj.enabled = false;
        objTask.enabled = false;
        objColl.enabled = false;

        isVisible = false;
    }

}

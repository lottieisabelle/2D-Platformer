using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectBoxes : MonoBehaviour
{
    public List<int> boxesInArea = new List<int>();
    // could make a list of all box ids that are in box and upon calling show on obstacle do something to boxes in list

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Reset()
    {
        this.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.CompareTag("Box")){
            Debug.Log("Box Enter");
        }
     
    }

    private void OnTriggerStay2D(Collider2D collision)
    {   
        if(collision.CompareTag("Box")){
            Debug.Log("Box Stay");
        }

     
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Box")){
            Debug.Log("Box Exit");
        }
        
            
    }


}

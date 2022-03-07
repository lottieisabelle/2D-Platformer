using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    /*
    public static bool isInteractable(this RaycastHit2D hit)
    {
        return hit.transform.GetComponent<PickUpable>();
    }

    public static void Interact(this RaycastHit2D hit)
    {
        hit.transform.GetComponent<PickUpable>().Interact();
    }
    */
}


/*
temp = new Vector3(grabCheck.collider.gameObject.transform.position.x, -3.15f, 0); // TODO : check if on button therefore dont put here
                grabCheck.collider.gameObject.transform.position = temp;

*/

/*

[RequireComponent(typeof(SpriteRenderer))]

public class Pressable : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    public Sprite pressed;
    public Sprite unpressed;
    public BoxCollider2D pressTrigger;
    public float rayDist;

    private Rigidbody2D button;
    private SpriteRenderer sr;
    private bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        // grab data references from object
        button = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = unpressed;
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D pressCheck = Physics2D.BoxCast(pressTrigger.bounds.center, pressTrigger.bounds.size, 0, Vector2.up, 0.2f, groundLayer);

        if(pressCheck.collider != null)
        {   
            if(!isPressed)
            {
                Debug.Log("Button Pressed");
                isPressed = true;
            }
        } else {
            isPressed =  false;
        }

        

        /*
        RaycastHit2D[] pressCheckHits = Physics2D.RaycastAll(button.position, Vector2.up, rayDist);

        if(pressCheckHits.Length > 0)
        {
            foreach (RaycastHit2D pressCheck in pressCheckHits)
            {
                if(pressCheck.collider.tag == "Box" || pressCheck.collider.tag == "Player")
                {
                    // button pressed
                    sr.sprite = pressed;
                    isPressed = true;
                }
                return;
            }
            
        } else {
            sr.sprite = unpressed;
            isPressed = false;
        }

    }
}

*/

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressable : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;

    private BoxCollider2D boxCollider;
    private bool isPressed;

    void start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        isPressed = false;
    }

    void Update()
    {
        RaycastHit2D pressCheck = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.up, 0.2f, groundLayer);

        if(pressCheck.collider != null)
        {   
            if(!isPressed)
            {
                Debug.Log("Button Pressed");
                isPressed = true;
            }
        } else {
            Debug.Log("Button released");
            isPressed =  false;
        }
    }
}

*/
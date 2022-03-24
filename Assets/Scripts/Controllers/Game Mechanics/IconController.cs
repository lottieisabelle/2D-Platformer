using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconController : MonoBehaviour
{   
    [SerializeField] private SpriteRenderer icon;
    [SerializeField] private Sprite _default, _pressed;
    [SerializeField] private string key;

    // Update is called once per frame
    void Update()
    {
        if(KeyCode.F.ToString().Equals(key))
        {
            if(Input.GetKey(KeyCode.F))
            {
                icon.sprite = _pressed;
            } else {
                icon.sprite = _default;
            }
        } 
        else if(KeyCode.W.ToString().Equals(key))
        {
            if(Input.GetKey(KeyCode.W))
            {
                icon.sprite = _pressed;
            } else {
                icon.sprite = _default;
            }
        }
        else if(KeyCode.Space.ToString().Equals(key))
        {
            if(Input.GetKey(KeyCode.Space))
            {
                icon.sprite = _pressed;
            } else {
                icon.sprite = _default;
            }
        }
        else if(KeyCode.LeftArrow.ToString().Equals(key))
        {
            if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                icon.sprite = _pressed;
            } else {
                icon.sprite = _default;
            }
        }
        else if(KeyCode.RightArrow.ToString().Equals(key))
        {
            if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                icon.sprite = _pressed;
            } else {
                icon.sprite = _default;
            }
        }
        
    }

    public void show()
    {
        icon.enabled = true;
    }

    public void hide()
    {
        icon.enabled = false;
    }
    
}
